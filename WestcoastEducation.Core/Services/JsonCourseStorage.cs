using System.Text.Json;
using WestcoastEducation.Core.Interfaces;
using WestcoastEducation.Core.Models;

namespace WestcoastEducation.Core.Services;

public class JsonCourseStorage : ICourseStorage
{
    public string FilePath { get; set; }

    public JsonCourseStorage(string filePath)
    {
        FilePath = filePath;
    }

    public void Save(List<Course> courses)
    {
        // Mappen måste finnas innan filen skrivs
        // Kollar null ifall sökvägen saknar mapp
        string? folder = Path.GetDirectoryName(FilePath);
        if (!string.IsNullOrEmpty(folder))
        {
            Directory.CreateDirectory(folder);
        }

        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(courses, options);
        File.WriteAllText(FilePath, json);
    }

    public List<Course> Load()
    {
        if (!File.Exists(FilePath)) // Filen finns inte vid första körning, den tomma listan förhindrar krasch
        {
            return new List<Course>();
        }

        string json = File.ReadAllText(FilePath);
        List<Course>? courses = JsonSerializer.Deserialize<List<Course>>(json);

        if (courses == null)
        {
            return new List<Course>();
        }

        return courses;
    }
}
