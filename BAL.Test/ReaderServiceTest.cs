using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Extras.Moq;
using AutoMapper;
using DAL.Data;
using DAL.Entitys.Dto;
using DAL.Entitys.Model;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using DataServices.MappingService;
using DataServices.ReaderServices;

namespace BAL.Test
{
    [TestFixture]
    class ReaderServiceTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GetLibraryCardTest()
        {

        }

        [Test]
        public void GetTest()
        {
            var data = new List<PeopleModel>
            {
                new PeopleModel { Id = 1, Name = "BBB", Books = new List<BookModel>() },
                new PeopleModel { Id = 2, Name = "ZZZ", Books = new List<BookModel>()  },
                new PeopleModel { Id = 3, Name = "AAA", Books = new List<BookModel>() },
            }.AsQueryable();

            using var mock = AutoMock.GetLoose();
            var mockSet = new Mock<DbSet<PeopleModel>>();
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = mock.Mock<LibraryDbContext>();
            mockContext.Setup(c => c.Set<PeopleModel>()).Returns(mockSet.Object);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            var service = new ReaderService(mockContext.Object, mapper, null);
            var actualData = service.Get();
            var expectedData = data.ToList();

            Assert.AreEqual(expectedData.Count, actualData.Count());
            for (int i = 0; i < actualData.Count(); i++)
            {
                Assert.AreEqual(expectedData.ElementAt(i).Id, actualData.ElementAt(i).Id, "different Id");
                Assert.AreEqual(expectedData.ElementAt(i).Name, actualData.ElementAt(i).Name, "different Name");
                Assert.AreEqual(expectedData.ElementAt(i).Books, actualData.ElementAt(i).Books, "different Books");
            }
        }

        [Test]
        public void DeleteTrueTest()
        {
            var data = new List<PeopleModel>
            {
                new PeopleModel { Id = 1, Name = "BBB", MidleName = "AXZ", Books = new List<BookModel>() },
                new PeopleModel { Id = 2, Name = "ZZZ", MidleName = "AXZ", Books = new List<BookModel>()  },
                new PeopleModel { Id = 3, Name = "AAA", MidleName = "AXZ", Books = new List<BookModel>() },
            }.AsQueryable();

            using var mock = AutoMock.GetLoose();
            var mockSet = new Mock<DbSet<PeopleModel>>();
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = mock.Mock<LibraryDbContext>();
            mockContext.Setup(c => c.Set<PeopleModel>()).Returns(mockSet.Object);
            mockContext.Setup(c => c.Peoples).Returns(mockSet.Object);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            var service = new ReaderService(mockContext.Object, mapper, null);
            var actualData = service.Remove(2);

            Assert.IsTrue(actualData);
        }

        [Test]
        public void DeleteFalseTest()
        {
            var data = new List<PeopleModel>
            {
                new PeopleModel { Id = 1, Name = "BBB", Books = new List<BookModel>() },
                new PeopleModel { Id = 2, Name = "ZZZ", Books = new List<BookModel>()  },
                new PeopleModel { Id = 3, Name = "AAA", Books = new List<BookModel>() },
            }.AsQueryable();

            using var mock = AutoMock.GetLoose();
            var mockSet = new Mock<DbSet<PeopleModel>>();
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = mock.Mock<LibraryDbContext>();
            mockContext.Setup(c => c.Set<PeopleModel>()).Returns(mockSet.Object);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            var service = new ReaderService(mockContext.Object, mapper, null);
            var actualData = service.Remove(5);

            Assert.IsFalse(actualData);
        }

        [Test]
        public void AddTest()
        {
            var data = new List<PeopleModel>
            {
                new PeopleModel { Id = 1, Name = "BBB", Books = new List<BookModel>() },
                new PeopleModel { Id = 2, Name = "ZZZ", Books = new List<BookModel>()  },
                new PeopleModel { Id = 3, Name = "AAA", Books = new List<BookModel>() },
            }.AsQueryable();

            using var mock = AutoMock.GetLoose();
            var mockSet = new Mock<DbSet<PeopleModel>>();
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = mock.Mock<LibraryDbContext>();
            mockContext.Setup(c => c.Set<PeopleModel>()).Returns(mockSet.Object);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            var addReader = new ReaderDto { Name = "ADD", Books = new List<BookBaseDto>() };

            var service = new ReaderService(mockContext.Object, mapper, null);
            var actualAnswer = service.Add(addReader);

            Assert.IsTrue(actualAnswer);
        }

        [Test]
        public void UpdateTrueTest()
        {
            using var mock = AutoMock.GetLoose();
            var mockContext = mock.Mock<LibraryDbContext>();

            var addGenry = new PeopleModel
            {
                Id = 3,
                Name = "AAA",
                Books = new List<BookModel>() { new BookModel() { Id = 1, Title = "Add" }
                    }
            };

            mockContext.Object.Update(addGenry);

            mockContext.Verify(c => c.Update(addGenry), Times.Exactly(1));

        }

        [Test]
        public void UpdateFalseTest()
        {
            var data = new List<PeopleModel>
            {
                new PeopleModel { Id = 1, Name = "BBB", Books = new List<BookModel>() },
                new PeopleModel { Id = 2, Name = "ZZZ", Books = new List<BookModel>()  },
                new PeopleModel { Id = 3, Name = "AAA", Books = new List<BookModel>() },
            }.AsQueryable();

            using var mock = AutoMock.GetLoose();
            var mockSet = new Mock<DbSet<PeopleModel>>();
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = mock.Mock<LibraryDbContext>();
            mockContext.Setup(c => c.Set<PeopleModel>()).Returns(mockSet.Object);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            ReaderDto addReader = new() { Name = "BBB", Books = new List<BookBaseDto>() };

            var service = new ReaderService(mockContext.Object, mapper, null);
            var actualAnswer = service.Update(addReader);

            Assert.IsFalse(actualAnswer);
        }

        [Test]
        public void UpdateNUllFalseTest()
        {
            var data = new List<PeopleModel>
            {
                new PeopleModel { Id = 1, Name = "BBB", Books = new List<BookModel>() },
                new PeopleModel { Id = 2, Name = "ZZZ", Books = new List<BookModel>()  },
                new PeopleModel { Id = 3, Name = "AAA", Books = new List<BookModel>() },
            }.AsQueryable();

            using var mock = AutoMock.GetLoose();
            var mockSet = new Mock<DbSet<PeopleModel>>();
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<PeopleModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            var mockContext = mock.Mock<LibraryDbContext>();
            mockContext.Setup(c => c.Set<PeopleModel>()).Returns(mockSet.Object);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            ReaderDto addReader = null;

            var service = new ReaderService(mockContext.Object, mapper, null);
            var actualAnswer = service.Update(addReader);

            Assert.IsFalse(actualAnswer);
        }
    }
}
