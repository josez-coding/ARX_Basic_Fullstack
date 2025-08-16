using FSTeam.Commands.Dto;
using FSTeam.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FSTeam.Controllers;


[ApiController]
[Route("api/[controller]")] //http://localhost:5001/api/TestData/get-all-test-data
public class TestDataController : ControllerBase // MVC -> Model, Controller 
{
    
    private readonly ITokenService _service;
    private readonly IMediator _mediator;

    public TestDataController(ITokenService service, IMediator mediator)
    {
        _service = service;
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-all-test-data")]
    public async Task<IActionResult> GetAllSync()
    {
        var data = await _service.GetAllDataFromTestModel();
        return Ok(data);

    }

    [HttpPost]
    [Route("add-new-name")]
    public async Task<IActionResult> CreateNewName([FromBody] TestDataDto dto)
    {
        var result = await _mediator.Send(new TestDataDto {Name = dto.Name });
        return Ok(result);

    }
    
}