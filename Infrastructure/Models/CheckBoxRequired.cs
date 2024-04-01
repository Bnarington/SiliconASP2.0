using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class CheckBoxRequired : ValidationAttribute
    {
        public override bool IsValid(object? value) => value is bool b && b;
    }
}
