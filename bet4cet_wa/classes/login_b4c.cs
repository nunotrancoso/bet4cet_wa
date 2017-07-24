using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;

namespace b4c_classes
{
	public class login_b4c
	{
		private dbdata_utilizador_b4c _user; private string _email, _pswd;
		public login_b4c(dbdata_utilizador_b4c user,string email, string pswd){ _user = user; _email = email;_pswd = pswd;}
		public b4c_message DoLogin()
		{
			// Standard b4c message passing structure
			b4c_message msg = new b4c_message();
			// Pre-flight checks on data
			if (!(stc_util_b4c.IsValidEmail(_email)))
			{
				msg.msg_res = -1; msg.msg_errnum = -2; msg.msg_errmsg = "Email not valid!";
				return msg;
			}
			else
			{
				if (string.IsNullOrEmpty(_email))
				{
					msg.msg_res = -1; msg.msg_errnum = -2; msg.msg_errmsg = "Email is empty!";
					return msg;
				}
				else
				{
					if (_email.Substring(_email.Length - 13, 13) != "@facebook.com")
					{
						// we need pswd if not coming from FB!
						if (string.IsNullOrEmpty(_pswd))
						{
							msg.msg_res = -1; msg.msg_errnum = -3; msg.msg_errmsg = "Password is empty!";
							return msg;
						}
					}
					else
					{
						// coming from FB, "make" the password
						//string _pswd=
					}
				}
			}
			// SQL call to the stored Procedure

			// If we got here, something happend but we don't know exactly WHAT
			msg.msg_res = -1; msg.msg_errnum = -1; msg.msg_errmsg = "Unspecified error has occurred!";
			return msg;
		}
	}
}