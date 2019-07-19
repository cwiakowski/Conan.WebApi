using Conan.Data.Tests.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using UnitTestCoder.Shouldly.Gen;

namespace Conan.Data.Tests.Repositories
{
    [TestClass]
    public class MessagesRepositoryTest
    {
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void Example()
        {
            var s = DataGenerator.GetExample();
            //ShouldlyTest.Gen(s, nameof(s));
            s.ShouldBe("Example");
        }
    }
}