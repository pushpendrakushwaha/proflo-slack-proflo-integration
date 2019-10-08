using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloSlackIntegration.Models
{
    public class SlackBindModel
    {
       
        [BsonElement("token")]
        public string Token { get; set; }
        [BsonElement("team_id")]
        public string Team_Id { get; set; }
        [BsonElement("team_domain")]
        public string Team_Domain { get; set; }
        [BsonElement("enterprise_id")]
        public string Enterprise_Id { get; set; }
        [BsonElement("enterprise_name")]
        public string Enterprise_Name { get; set; }
        [BsonElement("channel_id")]
        //[BsonId]
        public string Channel_Id { get; set; }
        [BsonElement("channel_name")]
        public string Channel_Name { get; set; }
        [BsonElement("user_id")]
        public string User_Id { get; set; }
        [BsonElement("user_name")]
        public string User_Name { get; set; }
        [BsonElement("command")]
        public string Command { get; set; }
        [BsonElement("text")]
        public string Text { get; set; }
        [BsonElement("response_url")]
        public string Response_Url { get; set; }
        [BsonElement("trigger_id")]
        public string Trigger_Id { get; set; }

       // public ICollection<Team> teams { get; set; }
        
        public override string ToString()
        {
            var details = $@"Token:{this.Token},
                     Team_Id:{this.Team_Id},
                     Team_Domain:{this.Team_Domain},
                     Enterprise_Id:{this.Enterprise_Id},
                     Enterprise_Name:{this.Enterprise_Name},
                     Channel_Id: {this.Channel_Id},
                     Channel_Name :{this.Channel_Name}, 
                     User_Id :{this.User_Id},
                     User_Name: {this.User_Name},
                     Command: { this.Command},
                     Text :{this.Text}, 
                     Response_Url: {this.Response_Url}, 
                     Trigger_Id :{this.Trigger_Id}";
            Console.WriteLine(details);
            return JsonConvert.SerializeObject(this);
        }
    }
}