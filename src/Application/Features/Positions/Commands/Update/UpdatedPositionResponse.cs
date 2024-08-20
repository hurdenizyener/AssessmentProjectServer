using Application.Features.Positions.Constans;

namespace Application.Features.Positions.Commands.Update;

public sealed record UpdatedPositionResponse(
    Guid Id,
    string Title,
    DateTime LastModifiedDate,
    string Message = PositionMessages.PositionSuccessfullyUpdated);
