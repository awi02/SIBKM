using API.Model;
using API.Models;

namespace API.Repositories.Interface
{
    public interface IMemberRepository : IGeneralRepository<Member, string>
    {
        public string GetMemberIdByEmail(string email);
        string GetFullNameByEmail(string email);
    }
}
