using System;
using System.Collections;
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
using DataServices.BookServices;
using DataServices.MappingService;

namespace BAL.Test
{
    [TestFixture]
    class BookServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetTest()
        {
            var data = new List<BookModel>
            {
                new BookModel { Id = 1, Title = "BBB", Genre = new List<GenryModel>() },
                new BookModel { Id = 2, Title = "ZZZ", Genre = new List<GenryModel>()  },
                new BookModel { Id = 3, Title = "AAA", Genre = new List<GenryModel>() },
            }.AsQueryable();

            using var mock = AutoMock.GetLoose();
            var mockSet = new Mock<DbSet<BookModel>>();
            mockSet.As<IQueryable<BookModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<BookModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<BookModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<BookModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = mock.Mock<LibraryDbContext>();
            mockContext.Setup(c => c.Set<BookModel>()).Returns(mockSet.Object);
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            var service = new BookService(mockContext.Object, mapper, null);
            var actualData = service.Get();
            var expectedData = data.ToList();

            Assert.AreEqual(expectedData.Count, actualData.Count());
            for (int i = 0; i < actualData.Count(); i++)
            {
                Assert.AreEqual(expectedData.ElementAt(i).Id, actualData.ElementAt(i).Id, "different Id");
                Assert.AreEqual(expectedData.ElementAt(i).Title, actualData.ElementAt(i).Title, "different Name");
                Assert.AreEqual(expectedData.ElementAt(i).Genre, actualData.ElementAt(i).Genre, "different Books");
            }
        }

        [Test]
        public void DeleteTrueTest()
        {
            var data = new List<BookModel>
            {
                new BookModel { Id = 1, Title = "BBB", Genre = new List<GenryModel>() },
                new BookModel { Id = 2, Title = "ZZZ", Genre = new List<GenryModel>()  },
                new BookModel { Id = 3, Title = "AAA", Genre = new List<GenryModel>() },
            }.AsQueryable();

            var user = new List<PeopleModel>
            {
                new PeopleModel { Id = 1, Name = "asd", Books = new List<BookModel>() }
            }.AsQueryable();

            using var mock = AutoMock.GetLoose();
            var mockSetBooks = new Mock<DbSet<BookModel>>();
            mockSetBooks.As<IQueryable<BookModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSetBooks.As<IQueryable<BookModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSetBooks.As<IQueryable<BookModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSetBooks.As<IQueryable<BookModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockSetPeople = new Mock<DbSet<PeopleModel>>();
            mockSetPeople.As<IQueryable<PeopleModel>>().Setup(m => m.Provider).Returns(user.Provider);
            mockSetPeople.As<IQueryable<PeopleModel>>().Setup(m => m.Expression).Returns(user.Expression);
            mockSetPeople.As<IQueryable<PeopleModel>>().Setup(m => m.ElementType).Returns(user.ElementType);
            mockSetPeople.As<IQueryable<PeopleModel>>().Setup(m => m.GetEnumerator()).Returns(user.GetEnumerator());

            var mockContext = mock.Mock<LibraryDbContext>();
            mockContext.Setup(c => c.Set<BookModel>()).Returns(mockSetBooks.Object);
            mockContext.Setup(c => c.Books).Returns(mockSetBooks.Object);
            mockContext.Setup(c => c.Peoples).Returns(mockSetPeople.Object);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            var service = new BookService(mockContext.Object, mapper, null);
            var actualData = service.Remove(1);

            Assert.IsTrue(actualData);
        }

        [Test]
        public void DeleteFalseTest()
        {
            var data = new List<BookModel>
            {
                new BookModel { Id = 1, Title = "BBB", Genre = new List<GenryModel>() },
                new BookModel { Id = 2, Title = "ZZZ", Genre = new List<GenryModel>()  },
                new BookModel { Id = 3, Title = "AAA", Genre = new List<GenryModel>() },
            }.AsQueryable();

            var user = new List<PeopleModel>
            {
                new PeopleModel { Id = 1, Name = "asd", Books = new List<BookModel>() }
            }.AsQueryable();

            using var mock = AutoMock.GetLoose();
            var mockSet = new Mock<DbSet<BookModel>>();
            mockSet.As<IQueryable<BookModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<BookModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<BookModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<BookModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockSetPeople = new Mock<DbSet<PeopleModel>>();
            mockSetPeople.As<IQueryable<PeopleModel>>().Setup(m => m.Provider).Returns(user.Provider);
            mockSetPeople.As<IQueryable<PeopleModel>>().Setup(m => m.Expression).Returns(user.Expression);
            mockSetPeople.As<IQueryable<PeopleModel>>().Setup(m => m.ElementType).Returns(user.ElementType);
            mockSetPeople.As<IQueryable<PeopleModel>>().Setup(m => m.GetEnumerator()).Returns(user.GetEnumerator());

            var mockContext = mock.Mock<LibraryDbContext>();
            mockContext.Setup(c => c.Set<BookModel>()).Returns(mockSet.Object);
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);
            mockContext.Setup(c => c.Peoples).Returns(mockSetPeople.Object);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            var service = new BookService(mockContext.Object, mapper, null);
            var actualData = service.Remove(5);

