using System.Text.Json.Serialization;

namespace WestcoastEducation.Core.Models;

public class Student : Person
{

    public override string ToString()
    {
        return $"Student: {base.ToString()}";
    }

}
