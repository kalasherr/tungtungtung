using DataAccessPostgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessPostgres.Repositories;

public class UserRepository
{
    private readonly ProgramDbContext _dbContext;

    public UserRepository(ProgramDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Guid Id, string login, string password, string icon)
    {
        var entity = new UserEntity();
        entity.Id = Id;
        entity.User_login = login;
        entity.User_password = password;
        entity.User_Icon = icon;
        
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }
    
    
}