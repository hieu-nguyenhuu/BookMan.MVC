using BookMan.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
namespace BookMan.Mvc.Controllers
{
    public class BookController : Controller
    {
        private readonly Service _service;
        public BookController(Service service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.Get());
        }
        public IActionResult Details(int id)
        {
            var b = _service.Get(id);
            if(b == null) return NotFound();
            else return View(b);
        }
        public IActionResult Delete(int id)
        {
            var book = _service.Get(id);
            if (book == null) return NotFound();
            else return View(book);
        }
        [HttpPost]
        public IActionResult Delete(Book book)
        {
            _service.Delete(book.Id);
            _service.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var book = _service.Get(id);
            if (book == null) return NotFound();
            else return View(book);
        }
        [HttpPost]
        public IActionResult Update(Book book)
        {
            _service.Update(book);
            _service.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View(_service.Create());
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            _service.Add(book);
            _service.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}