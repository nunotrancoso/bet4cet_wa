/*
* This is a personal academic project. Dear PVS-Studio, please check it.
* PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
*/

#define LOG

using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using b4c_classes;

namespace bet4cet_wa
{
	public partial class login_web : System.Web.UI.Page
	{
		private List<string> log_string = new List<string>();
		private int lang = (int)b4c_lang.pt_pt;
		protected void Page_Load(object sender, EventArgs e)
		{
			#if LOG
			stc_util_b4c.AddToWebLog(log_string, "Login WebPage - Page Load");
			#endif
			string title = b4c_global.site_title + " - Login ";
			lit_title.Text = "<title>" + title + "</title>";
			btn_login.Text = b4c_intl.site_trans[lang, (int)b4c_text.login];
			lit_register.Text = "<a href=\"/user/register/web_register.aspx\">" + b4c_intl.site_trans[lang, (int)b4c_text.register] + "</a>";
			#if LOG
			// Write WebLog if any
			lit_weblog.Text = stc_util_b4c.WriteWebLog(log_string);
			#endif
		}
		protected void Page_Init(object sender, EventArgs e)
		{
			// Standard Init code, copy/paste/adjust on every page
			#if LOG
			// Log where we are
			stc_util_b4c.AddToWebLog(log_string, "Login WebPage - Page Init");
			#endif
			// Check if we are logged in or not, act accordingly
			if (Session["islogged"] != null)
			{
				// We are. This is login page, we shouldn't be here, redirect to the correct landing page
			}
			else
			{
				if (IsPostBack)
				{
					#if LOG
					// Log it, dev only
					stc_util_b4c.AddToWebLog(log_string, "Postback");
					if (Request.Params["__EVENTTARGET"] != null) { stc_util_b4c.AddToWebLog(log_string, "[__EVENTTARGET] - " + Request.Params["__EVENTTARGET"].ToString()); }
					if (Request.Params["__EVENTARGUMENT"] != null) { stc_util_b4c.AddToWebLog(log_string, "[__EVENTARGUMENT] - " + Request.Params["__EVENTARGUMENT"].ToString()); }
					#endif
					// Is Facebook Login being triggered?
					if ((Request.Params["__EVENTTARGET"] != null) && (Request.Params["__EVENTARGUMENT"] != null)&&(Request.Params["__EVENTTARGET"].ToString() == "FBLOGIN"))
					{
						// It is, let's try and complete it
						string fbstring = ""; string fbuid = ""; string fbuname = "";
						fbstring = Request.Params["__EVENTARGUMENT"].ToString(); string[] fbstringarray = fbstring.Split('_');
						// We should have two elements in the array now
						if (fbstringarray.Length == 2)
						{
							fbuid = fbstringarray[0]; fbuname = fbstringarray[0];
							// We use the FB UID as email, so treat is as a "virtual" email
							fbuid += "@facebook.com";
							// Let's try to login then...
						}
					}
				}
			}
		}

		protected void btn_login_Click(object sender, EventArgs e)
		{
			#if LOG
				Debug.WriteLine(hf_hashpass.Value.ToString());
			#endif
		}
	}
}