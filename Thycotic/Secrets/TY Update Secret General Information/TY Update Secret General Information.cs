using System;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Helpers;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace Ayehu.Sdk.ActivityCreation
{
    public class CustomActivity_TY_Update_Secret_General_Information : IActivityAsync
    {


    
    public string endPoint = "https://{hostname}";
    
    public string Jsonkeypath = "general";
    
    public string password1 = "";
    
    public string id_p = "";
    
    public string dirty = "";
    
    public string value = "";
    
    public string enableInheritSecretPolicy_dirty = "";
    
    public string enableInheritSecretPolicy_value = "";
    
    public string folder_dirty = "";
    
    public string folder_value = "";
    
    public string generateSshKeys = "";
    
    public string heartbeatEnabled_dirty = "";
    
    public string heartbeatEnabled_value = "";
    
    public string isOutOfSync_dirty = "";
    
    public string isOutOfSync_value = "";
    
    public string name_dirty = "";
    
    public string name_value = "";
    
    public string secretFields__ = "";
    
    public string secretFields_dirty = "";
    
    public string slug = "";
    
    public string secretFields_value = "";
    
    public string secretPolicy_dirty = "";
    
    public string secretPolicy_value = "";
    
    public string site_dirty = "";
    
    public string site_value = "";
    
    public string template_dirty = "";
    
    public string template_value = "";
    
    private bool omitJsonEmptyorNull = true;
    
    private string contentType = "application/json";
    
    private string httpMethod = "PATCH";
    
    private string uriBuilderPath {
        get {
            return string.Format("SecretServer/api/v1/secrets/{0}/general",id_p);
        }
    }
    
    private string postData {
        get {
            return string.Format("{{ \"data\": {{   \"active\": {{     \"dirty\": \"{0}\",      \"value\": \"{1}\"     }},    \"enableInheritSecretPolicy\": {{     \"dirty\": \"{2}\",      \"value\": \"{3}\"     }},    \"folder\": {{     \"dirty\": \"{4}\",      \"value\": \"{5}\"     }},    \"generateSshKeys\": \"{6}\",    \"heartbeatEnabled\": {{     \"dirty\": \"{7}\",      \"value\": \"{8}\"     }},    \"isOutOfSync\": {{     \"dirty\": \"{9}\",      \"value\": \"{10}\"     }},    \"name\": {{     \"dirty\": \"{11}\",      \"value\": \"{12}\"     }},    \"secretFields\": [      {{       \"dirty\": \"{13}\",        \"slug\": \"{14}\",        \"value\": \"{15}\"       }}    ],    \"secretPolicy\": {{     \"dirty\": \"{16}\",      \"value\": \"{17}\"     }},    \"site\": {{     \"dirty\": \"{18}\",      \"value\": \"{19}\"     }},    \"template\": {{     \"dirty\": \"{20}\",      \"value\": \"{21}\"     }}   }} }}",dirty,value,enableInheritSecretPolicy_dirty,enableInheritSecretPolicy_value,folder_dirty,folder_value,generateSshKeys,heartbeatEnabled_dirty,heartbeatEnabled_value,isOutOfSync_dirty,isOutOfSync_value,name_dirty,name_value,secretFields_dirty,slug,secretFields_value,secretPolicy_dirty,secretPolicy_value,site_dirty,site_value,template_dirty,template_value);
        }
    }
    
    private System.Collections.Generic.Dictionary<string, string> headers {
        get {
            return new Dictionary<string, string>() {{"Authorization","Bearer " + password1}};
        }
    }
    
    private System.Collections.Generic.Dictionary<string, string> queryStringArray {
        get {
            return new Dictionary<string, string>() {};
        }
    }


        public async System.Threading.Tasks.Task<ICustomActivityResult> Execute()
        {

            HttpClient client = new HttpClient();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            UriBuilder UriBuilder = new UriBuilder(endPoint); 
            UriBuilder.Path = uriBuilderPath;
            UriBuilder.Query = AyehuHelper.queryStringBuilder(queryStringArray);
            HttpRequestMessage myHttpRequestMessage = new HttpRequestMessage(new HttpMethod(httpMethod), UriBuilder.ToString());
           
            if (contentType == "application/x-www-form-urlencoded")
                myHttpRequestMessage.Content = AyehuHelper.formUrlEncodedContent(postData);
            else
              if (string.IsNullOrEmpty(postData) == false)
                if (omitJsonEmptyorNull)
                    myHttpRequestMessage.Content = new StringContent(AyehuHelper.omitJsonEmptyorNull(postData), Encoding.UTF8, "application/json");
                else
                    myHttpRequestMessage.Content = new StringContent(postData, Encoding.UTF8, "application/json");


            foreach (KeyValuePair<string, string> headeritem in headers)
                client.DefaultRequestHeaders.Add(headeritem.Key, headeritem.Value);

            HttpResponseMessage response = client.SendAsync(myHttpRequestMessage).Result;

            switch (response.StatusCode)
            {
                case HttpStatusCode.NoContent:
                case HttpStatusCode.Created:
                case HttpStatusCode.Accepted:
                case HttpStatusCode.OK:
                    {
                        if (string.IsNullOrEmpty(response.Content.ReadAsStringAsync().Result) == false)
                            return this.GenerateActivityResult(response.Content.ReadAsStringAsync().Result, Jsonkeypath);
                        else
                            return this.GenerateActivityResult("Success");
                    }
                default:
                    {
                        if (string.IsNullOrEmpty(response.Content.ReadAsStringAsync().Result) == false)
                            throw new Exception(response.Content.ReadAsStringAsync().Result);
                        else if (string.IsNullOrEmpty(response.ReasonPhrase) == false)
                            throw new Exception(response.ReasonPhrase);
                        else
                            throw new Exception(response.StatusCode.ToString());
                    }
            }
        }

        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}