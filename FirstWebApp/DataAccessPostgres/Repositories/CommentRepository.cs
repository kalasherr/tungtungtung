using DataAccessPostgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessPostgres.Repositories;

public class CommentRepository
{
    private readonly ProgramDbContext _dbContext;

    public CommentRepository(ProgramDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Guid Id, Guid GameId, Guid UserId, string text)
    {
        var entity = new CommentEntity();
        entity.Id = Id;
        entity.Game_Id = GameId;
        entity.User_Id = UserId;
        entity.Text = text;
    }

    
}