using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Test : MonoBehaviour
{

    public bool MyRemoteCertificateValidationCallback(System.Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        bool isOk = true;
        // If there are errors in the certificate chain, look at each error to determine the cause.
        if (sslPolicyErrors != SslPolicyErrors.None)
        {
            for (int i = 0; i < chain.ChainStatus.Length; i++)
            {
                if (chain.ChainStatus[i].Status != X509ChainStatusFlags.RevocationStatusUnknown)
                {
                    chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                    chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                    chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                    chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
                    bool chainIsValid = chain.Build((X509Certificate2)certificate);
                    if (!chainIsValid)
                    {
                        isOk = false;
                    }
                }
            }
        }
        return isOk;
    }

    // Use this for initialization
    void Start()
    {
         ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;
        Debug.Log(Get("https://api.yelp.com/v3/autocomplete?text=del&latitude=37.786882&longitude=-122.399972"));
        
    }

    // Update is called once per frame
    void Update()
    {

    }
   

    public string Get(string uri)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
        request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
        request.Headers.Add("Authorization", "Bearer " + "Bffayat-NTxYFEu8MGzUuRT-z4t2UdmHWgyAQYfffA92lbbnrt1fzBMMhuR7MFJ_jWj_iqx1orSDPrHQVHBojoDveBn0kTkFsGdCtW0Dnk0xa-XtUGjFyxIzEF1nXHYx");
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            return reader.ReadToEnd();
        }
    }

  

}
