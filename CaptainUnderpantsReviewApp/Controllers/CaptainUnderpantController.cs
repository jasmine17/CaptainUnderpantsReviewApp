using AutoMapper;
using CaptainUnderpantsReviewApp.Dto;
using CaptainUnderpantsReviewApp.Interfaces;
using CaptainUnderpantsReviewApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaptainUnderpantsReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaptainUnderpantController : Controller
    {
        private readonly ICaptainUnderpantsRepository _captainUnderpantsRepository;
        private readonly IMapper _mapper;

        public CaptainUnderpantController(ICaptainUnderpantsRepository captainUnderpantsRepository, 
            IMapper mapper)
        {
            _captainUnderpantsRepository = captainUnderpantsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<CaptainUnderpant>))]
        
        public IActionResult GetCaptainUnderpants()
        {
            var captainUnderpants = _captainUnderpantsRepository.GetCaptainUnderpants();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(captainUnderpants);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200,Type=typeof(CaptainUnderpant))]
        [ProducesResponseType(400)]
        public IActionResult GetCaptainUnderpants(int id)
        {
            if (!_captainUnderpantsRepository.CaptainUnderpantExists(id))
                return NotFound();

            var captain = _captainUnderpantsRepository.GetCaptainUnderpant(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(captain);
        }

        [HttpGet("{id}/rating")]
        [ProducesResponseType(200, Type = typeof(CaptainUnderpant))]
        [ProducesResponseType(400)]

        public IActionResult GetCaptainUnderpantRating(int id)
        {
            if (_captainUnderpantsRepository.CaptainUnderpantExists(id))
                return NotFound();

            var rating = _captainUnderpantsRepository.GetCaptainUnderpantRating(id);

            if (!ModelState.IsValid)
              return BadRequest();

            return Ok(rating);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCaptainUnderpants([FromQuery] int ownerId, [FromQuery] int catId, [FromBody] CaptainUnderpantDto captainUnderpantCreate)
        {
            if (captainUnderpantCreate == null)
                return BadRequest(ModelState);

            var captainUnderpants = _captainUnderpantsRepository.GetCaptainUnderpants()
                .Where(c=>c.Name.Trim().ToUpper()==captainUnderpantCreate.Name.TrimEnd().ToUpper()).FirstOrDefault();

            if(captainUnderpants!=null)
            {
                ModelState.AddModelError("", "Owner already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pokemonMap = _mapper.Map<CaptainUnderpant>(captainUnderpantCreate);


            if (!_captainUnderpantsRepository.CreateCaptainUnderpants(ownerId, catId, pokemonMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

    }
}
