using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloSlackIntegration.Models
{
    public class ProfloSlackBoardBinding
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string ProfloSlackBoardBindingId { get; set; }
        public string ProfloBoardId { get; set; }
        public string ProfloTeamId { get; set; }
        public string SlackChannelId { get; set; }
    }
}
