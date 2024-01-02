using Models;
using Repositories;

namespace Services {
    public class UserService(IUserRepository userRepository) : IUserService {


        public Task<User?> GetUser(string id){
            return userRepository.GetUser(id);
        }

        public Task<List<User>> GetUsers(){
            return userRepository.GetUsers();
        }

        public Task<User> AddUser(User newUser){
            return userRepository.AddUser(newUser);
        }

        public Task UpdateUser(User updateMe) {
            return userRepository.UpdateUser(updateMe);
        }

        public Task DeleteUser(string id){
            return userRepository.DeleteUser(id);
        }
    }
}