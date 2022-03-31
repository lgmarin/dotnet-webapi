using AutoMapper;
using Contracts;
using Entities;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AccountOwnerServer.Controllers;

[ApiController]
[Route("[controller]")]
public class OwnerController : ControllerBase
{
    private readonly ILoggerManager _logger;
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public OwnerController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _logger = logger;
        _repository = repositoryWrapper;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllOwners()
    {
        try
        {
            var owners = _repository.Owner.GetAllOwners();

            _logger.LogInfo("GET Method Returned all Owners.");

            var ownersResult = _mapper.Map<IEnumerable<OwnerDTO>>(owners);
            return Ok(ownersResult); 
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something wrong in GetAllOwners action: {ex.Message}");
            return StatusCode(500);
        }
    }

    [HttpGet("{id}", Name = "OwnerById")]
    public IActionResult GetOwnerById(Guid id)
    {
        try
        {
            var owner = _repository.Owner.GetOwnerById(id);
            if (owner is null)
            {
                _logger.LogInfo($"GET Method Not Found Owner with id: {id}.");
                return NotFound();
            } 
            else
            {
                _logger.LogInfo($"GET Method Returned Owner with id: {id}.");

                var ownerResult = _mapper.Map<OwnerDTO>(owner);
                return Ok(ownerResult);                 
            }
        }
        catch (System.Exception ex)
        {
            _logger.LogError($"Something wrong in GetAllOwners action: {ex.Message}");
            return StatusCode(500);
        }
    }

    [HttpPost]
    public IActionResult CreateOwner([FromBody]OwnerCreateDTO owner)
    {
        try
        {
            if (owner is null)
            {
                _logger.LogInfo("The Owner object provided is null");
                return BadRequest("Owner object is null!");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogInfo("The Owner object provided is invalid");
                return BadRequest("Invalid Owner object!");                
            }

            var ownerEntity = _mapper.Map<Owner>(owner);

            _repository.Owner.CreateOwner(ownerEntity);
            _repository.Save();

            var createdOwner = _mapper.Map<OwnerDTO>(ownerEntity);

            return CreatedAtRoute("OwnerById", new{createdOwner.Id}, createdOwner);
        }
        catch (System.Exception ex)
        {
            _logger.LogError($"Something wrong in CreateOwner action: {ex.Message}");
            return StatusCode(500);
        }
    }

    [HttpPut("id")]
    public IActionResult UpdateOwner(Guid id, [FromBody]OwnerUpdateDTO owner)
    {
        try
        {
            if (owner is null)
            {
                _logger.LogInfo("The Owner object provided is null");
                return BadRequest("Owner object is null!");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogInfo("The Owner object provided is invalid");
                return BadRequest("Invalid Owner object!");                
            }

            var ownerEntity = _repository.Owner.GetOwnerById(id);

            if (ownerEntity is null)
            {
                _logger.LogInfo($"The Owner with id: {id} not found!");
                return NotFound();                     
            }
            
            _mapper.Map(owner, ownerEntity);

            _repository.Owner.UpdateOwner(ownerEntity);
            _repository.Save();

            return NoContent();
        }
        catch (System.Exception ex)
        {
            _logger.LogError($"Something wrong in UpdateOwner action: {ex.Message}");
            return StatusCode(500);
        }
    }

    [HttpDelete("id")]
    public IActionResult DeleteOwner(Guid id)
    {
        try
        {
            var owner = _repository.Owner.GetOwnerById(id);

            if (owner is null)
            {
                _logger.LogInfo($"The Owner with id: {id} not found!");
                return NotFound();    
            }

            if (_repository.Account.AccountsByOwner(id).Any())
            {
                _logger.LogInfo($"The Owner with id: {id} has related accounts that should be deleted firs!");
                return BadRequest("Cannot delete Owner. It has related Accounts that should be removed first!");                   
            }

            _repository.Owner.DeleteOwner(owner);
            _repository.Save();

            return NoContent();
        }
        catch (System.Exception ex)
        {
            _logger.LogError($"Something wrong in DeleteOwner action: {ex.Message}");
            return StatusCode(500);
        }
    }
}