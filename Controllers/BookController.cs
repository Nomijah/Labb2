using Labb1.Models;
using Labb1.Models.DTOs;
using Labb2.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Labb2.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public async Task<IActionResult> BookIndex()
        {
            List<Book> list = new List<Book>();
            var response = await _bookService.GetAllBooks<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<Book>>
                    (Convert.ToString(response.Result));
            }
            return View(list);
        }

        public async Task<IActionResult> AuthorIndex(string author)
        {
            List<Book> list = new List<Book>();
            var response = await _bookService.GetBooksByAuthor<APIResponse>(author);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<Book>>
                    (Convert.ToString(response.Result));
            }
            return View(list);
        }

        public async Task<IActionResult> TitleIndex(string title)
        {
            List<Book> list = new List<Book>();
            var response = await _bookService.GetBooksByTitle<APIResponse>(title);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<Book>>
                    (Convert.ToString(response.Result));
            }
            return View(list);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _bookService.GetBookById<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                Book book = JsonConvert.DeserializeObject<Book>
                    (Convert.ToString(response.Result));
                return View(book);
            }
            return NotFound();
        }

        public async Task<IActionResult> BookCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookCreate(BookCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.CreateBookAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> UpdateBook(int id)
        {
            var response = await _bookService.GetBookById<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                Book book = JsonConvert.DeserializeObject<Book>
                    (Convert.ToString(response.Result));
                return View(book);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(Book model)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.UpdateBookAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteBook(int id)
        {
            var response = await _bookService.GetBookById<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                Book book = JsonConvert.DeserializeObject<Book>
                    (Convert.ToString(response.Result));
                return View(book);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(Book model)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.DeleteBookAsync<APIResponse>(model.Id);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return NotFound();
        }
    }
}
