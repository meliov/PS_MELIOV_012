using System;
using System.Windows;
using StudentInfoSystem;

namespace WpfApp1;

public class StudentAndButtonContext
{
    private Student _student;
    private Visibility _disable;

    public Student Student
    {
        get => _student;
        set => _student = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Visibility Disable
    {
        get => _disable;
        set => _disable = value;
    }

    public StudentAndButtonContext(Student student, Visibility disable)
    {
        _student = student;
        _disable = disable;
    }
}