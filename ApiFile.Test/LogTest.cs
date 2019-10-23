using NUnit.Framework;
using ApiFile.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Http;

namespace ApiFile.Test
{
    public class LogTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void AddToDatabase()
        {
            var options = new DbContextOptionsBuilder<LogContext>()
                .UseInMemoryDatabase(databaseName: "LogTrace")
                .Options;

            // Run the test against one instance of the context
            using (var context = new LogContext(options))
            {
                var log = new LogRepository(context);
                log.Add(new FileText(){IdDocument=1077866886, Date=DateTime.Now}).Wait();
                context.SaveChanges();
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new LogContext(options))
            {
                var x= context.LogTraces.CountAsync().Result;
                Assert.AreEqual(1, x);
                Assert.AreEqual(1077866889, context.LogTraces.SingleAsync().Result.IdDocument);
            }
        }
    }
}