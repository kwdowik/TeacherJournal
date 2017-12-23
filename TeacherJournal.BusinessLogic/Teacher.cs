using System.Collections.Generic;

namespace TeacherJournal.BusinessLogic
{
    public class Teacher
    {
        public Teacher(int id, string firstName, string lastName, List<string> subjects)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Subjects = subjects != null ? subjects : new List<string>();
        }
        public int Id {get; private set;}
        public string FirstName {get; private set;}
        public string LastName {get; private set;}
        public List<string> Subjects {get; private set;}
    }
}