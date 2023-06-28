using API.Models;
using API.ViewModels;
using Client.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;
public class AccountController : Controller
{
    private readonly AccountRepository repository;

    public AccountController(AccountRepository repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM login)
    {
        var result = await repository.Login(login);
        if (result.Code == 200)
        {
            HttpContext.Session.SetString("JWToken", result.Data);
            return RedirectToAction("index", "home");
        }
        return View();
    }

    public async Task<IActionResult> Register(RegisterVM register)
    {
        var result = await repository.Register(register);
        if (result.Code == 200)
        {
            return RedirectToAction("login", "account");
        }
        return View();
    }

    [HttpGet("/Logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return Redirect("/Account/Login");
    }

    public async Task<IActionResult> Index()
    {
        //localhost/university/
        var Results = await repository.Get();
        var universities = new List<Accounts>();

        if (Results != null)
        {
            universities = Results.Data.ToList();
        }

        return View(universities);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Accounts accounts)
    {

        var result = await repository.Post(accounts);
        if (result.Code == 200)
        {
            TempData["Success"] = "Data berhasil masuk";
            return RedirectToAction(nameof(Index));
        }
        else if (result.Code == 409)
        {
            ModelState.AddModelError(string.Empty, result.Message);
            return View();
        }

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        //localhost/university/
        var Results = await repository.Get(id);
        //var universities = new University();

        //if (Results != null)
        //{
        //    universities = Results.Data;
        //}

        return View(Results.Data);
    }
}