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
	public class grupoutilizador_b4c : IErrorMessage
	{
		//
		private b4c_message _message;
		public long Message_Res { get { return _message.msg_res; } set { _message.msg_res = value; } }
		public long Message_ErrNum { get { return _message.msg_errnum; } set { _message.msg_errnum = value; } }
		public string Message_ErrMsg { get { return _message.msg_errmsg; } set { _message.msg_errmsg = value; } }
		//
		public grupoutilizador_b4c()
		{
			_message = new b4c_message();
		}
		public List<dbdata_grupoutilizador_b4c> Grupo_LerRanking(long idgrupo,long numeroutilizadores)
		{
			//Pre-Logic
			if (idgrupo < 1) { Message_Res = -1; Message_ErrNum = -1; Message_ErrMsg = "grupo<=0"; return null; }
			if (numeroutilizadores < 1) { Message_Res = -1; Message_ErrNum = -1; Message_ErrMsg = "numeroutilizadores<=0"; return null; }
			//
			List<dbdata_grupoutilizador_b4c> _temp = new List<dbdata_grupoutilizador_b4c>();
			try
			{
				// SQL calls to the stored Procedures
				SqlConnection sqlcon = new SqlConnection(b4c_global.ConnectionString);
				SqlCommand sqlcmd = new SqlCommand("Grupo_LerRanking", sqlcon);
				sqlcmd.CommandType = CommandType.StoredProcedure;
				sqlcmd.Parameters.Add("@idgrupo", SqlDbType.BigInt).Value = idgrupo;
				sqlcmd.Parameters.Add("@numeroutilizadores", SqlDbType.BigInt).Value = numeroutilizadores;
				sqlcmd.Parameters.Add("@res", SqlDbType.BigInt).Direction = ParameterDirection.Output;
				sqlcmd.Parameters.Add("@sql_errnum", SqlDbType.BigInt).Direction = ParameterDirection.Output;
				sqlcmd.Parameters.Add("@sql_errmsg", SqlDbType.VarChar, 192).Direction = ParameterDirection.Output;
				sqlcon.Open();
				SqlDataReader sqldr = sqlcmd.ExecuteReader();
				// sqlcmd.ExecuteNonQuery();
				while (sqldr.Read())
				{
					dbdata_grupoutilizador_b4c _tempru = new dbdata_grupoutilizador_b4c();
					_tempru.Ipk = Convert.ToInt64(sqldr["ipk"]);
					_tempru.IdGrupo = idgrupo;
					_tempru.Pontos = Convert.ToInt64(sqldr["pontos"]);
					_tempru.NomeGrupo = sqldr["nomegrupo"].ToString();
					_tempru.NomeUtilizador = sqldr["nomeutilizador"].ToString();
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
				Debug.WriteLine("Ler Ranking Grupo : Exception " + e.Message);
				// If we got here, something happend but we don't know exactly WHAT
				Message_Res = -1; Message_ErrNum = -1; Message_ErrMsg = "Unspecified error has occurred!"; _temp = null;
			}
			return _temp;
		}
		public List<dbdata_grupoutilizador_b4c> Grupo_ListarUtilizadores(long idgrupo)
		{
			// Pre-Logic
			if (idgrupo < 1) { Message_Res = -1;Message_ErrNum = -1;Message_ErrMsg = "grupo<=0";return null;}
			//
			List<dbdata_grupoutilizador_b4c> _temp = new List<dbdata_grupoutilizador_b4c>();
			try
			{
				// SQL calls to the stored Procedures
				SqlConnection sqlcon = new SqlConnection(b4c_global.ConnectionString);
				SqlCommand sqlcmd = new SqlCommand("Grupo_ListarUtilizadores", sqlcon);
				sqlcmd.CommandType = CommandType.StoredProcedure;
				sqlcmd.Parameters.Add("@idgrupo", SqlDbType.BigInt).Value = idgrupo;
				sqlcmd.Parameters.Add("@res", SqlDbType.BigInt).Direction = ParameterDirection.Output;
				sqlcmd.Parameters.Add("@sql_errnum", SqlDbType.BigInt).Direction = ParameterDirection.Output;
				sqlcmd.Parameters.Add("@sql_errmsg", SqlDbType.VarChar, 192).Direction = ParameterDirection.Output;
				sqlcon.Open();
				SqlDataReader sqldr = sqlcmd.ExecuteReader();
				while (sqldr.Read())
				{
					dbdata_grupoutilizador_b4c _tempru = new dbdata_grupoutilizador_b4c();
					_tempru.Ipk = Convert.ToInt64(sqldr["ipk"]);
					_tempru.NomeGrupo = sqldr["nomegrupo"].ToString();
					_tempru.NomeUtilizador = sqldr["nomeutilizador"].ToString();
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
				Debug.WriteLine("Ler Utilizadores Grupo : Exception " + e.Message);
				// If we got here, something happend but we don't know exactly WHAT
				Message_Res = -1; Message_ErrNum = -1; Message_ErrMsg = "Unspecified error has occurred!"; _temp = null;
			}
			return _temp;
		}
		public List<dbdata_grupoutilizador_b4c> Utilizador_ListarGrupos(long uid)
		{
			// Pre-Logic
			if (uid < 1) { Message_Res = -1; Message_ErrNum = -1; Message_ErrMsg = "uid<=0"; return null; }
			//
			List<dbdata_grupoutilizador_b4c> _temp = new List<dbdata_grupoutilizador_b4c>();
			try
			{
				// SQL calls to the stored Procedures
				SqlConnection sqlcon = new SqlConnection(b4c_global.ConnectionString);
				SqlCommand sqlcmd = new SqlCommand("Utilizador_ListarGrupos", sqlcon);
				sqlcmd.CommandType = CommandType.StoredProcedure;
				sqlcmd.Parameters.Add("@uid", SqlDbType.BigInt).Value = uid;
				sqlcmd.Parameters.Add("@res", SqlDbType.BigInt).Direction = ParameterDirection.Output;
				sqlcmd.Parameters.Add("@sql_errnum", SqlDbType.BigInt).Direction = ParameterDirection.Output;
				sqlcmd.Parameters.Add("@sql_errmsg", SqlDbType.VarChar, 192).Direction = ParameterDirection.Output;
				sqlcon.Open();
				SqlDataReader sqldr = sqlcmd.ExecuteReader();
				while (sqldr.Read())
				{
					dbdata_grupoutilizador_b4c _tempru = new dbdata_grupoutilizador_b4c();
					_tempru.Ipk = Convert.ToInt64(sqldr["ipk"]);
					_tempru.Uid = uid;
					_tempru.IdGrupo = Convert.ToInt64(sqldr["idgrupo"]);
					_tempru.NomeGrupo = sqldr["nomegrupo"].ToString();
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
				Debug.WriteLine("LerGruposUtilizador : Exception " + e.Message);
				// If we got here, something happend but we don't know exactly WHAT
				Message_Res = -1; Message_ErrNum = -1; Message_ErrMsg = "Unspecified error has occurred!";_temp=null;
			}
			return _temp;
		}
	}
}