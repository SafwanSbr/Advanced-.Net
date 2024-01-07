using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Route("api/Employees")]
        public HttpResponseMessage GetEmployees()
        {
            try
            {
                var data = EmployeeService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/Employees/{id}")]
        public HttpResponseMessage GetEmployeeById(int id)
        {
            try
            {
                var data = EmployeeService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/Employees/{id}/Orders")]
        public HttpResponseMessage GetEmployeeByIdWithOrders(int id)
        {
            try
            {
                var data = EmployeeService.GetByIdWithOrders(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/CreateEmployees")]
        public HttpResponseMessage CreateEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                var success = EmployeeService.Create(employeeDTO);
                if (success)
                    return Request.CreateResponse(HttpStatusCode.Created, "Employee created successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to create employee");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/UpdateEmployees/{id}")]
        public HttpResponseMessage UpdateEmployee(int id, EmployeeDTO employeeDTO)
        {
            try
            {
                if (employeeDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid employee data");
                }
                employeeDTO.Id = id; // Set the employee ID from the route parameter
                var updatedEmployee = EmployeeService.Update(employeeDTO);
                return Request.CreateResponse(HttpStatusCode.OK, updatedEmployee);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/DeleteEmployees/{id}")]
        public HttpResponseMessage DeleteEmployee(int id)
        {
            try
            {
                var success = EmployeeService.Delete(id);
                if (success)
                    return Request.CreateResponse(HttpStatusCode.OK, "Employee deleted successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee not found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
