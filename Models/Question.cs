using System;
using System.Collections.Generic;
using System.Linq;

namespace quizApi.Models
{
    public class Question
    {
        public int ID { get; set; }
        public string text { get; set; }
        public string CorrectAnswer { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }

    }
}