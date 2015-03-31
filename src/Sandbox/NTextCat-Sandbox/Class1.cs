using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IvanAkcheurov.NTextCat.Lib;
using NUnit.Framework;

namespace NTextCat_Sandbox
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void TestNTextCat()
        {
            var factory = new RankedLanguageIdentifierFactory();
            var identifier = factory.Load("Core14.profile.xml");
            IEnumerable<Tuple<LanguageInfo, double>> res = identifier.Identify("your text to get its language identified");

            Assert.That(res.Count(), Is.GreaterThan(0));
        }
    }
}
