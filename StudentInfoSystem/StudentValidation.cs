using System;
using System.Linq;
using UserLogin;

namespace StudentInfoSystem;

public class StudentValidation
{
    public static Student getStudentDataByUser(User user)
    {
        StudentInfoContext context = new StudentInfoContext();
        Student dbStud = context.Students
            .FirstOrDefault(it => it.FaqNumber.Equals(user.FakNum.Replace(" ", "")));
        if (user.FakNum == null || dbStud == null)
        {
            Console.WriteLine("User with this fq num does not exist.");
            return null;
        }

        return dbStud;
    }

    public static Student getStudentDataByUserSortedAlphabetically()
    {
        return StudentData.TestStudents.OrderBy(u => u.LastName)
                         .ThenBy(u => u.FirstName)
                         .ThenBy(u => u.MiddleName)
                         .FirstOrDefault();
    }
}