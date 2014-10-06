using System;
using ApiLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests
{
    [TestClass]
    public class EndToEndTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var twitter = new Twitter();
            var messages = twitter.GetLatestMessages(new Hashtag(){Name = "statsd"});
            

        }
    }
}
