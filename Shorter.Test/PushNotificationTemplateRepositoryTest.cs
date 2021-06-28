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
            connection = new SqlConnection("Data Source=sql-dev-elos-el.database.windows.net;Initial Catalog=sqldb-dev-elos-el;User Id=evupapp_dev;Password=4mGMpeQOZ#;Max Pool Size=32767;Pooling=true");
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
