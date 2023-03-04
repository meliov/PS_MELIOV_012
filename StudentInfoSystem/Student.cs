using System;

namespace StudentInfoSystem;

public class Student
{
    private string firstName;
    private string middleName;
    private string lastName;
    private string faculty;
    private string specialty; // xD
    private string educationDegree;
    private string status;
    private string faqNumber;
    private int course;
    private int stream; // lol
    private int group;
    
    
    public Student(string firstName, string middleName, string lastName, string faculty, string specialty, string educationDegree, string status, string faqNumber, int course, int stream, int group)
    {
        this.firstName = firstName;
        this.middleName = middleName;
        this.lastName = lastName;
        this.faculty = faculty;
        this.specialty = specialty;
        this.educationDegree = educationDegree;
        this.status = status;
        this.faqNumber = faqNumber;
        this.course = course;
        this.stream = stream;
        this.group = group;
    }

    public string FirstName
    {
        get => firstName;
        set => firstName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string MiddleName
    {
        get => middleName;
        set => middleName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string LastName
    {
        get => lastName;
        set => lastName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Faculty
    {
        get => faculty;
        set => faculty = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Specialty
    {
        get => specialty;
        set => specialty = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string EducationDegree
    {
        get => educationDegree;
        set => educationDegree = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Status
    {
        get => status;
        set => status = value;
    }

    public string FaqNumber
    {
        get => faqNumber;
        set => faqNumber = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Course
    {
        get => course;
        set => course = value;
    }

    public int Stream
    {
        get => stream;
        set => stream = value;
    }

    public int Group
    {
        get => group;
        set => group = value;
    }

}