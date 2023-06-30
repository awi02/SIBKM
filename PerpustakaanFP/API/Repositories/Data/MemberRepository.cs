using API.Context;
using API.Model;
using API.Models;
using API.Repositories.Interface;


namespace API.Repositories.Data
{
    public class MemberRepository : GeneralRepositories<Member, string, MyContext>, IMemberRepository
    {
        public MemberRepository(MyContext context) : base(context) { }
        public string GetMemberIdByEmail(string email)
        {
            var memberId = _context.Member.FirstOrDefault(e => e.Email == email)?.Id;
            return memberId;
        }
        public string GetFullNameByEmail(string email)
        {
            var member = _context.Member.FirstOrDefault(m => m.Email == email)!;
            return member.FirstName + " " + member.LastName;
        }
    }
}
