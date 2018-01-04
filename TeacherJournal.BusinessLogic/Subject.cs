using System;
using System.Collections.Generic;

namespace TeacherJournal.BusinessLogic
{
    public class Subject
    {
        public Subject() {}
        public int SubjectID { get; set; }
        public string Name { get; set; }
        public List<Mark> Marks { get; set; }
    }
}