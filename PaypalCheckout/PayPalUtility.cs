using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.VisualBasic;

namespace PaypalCheckout
{
    public class PayPalUtility
    {
        public double GrossTotal
        {
            get { return m_GrossTotal; }
            set { m_GrossTotal = value; }
        }
        private double m_GrossTotal;
        public int InvoiceNumber
        {
            get { return m_InvoiceNumber; }
            set { m_InvoiceNumber = value; }
        }
        private int m_InvoiceNumber;
        public string PaymentStatus
        {
            get { return m_PaymentStatus; }
            set { m_PaymentStatus = value; }
        }
        private string m_PaymentStatus;
        public string PayerFirstName
        {
            get { return m_PayerFirstName; }
            set { m_PayerFirstName = value; }
        }
        private string m_PayerFirstName;
        public double PaymentFee
        {
            get { return m_PaymentFee; }
            set { m_PaymentFee = value; }
        }
        private double m_PaymentFee;
        public string BusinessEmail
        {
            get { return m_BusinessEmail; }
            set { m_BusinessEmail = value; }
        }
        private string m_BusinessEmail;
        public string PayerEmail
        {
            get { return m_PayerEmail; }
            set { m_PayerEmail = value; }
        }
        private string m_PayerEmail;
        public string TxToken
        {
            get { return m_TxToken; }
            set { m_TxToken = value; }
        }
        private string m_TxToken;
        public string PayerLastName
        {
            get { return m_PayerLastName; }
            set { m_PayerLastName = value; }
        }
        private string m_PayerLastName;
        public string ReceiverEmail
        {
            get { return m_ReceiverEmail; }
            set { m_ReceiverEmail = value; }
        }
        private string m_ReceiverEmail;
        public string ItemName
        {
            get { return m_ItemName; }
            set { m_ItemName = value; }
        }
        private string m_ItemName;
        public string Currency
        {
            get { return m_Currency; }
            set { m_Currency = value; }
        }
        private string m_Currency;
        public string TransactionId
        {
            get { return m_TransactionId; }
            set { m_TransactionId = value; }
        }
        private string m_TransactionId;
        public string SubscriberId
        {
            get { return m_SubscriberId; }
            set { m_SubscriberId = value; }
        }
        private string m_SubscriberId;
        public string Custom
        {
            get { return m_Custom; }
            set { m_Custom = value; }
        }
        private string m_Custom;
        public string payer_id
        {
            get { return m_payer_id; }
            set { m_payer_id = value; }
        }
        private string m_payer_id;
        public string receiver_id
        {
            get { return m_receiver_id; }
            set { m_receiver_id = value; }
        }
        private string m_receiver_id;
        public string tax
        {
            get { return m_tax; }
            set { m_tax = value; }
        }
        private string m_tax;
        public string payer_status
        {
            get { return m_payer_status; }
            set { m_payer_status = value; }
        }
        private string m_payer_status;
        public string payment_fee
        {
            get { return m_payment_fee; }
            set { m_payment_fee = value; }
        }
        private string m_payment_fee;

        public string transaction_subject
        {
            get { return m_transaction_subject; }
            set { m_transaction_subject = value; }
        }
        private string m_transaction_subject;

        public static PayPalUtility Parse(string postData)
        {
            string sKey = null;
            string sValue = null;
            PayPalUtility ph = new PayPalUtility();

            try
            {
                //split response into string array using whitespace delimeter
                string[] StringArray = postData.Split(ControlChars.Lf);

                // NOTE:
                //
                //                * loop is set to start at 1 rather than 0 because first
                //                string in array will be single word SUCCESS or FAIL
                //                Only used to verify post data
                //                


                // use split to split array we already have using "=" as delimiter
                int i = 0;
                for (i = 1; i <= StringArray.Length - 2; i++)
                {
                    String[] StringArray1 = StringArray[i].Split('=');

                    sKey = StringArray1[0];
                    sValue = HttpUtility.UrlDecode(StringArray1[1]);

                    // set string vars to hold variable names using a switch
                    switch (sKey)
                    {
                        case "mc_gross":
                            ph.GrossTotal = Convert.ToDouble(sValue);
                            break; // TODO: might not be correct. Was : Exit Select


                            break;
                        case "invoice":
                            ph.InvoiceNumber = Convert.ToInt32(sValue);
                            break; // TODO: might not be correct. Was : Exit Select


                            break;
                        case "payment_status":
                            ph.PaymentStatus = Convert.ToString(sValue);
                            break; // TODO: might not be correct. Was : Exit Select


                            break;
                        case "first_name":
                            ph.PayerFirstName = Convert.ToString(sValue);
                            break; // TODO: might not be correct. Was : Exit Select


                            break;
                        case "mc_fee":
                            ph.PaymentFee = Convert.ToDouble(sValue);
                            break; // TODO: might not be correct. Was : Exit Select


                            break;
                        case "business":
                            ph.BusinessEmail = Convert.ToString(sValue);
                            break; // TODO: might not be correct. Was : Exit Select


                            break;
                        case "payer_email":
                            ph.PayerEmail = Convert.ToString(sValue);
                            break; // TODO: might not be correct. Was : Exit Select


                            break;
                        case "Tx Token":
                            ph.TxToken = Convert.ToString(sValue);
                            break; // TODO: might not be correct. Was : Exit Select


                            break;
                        case "last_name":
                            ph.PayerLastName = Convert.ToString(sValue);
                            break; // TODO: might not be correct. Was : Exit Select


                            break;
                        case "receiver_email":
                            ph.ReceiverEmail = Convert.ToString(sValue);
                            break; // TODO: might not be correct. Was : Exit Select


                            break;
                        case "item_name":
                            ph.ItemName = Convert.ToString(sValue);
                            break; // TODO: might not be correct. Was : Exit Select


                            break;
                        case "mc_currency":
                            ph.Currency = Convert.ToString(sValue);
                            break; // TODO: might not be correct. Was : Exit Select


                            break;
                        case "txn_id":
                            ph.TransactionId = Convert.ToString(sValue);
                            break; // TODO: might not be correct. Was : Exit Select


                            break;
                        case "custom":
                            ph.Custom = Convert.ToString(sValue);
                            break; // TODO: might not be correct. Was : Exit Select


                            break;
                        case "subscr_id":
                            ph.SubscriberId = Convert.ToString(sValue);
                            break; // TODO: might not be correct. Was : Exit Select

                            break;
                        case "payer_id":
                            ph.payer_id = Convert.ToString(sValue);
                            break; // TODO: might not be correct. Was : Exit Select

                            break;
                        case "receiver_id":
                            ph.receiver_id = Convert.ToString(sValue);
                            break; // TODO: might not be correct. Was : Exit Select

                            break;
                        case "tax":
                            ph.tax = Convert.ToString(sValue);
                            break; // TODO: might not be correct. Was : Exit Select

                            break;
                        case "payer_status":
                            ph.payer_status = Convert.ToString(sValue);
                            break; // TODO: might not be correct. Was : Exit Select

                            break;
                        case "payment_fee":
                            ph.payment_fee = Convert.ToString(sValue);
                            break; // TODO: might not be correct. Was : Exit Select

                            break;
                        case "transaction_subject":
                            ph.transaction_subject = Convert.ToString(sValue);
                            break; // TODO: might not be correct. Was : Exit Select

                            break;
                    }

                }

                return ph;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}