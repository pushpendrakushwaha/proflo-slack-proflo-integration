using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloSlackIntegration.Models
{
    public class Invitee
    {
        [BsonId]
        public string InviteId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
    }
}
