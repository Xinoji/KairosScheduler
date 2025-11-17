using HtmlAgilityPack;
using KairosScheduler.Siiau.Common.Constants;
using KairosScheduler.Siiau.Helpers;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace KairosScheduler.Siiau.DataScrapping;

/// <summary>
/// Class to get courses data on SIIAU
/// </summary>
public static class CourseInfoScrapper
{
    private static readonly Dictionary<string, string> _cuData = new();
    private static readonly Dictionary<string, string> _cicleData = new();
    private static string GetXPath(string field)
        => @$"//select[@name='{field}p']/option";

    public static async Task<Dictionary<string, string>> GetCuInfo(bool reload = false) 
    {
        if (_cuData.Count == 0 || reload)
            await GetFormsCatalogues();

        return new(_cuData);
    }

    public static async Task<Dictionary<string, string>> GetCicleInfo(bool reload = false)
    {
        if (_cicleData.Count == 0 || reload)
            await GetFormsCatalogues();

        return new(_cicleData);
    }

    private static async Task GetFormsCatalogues()
    {
        var RootNode = HtmlUtils.GetWebsiteRootNode(GetUrl());
        
        List<Task> tasks = new();

        tasks.Add(GetCuData(RootNode));
        
        tasks.Add(GetCicleData(RootNode));

        await Task.WhenAll(tasks);
    }



    private static string GetUrl()
    {
        var urlbuilder = new UrlBuilder();

        return urlbuilder.SetBaseUrl(UrlConstants.BaseUrl)
            .AddPath(UrlConstants.CoursePath)
            .BuildUrl();
    }

    private static async Task GetCuData(HtmlNode website)
    {
        foreach (var option in website.SelectNodes(GetXPath("cu")))
        {
            _cuData.Add(option.Attributes[0].Value, option.InnerText);
        }
    }

    private static async Task GetCicleData(HtmlNode website)
    {
        foreach (var option in website.SelectNodes(GetXPath("ciclo")))
        {
            _cicleData.Add(option.Attributes[0].Value, option.InnerText);
        }
    }


}
