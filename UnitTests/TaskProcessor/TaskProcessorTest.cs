using System.Collections.Generic;
using ApiLayer;
using AzureAccess;
using Moq;
using NUnit.Framework;
using TaskProcessor;

namespace UnitTests.TaskProcessor
{
    [TestFixture]
    public class TaskProcessorTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GetRecentHashtagsTest()
        {
            var sourceHashTag = new Hashtag { Name = "aaa" };
            const string foundTag = "twitter";
            var tableStoreMock = new Mock<ITableStore>();
            tableStoreMock.Setup(m => m.Add(sourceHashTag, It.Is<Hashtag>(h => h.Name == foundTag))).Returns(true);
            var twitterMock = new Mock<ITwitter>();
            twitterMock.Setup(m => m.GetLatestMessages(sourceHashTag)).Returns(new List<string> { "a #twitter message", "a message" });
            var taskProcessor = new HashtagProcessor(tableStoreMock.Object, twitterMock.Object);

            taskProcessor.AddRecentHashtagsToTable(sourceHashTag);

            tableStoreMock.VerifyAll();
            twitterMock.VerifyAll();
        }
    }
}
