using System;
using System.Collections.Generic;
using DAL.Data;
using DAL.Entitys.Dto;
using DAL.Entitys.Model;
using Service.GynericRepositorys;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Autofac.Extras.Moq;
using System.Linq;
using Service.GenryServices;
using AutoMapper;
using Service.MappingService;

namespace BAL.Test
{
    [TestFixture]
    class RepositoryTest
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void GetTest()
        {
            var data = new List<GenryModel>
            {
                new GenryModel { Id = 1, Name = "BBB", Books = new List<BookModel>() },
                new GenryModel { Id = 2, Name = "ZZZ", Books = new List<BookModel>()  },
                new GenryModel { Id = 3, Name = "AAA", Books = new List<BookModel>() },
            }.AsQueryable();

            using (var mock = AutoMock.GetLoose())
            {
                var mockSet = new Mock<DbSet<GenryModel>>();
                mockSet.As<IQueryable<GenryModel>>().Setup(m => m.Provider).Returns(data.Provider);
                mockSet.As<IQueryable<GenryModel>>().Setup(m => m.Expression).Returns(data.Expression);
                mockSet.As<IQueryable<GenryModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
                mockSet.As<IQueryable<GenryModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


                var mockContext = mock.Mock<LibraryDbContext>();
                mockContext.Setup(c => c.Set<GenryModel>()).Returns(mockSet.Object);

                var mapperConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapping());
                });
                IMapper mapper = mapperConfig.CreateMapper();

                var service = new GenryService(mockContext.Object, mapper, null);
                var actualData = service.Get();
                var expectedData = data.ToList();

                Assert.AreEqual(expectedData.Count(), actualData.Count());
                for (int i = 0; i < actualData.Count(); i++)
                {
                    Assert.AreEqual(expectedData.ElementAt(i).Id, actualData.ElementAt(i).Id, "different Id");
                    Assert.AreEqual(expectedData.ElementAt(i).Name, actualData.ElementAt(i).Name, "different Name");
                    Assert.AreEqual(expectedData.ElementAt(i).Books, actualData.ElementAt(i).Books, "different Books");
                }
            }
        }

        [Test]
        public void DeeleteTest()
        {
            var data = new List<GenryModel>
            {
                new GenryModel { Id = 1, Name = "BBB", Books = new List<BookModel>() },
                new GenryModel { Id = 2, Name = "ZZZ", Books = new List<BookModel>()  },
                new GenryModel { Id = 3, Name = "AAA", Books = new List<BookModel>() },
            }.AsQueryable();

            using (var mock = AutoMock.GetLoose())
            {
                var mockSet = new Mock<DbSet<GenryModel>>();
                mockSet.As<IQueryable<GenryModel>>().Setup(m => m.Provider).Returns(data.Provider);
                mockSet.As<IQueryable<GenryModel>>().Setup(m => m.Expression).Returns(data.Expression);
                mockSet.As<IQueryable<GenryModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
                mockSet.As<IQueryable<GenryModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


                var mockContext = mock.Mock<LibraryDbContext>();
                mockContext.Setup(c => c.Set<GenryModel>()).Returns(mockSet.Object);

                var mapperConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapping());
                });
                IMapper mapper = mapperConfig.CreateMapper();

                var service = new GenryService(mockContext.Object, mapper, null);
                var actualData = service.Remove(1);

                Assert.IsTrue(actualData);
            }
        }

        [Test]
        public void AddTest()
        {
            var data = new List<GenryModel>
            {
                new GenryModel { Id = 1, Name = "BBB", Books = new List<BookModel>() },
                new GenryModel { Id = 2, Name = "ZZZ", Books = new List<BookModel>()  },
                new GenryModel { Id = 3, Name = "AAA", Books = new List<BookModel>() },
            }.AsQueryable();

            using (var mock = AutoMock.GetLoose())
            {
                var mockSet = new Mock<DbSet<GenryModel>>();
                mockSet.As<IQueryable<GenryModel>>().Setup(m => m.Provider).Returns(data.Provider);
                mockSet.As<IQueryable<GenryModel>>().Setup(m => m.Expression).Returns(data.Expression);
                mockSet.As<IQueryable<GenryModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
                mockSet.As<IQueryable<GenryModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


                var mockContext = mock.Mock<LibraryDbContext>();
                mockContext.Setup(c => c.Set<GenryModel>()).Returns(mockSet.Object);

                var mapperConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapping());
                });
                IMapper mapper = mapperConfig.CreateMapper();

                var addGenry = new GenryDto { Name = "ADD", Books = new List<BookBaseDto>() };

                var service = new GenryService(mockContext.Object, mapper, null);
                var actualAnswer = service.Add(addGenry);

                Assert.IsTrue(actualAnswer);
            }
        }

        [Test]
        public void UpdateTest()
        {
            var data = new List<GenryModel>
            {
                new GenryModel { Id = 1, Name = "BBB", Books = new List<BookModel>() },
                new GenryModel { Id = 2, Name = "ZZZ", Books = new List<BookModel>()  },
                new GenryModel { Id = 3, Name = "AAA", Books = new List<BookModel>() },
            }.AsQueryable();

            using (var mock = AutoMock.GetLoose())
            {
                var mockSet = new Mock<DbSet<GenryModel>>();
                mockSet.As<IQueryable<GenryModel>>().Setup(m => m.Provider).Returns(data.Provider);
                mockSet.As<IQueryable<GenryModel>>().Setup(m => m.Expression).Returns(data.Expression);
                mockSet.As<IQueryable<GenryModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
                mockSet.As<IQueryable<GenryModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


                var mockContext = mock.Mock<LibraryDbContext>();
                mockContext.Setup(c => c.Set<GenryModel>()).Returns(mockSet.Object);

                var mapperConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapping());
                });
                IMapper mapper = mapperConfig.CreateMapper();

                var addGenry = new GenryDto {
                    Name = "ABC",
                    Books = new List<BookBaseDto>() { new BookBaseDto() { Title = "Add" }
                    } };

                var service = new GenryService(mockContext.Object, mapper, null);
                var actualAnswer = service.Update(addGenry);

                Assert.IsTrue(actualAnswer);
            }

        }
    }
}
