namespace TrelloApp.Models
{
    class ElementRepositoryLocator
    {
        private readonly static IElementRepository Repo = new ElementMemoryRepository();
        public static IElementRepository Get()
        {
            return Repo;
        }
    }
}
