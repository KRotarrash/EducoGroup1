using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model.Questionnaire;


namespace WebApplication.DbStuff.Repository.Questionnaire
{
    public class QuestionAnswerRepository : BaseRepository<QuestionAnswer>, IQuestionAnswerRepository
    {
        public QuestionAnswerRepository(WebContext webContext) : base(webContext) { }

    }
}
