﻿namespace DnaFragment.Services.Questions
{
    using System.Collections.Generic;
    using DnaFragment.Models.Question;

    public interface IQuestionsService
    {
        void AddQuestion(string userId,string description);

        List<QuestionListingViewModel> AllQuestions(string userId, bool isAdmin);

        string GetUserName(string lrQuestId);

        void DeleteQuest(string questId);

        void AutomaticDeleteQuest(string questId);
       
    }
}