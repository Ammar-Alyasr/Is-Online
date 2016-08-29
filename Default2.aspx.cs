﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Data;

public partial class Default2 : System.Web.UI.Page
{
    KontrolEt ktrl = new KontrolEt();
    veritabani vtb = new veritabani();

    class Listele
    {
        public string siteAd { get; set; }
        public string siteID { get; set; }
        public string siteURL { get; set; }
        public string siteDurum2 { get; set; }
        public string zaman { get; set; }

    }

    /// <summary>
    /// Butonlar calisimiyor......
    /// </summary>
    void sirala()
    {

        DataTable dt = vtb.GetDataTable("Select Siteler.* , users.userAdSoyad , users.userID from Siteler inner join users on Siteler.userID=users.userID where users.userID= '" + Session["UserID"].ToString() + "' ");
        List<Listele> siteBilgileri = new List<Listele>();
        if (dt.Rows.Count > 0)
        {
            foreach(DataRow dr in dt.Rows)
            {
                Listele birSite = new Listele();

                birSite.siteID = dr["siteID"].ToString();
                
                birSite.siteURL = dr["siteURL"].ToString();
                birSite.zaman = dr["zaman"].ToString();
                birSite.siteAd = dr["siteAd"].ToString();
                string durum = birSite.siteDurum2 = dr["siteDurum2"].ToString();
                string icon = "";
                
                if (dr["controlSuresi"].ToString() == "Passiv")
                {
                    icon = "<span class='label label-danger lable-lg'> Passiv </span>";
                    birSite.siteDurum2= icon;
                }

                else
                {
                    birSite.siteDurum2 = dr["siteDurum2"].ToString();
                }
                

                siteBilgileri.Add(birSite);
                
            }
            KapListe.DataSource = siteBilgileri;
            KapListe.DataBind();
        }
        
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        
        try
        {
            if (Session["UserID"] != null)
            {
                sirala();
                //SqlDataSource1.SelectCommand = "Select Siteler.* , users.userAdSoyad , users.userID from Siteler inner join users on Siteler.userID=users.userID where users.userID= '" + Session["UserID"].ToString() + "' ";

            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
        catch (Exception exe)
        {
            ktrl.Send("ammar.ahmet@gmail.com", exe.ToString(), "loading", "Anasyfa", Session["Isim"].ToString());
          
        }
        
    
    }
    protected void KapListe_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        Button btn = (Button)sender;
        
        string a = btn.CommandArgument;
        Session["siteid"] = a;
        Response.Redirect("Default8.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            Guncelle2(btn.CommandArgument);
            
        }
        catch (Exception exe)
        {
            ktrl.Send("ammar.ahmet@gmail.com", exe.ToString(), "Botun Tiklandiiginda", "Anasyfa", Session["Isim"].ToString());
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
            foreach(DataRow ddr in dtt.Rows)
            {

                if (gelenID == ddr["siteID"].ToString())
                {
                    if (htaMsji == ddr["siteDurum2"].ToString())
                    {

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

        catch(Exception exe)
        {
            ktrl.Send("ammar.ahmet@gmail.com", exe.ToString(), "Veritabani", "Anasyfa", Session["Isim"].ToString());
        }

        

    }
    void DrmuGncle2(string parameter, string where)
    {
        try
        {
            vtb.cmd("UPDATE GuncelSiteler SET siteDurum2 ='"+parameter+"', zaman='"+DateTime.Now.ToString()+"' where siteID='"+where+"'");
            
        }

        catch (Exception exe)
        {
            ktrl.Send("ammar.ahmet@gmail.com", exe.ToString(), "Veritabani", "Anasyfa", Session["Isim"].ToString());
        }



    }

    void yapilanDegisiklik(string siteID, string userID, string zaman, string degisik)
    {
        
        var sql = vtb.cmd("INSERT INTO Degisiklikler (siteID, userID, zaman, GosterilenDegisiklik) values  ('" + siteID + "' , '" + userID + "', '" + zaman + "' ,'" + degisik + "' ) ");

    }

}