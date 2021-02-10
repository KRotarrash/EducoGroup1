using DbFile;
using DbFile.Model;
using MazeCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeG1.RegistrUser
{
    public class UserReg
    {
        public string Registrarion()
        {
            ////Регистрация 
            var repositorty = new HumanRepository();
            var mapperBuilder = new MapperBuilder();
            var mapper = mapperBuilder.GetMapper();
            var userManager = new UserManager();

            //var user = userManager.GetDefaultHuman();
            Human user;
            var savedUser = repositorty.Get();
            if (savedUser != null)
            {
                user = mapper.Map<Human>(savedUser);
            }
            else
            {
                user = userManager.BuildHuman();
                savedUser = mapper.Map<DbHuman>(user);
                repositorty.Save(savedUser);
            }
            return null;
        }
    }
}
