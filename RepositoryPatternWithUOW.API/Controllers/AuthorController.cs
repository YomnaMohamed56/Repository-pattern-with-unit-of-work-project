using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;

namespace RepositoryPatternWithUOW.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //private readonly IBaseRepository<Author> _authorRepository;

        //public AuthorController(IBaseRepository<Author> authorRepository) 
        //{
        //    _authorRepository = authorRepository;
        //}       

        [HttpGet]
        public IActionResult GetById(int id)
        {
            //return Ok(_authorRepository.GetById(id));
            return Ok(_unitOfWork.Authors.GetById(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            //return Ok(_authorRepository.GetAll());
            return Ok(_unitOfWork.Authors.GetAll());
        }
    }
}
