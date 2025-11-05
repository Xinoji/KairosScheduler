using Siiau.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KairosScheduler.Siiau.Helpers;

public class UrlBuilder
{
    private string _BaseUrl;
    private List<string> _Paths;
    private List<KeyValuePair<string, string>> _Parameters;

    public UrlBuilder()
    {
        _BaseUrl = String.Empty;
        _Paths = new List<string>();
        _Parameters = new();
    }

    public UrlBuilder(string BaseUrl)
    {
        _BaseUrl = BaseUrl;
        _Paths = new List<string>();
        _Parameters = new();
    }

    public UrlBuilder AddParameter(string Key, string Value, bool UrlEncodeNeeded = false)
    {
        if (UrlEncodeNeeded)
            Key = WebUtility.UrlEncode(Key);

        _Parameters.Add(new(Key, Value));

        return this;
    }

    /// <summary>
    /// Method to add extra path to the url
    /// </summary>
    /// <param name="path">the path to be added without any "/" </param>
    /// <returns></returns>
    public UrlBuilder AddPath(string path, bool urlEncodeNeeded = false)
    {
        if (_Paths.Count == 0)
            throw new InvalidUrlException("Path Cannot be Empty");

        if (urlEncodeNeeded)
            path = WebUtility.UrlEncode(path);

        _Paths.Add(path);

        return this;
    }

    public UrlBuilder SetBaseUrl(string baseUrl)
    {
        //TODO: Define if it should throw an exception if the base url already exists
        _BaseUrl = _BaseUrl ?? baseUrl;

        return this;
    }

    public string BuildUrl()
    {
        string url = String.Empty;

        if (string.IsNullOrEmpty(_BaseUrl))
            throw new InvalidUrlException("The URL is missing the BaseURL");
        
        url += _BaseUrl;
        
        if(_Paths.Any(p => p.Contains("/") || string.IsNullOrEmpty(p)))
            throw new InvalidUrlException("An Empty Path or Path that include '/' was tried to be added");

        foreach (string path in _Paths)
            url += $@"/{path}";

        url += "?";

        return url;
    }
}