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
    public class AdminController : ApiController
    {
        [HttpGet]
        [Route("api/Admin")]
        public HttpResponseMessage GetAdmin()
        {
            try
            {
                var data = AdminService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/Admin/{id}")]
        public HttpResponseMessage GetAdminById(int id)
        {
            try
            {
                var data = AdminService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/CreateAdmin")]
        public HttpResponseMessage CreateEventFood(AdminDTO AdminDTO)
        {
            try
            {
                var success = AdminService.Create(AdminDTO);
                if (success)
                    return Request.CreateResponse(HttpStatusCode.Created, "Admin created successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to create Admin");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/UpdateAdmin/{id}")]
        public HttpResponseMessage UpdateAdmin(int id, AdminDTO AdminDTO)
        {
            try
            {
                if (AdminDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Admin data");
                }
                AdminDTO.Id = id; // Set the Admin ID from the route parameter
                var updatedAdmin = AdminService.Update(AdminDTO);
                return Request.CreateResponse(HttpStatusCode.OK, updatedAdmin);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/DeleteAdmin/{id}")]
        public HttpResponseMessage DeleteAdmin(int id)
        {
            try
            {
                var success = AdminService.Delete(id);
                if (success)
                    return Request.CreateResponse(HttpStatusCode.OK, "Admin deleted successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Admin not found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}