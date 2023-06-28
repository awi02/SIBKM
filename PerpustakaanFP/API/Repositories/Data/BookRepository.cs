using API.Context;
using API.Model;
using API.Repositories.Interface;


namespace API.Repositories.Data
{
    public class BookRepository : GeneralRepositories<Book, string, MyContext>, IBookRepository
    {
        public BookRepository(MyContext context) : base(context) { }
        public IEnumerable<Book> GetByName(string name)
        {
            return _context.Book.Where(x => x.BookTitle.Contains(name));
        }
    }
}
