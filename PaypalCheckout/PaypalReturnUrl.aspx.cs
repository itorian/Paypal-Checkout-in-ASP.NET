using System;
using System.IO;
using System.Net;
using System.Text;

namespace PaypalCheckout
{
    public partial class PaypalReturnUrl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PayPalResponseReturn_Token_Update();
        }
        private void PayPalResponseReturn_Token_Update()
        {
            try
            {
                string strFormValues = Encoding.ASCII.GetString(Request.BinaryRead(Request.ContentLength));
                dynamic strNewValue = null;
                string authToken = System.Configuration.ConfigurationManager.AppSettings["PayPalToken"];
                string txToken = Request.QueryString.Get("tx");
                string query = string.Format("cmd=_notify-synch&tx={0}&at={1}", txToken, authToken);
                string URL = System.Configuration.ConfigurationManager.AppSettings["PayPalSendBoxUrl"];

                // Create the request back
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL);

                // Set values for the request back
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                strNewValue = strFormValues + "&cmd=_notify-validate";
                req.ContentLength = query.Length;

                // Write the request back IPN strings
                StreamWriter stOut = new StreamWriter(req.GetRequestStream(), Encoding.ASCII);
                stOut.Write(query);
                stOut.Close();

                // Send the request, read the response
                HttpWebResponse strResponse = (HttpWebResponse)req.GetResponse();
                Stream IPNResponseStream = strResponse.GetResponseStream();
                Encoding encode = Encoding.GetEncoding("utf-8");
                StreamReader readStream = new StreamReader(IPNResponseStream, encode);
                string respons = readStream.ReadToEnd();
                PayPalUtility pdt = PayPalUtility.Parse(respons);

                if (respons.StartsWith("SUCCESS"))
                {
                    string OrderID = pdt.Custom;
                    string FirstName = pdt.PayerFirstName;
                    string LastName = pdt.PayerLastName;
                    string Payment_Gross = pdt.GrossTotal.ToString();
                    string CurrencyType = pdt.Currency.ToString();
                    string Payment_Status = pdt.PaymentStatus;
                    string Payment_fee = pdt.PaymentFee.ToString();
                    string CustomerID = pdt.transaction_subject;
                    string Payer_Email = pdt.PayerEmail;
                    string Transaction_ID = pdt.TransactionId;
                    string Receiver_ID = pdt.receiver_id;
                    string Tax = pdt.tax;

                    Label1.Text = "Thank you for your payment. Your transaction has been completed, and a receipt for your purchase has been emailed to you."
                }
                else if (respons.StartsWith("FAIL"))
                {
                    Label1.Text = "Payment failed due to some unknown reason.";
                }
                readStream.Close();
                strResponse.Close();
            }
            catch (Exception ex)
            {
                Label1.Text = "Server error";
            }
        }
    }
}