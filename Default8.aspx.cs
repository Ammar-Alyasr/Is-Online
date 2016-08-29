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
    veritabani vtab = new veritabani();
    public class SiteHareket {
        public string sid { get; set; }
        public string sad { get; set; }
        public string tarih { get; set; }
        public string Aciklama { get; set; }

    }
    protected void Page_Load(object sender, EventArgs e)
    {

       //Literal2.Text= "<div class=\"auto - style1\">< button type = \"button\" class=\"btn btn-info btn-lg\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">Action<span class=\"caret\"></span></button><ul class=\"dropdown-menu\"> <li><a href = \"#\" > Ayarlarini Değiştir</a></li><li><a href = \"#\" > Istatistikler </ a ></ li >< li role=\"separator\" class=\"divider\"></li><li><a href = \"#\" > < asp:Label ID = \"Label1\" runat=\"server\" class=\"label label-danger\" Text=\"Kaldır\"></asp:Label></a></li></ul></div>";
        if (!IsPostBack) {
            ilk_gelis();
        }

    }
    public void ilk_gelis() {
        listele();
       //iframe();
    }
    public void iframe() {

        string url = "https://getbootstrap.com/";
        Literal1.Text = " <iframe id=\"frame\" width=\"680\" height='360' class='embed-responsive-item' src='" + url+ "' frameborder='0' allowfullscreen'></iframe>";
            
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
                st.Aciklama = icon + "<br/> " + durum;
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