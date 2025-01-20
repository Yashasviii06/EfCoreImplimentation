using EfCoreImplimentation.Models;
using Microsoft.AspNetCore;

namespace DBFirstConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting DB-First Console App...\n");

           var context = new DbfirstapproachContext();

            // 1. READ - Fetch All Students
            Console.WriteLine("Fetching all students...");
            var veh = context.Vehichledata.ToList();
            foreach (var vh in veh)
            {
                Console.WriteLine($"ID: {vh.VehId}, Name: {vh.VehSerialno}, Age: {vh.VehName}, Grade: {vh.VehPrice}");
            }

            //// 2. CREATE - Add a New Student
            //Console.WriteLine("\nAdding a new student...");
            //var newveh = new Vehichledata { Name = "Charlie", Age = 23, Grade = "A+" };
            //context.newveh.Add(newStudent);
            //context.SaveChanges();
            //Console.WriteLine("New student added!");

            // 3. UPDATE - Update an Existing Student
            Console.WriteLine("\nUpdating the first student...");
            int studentId = 12; // Update karne ke liye specific ID
            var studentToUpdate = context.Vehichledata.FirstOrDefault(s => s.VehId == studentId);

            if (studentToUpdate != null)
            {
                studentToUpdate.VehName = "Updated Name";
                studentToUpdate.VehPrice = 259987766; // Age bhi update karein
                studentToUpdate.VehSerialno = 3434;
                context.SaveChanges();
                Console.WriteLine($"Student with ID {studentId} updated successfully!");
            }
            else
            {
                Console.WriteLine($"Student with ID {studentId} not found.");
            }
            //var firstStudent = context.Vehichledata.FirstOrDefault();
            //if (firstStudent != null)
            //{
            //    firstStudent.VehName = "Updated Name";
            //    context.SaveChanges();
            //    Console.WriteLine("Student updated!");
            //}

            // 4. DELETE - Remove a Student
            //Console.WriteLine("\nDeleting the first student...");
            //var studentToDelete = context.Vehichledata.FirstOrDefault();
            //if (studentToDelete != null)
            //{
            //    context.Students.Remove(studentToDelete);
            //    context.SaveChanges();
            //    Console.WriteLine("Student deleted!");
            //}

            //Console.WriteLine("\nAll operations completed.");
        }
    }
}
