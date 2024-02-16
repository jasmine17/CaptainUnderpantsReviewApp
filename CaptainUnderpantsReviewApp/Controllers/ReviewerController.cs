using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CaptainUnderpantsReviewApp.Dto;
using CaptainUnderpantsReviewApp.Interfaces;
using CaptainUnderpantsReviewApp.Models;

namespace CaptainUnderpantsReviewApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ReviewerController : Controller
    {
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMapper _mapper;
        public ReviewerController(IMapper mapper, IReviewerRepository reviewerRepository)
        {
            _mapper = mapper;
            _reviewerRepository = reviewerRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
        public IActionResult GetReviewers()
        {
          var reviewer= _reviewerRepository.GetReviewers();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewer);
        }

        [HttpGet("{reviewerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
        public IActionResult GetReviewer(int reviewerId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_reviewerRepository.ReviewerExists(reviewerId))
                return NotFound();

            var reviewer = _reviewerRepository.GetReviewer(reviewerId);

            

            return Ok(reviewer);
        }

        [HttpGet("reviews/{reviewerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public IActionResult  GetReviewsByReviewer(int reviewerId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_reviewerRepository.ReviewerExists(reviewerId))
                return NotFound();

            var reviewer = _reviewerRepository.GetReviewer(reviewerId);



            return Ok(reviewer);

        }

     

    }
}
