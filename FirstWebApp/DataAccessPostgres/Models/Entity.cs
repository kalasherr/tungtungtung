namespace DataAccessPostgres.Models;

public class UserEntity
{
    public Guid Id { get; set; }
    
    public string BIO { get; set; } = String.Empty;
    
    public string User_Name { get; set; } = String.Empty;
    
    public string User_login { get; set; } = String.Empty;
    
    public string User_password { get; set; } = String.Empty;
    
    public string User_Icon { get; set; } = String.Empty;
    
    public bool Role_admin { get; set; } = false ;
    
    public List<CommentEntity> Comments { get; set; } = [];
    public List<GameEntity> Games { get; set; } = [];
}


public class GameEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public DateTime release_date { get; set; } = DateTime.Now;
    
    public List<TagEntity> Tags { get; set; } = [];
    public List<CommentEntity> Comments { get; set; } = [];
    
    public Guid User_Id { get; set; }
      
    public UserEntity? User { get; set; }
}

public class TagEntity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = String.Empty;
    
    public List<GameEntity> Games { get; set; } = [];
    
}

public class CommentEntity
{
    public Guid Id { get; set; }
    public string Text { get; set; } = String.Empty;
    public Guid User_Id { get; set; }
    public UserEntity? User { get; set; }
    public Guid Game_Id { get; set; }
    public GameEntity? Game { get; set; }
}