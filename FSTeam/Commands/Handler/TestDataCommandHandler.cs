using FSTeam.Commands.Dto;
using FSTeam.Commands.Response;
using FSTeam.Services;
using MediatR;

namespace FSTeam.Commands.Handler;

public class TestDataCommandHandler : IRequestHandler<TestDataDto, TestDataResponse>
{
    private readonly ITokenService _service;

    public TestDataCommandHandler(ITokenService service)
    {
        _service = service;
    }
    
    public async Task<TestDataResponse> Handle(TestDataDto request, CancellationToken cancellationToken)
    {
        var execute = await _service.AddNewName(request.Name);
        return new TestDataResponse { Message = execute };
    }
}