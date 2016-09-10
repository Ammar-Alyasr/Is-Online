using System;

using System.Net;
using System.IO;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Mail;
using System.Data;

public partial class Default4 : System.Web.UI.Page
{
    KontrolEt ktrl = new KontrolEt();
    veritabani vtb = new veritabani();
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
        var dr = vtb.GetDataRow("SELECT *  FROM Siteler where siteID= '" + gelenID + "' ");
        DataTable dtt = vtb.GetDataTable("select * from GuncelSiteler");

        string vriTbndanGlnURL = dr["siteURL"].ToString();
        string htaMsji = ktrl.konrolEt(vriTbndanGlnURL);

        if (dtt.Rows.Count > 0)
        {
            foreach (DataRow ddr in dtt.Rows)
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
        }

    }


    void DrmuGncle(string parameter, string where)
    {
        try
        {
            vtb.cmd("UPDATE Siteler SET siteDurum2 ='" + parameter + "', zaman='" + DateTime.Now.ToString() + "' where siteID='" + where + "'");
        }

        catch (Exception exe)
        {
            ktrl.Send("ammar.ahmet@gmail.com", exe.ToString(), "Veritabani", "Anasyfa", Session["Isim"].ToString());
        }



    }

    void DrmuGncle2(string parameter, string where)
    {
        try
        {
            vtb.cmd("UPDATE GuncelSiteler SET siteDurum2 ='" + parameter + "', zaman='" + DateTime.Now.ToString() + "' where siteID='" + where + "'");

        }

        catch (Exception exe)
        {
            ktrl.Send("ammar.ahmet@gmail.com", exe.ToString(), "Veritabani", "Anasyfa", Session["Isim"].ToString());
        }



    }

    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// 


    protected void Timer1_Tick(object sender, EventArgs e)
    {
        DataTable ddt= vtb.GetDataTable("select * from Siteler");

      

        if (ddt.Rows.Count > 0)
        {
            foreach (DataRow dr in ddt.Rows)
            {
                string sonGnclme = dr["zaman"].ToString();
                string suAn = DateTime.Now.ToString();

                TimeSpan fark = DateTime.Parse(suAn).Subtract(DateTime.Parse(sonGnclme));

                string a = Convert.ToString(fark);
                string b = dr["controlSuresi"].ToString();

                if (b == "1 DK")
                {
                    b = "00:01:00";
                }
                else if (b == "1 SAAT")
                {
                    b = "01:00:00";
                }
                else if (b == "5 DK")
                {
                    b = "00:05:00";
                }
                else if (b == "1 GUN")
                {
                    b = "23:00:00";
                }
                else if (b == "Passiv")
                {
                    break;
                }
                TimeSpan vark = TimeSpan.Parse(a);
                TimeSpan contrlS = TimeSpan.Parse(b);


                if (vark > contrlS)
                {
                    Guncelle2(dr["siteID"].ToString());
                }

                else
                {
                    Label2.Text += "<br />" + " no";
                }
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