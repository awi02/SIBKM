using API.Model;
using Client.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{

    [Authorize]
    public class BookController : Controller
    {
        private readonly BookRepository repository;

        public BookController(BookRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var results = await repository.Get();
            var book = results?.Data ?? new List<Book>();

            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var result = await repository.Get(id);
            var book = result.Data;

            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(Book book)
        {
            var result = await repository.Post(book);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                var result = await repository.Put(book);
                if (result != null && result.Code == 200)
                {
                    return RedirectToAction(nameof(Index));
                }
                else if (result != null && result.Code == 409)
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(string id)
        {
            var result = await repository.Get(id);
            var book = new Book();
            if (result.Data?.Id is null)
            {
                return View(book);
            }
            else
            {
               book.Id = result.Data.Id;
                book.BookTitle = result.Data.BookTitle;
            }

            return View(book);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await repository.Get(id);
            var book = result?.Data;

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            var result = await repository.Delete(id);
            if (result.Code == 200)
            {
                TempData["Success"] = "Data berhasil dihapus";
                return RedirectToAction(nameof(Index));
            }
            else if (result.Code == 404)
            {
                ModelState.AddModelError(string.Empty, result.Message);
            }

            var book = await repository.Get(id);
            return View("Delete", book?.Data);
        }
    }
}
