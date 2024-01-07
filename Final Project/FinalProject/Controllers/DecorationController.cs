using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class DecorationController : ApiController
    {
        [HttpGet]
        [Route("api/decorations")]
        public HttpResponseMessage Decorations()
        {
            try
            {
                var data = DecorationService.GET();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });

            }
        }
        [HttpGet]
        [Route("api/decorations/{id}")]
        public HttpResponseMessage GetDecoration(int id)
        {
            try
            {
                var data = DecorationService.Get(id);
                if (data != null)
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Decoration Theme not found." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/deletedecorations/{id}")]
        public HttpResponseMessage DeleteDecoration(int id)
        {
            try
            {
                var operation = DecorationService.Delete(id);
                if (operation)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Decoration Theme deleted successfully." });
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Decoration not found." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/updatedecorations/{id}")]
        public HttpResponseMessage UpdateDecoration(int id, DecorationDTO decorationDTO)
        {
            try
            {
                decorationDTO.Id = id; // Set the team ID from the route parameter
                var updateDecoration = DecorationService.Update(decorationDTO);
                return Request.CreateResponse(HttpStatusCode.OK, updateDecoration);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/createdecorations")]
        public HttpResponseMessage CreateDecoration(DecorationDTO decorationDTO)
        {
            try
            {
                var success = DecorationService.Create(decorationDTO);
                if (success)
                    return Request.CreateResponse(HttpStatusCode.Created, "Decoration created successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to create Decoration");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/decorationsbycolor/{colors}")]
        public HttpResponseMessage DecorationsByColors(string colors)
        {
            try
            {
                var data = DecorationService.GetDecorationsByColors(colors);
                if (data != null)
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Decoration Theme not found." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}