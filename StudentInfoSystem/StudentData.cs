using System;
using System.Collections.Generic;

namespace StudentInfoSystem;

public class StudentData
{
    private static  List<Student> testStudents = new List<Student>()
    {
        new Student("Dragan", "ananas", 
            "mangov", "FKST", "KSI", 
            "bachelor", Status.ZAVERIL.ToString(), 
            "12334", 1, 9, 44
        )
    };

    public static  List<Student> TestStudents
    {
        get => testStudents;
        private set => testStudents = value ?? throw new ArgumentNullException(nameof(value));
    }
}