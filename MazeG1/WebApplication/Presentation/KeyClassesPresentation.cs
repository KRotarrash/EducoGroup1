using AutoMapper.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Models.KeyClasses;
using WebApplication.Sevrice.Helper;

namespace WebApplication.Presentation
{
    public class KeyClassesPresentation
    {
        private IKeyClassesPresentationHelper _keyClassesPresentationHelper;

        public KeyClassesPresentation(IKeyClassesPresentationHelper keyClassesPresentationHelper)
        {
            _keyClassesPresentationHelper = keyClassesPresentationHelper;
        }

        public KeyClassViewModel GetKeyClassViewModel()
        {
            var model = _keyClassesPresentationHelper.HelperGetKeyClassViewModel();
            return model;
        }
    }
}
