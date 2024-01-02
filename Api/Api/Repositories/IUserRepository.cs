using Models;

namespace Repositories {
    public interface IUserRepository {
        public Task<User?> GetUser(string id);
        public Task<List<User>> GetUsers();
        public Task<User> AddUser(User newUser);
        public Task UpdateUser(User updateMe);
        public Task DeleteUser(string id);
    }
}