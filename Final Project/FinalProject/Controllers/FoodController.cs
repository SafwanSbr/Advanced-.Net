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
    public class FoodController : ApiController
    {
        [HttpGet]
        [Route("api/Food")]
        public HttpResponseMessage GetFood()
        {
            try
            {
                var data = FoodService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/Food/{id}")]
        public HttpResponseMessage GetFoodById(int id)
        {
            try
            {
                var data = FoodService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/CreateFood")]
        public HttpResponseMessage CreateEventFood(FoodDTO FoodDTO)
        {
            try
            {
                var success = FoodService.Create(FoodDTO);
                if (success)
                    return Request.CreateResponse(HttpStatusCode.Created, "Food created successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to create Food");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/UpdateFood/{id}")]
        public HttpResponseMessage UpdateAdmin(int id, FoodDTO FoodDTO)
        {
            try
            {
                if (FoodDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Admin data");
                }
                FoodDTO.Id = id; // Set the Food ID from the route parameter
                var updatedFood = FoodService.Update(FoodDTO);
                return Request.CreateResponse(HttpStatusCode.OK, updatedFood);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/DeleteFood/{id}")]
        public HttpResponseMessage DeleteFood(int id)
        {
            try
            {
                var success = FoodService.Delete(id);
                if (success)
                    return Request.CreateResponse(HttpStatusCode.OK, "Food deleted successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Food not found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}