using CaptainUnderpantsReviewApp.Interfaces;
using CaptainUnderpantsReviewApp.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CaptainUnderpantsReviewApp.Dto;

namespace CaptainUnderpantsReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {
            var country = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());
            //   var country = _countryRepository.GetCountries();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(country);

        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        public IActionResult GetCountry(int id)
        {
            if (!_countryRepository.CountryExists(id))
                return NotFound();

           // var country = _countryRepository.GetCountry(id);
           var country = _mapper.Map<CountryDto>(_countryRepository.GetCountry(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(country);
        }

        [HttpGet("/owners/{Ownerid}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200,Type = typeof(Country))]
        public IActionResult GetCountryByOwner(int Ownerid)
        {
            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountryByOwner(Ownerid));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(country);
        }


        [HttpGet("/owners/{countryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Country))]
        public IActionResult GetOwnersFromCountry(int countryId)
        {
            var country = _mapper.Map<CountryDto>(_countryRepository.GetOwnersFromCountry(countryId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(country);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(200)]
        public IActionResult CreateCountry([FromBody] CountryDto countryCreate)
        {
            if (countryCreate == null)
                return BadRequest();

            var Country = _countryRepository.GetCountries()
                .Where(c => c.Name.Trim().ToUpper() == countryCreate.Name.ToUpper()).FirstOrDefault();

            if (Country != null)
            {
                ModelState.AddModelError("", "Country already existss");
                return StatusCode(422, ModelState);
            }
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var countryMap = _mapper.Map<Country>(countryCreate);

            if(!_countryRepository.CreateCountry(countryMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500,ModelState);
            }
            return Ok("Successfully added");
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCountry(int countryId, [FromBody] CountryDto updateCountry)
        {
            if (updateCountry == null)
                return BadRequest();

            if (countryId != updateCountry.Id)
                return BadRequest();

            if (!_countryRepository.CountryExists(countryId))
                return NotFound();

            var countryMap = _mapper.Map<Country>(updateCountry);
            
            if(!_countryRepository.UpdateCountry(countryMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }     
}
