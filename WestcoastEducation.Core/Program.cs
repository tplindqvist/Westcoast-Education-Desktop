using WestcoastEducation.Core.Interfaces;
using WestcoastEducation.Core.Models;
using WestcoastEducation.Core.Services;

namespace WestcoastEducation.Core;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Skapa registret
        CourseManager manager = new CourseManager();

        // Skapa personer och kurser
        Student student = new(
        "Fia",
        "Klasson",
        0701011010,
        "19930211-4549",
        "Knuffgatan 15",
        12345,
        "Stockholm");

        Student student2 = new(
        "Bert",
        "Karlsson",
        0704501010,
        "19960415-4539",
        "Semelgatan 30",
        14342,
        "Uppsala");

        Teacher teacher = new(
        "Anders",
        "Andersson",
        0701011010,
        "19640612-5217",
        "Storgatan 52",
        13439,
        "Karlstad",
        "Hemkunskap");

        EducationManager educationManager = new(
        "Peter",
        "Grandqvist",
        0705010550,
        "19750715-6510",
        "Maximusgatan 13B",
        43941,
        "Surte",
        "Drejning",
        new DateOnly(2026, 1, 2));

        Administrator administrator = new(
        "Admin",
        "Adminsson",
        0701032133,
        "850113-3319",
        "Admingatan 15",
        12456,
        "Karlshamn",
        "None",
        new DateOnly(2024, 5, 4));

        Course hemkunskap = new Course(
        "HK26B",
        "Hemkunskap",
        40,
        new DateOnly(2026, 8, 25),
        new DateOnly(2027, 6, 25),
        CourseType.Remote);

        Course drejning = new Course(
        "DG26C",
        "Drejning",
        40,
        new DateOnly(2026, 8, 26),
        new DateOnly(2027, 4, 24),
        CourseType.Classroom);

        // Lägg till allt i registret
        manager.AddStudent(student);
        manager.AddStudent(student2);
        manager.AddTeacher(teacher);
        manager.AddEducationManager(educationManager);
        manager.AddAdministrator(administrator);
        manager.AddCourse(hemkunskap);
        manager.AddCourse(drejning);

        // Koppla ihop kurser med lärare och studenter
        hemkunskap.AssignTeacher(teacher);

        hemkunskap.AddStudent(student);
        drejning.AddStudent(student2);

        // Visa resultat
        Console.WriteLine("── Kurser ──");
        manager.ListCourses();

        Console.WriteLine();

        Console.WriteLine("── Studenter ──");
        manager.ListStudents();

        // Spara kurserna till JSON
        ICourseStorage storage = new JsonCourseStorage("Data/courses.json"); // Variabeln har interfacets typ, så endast denna raden ändras om lagring byts ut
        storage.Save(manager.Courses);
        Console.WriteLine();
        Console.WriteLine("Kurserna har sparats till courses.json");

        // Läs in kurserna från JSON igen
        List<Course> loadedCourses = storage.Load();

        Console.WriteLine();
        Console.WriteLine("── Inlästa kurser från JSON ──");
        foreach (Course course in loadedCourses)
        {
            Console.WriteLine(course);
        }
    }
}