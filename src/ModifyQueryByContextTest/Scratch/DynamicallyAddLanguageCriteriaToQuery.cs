namespace Scratch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Remoting.Metadata.W3cXsd2001;
    using NUnit.Framework;

    [TestFixture]
    public class ScratchTests
    {
        [Test]
        public void SearchOnId()
        {
            var db = new DataDataBase();

            var runner = new QueryRunner(db);

            var searchParams = new SharedParams();
            searchParams.GroupIdToSearchFor = 1;

            var results = runner.Run(searchParams);

            Assert.That(results.Count(), Is.EqualTo(2));
        }

        [Test]
        public void SearchOnIdAndLanugage()
        {
            var db = new DataDataBase();

            var runner = new QueryRunner(db);

            var searchParams = new SharedParams();
            searchParams.GroupIdToSearchFor = 1;
            searchParams.RequestedLanguages = new List<Language>() {new Language("en")};


            var results = runner.Run(searchParams);

            Assert.That(results.Count(), Is.EqualTo(1));
        }



        [Test]
        public void SearchOnTextAndLanugage()
        {
            var db = new DataDataBase();

            var runner = new QueryRunner(db);

            var searchParams = new SharedParams();
            searchParams.TextToSearch = "cat";
            //searchParams.RequestedLanguages = new List<Language>() { new Language("en") };


            var results = runner.Run(searchParams);

            Assert.That(results.Count(), Is.EqualTo(1));
        }
    }

    public interface ILanguageFilterableQuery
    {

    }

    public class QueryRunner
    {
        private readonly DataDataBase _data;
        private readonly IEnumerable<IQueryDefinition> _queries;

        public QueryRunner(DataDataBase data)
        {
            _data = data;

            var queries = new List<IQueryDefinition>();
            queries.Add(new QueryByGroupIdDefinition());
            queries.Add(new QueryByTextDefinition());

            _queries = queries;
        }

        public IEnumerable<DataItem> Run(SharedParams searchParams)
        {
            var matchingQuery = GetMatchingQueries(searchParams);

            if (searchParams.RequestedLanguages.Any())
            {
                foreach (Language current in searchParams.RequestedLanguages)
                {
                    Language currentCopy = current;
                    IEnumerable<DataItem> result = matchingQuery.GetQuery(_data.Items.Where(data => data.LanguageOfData.Value == currentCopy.Value), searchParams);

                    if (!result.Any())
                        continue;

                    return result;
                }
            }
            else 
                return matchingQuery.GetQuery(_data.Items, searchParams);

            return new List<DataItem>();
        }

        private IQueryDefinition GetMatchingQueries(SharedParams searchParams)
        {
            IQueryDefinition matchingQuery = null;

            foreach (IQueryDefinition queryDefinition in _queries)
            {
                if (!queryDefinition.AreMyParameters(searchParams))
                    continue;

                matchingQuery = queryDefinition;
                break;
            }

            if (matchingQuery == null)
                throw new ArgumentException("Not matching queries for parameter set i.e. bad request");
            return matchingQuery;
        }
    }

    public class SharedParams
    {
        public SharedParams()
        {
            RequestedLanguages = new List<Language>();
        }

        public string TextToSearch { get; set; }
        public int GroupIdToSearchFor { get; set; }
        public IEnumerable<Language> RequestedLanguages { get; set; } 
    }

    public class DataItem
    {
        public DataItem(int id, int groupId, string text, Language lang)
        {
            Id = id;
            GroupId = groupId;
            Text = text;
            LanguageOfData = lang;
        }

        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Text { get; set; }
        public Language LanguageOfData { get; set; }
    }

    public struct Language
    {
        private readonly string _value;

        public Language(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }
    }

    public interface IQueryDefinition
    {
        bool AreMyParameters(SharedParams searchParams);
        IQueryable<DataItem> GetQuery(IQueryable<DataItem> source, SharedParams searchParams);
    }

    public class QueryByGroupIdDefinition : IQueryDefinition
    {
        public bool AreMyParameters(SharedParams searchParams)
        {
            return (searchParams.GroupIdToSearchFor != 0);
        }

        public IQueryable<DataItem> GetQuery(IQueryable<DataItem> source, SharedParams searchParams)
        {
            return source.Where(data => data.GroupId == searchParams.GroupIdToSearchFor);
        }
    }

    public class QueryByTextDefinition : IQueryDefinition
    {
        public bool AreMyParameters(SharedParams searchParams)
        {
            return (!string.IsNullOrWhiteSpace(searchParams.TextToSearch));
        }

        public IQueryable<DataItem> GetQuery(IQueryable<DataItem> source, SharedParams searchParams)
        {
            return source.Where(data => data.Text.Contains(searchParams.TextToSearch));
        }
    }


    public class DataDataBase
    {
        public DataDataBase()
        {
            var temp = new List<DataItem>();

            temp.Add(new DataItem(1, 1,"dog goes woof", new Language("en")));
            temp.Add(new DataItem(2, 1, "cats don't", new Language("jp")));
            temp.Add(new DataItem(3, 0, "dog eat", new Language("fr")));
            temp.Add(new DataItem(4, 0, "hamster", new Language("fr")));
            temp.Add(new DataItem(5, 3,"one", new Language("en")));

            Items = temp.AsQueryable();
        }

        public IQueryable<DataItem> Items { get; private set; }
    }
}
