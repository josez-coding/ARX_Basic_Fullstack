using FSTeam.Commands.Response;
using MediatR;

namespace FSTeam.Commands.Dto;

public class TestDataDto : IRequest<TestDataResponse>
{
    public string Name {get; set;}
}