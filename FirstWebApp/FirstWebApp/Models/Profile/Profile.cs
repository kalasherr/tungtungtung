using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FirstWebApp.Models;
using System;
using System.IO;
public class Profile
{
    [Required(ErrorMessage = "Введите логин")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Введите пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public List<string> games { get; set;}

    public void fill_list()
    {
        int b = 0;
        string rootPath = "wwwroot/Games";
        if (Directory.Exists(rootPath))
        {
            string[] folders = Directory.GetDirectories(rootPath);
            foreach (string folder in folders)
            {
                games.Add(Path.GetFileName(folder));
                Console.Write(folder);
            }
        }
    }
    public Profile()
    {
        games = new List<string>();
    }
    public bool Authenticated()
    {
        if  (Username == "admin" && Password == "1234")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
