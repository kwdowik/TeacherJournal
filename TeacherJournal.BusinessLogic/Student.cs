using System;
using System.Collections.Generic;

namespace TeacherJournal.BusinessLogic
{
    public class Student : IModelObject
    {
        public Student() {}
        public int ID {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public List<Mark> Marks {get; set;}
    }
}
