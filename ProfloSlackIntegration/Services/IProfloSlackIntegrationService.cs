using ProfloSlackIntegration.Models;
using System.Threading.Tasks;

namespace ProfloSlackIntegration.Services
{
    public interface IProfloSlackIntegrationService
    {
        Task<ProfloSlackTeamBinding> CreateOrUpdateSlackProfloTeamBinding(ProfloSlackTeamBinding profloSlackTeamBinding);
        //  Task<ProfloSlackTeamBinding> AddBoardToParticularTeam(ProfloSlackTeamBinding profloSlackBoardAdding);
        // void UpdateSlackTeamBoards(string slackChannelId, Board board);
        #region Board Operations
        Task<Board> CreateBoard(Board board);
        Task<Board> AddMemberToBoard(string boardId, Member member);
        

        #endregion

        #region List Operations
        Task<List> CreateList(List list);
        Task<List> AddMemberToList(string listId, Member member);

        #endregion


        #region Card Operations
        Task<Card> CreateCard(Card card);
        Task<Card> AddMemberToCard(string cardId, Member member);
        Task<Card> AddCommentToCard(string cardId, Comment comment);
        Task<Card> AddLabelToCard(string cardId, Label label);
        Task<Card> AddAttachmentToCard(string cardId, Attachment attachment);
        #endregion
    }
}