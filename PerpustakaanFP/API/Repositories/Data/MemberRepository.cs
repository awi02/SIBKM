using API.Context;
using API.Model;
using API.Models;
using API.Repositories.Interface;


namespace API.Repositories.Data
{
    public class MemberRepository : GeneralRepositories<Member, int, MyContext>, IMemberRepository
    {
        public MemberRepository(MyContext context) : base(context) { }
        public string GetFullNameByEmail(string email)
        {
            var member = _context.Member.FirstOrDefault(m => m.Email == email)!;
            return member.FirstName + " " + member.LastName;
        }
    }
}
