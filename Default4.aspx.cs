using System;

using System.Net;
using System.IO;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Mail;

public partial class Default4 : System.Web.UI.Page
{
    veritabani vtb = new veritabani();
    SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8GG3N5D;Initial Catalog=sites;Integrated Security=SSPI;MultipleActiveResultSets=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    void Guncelle2(string gelenID)
    {
        string sql = "SELECT *  FROM Siteler where siteID= '"+gelenID +"' ";
        string ssql = "select * from GuncelSiteler";
        if (baglanti.State == System.Data.ConnectionState.Closed)
        baglanti.Open();

        SqlCommand kmt = new SqlCommand(sql, baglanti);
        SqlDataReader dr = kmt.ExecuteReader();
        dr.Read();
        string vriTbndanGlnURL = dr["siteURL"].ToString();

        string htaMsji = konrolEt(vriTbndanGlnURL);

        
        SqlCommand kkmt = new SqlCommand(ssql, baglanti);
        SqlDataReader ddr = kkmt.ExecuteReader();
        while (ddr.Read())
         {
             if (gelenID == ddr["siteID"].ToString())
               {
                 if (/*dr["siteDurum2"].ToString() */htaMsji == ddr["siteDurum2"].ToString())
                  {
                    Label2.Text += "<br />" + dr["siteAd"].ToString() + "&nbsp; &nbsp;&nbsp;&nbsp;" + htaMsji;

                    DrmuGncle(htaMsji, dr["siteID"].ToString());
                    
                }

                 else
                   {
                    /// <summary>
                    /// Burada site durumu bir degisiklik gosterdi anlamina geliyor.... Errorcode: {0}500 * 
                    /// </summary>
                    DrmuGncle(htaMsji, dr["siteID"].ToString());
                    DrmuGncle2(htaMsji, ddr["siteID"].ToString());
                   

                    Send(Session["Email"].ToString(), htaMsji, dr["siteAd"].ToString(), dr["siteURL"].ToString(), dr["zaman"].ToString());
                  
                    yapilanDegisiklik(dr["siteID"].ToString(), dr["userID"].ToString(), DateTime.Now.ToString(), htaMsji);

                }
              }

            }

#pragma warning disable CS0162 // Unreachable code detected
       // baglanti.Close();
#pragma warning restore CS0162 // Unreachable code detected
    }


    void DrmuGncle( string parameter, string where )
    {
       

        var sql = ("UPDATE Siteler SET siteDurum2 =@siteDurum, zaman=@simdi where siteID=@siteid");
        if (baglanti.State==System.Data.ConnectionState.Closed)
        baglanti.Open();
        
        SqlCommand kmt1 = new SqlCommand(sql, baglanti);
        kmt1.Parameters.AddWithValue("@siteDurum", parameter);
        kmt1.Parameters.AddWithValue("@siteid", where);
        kmt1.Parameters.AddWithValue("@simdi", DateTime.Now.ToString()); //2 Ağu Sal  Saat Ö: 14:16 "d MMM ddd  Saa't' t: HH:mm"
        kmt1.ExecuteNonQuery();
       
    }

    void DrmuGncle2(string parameter, string where)
    {

        var sql = ("UPDATE GuncelSiteler SET siteDurum2 =@siteDurum, zaman=@simdi where siteID=@siteid");
        if (baglanti.State == System.Data.ConnectionState.Closed)
            baglanti.Open();

        SqlCommand kmt1 = new SqlCommand(sql, baglanti);
        kmt1.Parameters.AddWithValue("@siteDurum", parameter);
        kmt1.Parameters.AddWithValue("@siteid", where);
        kmt1.Parameters.AddWithValue("@simdi", DateTime.Now.ToString()); //2 Ağu Sal  Saat Ö: 14:16
        kmt1.ExecuteNonQuery();

    }

    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// 

         
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        var sql = "SELECT * FROM Siteler where userID='"+Session["UserID"] +"' ";
        SqlConnection.ClearPool(baglanti);
        baglanti.Open();
        SqlCommand kmt = new SqlCommand(sql, baglanti);
        SqlDataReader dr = kmt.ExecuteReader();

        while (dr.Read())
        {
            string sonGnclme = dr["zaman"].ToString();
            string suAn = DateTime.Now.ToString();

            TimeSpan fark = DateTime.Parse(suAn).Subtract(DateTime.Parse(sonGnclme));

            string a=Convert.ToString(fark);
            string b = dr["controlSuresi"].ToString();
            
            if(b== "1 DK")
            {
                b = "00:01:00";
            }
            else if (b== "1 SAAT")
            {
                b = "01:00:00";
            }
            else if(b=="5 DK")
            {
                b = "00:05:00";
            }
            else if(b=="1 GUN")
            {
                b = "23:00:00";
            }
            TimeSpan vark = TimeSpan.Parse(a);
            TimeSpan contrlS = TimeSpan.Parse(b);


            if (vark > contrlS)
            {
                Guncelle2(dr["siteID"].ToString());
            }

       
            else
            {
                Label2.Text += "<br />" +   " no";
            }

        }

    }

    //public Bitmap GenerateScreenshot(string url)
    //{
    //    // This method gets a screenshot of the webpage
    //    // rendered at its full size (height and width)
    //    return GenerateScreenshot(url, -1, -1);
    //}


    void Send(string to,  string Durum , string Adi, string url, string Songuncelleme)
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
                //message.Body = "Oops , '" + url + "' sitesinde bir değişiklik olmuştur, Gidin ve kontorl edin ";
               message.Body= @"<h2>oops , Sitenizden birinde Değişiklik olmuştur ...  </h2><p></p><p>Bilgileri Aşağıda yeralan Site Şu Durumla Karşılaşmıştır: '"+Durum+ "' </p> <p></p>Site Adi: '" + Adi + "'  <p></p>Site URL: '" + url + "' <p></p>Site Son Durumu: '" + Durum + "' <p></p>Site Son Güncelleme Zamanı '" + Songuncelleme+ "' <p></p><p></p><p></p>  <h1>Iyi Kodlamalar)...</h1>";
 
               // message.Body = "Your request is processed.!. Please click on the button to go the website  <a href=http://www.google.com> <img src=http://localhost:57198/image/explorer.png  width=50 height=31 border=0 alt=Click  title=Click ></a> ";
                message.IsBodyHtml = true;
                smtp.Send(message);

            }
            catch (Exception ext)
            {
                 //url = ext.InnerException.ToString();
                 Send("ammar.ahmet@gmail.com","hata olustu", ext.InnerException.ToString(), "","" );
                //Label2.Text= ext.InnerException.ToString();
            }
        }
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
                donus = "Hata; URL Adresinde Bir Yanlis olabilir mi).... " + "<br />"  + ("Error: {0}" + ex.Status);
               // Label1.Text = ("Error: {0}" + ex.Status);
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

    public bool yapilanDegisiklik(string siteID, string userID, string zaman, string degisik)
    {
        bool snc = false;
        var sql = vtb.GetDataSet("INSERT INTO Degisiklikler (siteID, userID, zaman, GosterilenDegisiklik) values  ('" + siteID + "' , '" + userID + "', '" +zaman + "' ,'" + degisik + "' ) ");
        if (sql != null)
        {
            snc = true;
        }
        return snc;

    }



}