using System;

namespace PaypalCheckout
{
    public partial class PayPalProcess : System.Web.UI.Page
    {
        protected string cmd = "_xclick";
        protected string business = System.Configuration.ConfigurationManager.AppSettings["PayPalBusinessEmail"];
        protected string return_url = System.Configuration.ConfigurationManager.AppSettings["PayPalReturnUrl"];
        protected string cancel_url = System.Configuration.ConfigurationManager.AppSettings["PayPalCancelPurchaseUrl"];
        protected string URL = System.Configuration.ConfigurationManager.AppSettings["PayPalSendBoxUrl"];
        protected string currency_code = "USD";
        protected string no_shipping = "1";
        protected string notify_url = "";
        protected string rm = "2";
        protected string request_id;
        protected string item_name;
        protected string amount;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Get order details from session
            amount = Session["amount"].ToString();
            request_id = Session["OrderNumber"].ToString();
            item_name = Session["ProductName"].ToString();
        }
    }
}