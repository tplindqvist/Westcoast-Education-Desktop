namespace WestcoastEducation.Core.Interfaces;

public interface IHttpService<T>
{
    Task<List<T>> Get(string resource);
    Task Post(string resource, T model);
}