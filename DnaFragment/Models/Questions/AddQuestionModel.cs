﻿namespace DnaFragment.Models.Questions
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.DefaultConstants;

    public class AddQuestionModel
    {
        [Required]
        [StringLength(
            DefaultDescriptionMaxLength, ErrorMessage = "The field Description must be a string with a minimum length of {2}.",
            MinimumLength = DefaultDescriptionMinLength)]          
        public string Description { get; set; }

        public List<QuestionListingViewModel> Questions { get; set; } = new List<QuestionListingViewModel>();

    }
}
