using System;
using System.Collections.Generic;

namespace TeacherJournal.BusinessLogic
{
    public class Subject : IModelObject
    {
        public Subject() {}
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Mark> Marks { get; set; }
    }
}