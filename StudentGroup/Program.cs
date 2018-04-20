using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new StudentGroupModelContainer())
            {
                var transaction = context.Database.BeginTransaction();
                try
                {
                    Group group = new Group { Id = 1, Name = "as", StudentId = "1" };
                    Student student = new Student { Id = 1, Name = "zxc" };

                    context.GroupSet.Add(group);
                    context.StudentSet.Add(student);
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
