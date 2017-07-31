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
		// Dataclasses that represent the DB tables data structures
		/*********************************************************/
		/*        All data acess through Properties only         */
		/*********************************************************/
	}
	public class dbdata_utilizador_b4c
	{
		/* [ipk],[uid],[gid],[email],[pswd],[uname],[datanascimento],[dataregisto] */
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
		public dbdata_utilizador_b4c() : this(-1,-1,-1,"","","", DateTime.MinValue, DateTime.MinValue){}
		public dbdata_utilizador_b4c(long ipk,long uid,long gid,string email,string pswd,string uname,DateTime datanascimento,DateTime dataregisto)
		{
			Ipk = ipk; Uid = uid; Gid = gid; Email = email; Pswd = pswd; Uname = uname;
			DataNascimento = datanascimento; DataRegisto = dataregisto;
		}
		public dbdata_utilizador_b4c(dbdata_utilizador_b4c obj)
		{
			Ipk = obj.Ipk; Uid = obj.Uid; Gid = obj.Gid; Email = obj.Email; Pswd = obj.Pswd; Uname = obj.Uname;
			DataNascimento = obj.DataNascimento; DataRegisto = obj.DataRegisto;
		}
		public bool CheckData()
		{
			if ((Ipk > 0) && (Uid > 0) && (Gid > 0) && (!string.IsNullOrEmpty(Email))
				&& (!string.IsNullOrEmpty(Pswd)) && (!string.IsNullOrEmpty(Uname)) && (DataNascimento!=null) && (DataRegisto != null))
			{ return true; }
			else { return false; }
		}
	}
	//
	public class dbdata_paginainicial_b4c
	{
		/* [ipk],[gid],[paginainicial] */
		//
		private long _ipk, _gid;
		private string _paginainicial;
		//
		public long Ipk { get { return _ipk; } set { _ipk = value; } }
		public long Gid { get { return _gid; } set { _gid = value; } }
		public string PaginaInicial { get { return _paginainicial; } set { _paginainicial = value; } }
		//
		public dbdata_paginainicial_b4c() : this(-1,-1,""){}
		public dbdata_paginainicial_b4c(long ipk, long gid, string paginainicial)
		{
			Ipk = ipk; Gid = gid; PaginaInicial = paginainicial;
		}
		public dbdata_paginainicial_b4c(dbdata_paginainicial_b4c obj)
		{
			Ipk = obj.Ipk; Gid = obj.Gid; PaginaInicial = obj.PaginaInicial;
		}
		public bool CheckData()
		{
			if ((Ipk > 0) && (Gid > 0) && (!string.IsNullOrEmpty(PaginaInicial)))
			{ return true; }
			else { return false; }
		}
	}
	//
	public class dbdata_grupoutilizador_b4c
	{
		/* [ipk],[idgrupo],[uid],[pontos] */
		/* [nomegrupo],[nomeutilizador] */
		//
		private long _ipk, _idgrupo, _uid,_pontos;
		private string _nomegrupo, _nomeutilizador;
		//
		public long Ipk { get { return _ipk; } set { _ipk = value; } }
		public long IdGrupo { get { return _idgrupo; } set { _idgrupo = value; } }
		public long Uid { get { return _uid; } set { _uid = value; } }
		public long Pontos { get { return _pontos; } set { _pontos = value; } }
		public string NomeGrupo { get { return _nomegrupo; } set { _nomegrupo = value; } }
		public string NomeUtilizador { get { return _nomeutilizador; } set { _nomeutilizador = value; } }
		//
		public dbdata_grupoutilizador_b4c() : this(-1,-1,-1,-1,"", ""){}
		public dbdata_grupoutilizador_b4c(long ipk, long idgrupo, long uid, long pontos, string nomegrupo,string nomeutilizador)
		{
			Ipk = ipk; IdGrupo = idgrupo; Uid = uid; Pontos = pontos;
			NomeGrupo = nomegrupo; NomeUtilizador = nomeutilizador;
		}
		public dbdata_grupoutilizador_b4c(dbdata_grupoutilizador_b4c obj)
		{
			Ipk = obj.Ipk; IdGrupo = obj.IdGrupo; Uid = obj.Uid; Pontos = obj.Pontos;
			NomeGrupo = obj.NomeGrupo; NomeUtilizador = obj.NomeUtilizador;
		}
		public bool CheckData()
		{
			if ((Ipk > 0) && (IdGrupo > 0) && (Uid>0) && (Pontos>=0))
			{ return true; }
			else { return false; }
		}
	}
	//
	public class dbdata_grupo_b4c
	{
		/* [ipk],[idgrupo],[nome],[datacriacao],[idadmin],[activo] */
		//
		private long _ipk, _idgrupo;
		private string _nome;
		private DateTime _datacriacao;
		private long _idadmin;
		private Int32 _activo;
		//
		public long Ipk { get { return _ipk; } set { _ipk = value; } }
		public long IdGrupo { get { return _idgrupo; } set { _idgrupo = value; } }
		public string Nome { get { return _nome; } set { _nome = value; } }
		public DateTime DataCriacao { get { return _datacriacao; } set { _datacriacao = value; } }
		public long IdAdmin { get { return _idadmin; } set { _idadmin = value; } }
		public Int32 Activo { get { return _activo; } set { _activo = value; } }
		//
		public dbdata_grupo_b4c() : this(-1,-1,"",DateTime.MinValue,-1,-1){}
		public dbdata_grupo_b4c(long ipk, long idgrupo, string nomegrupo, DateTime datacriacao, long idadmin, Int32 activo)
		{
			Ipk = ipk; IdGrupo = idgrupo; Nome = nomegrupo; DataCriacao = datacriacao; IdAdmin=idadmin; Activo = activo;
		}
		public dbdata_grupo_b4c(dbdata_grupo_b4c obj)
		{
			Ipk = obj.Ipk; IdGrupo = obj.IdGrupo; Nome = obj.Nome; DataCriacao = obj.DataCriacao;
			IdAdmin = obj.IdAdmin; Activo = obj.Activo;
		}
		public bool CheckData()
		{
			if ((Ipk > 0) && (IdGrupo > 0) && (!string.IsNullOrEmpty(Nome)) &&(Equals(DataCriacao,DateTime.MinValue)) && (IdAdmin > 0) && (Activo >= 0))
			{ return true; }
			else { return false; }
		}
	}
	//
	public class dbdata_grupocampeonato_b4c
	{
		/* [ipk],[idgrupo],[idcampeonato] */
		//
		private long _ipk, _idgrupo,_idcampeonato;
		//
		public long Ipk { get { return _ipk; } set { _ipk = value; } }
		public long IdGrupo { get { return _idgrupo; } set { _idgrupo = value; } }
		public long IdCampeonato { get { return _idcampeonato; } set { _idcampeonato = value; } }
		//
		public dbdata_grupocampeonato_b4c() : this(-1,-1,-1){}
		public dbdata_grupocampeonato_b4c(long ipk, long idgrupo, long idcampeonato)
		{
			Ipk = ipk; IdGrupo = idgrupo; IdCampeonato=idcampeonato;
		}
		public dbdata_grupocampeonato_b4c(dbdata_grupocampeonato_b4c obj)
		{
			Ipk = obj.Ipk; IdGrupo = obj.IdGrupo; IdCampeonato = obj.IdCampeonato;
		}
		public bool CheckData()
		{
			if ((Ipk > 0) && (IdGrupo > 0) && (IdCampeonato > 0))
			{ return true; }
			else { return false; }
		}
	}
	//
	public class dbdata_campeonato_b4c
	{
		/* [ipk],[idcampeonato],[idpais],[idtipocampeonato] */
		//
		private long _ipk, _idcampeonato,_idpais,_idtipocampeonato;
		//
		public long Ipk { get { return _ipk; } set { _ipk = value; } }
		public long IdCampeonato { get { return _idcampeonato; } set { _idcampeonato = value; } }
		public long IdPais { get { return _idpais; } set { _idpais = value; } }
		public long IdTipoCampeonato { get { return _idtipocampeonato; } set { _idtipocampeonato = value; } }
		//
		public dbdata_campeonato_b4c() : this(-1,-1,-1,-1){}
		public dbdata_campeonato_b4c(long ipk, long idcampeonato, long idpais, long idtipocampeonato)
		{
			Ipk = ipk; IdCampeonato = idcampeonato; IdPais = idpais; IdTipoCampeonato = idtipocampeonato;
		}
		public dbdata_campeonato_b4c(dbdata_campeonato_b4c obj)
		{
			Ipk = obj.Ipk; IdCampeonato = obj.IdCampeonato; IdPais = obj.IdPais; IdTipoCampeonato = obj.IdTipoCampeonato;
		}
		public bool CheckData()
		{
			if ((Ipk > 0) && (IdCampeonato > 0) && (IdPais > 0) && (IdTipoCampeonato > 0))
			{ return true; }
			else { return false; }
		}
	}
	//
	public class dbdata_tipocampeonato_b4c
	{
		/* [ipk],[idtipocampeonato],[descricao] */
		//
		private long _ipk,_idtipocampeonato;
		private string _descricao;
		//
		public long Ipk { get { return _ipk; } set { _ipk = value; } }
		public long IdTipoCampeonato { get { return _idtipocampeonato; } set { _idtipocampeonato = value; } }
		public string Descricao { get { return _descricao; } set { _descricao = value; } }
		//
		public dbdata_tipocampeonato_b4c() : this(-1,-1,""){}
		public dbdata_tipocampeonato_b4c(long ipk,long idtipocampeonato,string descricao)
		{
			Ipk = ipk; IdTipoCampeonato = idtipocampeonato; Descricao = descricao;
		}
		public dbdata_tipocampeonato_b4c(dbdata_tipocampeonato_b4c obj)
		{
			Ipk = obj.Ipk; IdTipoCampeonato = obj.IdTipoCampeonato; Descricao = obj.Descricao;
		}
		public bool CheckData()
		{
			if ((Ipk > 0) && (IdTipoCampeonato > 0) && (!string.IsNullOrEmpty(Descricao)))
			{ return true; }
			else { return false; }
		}
	}
	//
	public class dbdata_pais_b4c
	{
		/* [ipk],[idpais],[idzonageo],[fifa],[iso3] */
		//
		private long _ipk, _idpais,_idzonageo;
		private string _fifa,_iso3;
		//
		public long Ipk { get { return _ipk; } set { _ipk = value; } }
		public long IdPais { get { return _idpais; } set { _idpais = value; } }
		public long IdZonaGeo { get { return _idzonageo; } set { _idzonageo = value; } }
		public string Fifa { get { return _fifa; } set { _fifa = value; } }
		public string Iso3 { get { return _iso3; } set { _iso3 = value; } }
		//
		public dbdata_pais_b4c() : this(1,-1,-1,"",""){}
		public dbdata_pais_b4c(long ipk, long idpais,long idzonageo, string fifa,string iso3)
		{
			Ipk = ipk; IdPais = idpais; IdZonaGeo = idzonageo; Fifa = fifa; Iso3 = iso3;
		}
		public dbdata_pais_b4c(dbdata_pais_b4c obj)
		{
			Ipk = obj.Ipk; IdPais = obj.IdPais; IdZonaGeo = obj.IdZonaGeo; Fifa = obj.Fifa; Iso3 = obj.Iso3;
		}
		public bool CheckData()
		{
			if ((Ipk > 0) && (IdPais > 0) && (IdZonaGeo > 0) && (!string.IsNullOrEmpty(Fifa)) && (!string.IsNullOrEmpty(Iso3)))
			{ return true; }
			else { return false; }
		}
	}
	//
	public class dbdata_zonageo_b4c
	{
		/* [ipk],[idzonageo],[lang],[nome] */
		//
		private long _ipk, _idzonageo,_lang;
		private string _nome;
		//
		public long Ipk { get { return _ipk; } set { _ipk = value; } }
		public long IdZonaGeo { get { return _idzonageo; } set { _idzonageo = value; } }
		public long Lang { get { return _lang; } set { _lang = value; } }
		public string Nome { get { return _nome; } set { _nome = value; } }
		//
		public dbdata_zonageo_b4c() : this(-1, -1, -1, ""){}
		public dbdata_zonageo_b4c(long ipk, long idzonageo, long lang, string nome)
		{
			Ipk = ipk; IdZonaGeo = idzonageo; Lang = lang; Nome = nome;
		}
		public dbdata_zonageo_b4c(dbdata_zonageo_b4c obj)
		{
			Ipk = obj.Ipk; IdZonaGeo = obj.IdZonaGeo; Lang = obj.Lang; Nome = obj.Nome;
		}
		public bool CheckData()
		{
			if ((Ipk > 0) && (IdZonaGeo > 0) && (Lang >= 0) && (!string.IsNullOrEmpty(Nome)))
			{ return true; }
			else { return false; }
		}
	}
	//
	public class dbdata_aposta_b4c
	{
		/* [ipk],[idaposta],[uid],[idjogo],[data],[golos1],[golos2],[pontos] */
		//
		private long _ipk, _idaposta, _uid, _idjogo;
		private DateTime _data;
		private long _golos1, _golos2, _pontos;
		//
		public long Ipk { get { return _ipk; } set { _ipk = value; } }
		public long IdAposta { get { return _idaposta; } set { _idaposta = value; } }
		public long Uid { get { return _uid; } set { _uid = value; } }
		public long IdJogo { get { return _idjogo; } set { _idjogo = value; } }
		public DateTime Data { get { return _data; } set { _data = value; } }
		public long Golos1 { get { return _golos1; } set { _golos1 = value; } }
		public long Golos2 { get { return _golos2; } set { _golos2 = value; } }
		public long Pontos { get { return _pontos; } set { _pontos = value; } }
		//
		public dbdata_aposta_b4c() : this(-1,-1,-1,-1, DateTime.MinValue , -1,-1,-1){}
		public dbdata_aposta_b4c(long ipk, long idaposta, long uid,long idjogo,DateTime data,long golos1,long golos2,long pontos)
		{
			Ipk = ipk; IdAposta = idaposta; Uid = uid; IdJogo = idjogo;Data = data;Golos1 = golos1;Golos2 = golos2; Pontos = pontos;
		}
		public dbdata_aposta_b4c(dbdata_aposta_b4c obj)
		{
			Ipk = obj.Ipk; IdAposta = obj.IdAposta; Uid = obj.Uid; IdJogo = obj.IdJogo; Data = obj.Data; Golos1 = obj.Golos1;
			Golos2 = obj.Golos2; Pontos = obj.Pontos;
		}
		public bool CheckData()
		{
			if ((Ipk > 0) && (IdAposta > 0) && (Uid > 0)&&(IdJogo > 0) && (Equals(this.Data,DateTime.MinValue)) && (Golos1 >= 0) && (Golos2 >= 0) && (Pontos >= 0))
			{ return true; }
			else { return false; }
		}
	}
	//
	public class dbdata_jogo_b4c
	{
		/* [ipk],[idjogo],[idcampeonato],[ideq1],[ideq2],[data],[golos1],[golos2],[estado] */
		//
		private long _ipk, _idjogo, _idcampeonato, _ideq1,_ideq2;
		private DateTime _data;
		private long _golos1, _golos2, _estado;
		//
		public long Ipk { get { return _ipk; } set { _ipk = value; } }
		public long IdJogo { get { return _idjogo; } set { _idjogo = value; } }
		public long IdCampeonato { get { return _idcampeonato; } set { _idcampeonato = value; } }
		public long IdEquipa1 { get { return _ideq1; } set { _ideq1 = value; } }
		public long IdEquipa2 { get { return _ideq2; } set { _ideq2 = value; } }
		public DateTime Data { get { return _data; } set { _data = value; } }
		public long Golos1 { get { return _golos1; } set { _golos1 = value; } }
		public long Golos2 { get { return _golos2; } set { _golos2 = value; } }
		public long Estado { get { return _estado; } set { _estado = value; } }
		//
		public dbdata_jogo_b4c() : this(-1,-1,-1,-1,-1, DateTime.Now, -1, -1, -1) { }
		public dbdata_jogo_b4c(long ipk, long idjogo, long idcampeonato, long ideq1,long ideq2, DateTime data, long golos1, long golos2, long estado)
		{
			Ipk = ipk; IdJogo = idjogo; IdCampeonato = idcampeonato; IdEquipa1 = ideq1; IdEquipa2 = ideq2; Data = data;
			Golos1 = golos1; Golos2 = golos2; Estado = estado;
		}
		public dbdata_jogo_b4c(dbdata_jogo_b4c obj)
		{
			Ipk = obj.Ipk; IdJogo = obj.IdJogo; IdCampeonato = obj.IdCampeonato; IdEquipa1 = obj.IdEquipa1; IdEquipa2 = obj.IdEquipa2;
			Data = obj.Data; Golos1 = obj.Golos1; Golos2 = obj.Golos2; Estado = obj.Estado;
		}
		public bool CheckData()
		{
			if ((Ipk > 0) && (IdJogo > 0) && (IdCampeonato > 0)&&(IdEquipa1>0) && (IdEquipa2 > 0) &&(Data!=null)&&(Estado>0))
			{ return true; } else { return false; }
		}
	}
	//
	public class dbdata_equipa_b4c
	{
		/* [ipk],[idequipa],[idpais] */
		//
		private long _ipk,_idequipa, _idpais;
		//
		public long Ipk { get { return _ipk; } set { _ipk = value; } }
		public long IdEquipa { get { return _idequipa; } set { _idequipa = value; } }
		public long IdPais { get { return _idpais; } set { _idpais = value; } }
		//
		public dbdata_equipa_b4c() : this(-1,-1,-1) { }
		public dbdata_equipa_b4c(long ipk, long idequipa, long idpais)
		{
			Ipk = ipk; IdEquipa = idequipa; IdPais = idpais;
		}
		public dbdata_equipa_b4c(dbdata_equipa_b4c obj)
		{
			Ipk = obj.Ipk; IdEquipa = obj.IdEquipa; IdPais = obj.IdPais;
		}
		public bool CheckData()
		{
			if ((Ipk > 0) && (IdEquipa > 0) && (IdPais > 0)) { return true; } else { return false; }
		}
	}
}