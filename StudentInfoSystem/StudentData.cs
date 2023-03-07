using System;
using System.Collections.Generic;

namespace StudentInfoSystem;

public class StudentData
{
    private static List<Student> testStudents = new List<Student>()
    {
        new Student("Dragan", "ananas",
            "mangov", "FKST", "KSI",
            "bachelor", Status.ZAVERIL.ToString(),
            "12334", 1, 9, 44
        ),
        new Student
        (
            "John",
            "Robert",
            "Doe",
            "Computer Science",
            "Software Engineering",
            "Bachelor's Degree",
            "Full-time",
            "123456789",
            2,
            1,
            1
        ),
        new Student
        (
            "Alice",
            "Mary",
            "Smith",
            "Business",
            "Marketing",
            "Master's Degree",
            "Part-time",
            "987654321",
            3,
            2,
            1
        ),
        new Student
        (
            "Bob",
            "James",
            "Johnson",
            "Engineering",
            "Mechanical Engineering",
            "Bachelor's Degree",
            "Full-time",
            "246813579",
            4,
            1,
            2
        )
    };

    public static List<Student> TestStudents
    {
        get => testStudents;
        private set => testStudents = value ?? throw new ArgumentNullException(nameof(value));
    }
}