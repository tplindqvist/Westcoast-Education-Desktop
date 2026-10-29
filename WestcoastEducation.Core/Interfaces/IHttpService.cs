namespace WestcoastEducation.Core.Interfaces;

public interface IHttpService<T>
{
    Task<List<T>> Get(string resource);
    
}