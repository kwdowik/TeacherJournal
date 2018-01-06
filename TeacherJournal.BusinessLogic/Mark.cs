using System;
using System.Collections.Generic;

namespace TeacherJournal.BusinessLogic
{
    public class Mark
    {
        public Mark() {}
        public int MarkID { get; set; }
        public int StudentID {get; set;}
        public int SubjectID {get; set;}
        public int? Grade { get; set; }

        public Subject Subject {get; set;}
        public Student Student {get; set;}        

    }
}