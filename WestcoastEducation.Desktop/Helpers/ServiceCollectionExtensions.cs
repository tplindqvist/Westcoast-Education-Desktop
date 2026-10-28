using Microsoft.Extensions.DependencyInjection;
using WestcoastEducation.Desktop.ViewModels;

namespace WestcoastEducation.Desktop.Helpers;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection collection)
    {
        collection.AddSingleton<MainViewModel>();
    }
}