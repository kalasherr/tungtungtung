using DataAccessPostgres.Models;

namespace FirstWebApp.Models;

public class Game
{
    public GameEntity game_entity { get; set; }
    public int id { get; set; }
    public string name { get; set; } = "";
    public string description { get; set; } = "blablabla";
    public string tags { get; set; } = "";
    public List<string> tags_list  { get; set; } = new List<string>();
    public DateTime release_date { get; set; }
    public int window_width { get; set; } = 800;
    public int window_height { get; set; } = 600;
    public List<Comment> comments { get; set; } = new List<Comment>();
    public Game()
    {
        
    }
    public Game(int game_id)
    {
        UserEntity user = new UserEntity();
        CommentEntity comment = new CommentEntity();
        comment.Text = "Какой-то рандомный коммент, который должен быть каким-то отзывом к игре";
        comment.User = user;
        user.User_Name = "Рандомный комментатор";
        game_entity = new GameEntity();
        // gameEntity.Id;
        game_entity.Title  = "Ну да это просто игра";
        game_entity.Description  = "Здесь должно быть длинное описание игры, но у нас нет подключения к бд";
        game_entity.release_date = DateTime.Now;
        game_entity.Comments = [comment];

        // gameEntity.User_Id;
        //
        // gameEntity.User;
        
        // tags_list.Add("1000");
        // tags_list.Add("1000");
        // tags_list.Add("1000");
        // comments.Add(new Comment(0, "tralalelo tralala", "bombordiro crocodilo"));
        
        id = game_id;
        name = "default name";
    }

    public List<String> parse_tags(string tags)
    {
        List<string> list = new List<string>();
        string to_add = "";
        for (int i = 0; i < tags.Length; i++)
        {
            if (tags[i] != ' ' && tags[i] != ',' && tags[i] != ';')
            {
                to_add += tags[i];
            }
            else if (to_add != "")
            {
                list.Add(to_add);
                to_add = "";
            }
        }
        return list;
    }
    
    // public string get_html()
    // {
    //     return "/games/" + id + "/index.html";
    // }
    public class Comment
    {
        public int id { get; set; }
        public string text { get; set; } = "";
        public string author { get; set; } = "";
        public int author_id { get; set; }
        
        public Comment()
        {
            
        }
        
        public Comment(int id, string text, string author)
        {
             this.id = id;
             this.text = text;
             this.author = author;
        }
    }
}