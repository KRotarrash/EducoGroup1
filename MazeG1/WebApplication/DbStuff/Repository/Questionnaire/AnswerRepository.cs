using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model.Questionnaire;

namespace WebApplication.DbStuff.Repository.Questionnaire
{
    public class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(WebContext webContext) : base(webContext) { }
    }
}
