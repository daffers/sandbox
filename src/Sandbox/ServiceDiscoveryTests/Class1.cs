using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using NUnit.Framework;
using OpenTable.Services.Components.DiscoveryClient;

namespace ServiceDiscoveryTests
{
    [TestFixture]
    public class HowToDiscoverServices
    {
        [Test]
        public void Test()
        {
            var client = new CSDiscoveryClient();
            //ServiceLookup lookup = ServiceLookup.With().SetServiceType("language-detection-service");
            //client.FindAnnouncements(lookup);

            var body = @"{""TextForLanguageClassification"":""店舗運営者のみなさま""}";
            const string uri = @"srvc://language-detection-service/language-detector";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = WebRequestMethods.Http.Post;
            Stream stream = request.GetRequestStream();

            request.ContentType = "application/json; charset=utf-8";
            request.Accept = "application/json; charset=utf-8";
            var bytes = new UTF8Encoding().GetBytes(body);

            stream.Write(bytes, 0, bytes.Length);

            var response = (HttpWebResponse)request.GetResponse();

            string result;
            
            Encoding responseEncoding = Encoding.GetEncoding(response.CharacterSet);
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), responseEncoding))
            {
                result = sr.ReadToEnd();
            }

            response.Close();
        }
    }
}
