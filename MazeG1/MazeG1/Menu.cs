using System;
using System.Collections.Generic;
using System.Text;

namespace MazeG1
{
    class Menu
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Menu GetMenu()
        {
            var UserList = new UserList();
            var QuestionnarieList = new QuestionnarieList();
            var QuestionList = new QuestionList();


            //UserList.GetUser();
            //QuestionnarieList.GetQuestionnarie();
            QuestionList.GetQuestion();
            

            return null;
        }
    }
}
