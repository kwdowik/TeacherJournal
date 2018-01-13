using System.Collections.Generic;

namespace TeacherJournal.BusinessLogic
{
    public class Teacher : IModelObject
    {
        public Teacher() {}
        public int ID {get; set;}
        public string Login {get; set;}
        public string Password {get; set;}
    }
}