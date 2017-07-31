/*
* This is a personal academic project. Dear PVS-Studio, please check it.
* PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

namespace bet4cet_wa
{
	interface IErrorMessage
	{
		long Message_Res { get; set; }
		long Message_ErrNum { get; set; }
		string Message_ErrMsg { get; set; }
	}
	public class utilizador_b4c : IErrorMessage
	{
		//
		private b4c_message _message;
		public long Message_Res	{ get {	return _message.msg_res; } set { _message.msg_res = value; } }
		public long Message_ErrNum { get { return _message.msg_errnum; } set { _message.msg_errnum = value; } }
		public string Message_ErrMsg { get { return _message.msg_errmsg; } set { _message.msg_errmsg = value; } }
		//
		private dbdata_utilizador_b4c _user;
		public long Ipk { get { return _user.Ipk; }}
		public long Uid { get { return _user.Uid; }}
		public long Gid { get { return _user.Gid; }}
		public string Email { get { return _user.Email; }}
		public string Pswd { get { return _user.Pswd; }}
		public string Uname { get { return _user.Uname; }}
		public DateTime DataNascimento { get { return _user.DataNascimento; }}
		public DateTime DataRegisto { get { return _user.DataRegisto; }}
		//
		public utilizador_b4c(string email, string pswd)
		{
			_user = new dbdata_utilizador_b4c();
			_message = new b4c_message();
			_user.Email= email;
			_user.Pswd = pswd;
		}
		//
		public bool LoginUtilizador(string email, string pswd)
		{
			// Standard b4c message passing structure
			b4c_message msg = new b4c_message();
			// Pre-flight checks on data
			if (!(stc_util_b4c.IsValidEmail(_user.Email)))
			{ // We can't do this check on SQL server side, so we MUST prevent invalid emails HERE
				Message_Res = -1; Message_ErrNum = -2; Message_ErrMsg = "Email not valid!"; return false;
			}
			else
			{
				if (string.IsNullOrEmpty(_user.Email))
				{ Message_Res = -1; Message_ErrNum = -2; Message_ErrMsg = "Email is empty!"; return false; }
				else
				{
					if (_user.Email.Substring(_user.Email.Length - 13, 13) != "@facebook.com")
					{ // we need pswd if not coming from FB!
						if (string.IsNullOrEmpty(_user.Pswd))
						{ Message_Res = -1; Message_ErrNum = -3; Message_ErrMsg = "Password is empty!"; return false; }
						else
						{ // Stored password is the MD5 of email + the received md5 hash of the password
							_user.Pswd = security_b4c_md5.StringToMD5(_user.Email+_user.Pswd);
						}
					}
					else
					{ // coming from FB, "make" the password
						_user.Pswd = security_b4c_md5.StringToMD5(_user.Email);
					}
				}
			}
			// We have a email and a password, so, proceed to try and get a user out of it
			// We can assume user exists because the page MUST have already checked it

			// SQL calls to the stored Procedures
			try
			{
				// Are the Login Credentials right?
				SqlConnection sqlcon = new SqlConnection(b4c_global.ConnectionString);
				SqlCommand sqlcmd = new SqlCommand("Utilizador_Login", sqlcon);
				sqlcmd.CommandType = CommandType.StoredProcedure;
				sqlcmd.Parameters.Add("@email", SqlDbType.VarChar, 128).Value = _user.Email;
				sqlcmd.Parameters.Add("@pswd", SqlDbType.VarChar, 32).Value = _user.Pswd = pswd;
				sqlcmd.Parameters.Add("@res", SqlDbType.BigInt).Direction = ParameterDirection.Output;
				sqlcmd.Parameters.Add("@sql_errnum", SqlDbType.BigInt).Direction = ParameterDirection.Output;
				sqlcmd.Parameters.Add("@sql_errmsg", SqlDbType.VarChar, 192).Direction = ParameterDirection.Output;
				sqlcon.Open();
				sqlcmd.ExecuteNonQuery();
				Message_Res = Convert.ToInt64(sqlcmd.Parameters["@res"].Value);
				Message_ErrNum = Convert.ToInt64(sqlcmd.Parameters["@sql_errnum"].Value);
				Message_ErrMsg = (sqlcmd.Parameters["@sql_errmsg"].Value).ToString();
				sqlcon.Close();
				return true;
			}
			catch (Exception e)
			{
				// Output the Exception
				Debug.WriteLine("LoginUtilizador : Exception " + e.Message);
				// If we got here, something happend but we don't know exactly WHAT
				Message_Res = -1; Message_ErrNum = -1; Message_ErrMsg = "Unspecified error has occurred!";
				return false;
			}
		}
		public bool VerificarUtilizadorEmail()
		{
			// Pre-flight checks on data
			if (!(stc_util_b4c.IsValidEmail(_user.Email)))
			{ Message_Res = -1; Message_ErrNum = -2; Message_ErrMsg = "Email inválido."; return false; }
			else
			{
				if (string.IsNullOrEmpty(_user.Email))
				{ Message_Res = -1; Message_ErrNum = -2; Message_ErrMsg = "Email vazio."; return false; }
			}
			// SQL calls to the stored Procedures
			try
			{
				// Does user exist?
				SqlConnection sqlcon = new SqlConnection(b4c_global.ConnectionString);
				SqlCommand sqlcmd = new SqlCommand("Utilizador_VerificarEmail", sqlcon);
				sqlcmd.CommandType = CommandType.StoredProcedure;
				sqlcmd.Parameters.Add("@email", SqlDbType.VarChar, 128).Value = _user.Email;
				sqlcmd.Parameters.Add("@res", SqlDbType.BigInt).Direction = ParameterDirection.Output;
				sqlcmd.Parameters.Add("@sql_errnum", SqlDbType.BigInt).Direction = ParameterDirection.Output;
				sqlcmd.Parameters.Add("@sql_errmsg", SqlDbType.VarChar, 192).Direction = ParameterDirection.Output;
				sqlcon.Open();
				sqlcmd.ExecuteNonQuery();
				Message_Res = Convert.ToInt64(sqlcmd.Parameters["@res"].Value);
				Message_ErrNum = Convert.ToInt64(sqlcmd.Parameters["@sql_errnum"].Value);
				Message_ErrMsg = (sqlcmd.Parameters["@sql_errmsg"].Value).ToString();
				sqlcon.Close();
				return true;
			}
			catch (Exception e)
			{
				// Output the Exception
				Debug.WriteLine("VerificarUtilizadorEmail : Exception " + e.Message);
				// If we got here, something happend but we don't know exactly WHAT
				Message_Res = -1; Message_ErrNum = -1; Message_ErrMsg = "Unspecified error has occurred!";
				return false;
			}
		}
		//
		public List<dbdata_utilizador_b4c> ListarUtilizadores()
		{
			//
			List<dbdata_utilizador_b4c> _temp = new List<dbdata_utilizador_b4c>();
			try
			{
				// SQL calls to the stored Procedures
				SqlConnection sqlcon = new SqlConnection(b4c_global.ConnectionString);
				SqlCommand sqlcmd = new SqlCommand("Utilizador_Listar", sqlcon);
				sqlcmd.CommandType = CommandType.StoredProcedure;
				sqlcmd.Parameters.Add("@res", SqlDbType.BigInt).Direction = ParameterDirection.Output;
				sqlcmd.Parameters.Add("@sql_errnum", SqlDbType.BigInt).Direction = ParameterDirection.Output;
				sqlcmd.Parameters.Add("@sql_errmsg", SqlDbType.VarChar, 192).Direction = ParameterDirection.Output;
				sqlcon.Open();
				SqlDataReader sqldr = sqlcmd.ExecuteReader();
				// sqlcmd.ExecuteNonQuery();
				while (sqldr.Read())
				{
					/* [ipk],[uid],[gid],[email],[uname],[datanascimento],[dataregisto] */
					dbdata_utilizador_b4c _tempru = new dbdata_utilizador_b4c();
					_tempru.Ipk = Convert.ToInt64(sqldr["ipk"]);
					_tempru.Uid = Convert.ToInt64(sqldr["uid"]);
					_tempru.Gid = Convert.ToInt64(sqldr["gid"]);
					_tempru.Email = sqldr["email"].ToString();
					_tempru.Uname = sqldr["uname"].ToString();
					_tempru.DataNascimento = Convert.ToDateTime(sqldr["datanascimento"]);
					_tempru.DataRegisto = Convert.ToDateTime(sqldr["dataregisto"]);
					_temp.Add(_tempru);
				}
				sqlcon.Close();
				Message_Res = Convert.ToInt64(sqlcmd.Parameters["@res"].Value);
				Message_ErrNum = Convert.ToInt64(sqlcmd.Parameters["@sql_errnum"].Value);
				Message_ErrMsg = (sqlcmd.Parameters["@sql_errmsg"].Value).ToString();
			}
			catch (Exception e)
			{
				// Output the Exception
				Debug.WriteLine("ListarUtilizadores : Exception " + e.Message);
				// If we got here, something happend but we don't know exactly WHAT
				Message_Res = -1; Message_ErrNum = -1; Message_ErrMsg = "Unspecified error has occurred!"; _temp = null;
			}
			return _temp;
		}
	}
}