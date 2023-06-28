using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using API.Model;
using API.Repositories.Data;
using API.Repositories.Interface;
using API.ViewModels;
using API.Base;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : GeneralController<IMemberRepository, Member, string>
    {
        public MemberController(IMemberRepository repository) : base(repository)
        {
        }
    }
}
