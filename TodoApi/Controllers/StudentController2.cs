using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

[Route("api/students")]

public class StudentController2: Controller
{
    
    private readonly LibraryContext context;

    public StudentController2(LibraryContext context)
    {
        this.context = context;
    }
    
[HttpGet]
public List<Students> GetAllStudents()
{
    return context.Students.ToList();
}

[HttpPost]
public IActionResult CreateStudent([FromBody] Students newStudent)
{
context.Students.Add(newStudent);
context.SaveChanges();

return Created("", newStudent);
}

//ophalen student dmv ID
[Route("{id}")]
[HttpGet]
public IActionResult GetStudents(int id)
{
    var student = context.Students.Find(id);
    if (student == null)
    {
        return NotFound();
    }
    return Ok(student);
}
//student Verwijderen
  [Route("{id}")]
  [HttpDelete]
 public IActionResult DeleteStudent(int id)
    {
            var DelStudent = context.Students.Find(id);
            if (DelStudent == null)
                return NotFound();

            context.Students.Remove(DelStudent);
            context.SaveChanges();             // DO NOT FORGET !!!
            return NoContent();
     }
[HttpPost]
        public ActionResult<Students> AddBook([FromBody]Students student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            //return Student met ID
            return Created("", student);
        }

        [HttpPut]
        public ActionResult<Students> UpdateBook([FromBody]Students student)
        {
            //Boek updaten
            context.Students.Update(student);
            context.SaveChanges();
            //return boek met ID
            return Created("", student);
        }
        [HttpGet]
        public List<Students> FilterStudents(string study, string name, string sort, int? page, int length = 2, string dir = "asc")
        {
            IQueryable<Students> query = context.Students;

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(d => d.Name == name);

            if (!string.IsNullOrWhiteSpace(study))
                query = query.Where(d => d.Study == study);           
            if (page.HasValue){
                query = query.Skip(page.Value * length);             
            }
            if(!string.IsNullOrWhiteSpace(sort))
            {
                switch (sort)
                {
                    case "name":
                        if (dir == "asc")
                        query = query.OrderBy(d => d.Name);
                        else if (dir == "desc")
                        query = query.OrderByDescending(d => d.Name);
                        break;

                     case "study":
                     if (dir == "asc")
                        query = query.OrderBy(d => d.Study);
                        else if (dir == "desc")
                        query = query.OrderByDescending(d => d.Study);
                        break;
                }
            }
            query = query.Take(length); 
            return query.ToList();  
        }
        

}
