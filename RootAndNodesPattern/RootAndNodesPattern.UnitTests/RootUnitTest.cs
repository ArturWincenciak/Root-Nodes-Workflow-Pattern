using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TeoVincent.RootAndNodesPattern.UnitTests
{
    public class RootUnitTest
    {
        class RootMock : Root
        {
            public RootMock(string a_name)
                : base(a_name)
            {
            }
        }
        
        [Test]
        public void TestRootConstructor()
        {
            var target = new RootMock("test");
            Assert.IsNotNull(target);
        }
    }
}
