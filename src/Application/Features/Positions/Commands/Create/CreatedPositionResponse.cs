using Application.Features.Positions.Constans;

namespace Application.Features.Positions.Commands.Create;

public sealed record CreatedPositionResponse(
    Guid Id,
    string Title,
    DateTime CreatedDate,
    string Message = PositionMessages.PositionSuccessfullyCreated);
