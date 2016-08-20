using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default8 : System.Web.UI.Page
{
    SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8GG3N5D;Initial Catalog=sites;Integrated Security=SSPI;MultipleActiveResultSets=True");
   
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string sql = "SELECT Degisiklikler.zaman ,Degisiklikler.GosterilenDegisiklik , Siteler.siteID ,Siteler.siteDurum2,Siteler.siteAd FROM Degisiklikler INNER JOIN Siteler on   Degisiklikler.siteID=Siteler.siteID WHERE Degisiklikler.siteID='" + Session["siteid"] + "' ORDER BY Degisiklikler.zaman DESC ";
            SqlCommand Command = new SqlCommand(sql, baglanti);

            SqlDataAdapter da = new SqlDataAdapter(Command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            KapListe.DataSource = dt;
            KapListe.DataBind();
            baglanti.Close();
        }
        catch (Exception ext)
        {
            Send("ammar.ahmet@gmail.com", ext.ToString(), "Sayfa detalinde", "Degiskenler", Session["Isim"].ToString());
            baglanti.Close();
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
                message.Body = @"<h2>oops , Sitenizden birinde Değişiklik olmuştur ...  </h2><p></p><p>Bilgileri Aşağıda yeralan Site Şu Durumla Karşılaşmıştır: '" + Durum + "' </p> <p></p>Site Adi: '" + Adi + "'  <p></p>Site URL: '" + url + "' <p></p>Site Son Durumu: '" + Durum + "' <p></p>Site Son Güncelleme Zamanı '" + Songuncelleme + "' <p></p><p></p><p></p>  <h1>Iyi Kodlamalar)...</h1>";

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