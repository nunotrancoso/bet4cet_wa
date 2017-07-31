/*
* This is a personal academic project. Dear PVS-Studio, please check it.
* PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace bet4cet_wa
{
	public partial class teste_sendmail : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//Debug.WriteLine(b4c_SendMail.SendMailPub(new string[] { "erazerpt@gmail.com",b4c_SendMail.mailhostuser}, "teste numero 2", "testedosendmail depois de alteracoes"));
			//string _email = "0987654321@facebook.com";
			//Debug.WriteLine(_email.Substring(_email.Length - 13, 13));
			// TODO
			/*
			paginainicial_b4c pi = new paginainicial_b4c();
			List<dbdata_paginainicial_b4c> _temp= pi.LerPaginasIniciaisRawData();
			foreach (dbdata_paginainicial_b4c t in _temp)
			{
				Response.Write("|" + t.Ipk.ToString() + "|" + t.Gid.ToString() + "|" + t.PaginaInicial + "|<br/>");
			}
			*/
			DateTime td=new DateTime();
			Response.Write("Data :" + td.ToLongDateString());
		}
	}
}