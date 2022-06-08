
using System.Collections.Generic;
using MongoDB.Driver;
using PIPOC_WMDB.IRepository;
using PIPOC_WMDB.Models;

namespace PIPOC_WMDB.Repository
{
    public class UserRepository : IUserRespository
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Users> _userTable = null;

        public UserRepository()
        {
            _mongoClient = new MongoClient("mongodb+srv://system:sys123@cluster0.qiig9.mongodb.net/?retryWrites=true&w=majority");
            _database = _mongoClient.GetDatabase("PIPOC_DB");
            _userTable = _database.GetCollection<Users>("t_User");
        }

        public string Delete(string userId)
        {
            _userTable.DeleteOne(x => x.Id == userId);
            return "Deleted";
        }

        public Users Get(string userId)
        {
            return _userTable.Find(x => x.Id == userId).FirstOrDefault();
        }

        public List<Users> Gets()
        {
            return _userTable.Find(FilterDefinition<Users>.Empty).ToList();
        }

        public Users Save(Users user)
        {
            var userObj = _userTable.Find(x => x.Id == user.Id).FirstOrDefault();
            if (userObj == null)
            {
                _userTable.InsertOne(user);
            }
            else
            {
                _userTable.ReplaceOne(x => x.Id == user.Id, user);
            }
            return user;
        }
    }
}

