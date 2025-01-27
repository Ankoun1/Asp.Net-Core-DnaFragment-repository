﻿namespace DnaFragment.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.DefaultConstants;

    public class Question
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public DateTime CreatedOn { get; init; } = DateTime.UtcNow;

        [Required]
        [MaxLength(DefaultDescriptionMaxLength)]
        public string Description { get; set; }


        public bool StopAutomaticDelete { get; set; }

        [Required]
        public string UserId { get; init; }
        
        public User User { get; init; }        

        public IEnumerable<Answer> Answers { get; init; } = new List<Answer>();      

    }
}
