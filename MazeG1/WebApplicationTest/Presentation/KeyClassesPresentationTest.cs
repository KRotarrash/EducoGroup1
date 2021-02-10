using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WebApplication.Models;
using WebApplication.Models.KeyClasses;
using WebApplication.Presentation;
using WebApplication.Sevrice.Helper;

namespace WebApplicationTest.Presentation
{
    public class KeyClassesPresentationTest
    {
        private KeyClassesPresentation _keyClassesPresentation;
        private Mock<IKeyClassesPresentationHelper> _keyClassesPresentationHelperMock;

        [SetUp]
        public void SetUp()
        {
            _keyClassesPresentationHelperMock = new Mock<IKeyClassesPresentationHelper>();
            _keyClassesPresentation = new KeyClassesPresentationPublic(_keyClassesPresentationHelperMock.Object);
        }
        
        [Test]
        public void GetKeyClassViewModel_Verify()
        {
            var model = new KeyClassViewModel();

            _keyClassesPresentationHelperMock
                .Setup(x => x.HelperGetKeyClassViewModel())
                .Returns(model);

            _keyClassesPresentation.GetKeyClassViewModel();

            _keyClassesPresentationHelperMock.Verify(x =>
                x.HelperGetKeyClassViewModel(),
                Times.Once
                );
        }

        private class KeyClassesPresentationPublic : KeyClassesPresentation
        {
            public KeyClassesPresentationPublic(
                IKeyClassesPresentationHelper keyClassesPresentationHelper) 
                : base(keyClassesPresentationHelper)
            {
            }
        }

    }


}
