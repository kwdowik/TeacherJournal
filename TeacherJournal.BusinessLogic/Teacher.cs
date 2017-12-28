using System.Collections.Generic;

namespace TeacherJournal.BusinessLogic
{
    public class Teacher
    {
        public Teacher(int id, string login, string password, string subject)
        {
            Id = id;
            Login = login;
            Password = password;
            Subject = subject;
        }
        private Teacher() {}
        public int Id {get; private set;}
        public string Login {get; private set;}
        public string Password {get; private set;}
        public string Subject {get; private set;}
    }
}