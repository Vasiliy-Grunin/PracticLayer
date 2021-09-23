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
using DataServices.MappingService;
using DataServices.AuthorServices;
using DAL.Entitys.Dto;

namespace BAL.Test
{
    [TestFixture]
    public class AuthorServicesTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetTest()
        {
            var data = new List<AuthorModel>
            {
                new AuthorModel { Id = 1, Name = "BBB", Books = new List<BookModel>() },
                new AuthorModel { Id = 2, Name = "ZZZ", Books = new List<BookModel>()  },
                new AuthorModel { Id = 3, Name = "AAA", Books = new List<BookModel>() },
            }.AsQueryable();

            using var mock = AutoMock.GetLoose();
            var mockSet = new Mock<DbSet<AuthorModel>>();
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            var mockContext = mock.Mock<LibraryDbContext>();
            mockContext.Setup(c => c.Authors).Returns(mockSet.Object);
            mockContext.Setup(c => c.Set<AuthorModel>()).Returns(mockSet.Object);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            var service = new AuthorService(mockContext.Object, mapper, null);
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
            var data = new List<AuthorModel>
            {
                new AuthorModel { Id = 1, Name = "BBB", Books = new List<BookModel>() },
                new AuthorModel { Id = 2, Name = "ZZZ", Books = new List<BookModel>()  },
                new AuthorModel { Id = 3, Name = "AAA", Books = new List<BookModel>() },
            }.AsQueryable();

            using var mock = AutoMock.GetLoose();
            var mockSet = new Mock<DbSet<AuthorModel>>();
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            var mockContext = mock.Mock<LibraryDbContext>();
            mockContext.Setup(c => c.Authors).Returns(mockSet.Object);
            mockContext.Setup(c => c.Set<AuthorModel>()).Returns(mockSet.Object);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            var service = new AuthorService(mockContext.Object, mapper, null);
            var actualData = service.Remove(1);

            Assert.IsTrue(actualData);
        }

        [Test]
        public void DeleteFalseTest()
        {
            var data = new List<AuthorModel>
            {
                new AuthorModel { Id = 1, Name = "BBB", Books = new List<BookModel>() },
                new AuthorModel { Id = 2, Name = "ZZZ", Books = new List<BookModel>()  },
                new AuthorModel { Id = 3, Name = "AAA", Books = new List<BookModel>() },
            }.AsQueryable();

            using var mock = AutoMock.GetLoose();
            var mockSet = new Mock<DbSet<AuthorModel>>();
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            var mockContext = mock.Mock<LibraryDbContext>();
            mockContext.Setup(c => c.Authors).Returns(mockSet.Object);
            mockContext.Setup(c => c.Set<AuthorModel>()).Returns(mockSet.Object);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            var service = new AuthorService(mockContext.Object, mapper, null);
            var actualData = service.Remove(5);

            Assert.IsFalse(actualData);
        }

        [Test]
        public void AddTest()
        {
            var data = new List<AuthorModel>
            {
                new AuthorModel { Id = 1, Name = "BBB", Books = new List<BookModel>() },
                new AuthorModel { Id = 2, Name = "ZZZ", Books = new List<BookModel>()  },
                new AuthorModel { Id = 3, Name = "AAA", Books = new List<BookModel>() },
            }.AsQueryable();

            using var mock = AutoMock.GetLoose();
            var mockSet = new Mock<DbSet<AuthorModel>>();
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            var mockContext = mock.Mock<LibraryDbContext>();
            mockContext.Setup(c => c.Authors).Returns(mockSet.Object);
            mockContext.Setup(c => c.Set<AuthorModel>()).Returns(mockSet.Object);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            var addAuthor = new AuthorDto { Name = "ADD", Books = new List<BookBaseDto>() };

            var service = new AuthorService(mockContext.Object, mapper, null);
            var actualAnswer = service.Add(addAuthor);

            Assert.IsTrue(actualAnswer);
        }

        [Test]
        public void UpdateTrueTest()
        {
            using var mock = AutoMock.GetLoose();
            var mockContext = mock.Mock<LibraryDbContext>();

            var addAuthor = new AuthorModel
            {
                Id = 3,
                Name = "AAA",
                Books = new List<BookModel>() { new BookModel() { Id = 1, Title = "Add" } }
            };

            mockContext.Object.Update(addAuthor);

            mockContext.Verify(c => c.Update(addAuthor), Times.Exactly(1));

        }

        [Test]
        public void UpdateFalseTest()
        {
            var data = new List<AuthorModel>
            {
                new AuthorModel { Id = 1, Name = "BBB", Books = new List<BookModel>() },
                new AuthorModel { Id = 2, Name = "ZZZ", Books = new List<BookModel>()  },
                new AuthorModel { Id = 3, Name = "AAA", Books = new List<BookModel>() },
            }.AsQueryable();

            using var mock = AutoMock.GetLoose();
            var mockSet = new Mock<DbSet<AuthorModel>>();
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            var mockContext = mock.Mock<LibraryDbContext>();
            mockContext.Setup(c => c.Authors).Returns(mockSet.Object);
            mockContext.Setup(c => c.Set<AuthorModel>()).Returns(mockSet.Object);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            var addAuthor = new AuthorDto { Name = "ADD", Books = new List<BookBaseDto>() };

            var service = new AuthorService(mockContext.Object, mapper, null);
            var actualAnswer = service.Update(addAuthor);

            Assert.IsFalse(actualAnswer);
        }

        [Test]
        public void UpdateNUllFalseTest()
        {
            var data = new List<AuthorModel>
            {
                new AuthorModel { Id = 1, Name = "BBB", Books = new List<BookModel>() },
                new AuthorModel { Id = 2, Name = "ZZZ", Books = new List<BookModel>()  },
                new AuthorModel { Id = 3, Name = "AAA", Books = new List<BookModel>() },
            }.AsQueryable();

            using var mock = AutoMock.GetLoose();
            var mockSet = new Mock<DbSet<AuthorModel>>();
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<AuthorModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            var mockContext = mock.Mock<LibraryDbContext>();
            mockContext.Setup(c => c.Authors).Returns(mockSet.Object);
            mockContext.Setup(c => c.Set<AuthorModel>()).Returns(mockSet.Object);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            var service = new AuthorService(mockContext.Object, mapper, null);
            var actualAnswer = service.Update(null);

            Assert.IsFalse(actualAnswer);
        }

        [Test]
        public void DeeleteTest()
        {
            var data = new List<AuthorModel>
            {
                new AuthorModel { Id = 1, Name = "BBB", Books = new List<BookModel>()
                { new BookModel() { Id = 1, Title = "fg", Genre = new List<GenryModel>(),
                    Author = new AuthorModel() } } },
                new AuthorModel { Id = 2, Name = "ZZZ", Books = new List<BookModel>()  },
                new AuthorModel { Id = 3, Name = "AAA", Books = new List<BookModel>() },
            }.AsQueryable();

            using var mock = AutoMock.GetLoose();
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
