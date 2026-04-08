using CSharpFunctionalExtensions;
using System;
using System.Text.RegularExpressions;
using Domain.Exception;

namespace Domain.ValidObject;

public class NumberPhoneValidObject
{
    public string Text { get; }

    private NumberPhoneValidObject(string text)
    {
        Text = text;
    }

    public static NumberPhoneValidObject Create(string text)
    {
        string pattern = @"^(\+7|8)[\s\-]?\(?\d{3}\)?[\s\-]?\d{3}[\s\-]?\d{2}[\s\-]?\d{2}$";
        string cleanedPhoneNumber = Regex.Replace(text, @"\s+", "");

        if (Regex.IsMatch(cleanedPhoneNumber, pattern)) throw new ValidObjectException("Не корректный номер телефона");

        return new NumberPhoneValidObject(text);
    }
}