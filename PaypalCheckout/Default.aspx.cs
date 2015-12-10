using System;

namespace PaypalCheckout
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Required information, will be send with API request
            Session["amount"] = "12";
            Session["OrderNumber"] = new Guid().ToString();
            Session["ProductName"] = "This is product name";

            // TODO: Save data in database with 'OrderNumber' as reference

            Response.Redirect("PayPalProcess.aspx");
        }
    }
}