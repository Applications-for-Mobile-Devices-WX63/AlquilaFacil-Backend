using AlquilaFacilPlatform.IAM.Domain.Model.Aggregates;
using AlquilaFacilPlatform.IAM.Domain.Respositories;
using AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AlquilaFacilPlatform.IAM.Infrastructure.Persistence.EFC.Respositories;

/**
 * <summary>
 *     The user repository
 * </summary>
 * <remarks>
 *     This repository is used to manage users
 * </remarks>
 */
public class UserRepository (AppDbContext context) : BaseRepository<User>(context), IUserRepository 
{
    /**
     * <summary>
     *     Find a user by username
     * </summary>
     * <param name="email">The username to search</param>
     * <returns>The user</returns>
     */
    public async Task<User?> FindByEmailAsync(string email)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(user => user.Email == email);
    }
    
    /**
     * <summary>
     *     Check if a user exists by username
     * </summary>
     * <param name="username">The username to search</param>
     * <returns>True if the user exists, false otherwise</returns>
     */
    public bool ExistsByUsername(string username)
    {
        return Context.Set<User>().Any(user => user.Username.Equals(username));
    }

    public bool ExistsById(int userId)
    {
        return Context.Set<User>().Any(user => user.Id == userId);
    }
}