using ProfloSlackIntegration.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfloSlackIntegration.DataAccess
{
    public interface IProfloSlackHandler
    {
        Task<ProfloSlackTeamBinding> CreateOrUpdateSlackProfloTeamBinding(ProfloSlackTeamBinding profloSlackTeamBinding);
       // Task UpdateSlackTeamBoards(string slackChannelId, Board board);


    }
}