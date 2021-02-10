using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Institutions;
using WebApplication.DbStuff.Model.Job;
using WebApplication.DbStuff.Model.Questionnaire;
using WebApplication.DbStuff.Model.Calendar;
using WebApplication.DbStuff.Model.Hotels;
using WebApplication.DbStuff.Model.Hospital;
using WebApplication.DbStuff.Model.Firefighters;

namespace WebApplication.DbStuff.Model
{
    public class SpecialUser : BaseModel
    {
        [Required]
        [MaxLength(50)]
        public virtual string Name { get; set; }

        public virtual WebRole WebRole { get; set; }

        public virtual string Password { get; set; }

        public virtual int Age { get; set; }

        public virtual int Height { get; set; }

        public virtual SupportLang SupportLang { get; set; }

        public virtual List<SpecialUserAddress> Adresses { get; set; }

        public virtual List<MazeUser> MyMazes { get; set; }

        public virtual List<QuestionnaireRegistration> QuestionnaireRegistrations { get; set; }

        public virtual List<SpecialUserTag> Tags { get; set; }
        
        public virtual List<OrganizationPositionCandidate> Vacancies { get; set; }

        public virtual List<Order> Orders { get; set; }

        public virtual List<SpecialUserCalendarEvent> SeenCalendarEvents { get; set; }

        public virtual DateTime DateBlocked { get; set; }

        public virtual DateTime EndBlocked { get; set; }

        public virtual Hotel HotelUserIsHelper { get; set; }

        public virtual MedicalRecord MedicalRecord { get; set; }
        
        public virtual OrganizationPosition CurrentWork { get; set; }

        public virtual long? PartnerId { get; set; }

        public virtual List<Notification> Notifications { get; set; }

        public virtual List<Marriage> MarriagesForHusband { get; set; }

        public virtual List<SpecialUserFireInspection> PerformedFireInspectionsBuilding { get; set; }

        public virtual List<Marriage> MarriagesForWife { get; set; }
    }

    public enum WebRole
    {
        User = 1,
        Admin = 2,
        AdminHelp = 3
    }

    public enum SupportLang
    {
        Ru = 1,
        En = 2
    }
}
