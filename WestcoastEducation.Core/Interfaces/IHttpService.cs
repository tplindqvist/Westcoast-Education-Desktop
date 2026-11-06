namespace WestcoastEducation.Core.Interfaces;

public interface IHttpService<T>
{
    Task<List<T>> Get(string resource);
    Task Post(string resource, T model);
    Task Delete(string resource, string id);
    Task Put(string resource, string id, T data);
}