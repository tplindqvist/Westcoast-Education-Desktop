using WestcoastEducation.Core.Models;

namespace WestcoastEducation.Core.Interfaces;

// Med interface kan lagringen bytas ut mot en databas senare
public interface ICourseStorage
{
    void Save(List<Course> courses);
    List<Course> Load();
}
