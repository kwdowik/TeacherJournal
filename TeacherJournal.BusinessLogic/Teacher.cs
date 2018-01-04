using System.Collections.Generic;

namespace TeacherJournal.BusinessLogic
{
    public class Teacher
    {
        public Teacher(int id, string login, string password, string subject)
        {
            TeacherId = id;
            Login = login;
            Password = password;
            Subject = subject;
        }
        private Teacher() {}
        public int TeacherId {get; set;}
        public string Login {get; set;}
        public string Password {get; set;}
        public string Subject {get; set;}
    }
}