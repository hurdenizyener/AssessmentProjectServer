namespace Application.Common.Pagination.Requests;

public sealed record PageRequest(
    int PageIndex,
    int PageSize
    );