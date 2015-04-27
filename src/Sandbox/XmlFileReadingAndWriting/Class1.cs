using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace XmlFileReadingAndWriting
{
    [Serializable]
    public class LocaleLanguageMappings
    {
        public List<LocaleLanguageMapping> Mappings;
    }

    [Serializable]
    public class LocaleLanguageMapping
    {
        public string Iso639_1_LanguageCode;
        public CultureInfo DefaultLoclae;
        public List<CultureInfo> SupportedLocale;
    }

    [TestFixture]
    public class ReadingXmlTest
    {
        [Test]
        public void Method1()
        {
            var temp = GetObjectFromXML();

            Assert.That(temp, Is.Not.Null);
        }

        [Test]
        public void Method2()
        {
            TextReader tReader = new StreamReader("TargetFile.xml");
            var body = tReader.ReadToEnd();
            var result = Deserialize<LocaleLanguageMappings>(body);

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Attempt3()
        {
            string xml = File.ReadAllText("TargetFile.xml");
            LanguageLocaleMappings mappings = xml.ParseXML<LanguageLocaleMappings>();

            Assert.That(mappings, Is.Not.Null);

            Assert.That(mappings.LanguageLocaleMapping.Count(), Is.EqualTo(2));
        }

        [Test]
        public void WithJson()
        {
            string xml = File.ReadAllText("Mappings.json");
            var result = JsonConvert.DeserializeObject<Rootobject>(xml);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.LanguageLocaleMappings.Count(), Is.EqualTo(2));
        }

        public SuppoertedLocals GetObjectFromXML()
        {
            TextReader tReader = new StreamReader("TargetFile.xml");

            var settings = new XmlReaderSettings();
            var obj = new SuppoertedLocals();
            var reader = XmlReader.Create(tReader, settings);
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof (SuppoertedLocals));
            obj = (SuppoertedLocals) serializer.Deserialize(reader);

            reader.Close();
            return obj;
        }

        public T Deserialize<T>(string serializedResults)
        {
            var serializer = new XmlSerializer(typeof (T));
            using (var stringReader = new StringReader(serializedResults))
                return (T) serializer.Deserialize(stringReader);
        }
    }

    internal static class ParseHelpers
    {
       public static Stream ToStream(this string @this)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(@this);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static T ParseXML<T>(this string @this) where T : class
        {
            var reader = XmlReader.Create(@this.Trim().ToStream(), new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Document });
            return new XmlSerializer(typeof(T)).Deserialize(reader) as T;
        }
     
    }
    
}
