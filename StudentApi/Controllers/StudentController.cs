using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace StudentApi.Controllers
{
    [Route("api/Student")]
    public class StudentController : ControllerBase
    {
        private readonly StudentContext _Context;
        public StudentController(StudentContext context)
        {
            _Context = context;
            if (_Context.StudentItems.Count() == 0)
            {
                _Context.StudentItems.Add(new StudentItems { FullName = "Item1" });
                _Context.SaveChanges();
            }
        }
        [HttpGet]
        public IEnumerable<StudentItems> GetAll()
        {
            return _Context.StudentItems.ToList(); }
        public IActionResult GetById(long id)
        {
            var item = _Context.StudentItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        public IActionResult Create([FromBody] StudentItems item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _Context.StudentItems.Add(item);
            _Context.SaveChanges();
            return CreatedAtRoute("GetStudent", new { id = item.Id }, item);
        }
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] StudentItems item)
        {
            if(item == null || item.Id != id)
            {
                return BadRequest();
            }
            var Student = _Context.StudentItems.FirstOrDefault(t => t.Id == id);
            if(Student == null)
            {
                return NotFound();
            }
            Student.IsComplete = item.IsComplete;
            Student.FullName = item.FullName;
        return new NoContentResult();
        }

        public StudentContext Get_Context()
        {
            return _Context;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id, StudentContext _Context)
        {
            var Student = _Context.StudentItems.FirstOrDefault(t => t.Id == id);
            if(Student == null)
            {
                return NotFound();
            }

            _Context.StudentItems.Remove(Student);
            _Context.SaveChanges();
            return new NoContentResult();
        }

    }
}
