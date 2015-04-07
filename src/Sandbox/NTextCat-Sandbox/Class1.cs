using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using IvanAkcheurov.NTextCat.Lib;
using Nancy;
using Nancy.Conventions;
using Nancy.TinyIoc;
using Nancy.ViewEngines;
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
            IEnumerable<Tuple<LanguageInfo, double>> res =
                identifier.Identify("your text to get its language identified");

            Assert.That(res.Count(), Is.GreaterThan(0));
        }
    }

    public class ExternalModule : NancyModule
    {
        public ExternalModule()
        {
            Get["/external"] = _ => { return View["external"]; };
        }
    }

    //public class CustomConventionsBootstrapper : DefaultNancyBootstrapper
    //{
    //    protected override void ApplicationStartup(TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
    //    {
    //        this.Conventions.ViewLocationConventions.Add(EmbededConvention);
    //    }

    //    private string EmbededConvention(string viewName, object model, ViewLocationContext context)
    //    {
    //        return string.Concat("custom/", viewName);
    //    }

    //}

    public class EmbededViewConvention : IConvention
    {
        public void Initialise(NancyConventions conventions)
        {
            
        }

        public Tuple<bool, string> Validate(NancyConventions conventions)
        {
            return null;
        }
    }

}
