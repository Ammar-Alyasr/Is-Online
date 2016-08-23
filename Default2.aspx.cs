﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
public partial class Default2 : System.Web.UI.Page
{
    KontrolEt ktrl = new KontrolEt();
    veritabani vtb = new veritabani();
    SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8GG3N5D;Initial Catalog=sites;Integrated Security=SSPI;MultipleActiveResultSets=True");

    veritabani vtab = new veritabani();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"] != null)
            {
                SqlDataSource1.SelectCommand = "Select Siteler.* , users.userAdSoyad , users.userID from Siteler inner join users on Siteler.userID=users.userID where users.userID= '" + Session["UserID"].ToString() + "' ";

            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
        catch (Exception exe)
        {
            ktrl.Send("ammar.ahmet@gmail.com", exe.ToString(), "loading", "Anasyfa", Session["Isim"].ToString());
            baglanti.Close();
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
            baglanti.Close();
        }
        

    }
    void Guncelle2(string gelenID)
    {
        try
        {
            string sql = "SELECT *  FROM Siteler where siteID= '" + gelenID + "' ";
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

        catch (Exception exe)
        {
            ktrl.Send("ammar.ahmet@gmail.com", exe.ToString(), "Ilk satirlada ", "Anasyfa", Session["Isim"].ToString());
            baglanti.Close();
        }

#pragma warning disable CS0162 // Unreachable code detected
        // baglanti.Close();
#pragma warning restore CS0162 // Unreachable code detected
    }

    void DrmuGncle(string parameter, string where)
    {
        try
        {
            var sql = ("UPDATE Siteler SET siteDurum2 =@siteDurum, zaman=@simdi where siteID=@siteid");
            if (baglanti.State == System.Data.ConnectionState.Closed)
                baglanti.Open();

            SqlCommand kmt1 = new SqlCommand(sql, baglanti);
            kmt1.Parameters.AddWithValue("@siteDurum", parameter);
            kmt1.Parameters.AddWithValue("@siteid", where);
            kmt1.Parameters.AddWithValue("@simdi", DateTime.Now.ToString()); //2 Ağu Sal  Saat Ö: 14:16 "d MMM ddd  Saa't' t: HH:mm"
            kmt1.ExecuteNonQuery();

        }

        catch(Exception exe)
        {
            ktrl.Send("ammar.ahmet@gmail.com", exe.ToString(), "Veritabani", "Anasyfa", Session["Isim"].ToString());
            baglanti.Close();
        }

        

    }
    void DrmuGncle2(string parameter, string where)
    {
        try
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

        catch (Exception exe)
        {
            ktrl.Send("ammar.ahmet@gmail.com", exe.ToString(), "Veritabani", "Anasyfa", Session["Isim"].ToString());
            baglanti.Close();
        }



    }

    public bool yapilanDegisiklik(string siteID, string userID, string zaman, string degisik)
    {
        bool snc = false;
        var sql = vtb.GetDataSet("INSERT INTO Degisiklikler (siteID, userID, zaman, GosterilenDegisiklik) values  ('" + siteID + "' , '" + userID + "', '" + zaman + "' ,'" + degisik + "' ) ");
        if (sql != null)
        {
            snc = true;
        }
        return snc;

    }

}