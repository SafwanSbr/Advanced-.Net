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
    public class OrderController : ApiController
    {
        [HttpGet]
        [Route("api/orders")]
        public HttpResponseMessage Orders()
        {
            try
            {
                var data = OrderService.GET();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });

            }
        }
        [HttpGet]
        [Route("api/orders/{id}")]
        public HttpResponseMessage GetOrder(int id)
        {
            try
            {
                var data = OrderService.Get(id);
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
        [Route("api/deleteorders/{id}")]
        public HttpResponseMessage DeleteOrder(int id)
        {
            try
            {
                var operation = OrderService.Delete(id);
                if (operation)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Order deleted successfully." });
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Order not found." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/updateorders/{id}")]
        public HttpResponseMessage UpdateOrder(int id, OrderDTO orderDTO)
        {
            try
            {
                orderDTO.Id = id; // Set the team ID from the route parameter
                var updatedOrder = OrderService.Update(orderDTO);
                return Request.CreateResponse(HttpStatusCode.OK, updatedOrder);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}