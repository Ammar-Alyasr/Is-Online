using System;

using System.Net;
using System.IO;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Mail;

public partial class Default4 : System.Web.UI.Page
{
    KontrolEt ktrl = new KontrolEt();
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
        
        string htaMsji = ktrl.konrolEt(vriTbndanGlnURL);

        
        SqlCommand kkmt = new SqlCommand(ssql, baglanti);
        SqlDataReader ddr = kkmt.ExecuteReader();
        while (ddr.Read())
         {
             if (gelenID == ddr["siteID"].ToString())
               {
                 if (htaMsji == ddr["siteDurum2"].ToString())
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
                   

                    ktrl.Send(Session["Email"].ToString(), htaMsji, dr["siteAd"].ToString(), dr["siteURL"].ToString(), dr["zaman"].ToString());
                  
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