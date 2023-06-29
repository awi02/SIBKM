using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data
{
    public class AccountRoleRepository : GeneralRepositories<AccountRoles, int, MyContext>, IAccountRoleRepository
    {
        public AccountRoleRepository(MyContext context) : base(context) { }
        public IEnumerable<string> GetRolesByEmail(string email)
        {
            var MemberId = _context.Member.FirstOrDefault(e => e.Email == email)?.Id;
            var accountRoles = _context.AccountRoles
                                       .Where(ar => ar.AccountId == MemberId)
                                       .Join(_context.Roles,
                                             ar => ar.Roleid,
                                             r => r.Id,
                                             (ar, r) => new { ar, r })
                                       .Select(role => role.r.Name);


            return accountRoles;

        }
    }
}