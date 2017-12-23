using System.Collections.Generic;

namespace TeacherJournal.BusinessLogic
{
    public class Teacher
    {
        public Teacher(int id, string login, string password, List<string> subjects)
        {
            Id = id;
            Login = login;
            Password = password;
            Subjects = subjects != null ? subjects : new List<string>();
        }
        public int Id {get; private set;}
        public string Login {get; private set;}
        public string Password {get; private set;}
        public List<string> Subjects {get; private set;}
    }
}