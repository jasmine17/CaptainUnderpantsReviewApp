using AutoMapper;
using CaptainUnderpantsReviewApp.Dto;
using CaptainUnderpantsReviewApp.Interfaces;
using CaptainUnderpantsReviewApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaptainUnderpantsReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        private readonly IReviewerRepository _reviewerRepository;
        private readonly ICaptainUnderpantsRepository _captainUnderpantsRepository;

        public ReviewController(IReviewRepository reviewRepository, IMapper mapper, IReviewerRepository reviewerRepository,ICaptainUnderpantsRepository captainUnderpantsRepository)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _reviewerRepository = reviewerRepository;
            _captainUnderpantsRepository = captainUnderpantsRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CaptainUnderpant>))]
        public IActionResult GetReviews()
        {
            var review = _reviewRepository.GetReviews();

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(review);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public IActionResult GetReview(int reviewId)
        {
            if (!_reviewRepository.ReviewExists(reviewId))
                return NotFound();

            var review = _mapper.Map<ReviewDto>(_reviewRepository.GetReview(reviewId)); //_reviewRepository.GetReview(reviewId);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(review);

        }

        [HttpGet("captain/{captainId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public IActionResult GetReviewsOfACaptainUnderpants(int captainId)
        {
            var review = _mapper.Map<Review>(_reviewRepository.GetReviewsOfACaptainUnderpants(captainId));

            if (ModelState.IsValid)
                return BadRequest();

            return Ok(review);

        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public  IActionResult CreateReview([FromQuery] int ReviewerId, [FromQuery] int CaptainUnderpantId, [FromBody] ReviewDto reviewCreate)
        {
            if(reviewCreate==null)
                return BadRequest(ModelState);

            var reviews = _reviewRepository.GetReviews()
                .Where(c => c.Title.ToUpper() == reviewCreate.Title.ToUpper())
                .FirstOrDefault();

            if(reviews!=null)
            {
                ModelState.AddModelError("", "Review already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                BadRequest(ModelState);

            var ReviewMap = _mapper.Map<Review>(reviewCreate);

            ReviewMap.CaptainUnderpants = _captainUnderpantsRepository.GetCaptainUnderpant(CaptainUnderpantId);
            ReviewMap.Reviewer = _reviewerRepository.GetReviewer(ReviewerId);

            if(!_reviewRepository.CreateReview(ReviewMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok(ReviewMap);
        }
    }
}
