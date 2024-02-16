using CaptainUnderpantsReviewApp.Interfaces;
using CaptainUnderpantsReviewApp.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CaptainUnderpantsReviewApp.Dto;

namespace CaptainUnderpantsReviewApp.Controllers
{
    public class OwnerController : Controller
    {

        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult GetOwners()
        {
            var owner = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());
            if(!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(owner);
        }

        [HttpGet("ownerId")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult GetCaptainUnderpantsByOwner(int ownerId)
        {
            if (!_ownerRepository.OwnerExists(ownerId))
                return NotFound();

            var owner = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetCaptainUnderpantsByOwner(ownerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(owner);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Owner))]
        public IActionResult GetOwner(int ownerId)
        {
            if (!_ownerRepository.OwnerExists(ownerId))
                return NotFound();

            
            var owner = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwner(ownerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(owner);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CaptainUnderpant>))]
        public IActionResult GetOwnerOfACaptainUnderpants(int captainId)
        {
            var owner = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwnerOfACaptainUnderpants(captainId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(owner);
        }
    }
}
