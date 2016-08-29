using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Summary description for KontrolEt
/// </summary>
public class KontrolEt
{
    public KontrolEt()
    {
      
    }

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

        }
        catch (WebException ex)
        {
            if (ex.Status == WebExceptionStatus.ProtocolError)
            {

                response = (HttpWebResponse)ex.Response;

                donus = ("Errorcode: " + (int)response.StatusCode);


            }
            else
            {
                donus = "Hata; Internet Baglanitiniz Yok Veya URL Adresinde Bir Yanlis olabilir ).... " + "<br />" + ("HataKodu: " + ex.Status);

            }

        }

        catch (Exception ext)
        {
            ext.Message.Clone();
            donus = "Hatali Giris";
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

    public void Send(string to, string Durum, string Adi, string url, string Songuncelleme)
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

                //Send("ammar.ahmet@gmail.com", "Email Gondermede hata olustu", ext.InnerException.ToString(), "", "");

            }
        }
    }
}