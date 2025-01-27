﻿namespace DnaFragment.DnaFragmentControllers
{   
    using System.Collections.Generic;
    using System.Linq;       
    using DnaFragment.Data.Models;
    using DnaFragment.Models.Questions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using DnaFragment.Infrastructure;   
    using DnaFragment.Services.Questions;
    using DnaFragment.Services.Administrators;

    public class QuestionsController : Controller
    {
          
        private readonly IQuestionsService questionsService;     
        private readonly IAdministratorService adminService;     

        public QuestionsController(IQuestionsService questionsService, IAdministratorService adminService)
        {                     
            this.questionsService = questionsService;
            this.adminService = adminService;
        }

        [Authorize]
        public IActionResult All(byte sort)
        {
            var userId = User.GetId();
            bool isAdmin = User.IsAdmin();

            var questions = questionsService.AllQuestions(sort,userId, isAdmin);
            var questionModel = new AddQuestionModel { Description = "ask a question ...", Questions = questions };
            return View(questionModel);
        }
        

        [Authorize]
        [HttpPost]
        public IActionResult All(byte sort,AddQuestionModel questionModel)
        {
            var userId = this.User.GetId();
            bool isAdmin = User.IsAdmin();
            var lrUserId = adminService.AdministratorId(User.GetId());
            if (lrUserId != null)
            {               
                return Redirect("/Identity/Account/Login");
            }

            if (adminService.UserIsRegister(userId))
            {
                return Unauthorized();
            }            

            if (!ModelState.IsValid)
            {
                return View(questionModel);
            }

            //var questions = questionsService.AllQuestions(userId, isAdmin);

            questionsService.AddQuestion(userId, questionModel.Description);

            return Redirect("/Questions/All");

        }       

        [Authorize]
        public IActionResult Delete(string questId)
        {
            questionsService.DeleteQuest(questId);

            return this.Redirect("/Questions/All");
        }

        [Authorize]
        public IActionResult AutomaticDelete(string questId)
        {
            questionsService.AutomaticDeleteQuest(questId);
            ViewBag.message = "sucsses";
            return this.Redirect("/Questions/All");
        }      
    }
}
