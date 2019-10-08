using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ProfloSlackIntegration.Models
{
    public class ProfloSlackTeamBinding
    {        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string ProfloSlackTeamBindingId { get; set; }
        public string ProfloTeamId { get; set; }
        public string SlackChannelId { get; set; }
        [BsonElement("Teamboards")]
        public List<TeamBoard> TeamBoards { get; set; }


    }
}