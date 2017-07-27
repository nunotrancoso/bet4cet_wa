/*
* This is a personal academic project. Dear PVS-Studio, please check it.
* PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bet4cet_wa
{
	public class dbdata_b4c
	{
		/*[utilizadores](	[ipk] [bigint] IDENTITY(1,1) NOT NULL,  [uid] [bigint] NOT NULL, [gid] [bigint]	NOT NULL,
		  [email] [varchar](128) NOT NULL, [pswd] [char](32) NOT NULL, [uname] [varchar](64) NOT NULL, [datanascimento] [datetime]
				NULL, [dataregisto] [datetime]	NOT NULL, */
	}
	public class dbdata_utilizador_b4c
	{
		//
		private long _ipk, _uid, _gid;
		private string _email, _pswd, _uname;
		private DateTime _datanascimento, _dataregisto;
		//
		public long Ipk { get { return _ipk; } set { _ipk = value; } }
		public long Uid	{ get { return _uid; } set { _uid = value; } }
		public long Gid	{ get {	return _gid; } set { _gid = value; } }
		public string Email { get { return _email; } set { _email = value; } }
		public string Pswd { get { return _pswd; } set { _pswd = value; } }
		public string Uname { get { return _uname; } set { _uname = value; } }
		public DateTime DataNascimento { get { return _datanascimento; } set { _datanascimento = value;	} }
		public DateTime DataRegisto { get { return _dataregisto; } set { _dataregisto = value; } }
		//
		public dbdata_utilizador_b4c() : this(0,0,0,"","","", DateTime.Now, DateTime.Now)
		{
		}
		public dbdata_utilizador_b4c(long ipk,long uid,long gid,string email,string pswd,string uname,DateTime datanascimento,DateTime dataregisto)
		{
			_ipk = ipk;_uid = uid;_gid = gid; _email = email; _pswd = pswd; _uname = uname; _datanascimento = datanascimento;_dataregisto = dataregisto;
		}
		public dbdata_utilizador_b4c(dbdata_utilizador_b4c obj)
		{
			_ipk = obj._ipk; _uid = obj._uid; _gid = obj._gid; _email = obj._email; _pswd = obj._pswd; _uname = obj._uname;
			_datanascimento = obj._datanascimento; _dataregisto = obj._dataregisto;
		}
		//
	}
	public class dbdata_paginainicial_b4c
	{
		//
		private long _ipk, _gid;
		private string _paginainicial;
		//
		public long Ipk { get { return _ipk; } set { _ipk = value; } }
		public long Gid { get { return _gid; } set { _gid = value; } }
		public string PaginaInicial { get { return _paginainicial; } set { _paginainicial = value; } }
		//
		public dbdata_paginainicial_b4c() : this(0, 0,"/login_web.aspx")
		{
		}
		public dbdata_paginainicial_b4c(long ipk, long gid, string paginainicial)
		{
			_ipk = ipk; _gid = gid; _paginainicial = paginainicial;
		}
		public dbdata_paginainicial_b4c(dbdata_paginainicial_b4c obj)
		{
			_ipk = obj._ipk; _gid = obj._gid; _paginainicial = obj._paginainicial;
		}
		//
	}
}