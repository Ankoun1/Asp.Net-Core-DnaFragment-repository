﻿namespace DnaFragment.Models.Questions
{
    using System;

    public class QuestionListingViewModel
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public string Name { get; set; }       

        public DateTime CreatedOn { get; init; }

        public string Description { get; set; }

        public string QuestionId { get; init; }

        public string UserId { get; init; }


        public string AnswerDescription { get; set; }
        
        public string AnswerId { get; init; }     

        public bool IsAdministrator { get; set; }

        public bool StopAtomaticDelete { get; set; }

        


    }
}
