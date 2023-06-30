using API.Model;
using API.Models;
using API.ViewModels;
using Client.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Client.Controllers;
[Authorize]
public class BorrowController : Controller
{
    private readonly BorrowRepository repository;

    public BorrowController(BorrowRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        //localhost/university/
        var Results = await repository.Get();
        var borrow = new List<Borrow>();

        if (Results != null)
        {
            borrow = Results.Data.ToList();
        }

        return View(borrow);
    }
    [HttpGet]
    public IActionResult Create(string id)
    {
        var memberIdClaim = User.Claims.FirstOrDefault(c => c.Type == "MemberID");
        var borrow = new Borrow();
        if (memberIdClaim != null && id != null)
        {
            borrow.B_MemberId = memberIdClaim.Value;
            borrow.Id = 0;
            borrow.B_BookId = id;
            borrow.BorrowDate = DateTime.Now;
        }
        else
        {
            return View(borrow);
        }
        return View(borrow);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Borrow borrow)
    {
        var result = await repository.Post(borrow);
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
    //edit-id
    [HttpGet]
    [Authorize(Roles = "admin")]

    public async Task<IActionResult> Edit(int id, string b_MemberId, string b_BookId)
    {
        var Results = await repository.Get(id);
        var borrow = new Borrow();

        if (Results.Data?.Id is null)
        {
            return View(borrow);
        }
        else
        {
            borrow.Id = Results.Data.Id;
            borrow.B_MemberId = b_MemberId;
            borrow.B_BookId = b_BookId;
        }
        return View(borrow);
    }
    //edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Edit(Borrow borrow)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Put(borrow.Id, borrow);
            if (result.Code == 200)
            {
                return RedirectToAction(nameof(Index));
            }
            else if (result.Code == 500)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
        }

        return View();
    }
    //delete
    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await repository.Get(id);
        var borrow = result?.Data;

        return View(borrow);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> ConfirmDelete(int id)
    {
        var result = await repository.Delete(id);
        if (result.Code == 200)
        {
            TempData["Success"] = "Data berhasil dihapus";
            return RedirectToAction(nameof(Index));
        }

        var borrow = await repository.Get(id);
        return View("Delete", borrow?.Data);
    }
}
