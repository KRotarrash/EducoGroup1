using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class AnswerViewModel
    {
        public long Id { get; set; }
        public string Text { get; set; }

        public bool IsChecked { get; set; }
    }
}
