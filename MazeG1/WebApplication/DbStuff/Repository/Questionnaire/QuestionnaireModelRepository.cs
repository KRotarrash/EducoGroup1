using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model.Questionnaire;

namespace WebApplication.DbStuff.Repository.Questionnaire
{
    public class QuestionnaireModelRepository : BaseRepository<QuestionnaireModel>, IQuestionnaireModelRepository
    {
        public QuestionnaireModelRepository(WebContext webContext) : base(webContext) { }

    }
}
