using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Models.ApiModelsDto.Covid19_AssesmentQuestionDto
{
    public class Get_Covid19_Assesment_Questions
    {
        public int Covid_Question_ID { get; set; }
        public string Question_Description { get; set; }
    }

    public class Covid19_Assesment_Answers
    {
        public int QuestionId { set; get; }
        public string Question_description { set; get; }
        public int User_id { set; get; }
        public string Check_yes { set; get; }
        //public bool Check_no { set; get; }
        public string Yes_id { set; get; }
        public string No_id { set; get; }
    }
}
