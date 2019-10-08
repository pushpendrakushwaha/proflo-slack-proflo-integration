using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using ProfloSlackIntegration.DataAccess;
using ProfloSlackIntegration.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace ProfloSlackIntegration.Services
{
    public class ProfloSlackIntegrationService: IProfloSlackIntegrationService
    {
        private string CoreMicroServiceUrl;
        private readonly HttpClient httpClient;
        private readonly IProfloSlackHandler profloSlackHandler;
        public ProfloSlackIntegrationService(IProfloSlackHandler profloSlackHandler, IConfiguration config)
        {
            this.profloSlackHandler = profloSlackHandler;
            this.httpClient = new HttpClient();
            this.CoreMicroServiceUrl = config.GetSection("CoreMicroServiceUrl").Value;
        }
        public async Task<ProfloSlackTeamBinding> CreateOrUpdateSlackProfloTeamBinding(ProfloSlackTeamBinding profloSlackTeamBinding)
        {
            return await this.profloSlackHandler
                .CreateOrUpdateSlackProfloTeamBinding(profloSlackTeamBinding);
        }

        #region Board Operations
        public async Task<Board> CreateBoard(Board board)
        {
            if (board.BoardMembers == null)
            {
                board.BoardMembers = new List<Member>();
            }
            if (board.BoardInvites == null)
            {
                board.BoardInvites = new List<Invitee>();
            }
            if (board.BoardLists == null)
            {
                board.BoardLists = new List<List>();
            }
            var response = await this.httpClient.PostAsJsonAsync<Board>($"{this.CoreMicroServiceUrl}/api/boards", board);
            var createdBoardString = (await response.Content.ReadAsStringAsync());
            var createdBoard = JsonConvert.DeserializeObject<Board>(createdBoardString);
            return createdBoard;          
        }
        public async Task<Board> AddMemberToBoard(string boardId, Member member)
        {
            var response = await this.httpClient.PostAsJsonAsync<Member>($"{this.CoreMicroServiceUrl}/api/boards/{boardId}/member", member);
            var AddMembersToBoardString = (await response.Content.ReadAsStringAsync());
            var AddMembersToBoard = JsonConvert.DeserializeObject<Board>(AddMembersToBoardString);
            return AddMembersToBoard;
        }
        #endregion

        #region List Operations
        public async Task<List> CreateList(List list)
        {
            if (list.ListCards == null)
            {
                list.ListCards = new List<Card>();
            }
            var response = await this.httpClient.PostAsJsonAsync<List>($"{this.CoreMicroServiceUrl}/api/lists", list);
            var createListString = (await response.Content.ReadAsStringAsync());
            var createList = JsonConvert.DeserializeObject<List>(createListString);
            return createList;

        }
        public async Task<List> AddMemberToList(string listId, Member member)
        {
            var response = await this.httpClient.PostAsJsonAsync<Member>($"{this.CoreMicroServiceUrl}/api/lists/{listId}/member", member);
            var AddMembersToListString = (await response.Content.ReadAsStringAsync());
            var AddMemberToList = JsonConvert.DeserializeObject<List>(AddMembersToListString);
            return AddMemberToList;
        }
        #endregion

        #region Card Operations
        public async Task<Card> CreateCard(Card card)
        {
            if (card.Assignees == null)
            {
                card.Assignees = new List<Member>();
            }
            if (card.Labels == null)
            {
                card.Labels = new List<Label>();
            }
            if (card.Attachments == null)
            {
                card.Attachments = new List<Attachment>();
            }
            if (card.Comments == null)
            {
                card.Comments = new List<Comment>();
            }
            if (card.CardInvites == null)
            {
                card.CardInvites = new List<Invitee>();
            }
            var response = await this.httpClient.PostAsJsonAsync<Card>($"{this.CoreMicroServiceUrl}/api/cards", card);
            var createCardString = (await response.Content.ReadAsStringAsync());
            var createCard = JsonConvert.DeserializeObject<Card>(createCardString);
            return createCard;
        }
        //Adding Members to Team
        public async Task<Card> AddMemberToCard(string cardId, Member member)
        {
            var response = await this.httpClient.PostAsJsonAsync<Member>($"{this.CoreMicroServiceUrl}/api/cards/{cardId}/member", member);
            var AddMembersToCardString = (await response.Content.ReadAsStringAsync());
            var AddMemberToCard = JsonConvert.DeserializeObject<Card>(AddMembersToCardString);
            return AddMemberToCard;
        }

        public async Task<Card> AddCommentToCard(string cardId, Comment comment)
        {
            var response = await this.httpClient.PostAsJsonAsync<Comment>($"{this.CoreMicroServiceUrl}/api/cards/{cardId}/comment", comment);
            var AddCommentsToCardString = (await response.Content.ReadAsStringAsync());
            var AddCommentsToCard = JsonConvert.DeserializeObject<Card>(AddCommentsToCardString);
            return AddCommentsToCard;
        }

        public async Task<Card> AddLabelToCard(string cardId, Label label)
        {
            var response = await this.httpClient.PostAsJsonAsync<Label>($"{this.CoreMicroServiceUrl}/api/cards/{cardId}/label", label);
            var AddLabelsToCardString = (await response.Content.ReadAsStringAsync());
            var AddLabelToCard = JsonConvert.DeserializeObject<Card>(AddLabelsToCardString);
            return AddLabelToCard;
        }

        public async Task<Card> AddAttachmentToCard(string cardId, Attachment attachment)
        {
            var response = await this.httpClient.PostAsJsonAsync<Attachment>($"{this.CoreMicroServiceUrl}/api/cards/{cardId}/attachment", attachment);
            var AddAttachmentsToCardString = (await response.Content.ReadAsStringAsync());
            var AddAttachmentToCard = JsonConvert.DeserializeObject<Card>(AddAttachmentsToCardString);
            return AddAttachmentToCard;
        }

        #endregion


        //public void UpdateSlackTeamBoards(string slackChannelId, Board board)
        //{
        //    profloSlackHandler.UpdateSlackTeamBoards(slackChannelId, board);
        //}
    }
}