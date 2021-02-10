using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Repository;
using WebApplication.Models;
using WebApplication.Service;
using System.Threading.Tasks;
using WebApplication.DbStuff.Repository.IRepository.IJob;
using WebApplication.Models.Users;

namespace WebApplication.Presentation
{
    public class PolicePresentation
    {
        private ISpecialUserRepository _specialUserRepository;
        private IMapper _mapper;

        public PolicePresentation(
            ISpecialUserRepository specialUserRepository,
            IMapper mapper)
        {
            _specialUserRepository = specialUserRepository;
            _mapper = mapper;
        }

        public ManageUsersViewModel GetUserList()
        {
            var model = new ManageUsersViewModel();

            model.Users = _mapper.Map<List<UserViewModel>>(_specialUserRepository.GetAll().ToList());

            return model;
        }

        public void UserBlock(long id, DateTime EndDateBan)
        {
            var user = _specialUserRepository.Get(id);
            user.DateBlocked = DateTime.Now;
            user.EndBlocked = EndDateBan;

            _specialUserRepository.Save(user);
        }

        public void UserUnblock(long id)
        {
            var user = _specialUserRepository.Get(id);

            user.EndBlocked = DateTime.MinValue;
            user.DateBlocked = DateTime.MinValue;

            _specialUserRepository.Save(user);
        }

    }
}
