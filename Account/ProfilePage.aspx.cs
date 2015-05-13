using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProfilePage : System.Web.UI.Page
{
    DatabaseEntities de = new DatabaseEntities();
    ProfileTable pt = new ProfileTable();

    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme=Session["th"].ToString();
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Account/Login");
        }
        else
        {
            if (!IsPostBack)
            {
                var result = from p in de.ProfileTables
                             where p.userName == User.Identity.Name
                             select p;

                foreach (var r in result)
                {
                    TextBox1.Text = r.firstName;
                    TextBox2.Text = r.lastName;
                    TextBox3.Text = r.email;
                    TextBox4.Text = r.mobile;
                    TextBox5.Text = r.userAddress;
                }
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var result = from p in de.ProfileTables
                     where p.userName == User.Identity.Name
                     select p;
        if (result.Count() == 1)
        {
            foreach(var r in result)
            {
                r.firstName = TextBox1.Text;
                r.lastName = TextBox2.Text;
                r.email = TextBox3.Text;
                r.mobile = TextBox4.Text;
                r.userAddress = TextBox5.Text;
                de.SaveChanges();
            }
        }
        else
        {
            pt.firstName = TextBox1.Text;
            pt.lastName = TextBox2.Text;
            pt.email = TextBox3.Text;
            pt.mobile = TextBox4.Text;
            pt.userName = User.Identity.Name;
            pt.userAddress = TextBox5.Text;
            de.ProfileTables.Add(pt);
            de.SaveChanges();
        }
       
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["th"] = DropDownList1.Text;
    }
}