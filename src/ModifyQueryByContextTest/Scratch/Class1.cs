using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Scratch
{
    public interface IDataStore
    {
        IQueryable<SomeData> Data { get; }
    }

    public class DataStore : IDataStore
    {
        public DataStore(List<SomeData> testData)
        {
            Data = testData.AsQueryable();
        }

        public IQueryable<SomeData> Data { get; private set; } 
    }

    public class LanguageFilter : IDataStore
    {
        private readonly IDataStore _source;

        public LanguageFilter(IDataStore source)
        {
            _source = source;
        }

        public IQueryable<SomeData> Data
        {
            get
            {
                var language = LanguageContext.Language;
                if (string.IsNullOrEmpty(language))
                    return _source.Data;
                return _source.Data.Where(data => data.Language == language);
            }
        }
    }

    public class SomeData   
    {
        public SomeData(int id, string theData, string language)
        {
            Id = id;
            TheData = theData;
            Language = language;
        }

        public int Id { get; set; }
        public string TheData { get; set; }
        public string Language { get; set; }
    }

    public class TheQuery
    {
        private readonly IDataStore _store;

        public TheQuery(IDataStore store)
        {
            _store = store;
        }

        public IEnumerable<SomeData> GetWithThisDataInIt(string theDataToLookFor)
        {
            return _store.Data.Where(data => data.TheData.Contains(theDataToLookFor));
        }
    }

    public class TheConsumer
    {
        private readonly TheQuery _theQuery;

        public TheConsumer(TheQuery theQuery)
        {
            _theQuery = theQuery;
        }

        public int HowManyHaveThisText(string theTextToLookFor)
        {
            return _theQuery.GetWithThisDataInIt(theTextToLookFor).Count();
        }
    }

    public static class LanguageContext
    {
        public static string Language { get; set; }
    }

    [TestFixture]
    public class TestingModifyingTheQuery
    {
        [Test]
        public void JustASimpleTest()
        {
            TheConsumer consumer = BuildUpClassUnderTest();

            var numberOfBlue = consumer.HowManyHaveThisText("blue");
            Assert.That(numberOfBlue, Is.EqualTo(5));
        }

        [Test]
        public void NextText()
        {
            TheConsumer consumer = BuildUpClassUnderTest();

            var numberOfBlue = consumer.HowManyHaveThisText("red");
            Assert.That(numberOfBlue, Is.EqualTo(3));
        }

        [Test]
        public void TestName()
        {
            TheConsumer consumer = BuildUpClassUnderTest();

            LanguageContext.Language = "en";

            var numberOfBlue = consumer.HowManyHaveThisText("blue");
            Assert.That(numberOfBlue, Is.EqualTo(2));
        }

        private static TheConsumer BuildUpClassUnderTest()
        {
            var sampleData = new List<SomeData>();
            sampleData.Add(new SomeData(1, "blue, red, green", "en"));
            sampleData.Add(new SomeData(2, "blue, red, black", "en"));
            sampleData.Add(new SomeData(3, "blue, red, white", "fr"));
            sampleData.Add(new SomeData(4, "blue, yellow", "jp"));
            sampleData.Add(new SomeData(5, "blue, yello, purple", "jp"));

            return new TheConsumer(new TheQuery(new LanguageFilter(new DataStore(sampleData))));
        }
    }
}
