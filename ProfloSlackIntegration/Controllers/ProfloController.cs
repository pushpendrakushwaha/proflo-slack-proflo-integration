using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfloSlackIntegration.BusinessLayer;
using ProfloSlackIntegration.BusinessLayer.Exceptions;
using ProfloSlackIntegration.Models;
using ProfloSlackIntegration.Services;

namespace ProfloSlackIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfloSlackController : ControllerBase
    {
        
        private readonly IProfloSlackIntegrationService profloSlackIntegrationService;
        public ProfloSlackController(IProfloSlackIntegrationService profloSlackIntegrationService)
        {
           
            this.profloSlackIntegrationService = profloSlackIntegrationService;
        }

        // POST api/profloslack
        [HttpPost]
        public ActionResult<IEnumerable<string>> Post([FromForm] SlackBindModel slackBindModel)
        {
            var url = string.Join($"/", slackBindModel.Text.Split(' ').Prepend($"/api/profloslack/{slackBindModel.Channel_Id}"));
            Console.WriteLine("URL IS:");
            Console.WriteLine(url);
            return Redirect(url);
        }

        #region help to get all commands
        [HttpGet("{channelId}/help")]
        public ActionResult<IEnumerable<string>> Proflohelp([FromRoute] string channelId,[FromRoute] string help)
        {
            return Ok(" ```Proflo Commands``` ```To Bind Team to the Channel use /proflo bind team {teamId}``` ```To Create Board to the team use /proflo create board {teamId} {boardName} {boardDescription}``` ```To Create list to the board use /proflo create list {boardId} {listTitle}``` ```To Create card to the board use /proflo create card {boardId} {listId} {cardTitle} {cardDescription}``` ");
        }
        #endregion
        #region Team Bind
        [HttpGet("{channelId}/bind/team/{teamId}")]
        public async Task<ActionResult> BindTeam([FromRoute] string channelId, [FromRoute] string teamId)
        {
            Console.WriteLine("Binding Team");
            var profloSlackTeamBinding = new ProfloSlackTeamBinding()
            {
                ProfloTeamId = teamId,
                SlackChannelId = channelId,
                TeamBoards = new List<TeamBoard>()

            };
            await profloSlackIntegrationService.CreateOrUpdateSlackProfloTeamBinding(profloSlackTeamBinding);
            return Ok("Team Binding Done");
        }

        #endregion
 
        #region Board Operations
        // POST api/profloslack
        [HttpGet("{channelId}/create/board/{teamId}/{boardName}/{Description}")]
        public async Task<IActionResult> PostBoard([FromRoute] string channelId, [FromRoute] Board board)
        {
            Console.WriteLine(board);
            //ProfloSlackTeamBinding profloSlackTeamBinding = new ProfloSlackTeamBinding();
            var ProfloSlackTeamBindingcreator = new ProfloSlackTeamBinding();
            var boardCreation = new Board()
            {
                TeamId = board.TeamId,
                BoardName = board.BoardName,
                Description = board.Description
            };
            await profloSlackIntegrationService.CreateBoard(boardCreation);
            return Ok("Created Board");
        }
        //// POST api/profloslack
        //[HttpGet("{channelId}/add/board/member/{memberName}")]
        //public async Task<IActionResult> AddMemberToBoard([FromRoute] string channelId, [FromRoute] string boardId, [FromRoute] Member member)
        //{
        //    Console.WriteLine(member);
        //    var addMemberToBoard = new Member()
        //    {
        //        MemberName = member.MemberName,
        //    };
        //    await profloSlackIntegrationService.AddMemberToBoard(boardId,addMemberToBoard);
        //    return Ok("Added Member to Board");
        //}

        #endregion

        #region List Opearions

        // POST api/profloslack
        [HttpGet("{channelId}/create/list/{boardId}/{listTitle}")]
        public async Task<IActionResult> PostList([FromRoute] string channelId, [FromRoute] List list)
        {
            //Console.WriteLine(list.ListTitle);
            var listCreation = new List()
            {
                
                BoardId = list.BoardId,
                ListTitle = list.ListTitle
            };
            await profloSlackIntegrationService.CreateList(listCreation);
            return Ok("Created List");
        }
        //// POST api/profloslack
        //[HttpGet("{channelId}/add/list/member/{memberName}")]
        //public async Task<IActionResult> AddMemberToList([FromRoute] string channelId, [FromRoute] string listId, [FromRoute] Member member)
        //{
        //    Console.WriteLine(member);
        //    var addMemberToList = new Member()
        //    {
        //        MemberName = member.MemberName,
        //    };
        //    await profloSlackIntegrationService.AddMemberToList(listId, addMemberToList);
        //    return Ok("Added Member to List");
        //}
        #endregion


        #region Card Operations
        // POST api/profloslack
        [HttpGet("{channelId}/create/card/{boardId}/{listId}/{cardTitle}/{cardDescription}")]
        public async Task<IActionResult> PostCard([FromRoute] string channelId, [FromRoute] Card card)
        {
            // Console.WriteLine(card.CardTitle);
            var cardCreation = new Card()
            {
                BoardId = card.BoardId,
                ListId = card.ListId,
                CardTitle = card.CardTitle,
                description = card.description
            };
            await profloSlackIntegrationService.CreateCard(cardCreation);
            return Ok("Created Card");
        }
        //// POST api/profloslack
        //[HttpGet("{channelId}/add/card/member/{memberName}")]
        //public async Task<IActionResult> AddMemberToCard([FromRoute] string channelId, [FromRoute] string cardId, [FromRoute] Member member)
        //{
        //    Console.WriteLine(member);
        //    var addMemberToCard = new Member()
        //    {
        //        MemberName = member.MemberName,
        //    };
        //    await profloSlackIntegrationService.AddMemberToCard(cardId, addMemberToCard);
        //    return Ok("Added Member to Card");
        //}

        //// POST api/profloslack
        //[HttpGet("{channelId}/add/card/comment/{commentText}")]
        //public async Task<IActionResult> AddCommentToCard([FromRoute] string channelId, [FromRoute] string cardId, [FromRoute] Comment comment)
        //{
        //    Console.WriteLine(comment);
        //    var addCommentToCard = new Comment()
        //    {
        //        CommentText = comment.CommentText,
        //    };
        //    await profloSlackIntegrationService.AddCommentToCard(cardId, addCommentToCard);
        //    return Ok("Added Comment to Card");
        //}

        //// POST api/profloslack
        //[HttpGet("{channelId}/add/card/attachment/{name}")]
        //public async Task<IActionResult> AddAttachmentToCard([FromRoute] string channelId, [FromRoute] string cardId, [FromRoute] Attachment attachment)
        //{
        //    Console.WriteLine(attachment);
        //    var addAttachmentToCard = new Attachment()
        //    {
        //        Name = attachment.Name,
        //    };
        //    await profloSlackIntegrationService.AddAttachmentToCard(cardId, addAttachmentToCard);
        //    return Ok("Added Attachment to Card");
        //}

        //// POST api/profloslack
        //[HttpGet("{channelId}/add/card/label/{labelName}")]
        //public async Task<IActionResult> AddInviteeToCard([FromRoute] string channelId, [FromRoute] string cardId, [FromRoute] Label label)
        //{
        //    Console.WriteLine(label);
        //    var addLabelToCard = new Label()
        //    {
        //        LabelName = label.LabelName,
        //    };
        //    await profloSlackIntegrationService.AddLabelToCard(cardId, addLabelToCard);
        //    return Ok("Added Label to Card");
        //}
        #endregion
    }
}