using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaskedTextBox;

namespace OnurAltuntas
{
    public partial class _default : System.Web.UI.Page
    {
        public string[] errorMessages = new string[5];
        public string[] cardImageTypes = new string[5];
        public string selectedCardType = "";
        public string cardNumber = "";
        public bool empty=false;
        protected void Page_Load(object sender, EventArgs e)
        {
            cardImageTypes[0] = "https://image.flaticon.com/icons/svg/196/196561.svg";
            cardImageTypes[1] = "https://image.flaticon.com/icons/svg/217/217449.svg";
            cardImageTypes[2] = "https://image.flaticon.com/icons/svg/349/349221.svg";
            cardImageTypes[3] = "https://image.flaticon.com/icons/svg/196/196548.svg";
            cardImageTypes[4] = "https://cdn3.iconfinder.com/data/icons/credit-cards-pos/2288/dankort_1-512.png";
            
            errorMessages[0]=" Credit card number has an inappropriate number of digits";
        }

        protected void ddlCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCardType = ddlCardType.SelectedIndex.ToString();
            Image1.ImageUrl = cardImageTypes[Int32.Parse(selectedCardType)];
            
        }
        protected void txtCardNumber_TextChanged(object sender, EventArgs e)
        {
            cardNumber = txtCardNumber.Text;
            cardNumber=cardNumber.Replace("-", "");
            cardNumber = cardNumber.Replace("_", "");
            if (cardNumber.ToString() == "")
            {
                empty = true;
            }
        }
        protected bool CheckValidation(string selectedCardType,string cardNumber)
        {
            if (empty == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Not allowed empty Card Number field')", true);
                return true;
            }
       

            if (ddlCardType.SelectedValue.ToString().Trim() =="Dankort")
            {

                if ((cardNumber.Length >=13 && cardNumber.Length <=19) && (cardNumber.StartsWith("5019"))) {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' valid Dankord pay')", true);
                    return true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Non-Valid  Dankord pay')", true);
                    return false;
                }
            }
            else if (ddlCardType.SelectedValue.ToString().Trim() == "MasterCard")
            {
                if ((cardNumber.Length == 16) && (cardNumber.Substring(0, cardNumber.Length - 14) == "51" || cardNumber.Substring(0, cardNumber.Length - 14) == "52" || cardNumber.Substring(0, cardNumber.Length - 14) == "53" || cardNumber.Substring(0, cardNumber.Length - 14) == "54" || cardNumber.Substring(0, cardNumber.Length - 14) == "55"
                    || (Int32.Parse(cardNumber.Substring(0, cardNumber.Length - 10)) >= 222100 && Int32.Parse(cardNumber.Substring(0, cardNumber.Length - 10)) <= 272099)))
                    
                    {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Valid MasterCard')", true);
                    return true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Non-Valid MasterCard')", true);
                    return false;
                }
            }
            else if (ddlCardType.SelectedValue.ToString().Trim() == "Visa Electron")
            {
                if ((cardNumber.Length == 16) && (cardNumber.Substring(0, cardNumber.Length - 12) == "4026" || (cardNumber.Substring(0, cardNumber.Length - 10) == "417500" || (cardNumber.Substring(0, cardNumber.Length - 12) == "4405") 
                    || (cardNumber.Substring(0, cardNumber.Length - 12) == "4508")
                    || (cardNumber.Substring(0, cardNumber.Length - 12) == "4844")
                    || (cardNumber.Substring(0, cardNumber.Length - 12) == "4913")
                    || (cardNumber.Substring(0, cardNumber.Length - 12) == "4917"))))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Visa Electron')", true);
                    return true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Non-Valid Visa Electron')", true);
                    return false;
                }
            }
            else if (ddlCardType.SelectedValue.ToString().Trim() == "Diners Club United States & Canada")
            {
                if ((cardNumber.Length == 16) && (cardNumber.Substring(0, cardNumber.Length - 14) == "54") || (cardNumber.Substring(0, cardNumber.Length - 14) == "55"))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Diners Club United States & Canada is valid')", true);
                    return true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Non-Valid American Express Card')", true);
                    return false;
                }
            }
            else if (ddlCardType.SelectedValue.ToString().Trim() == "China UnionPay")
            {
                if ((cardNumber.Length<=19 && cardNumber.Length>=16) && (cardNumber.StartsWith("62")))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('China UnionPay Card is valid')", true);
                    return true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' Non-Valid China UnionPay Card')", true);
                    return false;
                }
            }
          
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Non-Valid Card Number')", true);
                return false;
            }
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            CheckValidation(selectedCardType, cardNumber);
        }
    }
}