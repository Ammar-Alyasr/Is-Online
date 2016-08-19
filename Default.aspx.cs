using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

public partial class _Default : System.Web.UI.Page
{
    veritabani vtab = new veritabani();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
    }

    public bool kullaniciLogin(string kadi, string pass) {
        Session["UserID"] = "";
        Session["Isim"] = "";
        Session["Email"] = "";
        bool snc = false;
      
       var user =  vtab.GetDataRow("SELECT * From users where userEmail ='" + kadi + "' AND userPas='" + pass + "'");
        
        if (user != null) {
            string isim = user["userAdSoyad"].ToString();
            string email = user["userEmail"].ToString();
            string uid2 = user["userID"].ToString();

            Session["UserID"] = uid2;
            Session["Isim"] = isim;
            Session["Email"] = email;
            snc = true;
        }


        return snc;

    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";

            if (kullaniciLogin(TextBox1Em.Text, TextBox1Pas.Text))
            {

                Response.Redirect("Default2.aspx");
            }
            else
            {
                Label1.Visible = true;
                Label1.Text += "<br> HATALI";

            }
        }

        catch (Exception exe)
        {
            Send("ammar.ahmet@gmail.com", exe.ToString(), "Veritabani", "Anasyfa", Session["Isim"].ToString());
           
        }

       
    }

    void Send(string to, string Durum, string Adi, string url, string Songuncelleme)
    {
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.EnableSsl = true;
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential("yaaserhamod@gmail.com", "258025802yaser");

        using (var message = new MailMessage("yaaserhamod@gmail.com", to))
        {
            try
            {
                message.Subject = "Is Online !";
                message.Body = @"<h2>oops , Sitenizden birinde Değişiklik olmuştur ...  </h2><p></p><p>Bilgileri Aşağıda yeralan Site Şu Durumla Karşılaşmıştır: '" + Durum + "' </p> <p></p>Site Adi: '" + Adi + "'  <p></p>Site URL: '" + url + "' <p></p>Site Son Durumu: '" + Durum + "' <p></p>Site Son Güncelleme Zamanı '" + Songuncelleme + "' <p></p><p></p><p></p>  <h1>Iyi Kodalamalar)...</h1>";

                message.IsBodyHtml = true;
                smtp.Send(message);

            }
            catch (Exception ext)
            {

                Send("ammar.ahmet@gmail.com", "Email Gondermede hata olustu", ext.InnerException.ToString(), "", "");
               
            }
        }
    }
}