using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Final.Controllers
{
    public class EventFoodController : ApiController
    {
        [HttpGet]
        [Route("api/EventFood")]
        public HttpResponseMessage GetEventFood()
        {
            try
            {
                var data = EventFoodService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/EventFood/{id}")]
        public HttpResponseMessage GetEventFoodById(int id)
        {
            try
            {
                var data = EventFoodService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/CreateEventFood")]
        public HttpResponseMessage CreateEventFood(EventFoodDTO EventFoodDTO)
        {
            try
            {
                var success = EventFoodService.Create(EventFoodDTO);
                if (success)
                    return Request.CreateResponse(HttpStatusCode.Created, "EventFood created successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to create EventFood");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/UpdateEventFood/{id}")]
        public HttpResponseMessage UpdateEventFood(int id, EventFoodDTO EventFoodDTO)
        {
            try
            {
                if (EventFoodDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid EventFood data");
                }
                EventFoodDTO.Id = id; // Set the EventFood ID from the route parameter
                var updatedEventFood = EventFoodService.Update(EventFoodDTO);
                return Request.CreateResponse(HttpStatusCode.OK, updatedEventFood);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/DeleteEventFood/{id}")]
        public HttpResponseMessage DeleteEventFood(int id)
        {
            try
            {
                var success = EventFoodService.Delete(id);
                if (success)
                    return Request.CreateResponse(HttpStatusCode.OK, "EventFood deleted successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "EventFood not found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }


    }
}