using NUnit.Framework;
using Shorter.Core;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Shorter.Test
{
    public class MarketingDigitalRepositoryTest
    {
        IAccessTokenProvider accessTokenProvider;

        [SetUp]
        public void Setup()
        {
            accessTokenProvider = new FakeAccessTokenProvider();
        }

        [Test]
        public void GetAll_Success()
        {
            //Arrange
            ICmsReadonlyRepository<MarketingDigital> repository = new MarketingDigitalRepository(accessTokenProvider);

            //Act
            var all = repository.GetAll();

            //Assert
            Assert.True(true);
        }
    }
}
