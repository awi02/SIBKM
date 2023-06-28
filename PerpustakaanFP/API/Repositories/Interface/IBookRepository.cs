using API.Model;


namespace API.Repositories.Interface
{
    public interface IBookRepository : IGeneralRepository<Book, string>
    {
        IEnumerable<Book> GetByName(string name);
    }
}
