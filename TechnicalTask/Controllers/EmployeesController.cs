using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalTask.Models;
using TechnicalTask.ViewModels;

namespace TechnicalTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly LuftBornContext _context;

        public EmployeesController(LuftBornContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<Result<List<Employee>>> GetEmployee()
        {

            Result<List<Employee>> allEmployee = new(true) {
                ResponseObject = await _context.Employee.ToListAsync()
            };
            return allEmployee;
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<Result<Employee>> GetEmployee(Guid id)
        {
            try
            {
                var employee = await _context.Employee.SingleOrDefaultAsync(e=>e.Id==id);

                if (employee == null)
                {
                    return new (true)
                    {
                        ResponseMessage = "Employee with this id is not Exist",
                    };
                }
                return new(true)
                {
                    ResponseObject = employee,
                };
            }
            catch (Exception ex)
            {
                return new(true)
                {
                    ResponseMessage = ex.Message,
                };
            }
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<Result<Employee>> PutEmployee(Guid id, Employee employee)
        {
            try
            {
                var emp = await _context.Employee.SingleOrDefaultAsync(e => e.Id == id);
                if (emp==null)
                {
                    return new Result<Employee>(false)
                    {
                        ResponseMessage = "Id is not exist check and try again"
                    };
                }
                emp.Name = employee.Name;
                emp.Title = employee.Title;
                emp.PhoneNumber = employee.PhoneNumber;
                emp.JobDescription = employee.JobDescription;
                emp.Age = employee.Age;
                emp.Address = employee.Address;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new Result<Employee>(false)
                {
                    ResponseMessage = ex.Message,
                };
            }
            return new Result<Employee>(true)
            {
                ResponseMessage = "Employee Updated Successfully",
            };
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Result<Employee>> PostEmployee(Employee employee)
        {
            if(!ModelState.IsValid)
            {
                return new Result<Employee>(false)
                {
                    ResponseMessage = "Please check for Employee data and try again"
                };
            }
            try
            {
                employee.Id = Guid.NewGuid();
                _context.Employee.Add(employee);
                await _context.SaveChangesAsync();
                return new Result<Employee>(true)
                {
                    ResponseObject = employee,
                    ResponseMessage="Employee Added Successfully"
                };
            }
            catch (Exception ex)
            {
                return new Result<Employee>(false)
                {
                    ResponseMessage = ex.Message
                };
            }
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<Result<Employee>> DeleteEmployee(Guid id)
        {
            var employee = await _context.Employee.SingleOrDefaultAsync(e => e.Id == id);
            if (employee == null)
            {
                return new Result<Employee>(false)
                {
                    ResponseMessage = "This employee is not exist"
                };
            }
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return new Result<Employee>(true)
            {
                ResponseMessage = "Employee deleted Successfully",
                ResponseObject=employee,
            };
        }

    }
}
