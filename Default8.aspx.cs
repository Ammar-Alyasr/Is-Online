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
    //SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8GG3N5D;Initial Catalog=sites;Integrated Security=SSPI;MultipleActiveResultSets=True");
    //KontrolEt ktr = new KontrolEt();
    veritabani vtab = new veritabani();
    public class SiteHareket {
        public string sid { get; set; }
        public string sad { get; set; }
        public string tarih { get; set; }
        public string Aciklama { get; set; }

    }
    protected void Page_Load(object sender, EventArgs e)
    {

        //try
        //{
        //    string sql = "SELECT Degisiklikler.zaman ,Degisiklikler.GosterilenDegisiklik , Siteler.siteID ,Siteler.siteDurum2,Siteler.siteAd FROM Degisiklikler INNER JOIN Siteler on   Degisiklikler.siteID=Siteler.siteID WHERE Degisiklikler.siteID='" + Session["siteid"] + "' ORDER BY Degisiklikler.zaman DESC ";
        //    SqlCommand Command = new SqlCommand(sql, baglanti);

        //    SqlDataAdapter da = new SqlDataAdapter(Command);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    KapListe.DataSource = dt;
        //    KapListe.DataBind();
        //    baglanti.Close();
        //}
        //catch (Exception ext)
        //{
        //    ktr.Send("ammar.ahmet@gmail.com", ext.ToString(), "Sayfa detalinde", "Degiskenler", Session["Isim"].ToString());
        //    baglanti.Close();
        //}
        if (!IsPostBack) {
            ilk_gelis();
        }

    }
    public void ilk_gelis() {
        listele();
       // iframe();
    }
    public void iframe() {

        string url = "http://mu.edu.tr/";
        Literal1.Text = " <iframe id=\"frame\" width=\"680\" height='360' class='if' src='"+url+"'></iframe>";

    }


    public string siteURLGetir(string sid)
    {
        string st = "";
        string sad = vtab.GetDataCell("Select siteURL FROM Siteler Where siteID=" + sid + "");
        st = sad.ToString();
        return st;
    }
    public void listele() {
        string sid = Session["siteid"].ToString();
        DataTable dt = vtab.GetDataTable("Select * FROM Degisiklikler WHERE siteID=" + sid + "");

        List<SiteHareket> siteler = new List<SiteHareket>();

        if (dt.Rows.Count > 0) {
            foreach (DataRow dr in dt.Rows) {
                SiteHareket st = new SiteHareket();
                st.sid = dr["siteID"].ToString();
                st.sad = siteAdiGetir(sid);
                st.tarih = dr["zaman"].ToString();
                string durum = dr["GosterilenDegisiklik"].ToString();
                string icon = "";
                icon = "<span class='label label-danger'><span class='glyphicon  glyphicon-arrow-down'></span> Down</span>";
                if (durum == "OK") {
                    icon = "<span class='label label-success'><span class='glyphicon glyphicon-arrow-up'></span> Up</span>";
                }
                st.Aciklama = durum + " " + icon;
                siteler.Add(st);
            }
            siteler = siteler.OrderBy(p => p.sad).ToList();

            KapListe.DataSource = siteler;
            KapListe.DataBind();
        }
        string url= siteURLGetir(sid);
        
        Literal1.Text = " <iframe id=\"frame\" width=\"680\" height='360' class='if' src='" + url + "'></iframe>";

    }
    public string siteAdiGetir(string sid) {
        string st = "";
        string sad = vtab.GetDataCell("Select siteAd FROM Siteler Where siteID=" + sid + "");
        st = sad.ToString();
        return st;
    }


    protected void KapListe_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}