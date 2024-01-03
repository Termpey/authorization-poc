using System.Security.Cryptography;
using Models;
using Utility;

namespace Repositories {
    public class UserRepository : IUserRepository {
        private string[] _features = {"InvoiceManage", "InvoiceView", "UserManage", "UserView"};

        private List<User> _users;

        private readonly ILatencyUtility<User> _latencyUtility;

        public UserRepository(ILatencyUtility<User> latencyUtility){
            _latencyUtility = latencyUtility;
            _users = SeedUserData();
        }

        public async Task<User?> GetUser(string id) {
            return await _latencyUtility.LatencyWithData(_users.Find(u => u.Uuid == id));
        }

        public async Task<List<User>> GetUsers(){
            return await _latencyUtility.LatencyWithListData(_users);
        }

        public async Task<User> AddUser(User newUser) {
            _users.Add(newUser);

            return await _latencyUtility.LatencyWithData(newUser);
        }

        public Task UpdateUser(User updateMe) {
            int index = _users.FindIndex(u => updateMe.Uuid == u.Uuid);
            _users[index] = updateMe;

            return _latencyUtility.Latency();
        }

        public Task DeleteUser(string id){

            int index = _users.FindIndex(u => u.Uuid == id);

            _users.RemoveAt(index);

            return _latencyUtility.Latency();
        }

        private List<User> SeedUserData(){
            List<User> tempUsers = new();


            for(int i = 0; i < 10; i++){
                tempUsers.Add(new User() {
                    Uuid = i.ToString(),
                    Name = "Name: " + i.ToString(),
                    Email = i.ToString() + "@email.com",
                    Features = GetRandomFeatures()
                });
            }

            return tempUsers;
        }

        private string[] GetRandomFeatures(){
            string[] features = [_features[RandomNumberGenerator.GetInt32(2)], _features[RandomNumberGenerator.GetInt32(2, 4)]];

            return features;
        }
    }
}