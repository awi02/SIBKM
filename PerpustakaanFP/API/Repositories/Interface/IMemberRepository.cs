using API.Model;
using API.Models;

namespace API.Repositories.Interface
{
    public interface IMemberRepository : IGeneralRepository<Member, int>
    {
        string GetFullNameByEmail(string email);
    }
}
