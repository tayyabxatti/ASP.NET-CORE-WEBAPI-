using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Clv.Models.ApiModelsDto.QuizDto
{
    public class QuizListDto
    {
        [Key]
        public int QuizID { get; set; }
        public string Title { get; set; }
        public string Decription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartTime { get; set; }
        public int TotalMarks { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; }
        public int Pod_ID { get; set; }

        ////////// Question 


        public int QuizQuestionsID { get; set; }
        [ForeignKey("Quiz_ID")]
        public int Quiz_ID { get; set; }
        public string QuestionType { get; set; }
        public string Question { get; set; }

        ///// <summary>
        /////  option detail
        ///// </summary>
        public int QuizQuestionOptionID { get; set; }
        //[ForeignKey("QuizQuestions_ID")]
        public int QuizQuestions_ID { get; set; }
        public bool IsCorrectOption { get; set; }
        public string Option { get; set; }
    }
}
