using System;
using System.Collections.Generic;

namespace TeacherJournal.BusinessLogic
{
    public class Subject
    {
        public Subject(int id, string name, List<Mark> marks)
        {
            Id = id;
            Name = name;
            Marks = marks != null ? marks : new List<Mark>();
        }
        private Subject() {}
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Mark> Marks { get; private set; }
    }
}