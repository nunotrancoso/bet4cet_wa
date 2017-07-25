using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

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
						string _pswd = security_b4c_md5.StringToMD5(_email);
					}
				}
			}
			// SQL calls to the stored Procedures

			// Does user exist already?
			SqlConnection sqlcon = new SqlConnection(b4c_global.ConnectionString);
			SqlCommand sqlcmd = new SqlCommand("LerUtilizadorEmail", sqlcon);
			sqlcmd.CommandType = CommandType.StoredProcedure;
			sqlcmd.Parameters.Add("@", SqlDbType.VarChar).Value = _email;
			sqlcmd.Parameters.Add("@res", SqlDbType.BigInt).Direction = ParameterDirection.Output;
			sqlcmd.Parameters.Add("@sql_errnum", SqlDbType.BigInt).Direction = ParameterDirection.Output;
			sqlcmd.Parameters.Add("@sql_errmsg", SqlDbType.BigInt).Direction = ParameterDirection.Output;
			sqlcon.Open();
			SqlDataReader sqldr = sqlcmd.ExecuteReader();
			if (sqldr.HasRows)
			{
				sqldr.Read();
				_user.Ipk = Convert.ToInt64(sqldr["uid"]);
				_user.Uid = Convert.ToInt64(sqldr["uid"]);
				_user.Gid = Convert.ToInt64(sqldr["gid"]);
				_user.Ipk = Convert.ToInt64(sqldr["uid"]);
			}
			// If we got here, something happend but we don't know exactly WHAT
			msg.msg_res = -1; msg.msg_errnum = -1; msg.msg_errmsg = "Unspecified error has occurred!";
			return msg;
		}
	}
	public class VerificarUtilizadorEmail_b4c
	{
		private string _email;
		public VerificarUtilizadorEmail_b4c(string email) { _email = email; }
		public b4c_message Check()
		{
			// Standard b4c message passing structure
			b4c_message msg = new b4c_message();
			// Pre-flight checks on data
			if (!(stc_util_b4c.IsValidEmail(_email)))
			{ msg.msg_res = -1; msg.msg_errnum = -2; msg.msg_errmsg = "Email inválido."; return msg; }
			else
			{
				if (string.IsNullOrEmpty(_email))
				{ msg.msg_res = -1; msg.msg_errnum = -2; msg.msg_errmsg = "Email vazio."; return msg; }
			}
			// SQL calls to the stored Procedures
			try
			{
				// Does user exist?
				SqlConnection sqlcon = new SqlConnection(b4c_global.ConnectionString);
				SqlCommand sqlcmd = new SqlCommand("VerificarUtilizadorEmail", sqlcon);
				sqlcmd.CommandType = CommandType.StoredProcedure;
				sqlcmd.Parameters.Add("@email", SqlDbType.VarChar, 128).Value = _email;
				sqlcmd.Parameters.Add("@res", SqlDbType.BigInt).Direction = ParameterDirection.Output;
				sqlcmd.Parameters.Add("@sql_errnum", SqlDbType.BigInt).Direction = ParameterDirection.Output;
				sqlcmd.Parameters.Add("@sql_errmsg", SqlDbType.VarChar, 192).Direction = ParameterDirection.Output;
				sqlcon.Open();
				sqlcmd.ExecuteNonQuery();
				msg.msg_res = Convert.ToInt64(sqlcmd.Parameters["@res"].Value);
				msg.msg_errnum = Convert.ToInt64(sqlcmd.Parameters["@sql_errnum"].Value);
				msg.msg_errmsg = (sqlcmd.Parameters["@sql_errmsg"].Value).ToString();
				sqlcon.Close();
				return msg;
			}
			catch (Exception e)
			{
				// If we got here, something happend but we don't know exactly WHAT
				msg.msg_res = -1; msg.msg_errnum = -1; msg.msg_errmsg = "Unspecified error has occurred!";
				return msg;
			}
		}
	}
}