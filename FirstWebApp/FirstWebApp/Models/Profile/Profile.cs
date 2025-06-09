namespace FirstWebApp.Models;
using System;
using System.IO;
public class Profile
{
    public List<string> games { get; set;}

    public void fill_list()
    {
        

        string rootPath = "/Games";

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
}
