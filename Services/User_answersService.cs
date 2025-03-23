using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;

namespace AmadeusAPI.Services;

    public class User_answersService:IUser_answersService
    {
        private readonly IUser_answersRepository _user_answersRepository;

        public User_answersService(IUser_answersRepository user_answersRepository)
        {
            _user_answersRepository = user_answersRepository;
        }

        public async Task<IEnumerable<User_answers>> GetUsers()
    {
        try
        {
            return await _user_answersRepository.GetUser_answer();
        }
        catch (Exception ex)
        {
            throw new Exception("no users found", ex);
        }
    }
    
    public async Task<User_answers> GetUser(int id)
    {
        try
        {
            return await _user_answersRepository.GetUser_answer(id);
        }
        catch (Exception ex)
        {
            throw new Exception("user not found", ex);
        }
    }

    public async Task AddUser(User_answers user)
    {
        try
        {
            await _user_answersRepository.AddUser(user);
        }
        catch (Exception ex)
        {
            throw new Exception("user not added", ex);
        }
    }

    public async Task  UpdateUser(User_answers user)
    {
        try
        {
             await _user_answersRepository.UpdateUser(user);
        }
        catch (Exception ex)
        {
            throw new Exception("user not updated", ex);
        }
    }

    public async Task<User_answers> DeleteUser(int id)
    {
        try
        {
            var user = await _user_answersRepository.DeleteUser(id);
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