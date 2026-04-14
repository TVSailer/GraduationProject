using Domain.Entitys;
using Domain.Exception;
using Domain.Service.FielService.BaseFileService;

namespace General.Service.File;

public class AuthFileService(string nameFile) : IAuthFileService
{
    public void WriteAuth(AuthEntity auth)
    {
        using StreamWriter outputFijle = new StreamWriter(nameFile, false);

        outputFijle.WriteLine(auth.Login);
        outputFijle.WriteLine(auth.Password);
    }

    public (string login, string password) ReadAuth()
    {
        if (!System.IO.File.Exists(nameFile)) throw new ServiceException("Нету записей");

        using StreamReader inputFile = new StreamReader(nameFile);

        var login = inputFile.ReadLine();
        var paswword = inputFile.ReadLine();

        return (login, paswword);
    }

    public bool Exists()
    {
        if (!System.IO.File.Exists(nameFile)) return false;
        return true;
    }
}