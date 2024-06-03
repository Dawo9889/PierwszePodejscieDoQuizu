﻿using System.ComponentModel.DataAnnotations;

namespace QuizSolution.Model
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string? Content { get; set; }
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}