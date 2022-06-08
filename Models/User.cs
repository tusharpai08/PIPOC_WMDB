using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PIPOC_WMDB.Models
{
    public class Users
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("Username")]
        public string Username { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        [BsonElement("UserTypeID")]
        public int UserTypeID { get; set; }
    }
}

