using System.ComponentModel.DataAnnotations;

public class NoWhitespaceAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                // Строка пуста или состоит только из пробелов
                return false;
            }

            return true;
        }

        return false;
    }
}