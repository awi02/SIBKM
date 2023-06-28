using API.Model;
using API.Models;

namespace API.Repositories.Interface
{
    public interface IMemberRepository : IGeneralRepository<Member, string>
    {
        string GetFullNameByEmail(string email);
    }
}
