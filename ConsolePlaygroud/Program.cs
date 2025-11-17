using KairosScheduler.Siiau.Helpers;
using KairosScheduler.Siiau.Common.Constants;
using KairosScheduler.Siiau.DataScrapping;
namespace Playground;

public class Program
{
    public static void Main()
    {
        var cuData = CourseInfoScrapper.GetCuInfo();
        var cicleData = CourseInfoScrapper.GetCicleInfo();
        return;
    }

}