            Assert.IsFalse(actualData);
        }

        [Test]
        public void AddTest()
        {
            var data = new List<BookModel>
            {
                new BookModel { Id = 1, Title = "BBB", Genre = new List<GenryModel>() },
                new BookModel { Id = 2, Title = "ZZZ", Genre = new List<GenryModel>()  },
                new BookModel { Id = 3, Title = "AAA", Genre = new List<GenryModel>() },
            }.AsQueryable();

            using var mock = AutoMock.GetLoose();
            var mockSet = new Mock<DbSet<BookModel>>();
            mockSet.As<IQueryable<BookModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<BookModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<BookModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<BookModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = mock.Mock<LibraryDbContext>();
            mockContext.Setup(c => c.Set<BookModel>()).Returns(mockSet.Object);
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            BookDto book = new() { Title = "ADD", Genre = new List<GenryBaseDto>() };

            var service = new BookService(mockContext.Object, mapper, null);
            var actualAnswer = service.Add(book);

            ArrayList list = new ArrayList();
            list.Add(new object());
            list.Add(89);
            list.Add(new Random());

            Assert.IsTrue(actualAnswer);
        }

        [Test]
        public void UpdateTrueTest()
        {
            using var mock = AutoMock.GetLoose();
            var mockContext = mock.Mock<LibraryDbContext>();

            var addGenry = new BookModel
            {
                Id = 3,
                Title = "AAA",
                Genre = new List<GenryModel>() { new GenryModel() { Id = 1, Name = "Add" }
                    }
            };

            mockContext.Object.Update(addGenry);

            mockContext.Verify(c => c.Update(addGenry), Times.Exactly(1));

        }

        [Test]
        public void UpdateFalseTest()
        {
            var data = new List<BookModel>
            {
                new BookModel { Id = 1, Title = "BBB", Genre = new List<GenryModel>() },
                new BookModel { Id = 2, Title = "ZZZ", Genre = new List<GenryModel>()  },
                new BookModel { Id = 3, Title = "AAA", Genre = new List<GenryModel>() },
            }.AsQueryable();

            using var mock = AutoMock.GetLoose();
            var mockSet = new Mock<DbSet<BookModel>>();
            mockSet.As<IQueryable<BookModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<BookModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<BookModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<BookModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            var mockContext = mock.Mock<LibraryDbContext>();
            mockContext.Setup(c => c.Set<BookModel>()).Returns(mockSet.Object);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            BookDto addReader = new() { Title = "BB", Genre = new List<GenryBaseDto>() { new GenryBaseDto() { Name = "Test" } } };

            var service = new BookService(mockContext.Object, mapper, null);
            var actualAnswer = service.Update(addReader);

            Assert.IsFalse(actualAnswer);
        }

        [Test]
        public void UpdateNUllFalseTest()
        {
            var data = new List<BookModel>
            {
                new BookModel { Id = 1, Title = "BBB", Genre = new List<GenryModel>() },
                new BookModel { Id = 2, Title = "ZZZ", Genre = new List<GenryModel>()  },
                new BookModel { Id = 3, Title = "AAA", Genre = new List<GenryModel>() },
            }.AsQueryable();

            using var mock = AutoMock.GetLoose();
            var mockSet = new Mock<DbSet<BookModel>>();
            mockSet.As<IQueryable<BookModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<BookModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<BookModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<BookModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            var mockContext = mock.Mock<LibraryDbContext>();
            mockContext.Setup(c => c.Set<BookModel>()).Returns(mockSet.Object);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            BookDto addReader = null;

            var service = new BookService(mockContext.Object, mapper, null);
            var actualAnswer = service.Update(addReader);

            Assert.IsFalse(actualAnswer);
        }
    }
}
