using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloSlackIntegration.Models
{
    public class TeamBoard
    {
        [BsonId]
        [BsonElement("boardId")]
        public string BoardId { get; set; }
        //[BsonElement("boardName")]
        //public string BoardName { get; set; }
    }
}
