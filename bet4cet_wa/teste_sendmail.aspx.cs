using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using b4c_classes;
using System.Diagnostics;

namespace bet4cet_wa
{
	public partial class teste_sendmail : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Debug.WriteLine(b4c_SendMail.SendMailPub(new string[] { "erazerpt@gmail.com",b4c_SendMail.mailhostuser}, "teste numero 2", "testedosendmail depois de alteracoes"));
		}
	}
}