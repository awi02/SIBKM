using API.Context;
using API.Model;
using API.Repositories.Interface;


namespace API.Repositories.Data
{
    public class BorrowRepository : GeneralRepositories<Borrow, int, MyContext>, IBorrowRepository
    {
        public BorrowRepository(MyContext context) : base(context) { }


    }
}
