﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MarinaRemake.Data;
using MarinaRemake.Utility;

/// <summary>
/// Register page created by Evan Tucker for Team7 ASP.NET Lab 2. This page takes the user information from the form, and inputs into the database/Data source
/// </summary>

namespace MarinaRemake.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void MarinaSource_Inserting(object sender, EntityDataSourceChangingEventArgs e)
        {
            var customer = (Customer)e.Entity;
            var password = Util.Encrypt(customer.Password);

            // Set password to hashed password
            customer.Password = password;
        }

        protected void MarinaSource_Inserted(object sender, EntityDataSourceChangedEventArgs e)
        {
            var customer = (Customer)e.Entity;

            // If customer is null, then they weren't successfully inserted.
            if (customer != null)
                Response.Redirect("Login.aspx");
            else
                Response.Redirect("Register.aspx");
        }
    }
}