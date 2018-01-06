using System;
using System.Collections.Generic;

namespace TeacherJournal.Core.Models
{
    public class StudentViewModel
    {
        public int ID {get; set;}
        public int SubjectID {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public Dictionary<string, List<int?>> Marks {get; set;}
    }
}