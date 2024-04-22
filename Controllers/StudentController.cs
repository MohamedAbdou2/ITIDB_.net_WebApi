using ITIDB_.net_WebApi.DTO;
using ITIDB_.net_WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITIDB_.net_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ITIContext _context;

        public StudentController(ITIContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAllStudents()
        {
            List<Student> std = _context.Students.ToList();
            List<StudentDto> stdDtoList = new List<StudentDto>();
            foreach (Student item in std)
            {
                StudentDto stdDto = new StudentDto()
                {

                    Id = item.St_Id,
                    Name = (item.St_Fname + ' ' + item.St_Lname).Trim(),
                    Address = item.St_Address,
                    Age = item.St_Age,
                    DepartmentName = item.Dept!=null ? item.Dept.Dept_Name:null,
                    SupervisorName =item.St_superNavigation != null? (item.St_superNavigation.St_Fname + ' ' + item.St_superNavigation.St_Lname).Trim():null,

                };

                stdDtoList.Add(stdDto);
            }

            return Ok(stdDtoList);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            Student std = _context.Students.Find(id);
            if (std == null) { return NotFound(); }
            else
            {
                StudentDto stdDto = new StudentDto()
                {
                    Id = std.St_Id,
                    Name= (std.St_Fname+' '+std.St_Lname).Trim(),
                    Address= std.St_Address,
                    Age = std.St_Age,
                    DepartmentName = std.Dept != null ? std.Dept.Dept_Name : null,
                    SupervisorName = std.St_superNavigation != null ? (std.St_superNavigation.St_Fname + ' ' + std.St_superNavigation.St_Lname).Trim() : null,
                };
                return Ok(stdDto);

            }
        }

       
    }
}
