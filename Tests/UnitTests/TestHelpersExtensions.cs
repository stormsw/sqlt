namespace SQLt.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SQLt;
    using System.Collections.Generic;
    using System.Linq;

    internal class TestEnum
    {
        public string bla;
    }

    [TestClass]
    public class TestHelpersExtensions
    {
        /// <summary>
        /// Test deferred execution iterator
        /// </summary>
        [TestMethod]
        public void ForEachLazzy_ModifiedItems()
        {
            List<TestEnum> testFixture1 = new List<TestEnum>(){
                new TestEnum()
                {
                    bla="1"
                },
                new TestEnum()
                {
                    bla="2"
                },
                new TestEnum()
                {
                    bla="3"
                },
                new TestEnum()
                {
                    bla="4"
                },
            };

            List<string> result = new List<string>();
            /// at first step we will not have resultFixture collection calculated, and result as a result too
            var resultFixture = testFixture1.ForEachLazzy(item => item.bla += "+").ForEachLazzy(item => result.Add(item.bla));
            /// during iteration on resultFixture willl be called callback for result collection
            /// (cause resultFixture computed from second (not first!) ForEachLazzy call
            /// so at this moment both collections are "empty"
            foreach (var item in resultFixture)
            {
                /// ensure callback was performed
                Assert.IsTrue(item.bla.EndsWith("+"));
            }
            /// after iterration on its elements collection is fillled
            Assert.AreEqual(resultFixture.Count(), 4);
            /// and dependent collection aswell filled
            Assert.AreEqual(result.Count(), 4);
        }
    }
}