using System.Web;
using System.Web.Mvc;
using AzureExampleWithDB.Models;
namespace AzureExampleWithDB
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
