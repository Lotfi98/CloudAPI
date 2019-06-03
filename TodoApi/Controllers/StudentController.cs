using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

    [Route("api/students")]
    public class StudentController : Controller
    {
        static List<Students> list = new List<Students>();

        static StudentController()
        {
            list.Add(new Students()
            {
                Id = 1,
                Name = "Lotfi",
                surName = "El Ouaamari",
                Age = 21,
                Study = "Electronica-ICT"
            });

            list.Add(new Students()
            {
                Id = 2,
                Name = "Jan",
                surName = "De Muleder",
                Age = 19,
                Study = "Logistiek"
            });
        }

        [HttpGet]
        public List<Students> GetStudents()
        {
            return list;
        }


        [Route("{id}")]
        [HttpGet]
        public ActionResult<Students> GetStudents(int id)
        {
            if (list.Exists(book => book.Id == id))
                return list.First(book => book.Id == id);
            else
                return NotFound();
        }



        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            if (list.Exists(student => student.Id == id))
            {
                var student = list.First(b => b.Id == id);
                list.Remove(student);
                return NoContent();
            }
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult<Students> AddStudent([FromBody]Students student)
        {
            //ken er ID aan toe
            var max = list.Max(b => b.Id);
            student.Id = max + 1;
            list.Add(student);
            //return student id
            return Created("", student);
        }
    }