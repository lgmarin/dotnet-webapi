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

    [HttpGet("id")]
    public IActionResult GetOwnerById(Guid id)
    {
        try
        {
            var owner = _repository.Owner.GetOwnerById(id);
            if (owner == null)
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
}