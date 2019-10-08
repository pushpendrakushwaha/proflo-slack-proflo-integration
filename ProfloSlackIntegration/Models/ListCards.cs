using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloSlackIntegration.Models
{
    public class ListCards
    {
        [BsonId]
        public string CId { get; set; }

        [BsonElement("cardTitle")]
        public string CardTitle { get; set; }
    }
}
