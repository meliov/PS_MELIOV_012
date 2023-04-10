using System.Globalization;
using System.Windows.Controls;

namespace WpfApp1;

public class ValidateFields: ValidationRule
{
    public string ErrorMessage { get; set; }
    public int MinLength { get; set; }

    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (string.IsNullOrEmpty(value as string) || ((string)value).Length < MinLength)
        {
            return new ValidationResult(false, ErrorMessage);
        }

        return ValidationResult.ValidResult;
    }
}