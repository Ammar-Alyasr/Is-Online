using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

public partial class Default3 : System.Web.UI.Page
{

    veritabani vtb = new veritabani();
    
    public bool siteEkle(string siteAd, string url, string controlSuresi)
    {
        try
        {
            bool snc = false;
            string gelenmsj = konrolEt(TextBox2.Text);

            if (gelenmsj == "OK")
            {
                var sql = vtb.GetDataSet("INSERT INTO siteler (siteAd, siteURL, controlSuresi, siteDurum2, zaman, userID) values  ('" + TextBox1.Text + "' , '" + TextBox2.Text + "', '" + DropDownList1.Text + "' ,'" + gelenmsj + "', '" + DateTime.Now.ToString() + "', '" + Session["UserID"] + "' ) ");
                uyari1.show("Bilgi", TextBox2.Text + " Eklendi");
                if (sql != null)
                {
                    snc = true;
                }

                return snc;
            }

            else if (gelenmsj == "Hatali Giris")
            {
                uyari1.show("Hata", "Yanlis Bir URL Girdiniz , Tekrar Deneyin....");
                snc = false;
                return snc;
            }

            else
            {
                var sql = vtb.GetDataSet("INSERT INTO siteler (siteAd, siteURL, controlSuresi, siteDurum2, zaman, userID) values  ('" + TextBox1.Text + "' , '" + TextBox2.Text + "', '" + DropDownList1.Text + "' ,'" + gelenmsj + "', '" + DateTime.Now.ToString() + "', '" + Session["UserID"] + "' ) ");

                if (sql != null)
                {
                    uyari1.show("Hata", "Girdiğiniz URL Bozuk ya da kapalı bir Siteye Aittir, Siteyi Konterol Etmeyi Unutmayınız!!  ");
                    snc = true;
                }

                return snc;

            }
           
        }
        catch (Exception exe)
        {
            Send("ammar.ahmet@gmail.com", exe.ToString(), "Site ekle Fonks.", "Site Eklemede ", Session["Isim"].ToString());
            return false;
        }

    }
 

    void GuncelSitelereekle()
    {
        string gelenmsj= konrolEt(TextBox2.Text);
        if (gelenmsj != "Hatali Giris")
        {
            var sql = vtb.cmd("insert into GuncelSiteler (siteDurum2, zaman) values('" + gelenmsj + "' , '" + DateTime.Now.ToString() + "' ) ");

        }
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        try
        {
            GuncelSitelereekle();

            if (TextBox1.Text != "" || TextBox2.Text != "")
            {
                if (siteEkle(TextBox1.Text, TextBox2.Text, DropDownList1.Text) == true)
                {

                }

            }

            else
            {
                uyari1.show("Hata", " bos veri girilmez...");

            }
        }
        catch (Exception exe)
        {
            Send("ammar.ahmet@gmail.com", exe.ToString(), "Site ekle Fonks.", "Site Eklemede ", Session["Isim"].ToString());
            
        }


    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        uyari1.show("hata", "HATALI GİRİŞ");
    }

    /// <summary>
    /// Bu fonksnda, yeni eklenen url hemen control edip gelen msji Guncel Sitelere eklenecek ve daha sonra o Guncel Siteler msji 
    /// karsilastirmada bize yardimci olacaktir....
    /// </summary>
    /// <param name="gelenURL"></param>
    /// <returns></returns>
    public string konrolEt(string gelenURL)   
    {
        HttpWebResponse response = null;
        string donus = "";
        try
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(gelenURL);
            request.Method = "GET";

            response = (HttpWebResponse)request.GetResponse();

            donus = response.StatusCode.ToString();
            //Label1.Text = response.StatusCode.ToString();
        }
        catch (WebException ex)
        {
            if (ex.Status == WebExceptionStatus.ProtocolError)
            {

                response = (HttpWebResponse)ex.Response;

                donus = ("Errorcode: {0}" + (int)response.StatusCode);
                //Label1.Text = ("Errorcode: {0}" + (int)response.StatusCode);

            }
            else
            {
                donus = "Hata; URL Adresinde Bir Yanlis olabilir mi).... " + "<br />" + ("Error: {0}" + ex.Status);
                // Label1.Text = ("Error: {0}" + ex.Status);
            }

        }

        catch (Exception ext)
        {
            ext.Message.Clone();
            donus = "Hatali Giris";
            //Label1.Text = "hatali";
        }
        finally
        {
            if (response != null)
            {
                response.Close();
            }
        }
        return (donus);
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        //DropDownList1.SelectedIndex = 2;
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