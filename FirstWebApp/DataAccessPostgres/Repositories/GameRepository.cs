using DataAccessPostgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessPostgres.Repositories;

public class GameRepository
{
    private readonly ProgramDbContext _dbContext;

    public GameRepository(ProgramDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    
    public async Task Add(Guid Id, string Title, string description)
    {
        var entity = new GameEntity();
        entity.Id = Id;
        entity.Title = Title;
        entity.Description = description;
        
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }
    
    
    
    
    
    public async Task<List<GameEntity>> GetAllGames()
    {
        return await _dbContext.Games
            .AsNoTracking()
            .OrderBy(c => c.Id)
            .ToListAsync();
    }

    public async Task<GameEntity> GetGame(Guid Id)
    {
         return await _dbContext.Games.AsNoTracking()
             .Include(g => g.Comments).
             FirstOrDefaultAsync(g => g.Id == Id);
    }
    
    
}