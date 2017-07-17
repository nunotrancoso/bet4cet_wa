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

namespace bet4cet_wa.masterpages
{
	public partial class web_mp : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Debug.WriteLine("Web MasterPage - Page Load");
		}
		protected void Page_Init(object sender, EventArgs e)
		{
			Debug.WriteLine("Web MasterPage - Page Init");
		}
	}
}