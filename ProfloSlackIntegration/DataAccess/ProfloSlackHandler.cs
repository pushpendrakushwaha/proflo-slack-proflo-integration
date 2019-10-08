using ProfloSlackIntegration.Models;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProfloSlackIntegration.DataAccess
{
    public class ProfloSlackHandler: IProfloSlackHandler 
    {
        private readonly PowerupDbContext context; 
        public ProfloSlackHandler(PowerupDbContext context)
        {
            this.context = context;
        }

        public async Task<ProfloSlackTeamBinding> CreateOrUpdateSlackProfloTeamBinding(ProfloSlackTeamBinding profloSlackTeamBinding)
        {
           // Console.WriteLine("Created First builder");
            var filterBySlackTeamId = Builders<ProfloSlackTeamBinding>.Filter.Eq(p => 
                    p.SlackChannelId, profloSlackTeamBinding.SlackChannelId
            );
           // Console.WriteLine("Created Second Filter and done AND operation");
            var matchSlackProfloBinding = Builders<ProfloSlackTeamBinding>.Filter.And(
                filterBySlackTeamId
            );
           // Console.WriteLine("Async await for the context");
            await context.ProfloSlackTeamBindings.ReplaceOneAsync(matchSlackProfloBinding, profloSlackTeamBinding, new UpdateOptions() { IsUpsert = true });
           // Console.WriteLine("returning Data" + profloSlackTeamBinding.SlackChannelId + profloSlackTeamBinding.ProfloTeamId);
            return profloSlackTeamBinding;
        }
        //public async Task UpdateSlackTeamBoards(string slackChannelId, Board board)
        //{
        //    // board.BoardLists = new List<BoardList>();
        //    await context.Boards.InsertOneAsync(board);
        //    var teamBoard = new TeamBoard()
        //    {
        //        BoardId = board.BoardId
        //    };
        //    var filter = Builders<ProfloSlackTeamBinding>.Filter.Eq(c => c.SlackChannelId, slackChannelId);
        //    var update = Builders<ProfloSlackTeamBinding>.Update.Push(c => c.TeamBoards, teamBoard);
        //    var updateTeam = context.ProfloSlackTeamBindings.FindOneAndUpdateAsync(filter, update);
        //    await updateTeam;
        //}

    }
}