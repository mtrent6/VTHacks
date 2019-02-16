using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using WebHeaderCollection;
using UnityEngine;

public class Test : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

      private int GetContent()
        {
            var content = "";

            var client = new WebClient();

            var headers = new WebHeaderCollection();

            headers.Add(HttpRequestHeader.Accept, "text/html, application/xhtml+xml, */*");
            //headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
            headers.Add(HttpRequestHeader.AcceptLanguage, "en-GB");
            headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko");
            
            client.Headers = headers;

            var rawhtml = client.DownloadString("https://api.yelp.com/v3/autocomplete?text=del&latitude=37.786882&longitude=-122.399972");

            HtmlAgilityPack.HtmlDocument Html = new HtmlAgilityPack.HtmlDocument();

            Html.LoadHtml(rawhtml);

            var title = GetTitle(Html);

            var description = GetDescription(Html);
            Conslole.WriteLine(description);

            return 0;
        }

}
