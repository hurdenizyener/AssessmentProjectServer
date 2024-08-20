namespace Application.Common.Pagination.Responses;


public sealed class GetListResponse<T> : BasePageableModel
{
    private IList<T> _items = [];

    public IList<T> Items
    {
        get => _items;
        set => _items = value;
    }
}