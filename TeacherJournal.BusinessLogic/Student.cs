using System;
using System.Collections.Generic;

namespace TeacherJournal.BusinessLogic
{
    public class Student
    {
        public Student(int id, string firstName, string lastName, List<Subject> subjects)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Subjects = subjects != null ? subjects : new List<Subject>();
        }

        private Student() {}
        public int Id {get; private set;}
        public string FirstName {get; private set;}
        public string LastName {get; private set;}
        public List<Subject> Subjects {get; private set;}
    }
}
