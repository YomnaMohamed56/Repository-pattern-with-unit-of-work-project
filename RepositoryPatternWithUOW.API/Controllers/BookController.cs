using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Consts;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;

namespace RepositoryPatternWithUOW.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //private readonly IBaseRepository<Book> _bookRepository;

        //public BookController(IBaseRepository<Book> bookRepository)
        //{
        //    _bookRepository = bookRepository;
        //}

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            //return Ok(_bookRepository.GetById(id));
            return Ok(_unitOfWork.Books.GetById(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            //return Ok(_bookRepository.GetAll());
            return Ok(_unitOfWork.Books.GetAll());
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            //return Ok(_bookRepository.Find(b => b.Title == name, new[] { "Author" }));
            return Ok(_unitOfWork.Books.Find(b => b.Title == name, new[] { "Author" }));
        }

        [HttpGet("GetByAuthorId")]
        public IActionResult GetByAuthorId(int AuthourId)
        {
            //return Ok(_bookRepository.Find(b => b.AuthorId == AuthourId));
            return Ok(_unitOfWork.Books.Find(b => b.AuthorId == AuthourId));
        }

        [HttpGet("GetAllWithAuthors")]
        public IActionResult GetAllWithAuthors(string name)
        {
            //return Ok(_bookRepository.FindAll(b => b.Title.Contains(name), new[] { "Author" }));
            return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains(name), new[] { "Author" }));
        }

        [HttpGet("GetAllWithAuthorsWithTake&Skip")]
        public IActionResult GetAllWithAuthors(string name, int skip, int take)
        {
            //return Ok(_bookRepository.FindAll(b => b.Title.Contains(name), skip, take));
            return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains(name), skip, take));
        }

        [HttpGet("GetOrderd")]
        public IActionResult GetOrderd()
        {
            //return Ok(_bookRepository.FindAll(b => b.Title.Contains("Book"), null, null, b => b.Id, OrderBy.Descending));
            return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains("Book"), null, null, b => b.Id, OrderBy.Descending));
        }

        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
            //return Ok(_bookRepository.Add(new Book() { Title = "Book4", AuthorId = 3 }));
            var book = _unitOfWork.Books.Add(new Book() { Title = "Book5", AuthorId = 3 });
            _unitOfWork.Complete();
            return Ok(book);
        }

        [HttpPost("AddRange")]
        public IActionResult AddRange(IEnumerable<Book> books)
        {
            //return Ok(_bookRepository.AddRange(books));
            return Ok(_unitOfWork.Books.AddRange(books));
        }
    }
}
