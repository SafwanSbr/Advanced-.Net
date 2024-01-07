using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class TeamController : ApiController
    {
        [HttpGet]
        [Route("api/Teams")]
        public HttpResponseMessage GetTeams()
        {
            try
            {
                var data = TeamService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/Teams/{id}")]
        public HttpResponseMessage GetTeamById(int id)
        {
            try
            {
                var data = TeamService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/Teams/{id}/Members")]
        public HttpResponseMessage GetTeamByIdWithMembers(int id)
        {
            try
            {
                var data = TeamService.GetByIdWithMembers(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/CreateTeams")]
        public HttpResponseMessage CreateTeam(TeamDTO teamDTO)
        {
            try
            {
                var success = TeamService.Create(teamDTO);
                if (success)
                    return Request.CreateResponse(HttpStatusCode.Created, "Team created successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to create team");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/UpdateTeams/{id}")]
        public HttpResponseMessage UpdateTeam(int id, TeamDTO teamDTO)
        {
            try
            {
                teamDTO.Id = id; // Set the team ID from the route parameter
                var updatedTeam = TeamService.Update(teamDTO);
                return Request.CreateResponse(HttpStatusCode.OK, updatedTeam);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/DeleteTeam/{id}")]
        public HttpResponseMessage DeleteTeam(int id)
        {
            try
            {
                var success = TeamService.DeleteOnlyTeam(id);
                if (success)
                    return Request.CreateResponse(HttpStatusCode.OK, "Team deleted successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Team not found");
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
