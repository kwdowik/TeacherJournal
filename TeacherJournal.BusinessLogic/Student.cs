using System;
using System.Collections.Generic;

namespace TeacherJournal.BusinessLogic
{
    public class Student
    {
        public Student(int id, string firstName, string lastName, Dictionary<string,List<int>> subjects)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Subjects = subjects != null ? subjects : new Dictionary<string, List<int>>();
        }
        public int Id {get; private set;}
        public string FirstName {get; private set;}
        public string LastName {get; private set;}
        public Dictionary<string,List<int>> Subjects {get; private set;}
    }
}
