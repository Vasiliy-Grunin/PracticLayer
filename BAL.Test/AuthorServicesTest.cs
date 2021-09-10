using System;
using System.Collections.Generic;
using DAL.Entitys.Model;
using Moq;
using NUnit.Framework;
using System.Linq;
using AutoMapper;
using DAL.Data;
using Autofac.Extras.Moq;
using Microsoft.EntityFrameworkCore;
using Service.MappingService;
using Service.AuthorServices;

namespace BAL.Test
{
    [TestFixture]
    public class AuthorServicesTest
    {
        [SetUp]
        public void Setup()
        {
        }


        [TestCase()]
        [Test]
        public void DeeleteTest()
        {
            var data = new List<AuthorModel>
            {
                new AuthorModel { Id = 1, Name = "BBB", Books = new List<BookModel>()
                { new BookModel() { Id = 1, Title = "fg", Genre = new List<GenryModel>(),
                    Author = new AuthorModel(), Master = new PeopleModel() } } },
                new AuthorModel { Id = 2, Name = "ZZZ", Books = new List<BookModel>()  },
                new AuthorModel { Id = 3, Name = "AAA", Books = new List<BookModel>() },
            }.AsQueryable();

            using (var mock = AutoMock.GetLoose())
            {
                var mockSet = new Mock<DbSet<AuthorModel>>();
                mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.Provider).Returns(data.Provider);
                mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.Expression).Returns(data.Expression);
                mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
                mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


                var mockContext = mock.Mock<LibraryDbContext>();
                mockContext.Setup(c => c.Set<AuthorModel>()).Returns(mockSet.Object);

                var mapperConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapping());
                });
                IMapper mapper = mapperConfig.CreateMapper();

                var service = new AuthorService(mockContext.Object, mapper, null);
                var deleteResult = service.Remove(-1);

                Assert.IsFalse(deleteResult);
            }
        }
    }
}
