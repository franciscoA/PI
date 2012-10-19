using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System;
using System.Collections.Generic;
using WebGarten2.Html;

namespace WebGarten2
{
    public class FrontHandler : DelegatingHandler
    {
        private readonly string _baseAddress;
        private readonly IDictionary<HttpMethod, UriTemplateTable> _tables = new Dictionary<HttpMethod, UriTemplateTable>();

        public FrontHandler(string baseAddress)
        {
            _baseAddress = baseAddress;
        }

        public void Add(params CommandBind[] binds)
        {
            foreach (var b in binds)
            {
                UriTemplateTable t;
                if (!_tables.TryGetValue(b.HttpMethod, out t))
                {
                    t = new UriTemplateTable(new Uri(_baseAddress));
                    _tables.Add(b.HttpMethod, t);
                }
                t.KeyValuePairs.Add(new KeyValuePair<UriTemplate, object>(b.UriTemplate, b.Command));
            }
        }

        public HttpResponseMessage Handle(HttpRequestMessage req)
        {
            UriTemplateTable t;
            if (!_tables.TryGetValue(req.Method, out t))
            {
                return new HttpResponseMessage(HttpStatusCode.MethodNotAllowed) 
                {
                    Content = new ErrorView("405 Method Not Allowed. Cant execute requested action.").AsHtmlContent()
                };
            }

            var match = t.MatchSingle(req.RequestUri);
            if (match == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new ErrorView("404 Not Found. That resource doesnt exist.").AsHtmlContent()
                };
            }

            req.SetUriTemplateMatch(match);
            try
            {
                return (match.Data as ICommand).Execute(req);
            }
            catch(Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new ErrorView("500 Internal Sever Error. Oups, something went bad over here.").AsHtmlContent()
                };
            }
        }
    }
}