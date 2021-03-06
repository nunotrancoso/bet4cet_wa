﻿/*
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
			// Setup some page small stuff like title, internationalize text, etc...
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
							fbuid = fbstringarray[0];
							fbuname = fbstringarray[1];
							// Check if FB user already exists
							utilizador_b4c user = new utilizador_b4c(fbuid + "@facebook.com","");
							if (user.VerificarUtilizadorEmail())
							{
								#if LOG
									stc_util_b4c.AddToWebLog(log_string, "Login WebPage - FBLOGIN Postback - res : " + user.Message_Res.ToString() + " sql_errnum : " + user.Message_ErrNum.ToString() + " sql_errmsg : " + user.Message_ErrMsg.ToString());
								#endif
								// If user exists log him in, if not, try to create it
								if (user.Message_Res > 0)
								{
									// User already exists, log him in and redirect to landing page
									Session["islogged"] = "1";
								}
								else
								{
									// User doesn't exist yet, try to create

								}
							}
						}
					}
				}
			}
		}

		protected void btn_login_Click(object sender, EventArgs e)
		{
			// Normal login, let's try and process it
			#if LOG
				Debug.WriteLine(hf_hashpass.Value.ToString());
			#endif
			// Get email from tb
			string _email = tb_username.Text;
			// Get password, which comes as a MD5 hash of the real password through a hf form field hashed on the client side
			// This means we NEVER EVER get to see the real user password. CB sees one hash and DB stores an hash of the hash :)
			// SSL/TLS would be better of course, but still better than no security at all...
			string _pswd = hf_hashpass.Value.ToString();
		}
	}
}