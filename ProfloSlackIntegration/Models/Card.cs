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
    public class Card
    {
        [BsonId]
        [BsonElement("cardId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CardId { get; set; }

        [BsonElement("description")]
        public string description { get; set; }
        [BsonElement("cardTitle")]
        public string CardTitle { get; set; }
        [BsonElement("boardId")]
        public string BoardId { get; set; }

        [BsonElement("listId")]
        public string ListId { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        public List<Member> Assignees { get; set; }
        [BsonElement("labels")]
        public List<Label> Labels { get; set; }
        [BsonElement("attachments")]
        public List<Attachment> Attachments { get; set; }
        [BsonElement("comments")]
        public List<Comment> Comments { get; set; }
        [BsonElement("cardInvites")]
        public List<Invitee> CardInvites { get; set; }
    }
}
