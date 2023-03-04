using System;
using UserLogin;

namespace StudentInfoSystem;

public class StudentValidation
{
    public static Student getStudentDataByUser(User user)
    {
        if (user.FakNum == null || StudentData.TestStudents.Find(it => it.FaqNumber.Equals(user.FakNum)) == null)
        {
            Console.WriteLine("User with this fq num does not exist.");
            return null;
        }

        return StudentData.TestStudents.Find(it => it.FaqNumber.Equals(user.FakNum));
    }
}