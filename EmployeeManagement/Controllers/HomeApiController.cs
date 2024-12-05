using EmployeeManagement.Data;
using EmployeeManagement.Model;
using EmployeeManagement.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class HomeApiController : ControllerBase
    {
        public readonly AppDbContext _context;
        public readonly ResponseDto _response;
        public HomeApiController(AppDbContext context, ResponseDto response)
        {
            _context = context;
            _response = response;
        }


        [HttpGet]
        [Route("getEmployee/{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                Employee? employee = _context.employees.FirstOrDefault(u => u.Id == id);
                if (employee !=null)
                {
                    _response.Message = "Get Data";
                    _response.isSuccess = true;
                    _response.Result = employee;
                }
                else
                {
                    _response.Message = "Employee not Exist";
                    _response.isSuccess = false;
                }
           
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return Ok(_response);
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Employee> empList = _context.employees.ToList();
                _response.Message = "Get";
                _response.isSuccess = true;
                _response.Result = empList;


            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return Ok(_response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Employee? employee = _context.employees.FirstOrDefault(u => u.Id == id);
                if (employee != null)
                {
                    var delEmp = _context.Remove(employee);
                    _context.SaveChanges();
                    _response.Message = "Deleted";
                    _response.isSuccess = true;
                }
                else
                {
                    _response.Message = "employee not exist";
                    _response.isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return Ok(_response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] List<Employee> emp)
        {
            try
            {

                _response.Message = "Save";
                _response.isSuccess = true;
                foreach (var item in emp)
                {
                    var empObj = _context.employees.Add(item);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return Ok(_response);
        }

        [HttpPut]
        [Route("updateEmp")]
        public IActionResult Put([FromBody] Employee emp)
        {
            try
            {

                //Employee employee = _context.employees.FirstOrDefault(u => u.Id == emp.Id);
                _context.employees.Update(emp);
                _context.SaveChanges();
                _response.Message = "Update";
                _response.isSuccess = true;

            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return Ok(_response);
        }


    }
}
