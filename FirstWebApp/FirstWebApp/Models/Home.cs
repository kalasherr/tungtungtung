using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FirstWebApp.Models;
using System;
using System.IO;

public class Home
{
    public List<String> tags = new List<string>() {"adventure", "puzzle", "simulator"};
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

    public Home()
    {
        games = new List<string>();
    }
}