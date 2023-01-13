using System.Web;
using System.Web.Mvc;

namespace BE.U2_W2_D5.PS_GrandBudapestHotel
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
