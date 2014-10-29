using System;
using System.Collections.Generic;

namespace InheritanceAndPolymorphism
{
    class CoursesExamples
    {
        static void Main()
        {
            List<Student> phpLocalStudents = new List<Student>()
            {
                new Student("Maria"),
                new Student("Bobi"),
                new Student("Dani"),
                new Student("Stefi"),
                new Student("Pesho"),
            };

            List<Student> unityStudents = new List<Student>()
            {
                new Student("Gosho"),
                new Student("Penka"),
                new Student("Ginka"),
                new Student("Drago"),
                new Student("Pesho"),
            };

            List<Course> courses = new List<Course>()
            {
                new LocalCourse("PHP", "Bogdan Borisov", phpLocalStudents, "Optic"),
                new OffsiteCourse("Unity3D", "Todor Petrov", unityStudents, "Sofia"),
            };

            courses.ForEach(c => Console.WriteLine(c + "\r\n"));           

            Console.ReadLine();
        }

    }
}
