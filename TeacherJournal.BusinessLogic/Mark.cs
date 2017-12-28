using System;
using System.Collections.Generic;

namespace TeacherJournal.BusinessLogic
{
    public class Mark
    {

        public Mark(int id, int value)
        {
            Id = id;
            Value = value;

        }

        private Mark() {}
        public int Id { get; private set; }
        public int Value { get; private set; }

    }
}