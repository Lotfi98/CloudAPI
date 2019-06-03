using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DBInitializer
{
  public static void Initialize(LibraryContext context)
        {
            //Create the db if not yet exists
            context.Database.EnsureCreated();

            //Are there already books present ?
            if (!context.Students.Any())
            {


                var student1 = new Students()
                {
                 Id = 1,
                Name = "Lotfi",
                surName = "El Ouaamari",
                Age = 22,
                Study = "Electronica-ICT"
                };

                var student2 = new Students()
                {
                Id = 2,
                Name = "Jan",
                surName = "De Muleder",
                Age = 19,
                Study = "Logistiek"
                };

                context.Students.Add(student1);
                context.Students.Add(student2);
                context.SaveChanges();
            }
        }
}