using ITIDB_.net_WebApi.DTO;
using ITIDB_.net_WebApi.interfaces;
using ITIDB_.net_WebApi.Models;
using ITIDB_.net_WebApi.repositories;
using ITIDB_.net_WebApi.UniitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ITIDB_.net_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly UnitWork unit;


        //private readonly GenericRepository<Student> repository;

        //public StudentController(GenericRepository<Student> repository)
        //{


        //    this.repository = repository;
        //}

        public StudentController(UnitWork unit)
        {
            this.unit = unit;
        }

        [HttpGet]
        [SwaggerOperation(summary: "gat all student", description: "my desc")]
        [SwaggerResponse(200, description: "all student", Type = typeof(List<StudentDto>))]
        [Produces("application/json")]
        public IActionResult GetAllStudents()
        {
            List<Student> std = unit.StudentRepository.GetAll();

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

        //#region pagination for students
        //[HttpGet("pagination")]
        //public IActionResult GetAllStudentsPagination([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        //{
            
        //    if (pageNumber <= 0 || pageSize <= 0)
        //    {
        //        return BadRequest("Page number and page size must be positive.");
        //    }

            
        //    int skip = (pageNumber - 1) * pageSize;

            
        //    var students = _context.Students
        //        .Skip(skip)
        //        .Take(pageSize)
        //        .ToList();

            
        //    List<StudentDto> stdDtoList = students.Select(item => new StudentDto
        //    {
        //        Id = item.St_Id,
        //        Name = (item.St_Fname + ' ' + item.St_Lname).Trim(),
        //        Address = item.St_Address,
        //        Age = item.St_Age,
        //        DepartmentName = item.Dept != null ? item.Dept.Dept_Name : null,
        //        SupervisorName = item.St_superNavigation != null ? (item.St_superNavigation.St_Fname + ' ' + item.St_superNavigation.St_Lname).Trim() : null,
        //    }).ToList();

            
        //    return Ok(stdDtoList);
        //}

        //#endregion




        /// <summary>
        /// get student by student id
        /// </summary>
        /// <param name="id"> student id</param>
        /// <returns> list of students</returns>
        /// <remarks>
        /// request example:
        ///  /api/student/1
        /// </remarks>
        [HttpGet("{id}", Name = "StudentRoute")]

        [ProducesResponseType<List<StudentDto>>(200)]
        [ProducesResponseType(404, Type = typeof(void))]
        public IActionResult GetStudentById(int id)
        {
            Student std =unit.StudentRepository.GetById(id);
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

        [HttpPost]
        //[Consumes("appliction/json")]
        public IActionResult PostStudent(Student newstudent)
        {
            if (newstudent != null && ModelState.IsValid)
            {
                unit.StudentRepository.Add(newstudent);
                unit.save();
                string url = Url.Link("StudentRoute", new { id = newstudent.St_Id });
                return Created(url, newstudent);
            }
            return BadRequest();

        }


       
    }
}
