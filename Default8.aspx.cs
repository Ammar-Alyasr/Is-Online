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
    KontrolEt ktr = new KontrolEt();
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
            ktr.Send("ammar.ahmet@gmail.com", ext.ToString(), "Sayfa detalinde", "Degiskenler", Session["Isim"].ToString());
            baglanti.Close();
        }

    }

}