using SuperShop.Helpers;

namespace SuperShopGS.Helperes
{
    public interface IMailHelper
    {
        Response SendEmail(string to, string subject, string body);
    }
}