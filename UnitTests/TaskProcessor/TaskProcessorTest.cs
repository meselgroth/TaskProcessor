using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var queueMock = new Mock<IQueue>();
            var hashtag = new Hashtag{Name = "aaa"};
            queueMock.Setup(m => m.Dequeue()).Returns(hashtag);
            var tableStoreMock = new Mock<ITableStore>();
            tableStoreMock.Setup(m => m.Add(It.IsAny<Hashtag>())).Returns(true);
            var twitterMock = new Mock<ITwitter>();
            twitterMock.Setup(m => m.GetLatestMessages(hashtag)).Returns(new List<string> {"a #twitter message", "a message"});
            var taskProcessor = new HashtagProcessor(queueMock.Object, tableStoreMock.Object, twitterMock.Object);

            taskProcessor.GetRecentHashtags();

            queueMock.VerifyAll();
            tableStoreMock.VerifyAll();
            twitterMock.VerifyAll();
        }
    }
}
