namespace WestcoastEducation.Core.Models;

public class Teacher : Staff
{

    public override string ToString()
    {
        return $"Lärare: {base.ToString()}";
    }
}
