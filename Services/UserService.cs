using AmadeusAPI.Models;
using AmadeusAPI.Repositories;
using AmadeusAPI.Interfaces;

namespace  AmadeusAPI.services;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        try
        {
            return await _userRepository.GetUsers();
        }
        catch (Exception ex)
        {
            throw new Exception("no users found", ex);
        }
    }
    
    public async Task<User> GetUser(int id)
    {
        try
        {
            return await _userRepository.GetUser(id);
        }
        catch (Exception ex)
        {
            throw new Exception("user not found", ex);
        }
    }

    public async Task<User> AddUser(User user)
    {
        try
        {
            return await _userRepository.AddUser(user);
        }
        catch (Exception ex)
        {
            throw new Exception("user not added", ex);
        }
    }

    public async Task<User> UpdateUser(User user)
    {
        try
        {
            return await _userRepository.UpdateUser(user);
        }
        catch (Exception ex)
        {
            throw new Exception("user not updated", ex);
        }
    }

    public async Task<User> DeleteUser(int id)
    {
        try
        {
            var user = await _userRepository.DeleteUser(id);
            if (user == null)
            {
                throw new Exception("user not deleted");
            }
            return user;
        }
        catch (Exception ex)
        {
            throw new Exception("user not deleted", ex);
        }
    }





    }
