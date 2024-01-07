using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class TeamMemberController : ApiController
    {
        [HttpGet]
        [Route("api/TeamMembers")]
        public HttpResponseMessage GetTeamMembers()
        {
            try
            {
                var data = TeamMemberService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/TeamMembers/{id}")]
        public HttpResponseMessage GetTeamMemberById(int id)
        {
            try
            {
                var data = TeamMemberService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/CreateTeamMembers")]
        public HttpResponseMessage CreateTeamMember(TeamMemberDTO teamMemberDTO)
        {
            try
            {
                var success = TeamMemberService.Create(teamMemberDTO);
                if (success)
                    return Request.CreateResponse(HttpStatusCode.Created, "Team member created successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to create team member");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/UpdateTeamMembers/{id}")]
        public HttpResponseMessage UpdateTeamMember(int id, TeamMemberDTO teamMemberDTO)
        {
            try
            {
                teamMemberDTO.Id = id; // Set the team member ID from the route parameter
                var updatedTeamMember = TeamMemberService.Update(teamMemberDTO);
                return Request.CreateResponse(HttpStatusCode.OK, updatedTeamMember);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/DeleteTeamMembers/{id}")]
        public HttpResponseMessage DeleteTeamMember(int id)
        {
            try
            {
                var success = TeamMemberService.Delete(id);
                if (success)
                    return Request.CreateResponse(HttpStatusCode.OK, "Team member deleted successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Team member not found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
