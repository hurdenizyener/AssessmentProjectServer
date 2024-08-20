namespace Application.Common.Repositories.Abstractions;

public interface IQuery<T>
{
    IQueryable<T> Query();
}