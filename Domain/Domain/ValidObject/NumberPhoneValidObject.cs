using Domain.Exception;
using System.Text.RegularExpressions;

namespace Domain.ValidObject;

public class NumberPhoneValidObject
{
    public string Text { get; }

    public NumberPhoneValidObject(string text)
    {
        string pattern = @"^(\+7|8)[\s\-]?\(?\d{3}\)?[\s\-]?\d{3}[\s\-]?\d{2}[\s\-]?\d{2}$";
        string cleanedPhoneNumber = Regex.Replace(text, @"\s+", "");

        if (!Regex.IsMatch(cleanedPhoneNumber, pattern)) throw new ValidObjectException("Не корректный номер телефона");

        Text = text;
    }
}