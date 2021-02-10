using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Repository;
using WebApplication.Models;
using WebApplication.Presentation;
using WebApplication.Service;
using WebApplication.DbStuff.Repository.IRepository.IJob;

namespace WebApplicationTest.Presentation
{
    public class UserPresentationTest
    {
        private UserPresentationPublic _userPresentation;
        private Mock<ISpecialUserRepository> _userRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void SetUp()
        {
            _userRepositoryMock = new Mock<ISpecialUserRepository>();
            var userServiceMock = new Mock<IUserService>();
            var adressRepositoryMock = new Mock<IAdressRepository>();
            var tagRepositoryMock = new Mock<ITagRepository>();
            var specialUserTagRepositoryMock = new Mock<ISpecialUserTagRepository>();
            var fileProfileService = new Mock<FileProfileService>();
            var openXmlProfileService = new Mock<OpenXmlProfileService>();
            var hostingEnvironment = new Mock<IWebHostEnvironment>();
            var organizationPositionRepositoryMock = new Mock<IOrganizationPositionRepository>();
            var jobPresentation = new Mock<JobPresentation>();
            var specialUserAddressRepositoryMock = new Mock<ISpecialUserAddressRepository>();
            var addressPresentationMock = new Mock<AddressPresentation>();
            _mapperMock = new Mock<IMapper>();
            var marriageRepositoryMock = new Mock<IMarriageRepository>();
            var notificationRepositoryMock = new Mock<INotificationRepository>();

            _userPresentation = new UserPresentationPublic(_userRepositoryMock.Object,
                userServiceMock.Object,
                adressRepositoryMock.Object,
                _mapperMock.Object,
                tagRepositoryMock.Object,
                specialUserTagRepositoryMock.Object,
                fileProfileService.Object,
                openXmlProfileService.Object,
                hostingEnvironment.Object,
                organizationPositionRepositoryMock.Object,
                jobPresentation.Object,
                specialUserAddressRepositoryMock.Object,
                addressPresentationMock.Object,
                marriageRepositoryMock.Object,
                notificationRepositoryMock.Object
                );
        }

        [TestCaseSource("SortTestCases")]
        public void Sort(SortColumn sortColumn, SortDirection sortDirection)
        {
            var users = new List<SpecialUser>();
            users.Add(GenerateUser(0, 1, 3, 2));
            users.Add(GenerateUser(3, 2, 1, 0));
            users.Add(GenerateUser(2, 0, 2, 1));
            users.Add(GenerateUser(1, 3, 0, 3));

            var sortedUser = _userPresentation
                .SortPublic(users.AsQueryable(), sortColumn, sortDirection)
                .ToList();

            for (int i = 0; i < users.Count; i++)
            {
                var expected = sortDirection == SortDirection.ASC
                    ? i
                    : users.Count - i - 1;
                object actual = 1;
                switch (sortColumn)
                {
                    case SortColumn.Id:
                        actual = sortedUser[i].Id;
                        break;
                    case SortColumn.Name:
                        break;
                    case SortColumn.Age:
                        actual = sortedUser[i].Age;
                        break;
                    case SortColumn.Height:
                        actual = sortedUser[i].Height;
                        break;
                    case SortColumn.AddressCount:
                        actual = sortedUser[i].Adresses.Count();
                        break;
                    case SortColumn.Role:
                        break;
                }

                Assert.AreEqual(expected, actual);
            }
        }

        [Test]
        public void GetUserViewModels()
        {
            var user = new List<SpecialUser>();
            _userRepositoryMock.Setup(x => x.GetAll()).Returns(user.AsQueryable());

            var userViewModel = new List<UserViewModel>();
            _mapperMock.Setup(x => x
                .Map<List<UserViewModel>>(It.IsAny<List<SpecialUser>>()))
                .Returns(userViewModel);

            _userPresentation.GetUserViewModels();

            _userRepositoryMock.Verify(x =>
                x.GetAll(),
                Times.Once);
            _mapperMock.Verify(x =>
                x.Map<List<UserViewModel>>(It.IsAny<List<SpecialUser>>()),
                Times.Once);
        }

        private SpecialUser GenerateUser(long id, int age, int adressCount, int height)
        {
            var mock = new Mock<SpecialUser>();
            mock.Setup(x => x.Id).Returns(id);
            mock.Setup(x => x.Age).Returns(age);
            mock.Setup(x => x.Height).Returns(height);

            var adress = new List<SpecialUserAddress>();
            for (int i = 0; i < adressCount; i++)
            {
                adress.Add(new SpecialUserAddress());
            }

            mock.Setup(x => x.Adresses).Returns(adress);

            return mock.Object;
        }

        public static IEnumerable<TestCaseData> SortTestCases
        {
            get
            {
                var sortColumns = new List<SortColumn>() {
                    SortColumn.Id, SortColumn.Age,
                    SortColumn.AddressCount,
                    SortColumn.Height
                };

                foreach (var sortColumn in sortColumns)
                {
                    yield return new TestCaseData(sortColumn, SortDirection.ASC);
                    yield return new TestCaseData(sortColumn, SortDirection.DESC);
                }
            }
        }

        private class UserPresentationPublic : UserPresentation
        {
            public UserPresentationPublic(
                ISpecialUserRepository specialUserRepository,
                IUserService userService,
                IAdressRepository adressService,
                IMapper mapper,
                ITagRepository tagRepository,
                ISpecialUserTagRepository specialUserTagRepository,
                FileProfileService fileProfileService,
                OpenXmlProfileService openXmlProfileService,
                IWebHostEnvironment hostingEnvironment,
                IOrganizationPositionRepository organizationPositionRepository,
                JobPresentation jobPresentation,
                ISpecialUserAddressRepository specialUserAddressRepository,
                AddressPresentation addressPresentation,
                IMarriageRepository marriageRepository,
                INotificationRepository notificationRepository)
                : base(specialUserRepository, userService, adressService, mapper, tagRepository, specialUserTagRepository, fileProfileService, openXmlProfileService,
                       hostingEnvironment, organizationPositionRepository, jobPresentation, specialUserAddressRepository, addressPresentation, marriageRepository, notificationRepository)
            { }

            public IEnumerable<SpecialUser> SortPublic(
                IQueryable<SpecialUser> users,
                SortColumn sortColumn, SortDirection sortDirection)
            {
                return Sort(users, sortColumn, sortDirection);
            }
        }
    }
}
