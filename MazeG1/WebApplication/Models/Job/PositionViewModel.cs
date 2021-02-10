using System.Collections.Generic;
using System.ComponentModel;

namespace WebApplication.Models
{
    public class PositionViewModel
    {
        public long Id { get; set; }
        [DisplayName("Должность:")]
        public string Name { get; set; }
        public List<OrganizationPositionViewModel> Organizations { get; set; }
        public double Salary { get; set; }
    }
}