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
    public class HallController : ApiController
    {
        [HttpGet]
        [Route("api/halls")]
        public HttpResponseMessage Halls()
        {
            try
            {
                var data = HallService.GET();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });

            }
        }
        [HttpGet]
        [Route("api/halls/{id}")]
        public HttpResponseMessage GetHall(int id)
        {
            try
            {
                var data = HallService.Get(id);
                if (data != null)
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Order not found." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/deletehalls/{id}")]
        public HttpResponseMessage DeleteHall(int id)
        {
            try
            {
                var operation = HallService.Delete(id);
                if (operation)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Hall deleted successfully." });
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Hall not found." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/updatehalls/{id}")]
        public HttpResponseMessage UpdateHall(int id, HallDTO hallDTO)
        {
            try
            {
                hallDTO.Id = id; // Set the team ID from the route parameter
                var updateHall = HallService.Update(hallDTO);
                return Request.CreateResponse(HttpStatusCode.OK, updateHall);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/createhalls")]
        public HttpResponseMessage CreateHall(HallDTO hallDTO)
        {
            try
            {
                var success = HallService.Create(hallDTO);
                if (success)
                    return Request.CreateResponse(HttpStatusCode.Created, "Hall created successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to create Hall");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/hallwithorders/{id}")]
        public HttpResponseMessage HallWithOrder(int id)
        {
            try
            {
                var data = HallService.GetWithOrders(id);
                if (data != null)
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Order not found." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/hallsbylocation/{location}")]
        public HttpResponseMessage HallsbyLocation(string location)
        {
            try
            {
                var data = HallService.GetHallsByLocation(location);
                if (data != null)
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Halls not found." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}