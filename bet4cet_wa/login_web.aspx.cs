/*
* This is a personal academic project. Dear PVS-Studio, please check it.
* PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
*/
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace bet4cet_wa
{
	public partial class login_web : System.Web.UI.Page
	{
		private int lang = (int)b4c_lang.pt_pt;
		protected void Page_Load(object sender, EventArgs e)
		{
			Debug.WriteLine("Login WebPage - Page Load");
			string title = b4c_global.site_title + " - Login ";
			lit_title.Text = "<title>" + title + "</title>";
			btn_login.Text = b4c_intl.site_trans[lang, (int)b4c_text.login];
			lit_register.Text = "<a href=\"/user/register/web_register.aspx\">" + b4c_intl.site_trans[lang, (int)b4c_text.register] + "</a>";
		}
		protected void Page_Init(object sender, EventArgs e)
		{
			Debug.WriteLine("Login WebPage - Page Init");
		}

		protected void btn_login_Click(object sender, EventArgs e)
		{
			//Debug.WriteLine(tb_password.Value.ToString());
			Debug.WriteLine(hf_hashpass.Value.ToString());
			string[] a = new string[2];
			a[0] = "SSS"; a[1] = "SSS";
		}
	}
}