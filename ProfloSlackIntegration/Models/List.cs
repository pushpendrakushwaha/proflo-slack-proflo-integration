using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace ProfloSlackIntegration.Models
{
    public class List
    {
        [BsonId]
        [BsonElement("listId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string LId { get; set; }
        [BsonElement("boardId")]
        public string BoardId { get; set; }
        
        [BsonElement("listTitle")]
        public string ListTitle { get; set; }
        [BsonElement("listPosition")]
        public int ListPosition { get; set; }
        [BsonElement("creationDate")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        [BsonElement("cards")]
        public List<Card> ListCards { get; set; }
    }
}
