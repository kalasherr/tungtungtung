namespace FirstWebApp.Models;

public class Game
{
    public int id { get; set; }
    public string name { get; set; } = "";
    public string description { get; set; } = "";
    public string genre { get; set; } = "";
    public DateTime release_date { get; set; }
    
    public Game()
    {
        
    }
    public Game(int game_id)
    {
        id = game_id;
        name = game_id.ToString();
    }

    public string get_html()
    {
        return "/games/" + id + "/index.html";
    }
}