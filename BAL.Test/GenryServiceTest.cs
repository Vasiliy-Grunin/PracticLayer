using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Extras.Moq;
using AutoMapper;
using DAL.Data;
using DAL.Entitys.Model;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Service.GenryServices;
using Service.MappingService;

namespace BAL.Test
{
    class GenryServiceTest
    {
        [TestCase()]

        [Test]
        public void GetStatisticsTest()
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
                mockSet.As<IEnumerable<GenryModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


                var mockContext = mock.Mock<LibraryDbContext>();
                mockContext.Setup(c => c.Genries).Returns(mockSet.Object);

                var mapperConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapping());
                });
                IMapper mapper = mapperConfig.CreateMapper();

                var service = new GenryService(mockContext.Object, mapper, null);
                var actualData = service.GetStatistic();
                var expectedData = new Dictionary<string, int>
                {
                    { "BBB", 0 },
                    { "ZZZ", 0 },
                    { "AAA", 0 }
                };

                Assert.AreEqual(expectedData.Count, actualData.Count);
                for (int i = 0; i < actualData.Count; i++)
                {
                    Assert.AreEqual(expectedData.ElementAt(i).Key, actualData.ElementAt(i).Key);
                    Assert.AreEqual(expectedData.ElementAt(i).Value, actualData.ElementAt(i).Value);
                }
            }
        }
    }
}
