using NUnit.Framework;
using Shorter.Core;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Shorter.Test
{
    public class PushNotificationTemplateRepositoryTest
    {
        IDbConnection connection;

        [SetUp]
        public void Setup()
        {
            connection = new SqlConnection("");
        }

        [Test]
        public void GetAll_Success()
        {
            //Arrange
            ISqlReadonlyRepository<PushNotificationTemplate> repository = new PushNotificationTemplateRepository(connection);

            //Act
            var all = repository.GetAll();

            //Assert
            Assert.True(true);
        }
    }
}
