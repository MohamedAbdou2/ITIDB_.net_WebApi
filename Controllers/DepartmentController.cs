using ITIDB_.net_WebApi.DTO;
using ITIDB_.net_WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITIDB_.net_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ITIContext _context;

        public DepartmentController(ITIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            List<Department> depts= _context.Departments.ToList();
            List<DepartmentDto> deptDtoList = new List<DepartmentDto>();
            foreach (var item in depts)
            {
                DepartmentDto deptDto = new DepartmentDto()
                {
                    Id = item.Dept_Id,
                    Name = item.Dept_Name,
                    Location = item.Dept_Location,
                    StudentsNum = item.Students.Select(s => s.St_Id).Count(),

                };

                deptDtoList.Add(deptDto);
            }

            return Ok(deptDtoList);
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartmentById(int id)
        {
            Department dept = _context.Departments.Find(id);
            if(dept == null)
            {
                return NotFound();
            }
            else
            {
                DepartmentDto deptDto = new DepartmentDto()
                {
                    Id = dept.Dept_Id,
                    Name = dept.Dept_Name,
                    Location = dept.Dept_Location,
                    StudentsNum = dept.Students.Select(s => s.St_Id).Count(),

                };
                return Ok(deptDto);


            }
        }
    }
}
