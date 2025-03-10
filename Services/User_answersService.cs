using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;

namespace AmadeusAPI.services;

    public class User_answersService
    {
        private readonly User_answersRepository _user_answersRepository;

        public User_answersService(User_answersRepository user_answersRepository)
        {
            _user_answersRepository = user_answersRepository;
        }

        public async Task<IEnumerable<User>> GetUsers()
    {
        try
        {
            return await _user_answersRepository.GetUsers();
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
            return await _user_answersRepository.GetUser(id);
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
            return await _user_answersRepository.AddUser(user);
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
            return await _user_answersRepository.UpdateUser(user);
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
            return await _user_answersRepository.DeleteUser(id);
        }
        catch (Exception ex)
        {
            throw new Exception("user not deleted", ex);
        }
    }
    }