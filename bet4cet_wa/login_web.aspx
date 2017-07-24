<%@ Page Language="C#" MasterPageFile="~/masterpages/web_mp.master" AutoEventWireup="true" CodeBehind="login_web.aspx.cs" Inherits="bet4cet_wa.login_web" %>
<asp:Content ID="cnt_tohead" ContentPlaceHolderID="tohead_web" Runat="Server">
	<script src="/js/md5.min.js"></script>
	<script src="/js/facebook.js"></script>
	<asp:Literal ID="lit_title" runat="server"></asp:Literal>
	<!-- FB OG Tags -->
	<meta property="og:url" content="http://www.bet4cet.net">
	<meta property="og:type" content="article">
	<meta property="og:title" content="OG Test">
	<meta property="og:description" content="Just a small FB test on OG tags">
	<meta property="og:image" content="">
</asp:Content>
<asp:Content ID="cnt_tobody" ContentPlaceHolderID="tobody_web" Runat="Server">
<!-- FB Init code -->
<div id="fb-root"></div>
<script src="//connect.facebook.net/pt_PT/all.js"></script>
<script>
	FB.init({
		appId: '1377509185667562',
	channelUrl : '', // Channel File
	status     : true, // check login status
	cookie     : true, // enable cookies to allow the server to access the session
	xfbml      : true  // parse XFBML
	});
</script>
<div class="container">
	<div class="row">
		<form runat="server">
			<div class="col-xs-12 col-sm-4 col-sm-offset-4">
				<h1>Bet 4 Cet - Login</h1>
          			<label for="lbl_username" class="col-2 col-form-label">Utilizador (e-mail)</label>
				<asp:TextBox CssClass="form-control" ID="tb_username" runat="server" ViewStateMode="Disabled"></asp:TextBox>
				<br />
				<label for="lbl_password" class="col-2 col-form-label">Password</label>
				<input id="tb_password" class="form-control" onchange="hashpass(); return false;" type="password" />
				<!-- <asp:TextBox CssClass="form-control" ID="tb_password_" runat="server" ViewStateMode="Disabled"></asp:TextBox> -->
				<br/>
				<input id="btn_loginfacebook" class="btn btn-primary btn-lg btn-block" type="button" value="Login com Facebook" onclick="FBLogin(); return false;"/>
				<input id="btn_loginfacebookfake" class="btn btn-primary btn-lg btn-block" type="button" value="Login com Facebook fake" onclick="__doPostBack('FBLOGIN','0987654321_Nuno Trancoso'); return false;"/>
				<asp:Button type="button" CssClass="btn btn-primary btn-lg btn-block" id="btn_login" runat="server" Text="" ViewStateMode="Disabled" OnClick="btn_login_Click" />
				<div class="row">
					<div class="col-xs-12 col-sm-6">
						<asp:Literal ID="lit_register" runat="server"></asp:Literal>
						<asp:HiddenField ID="hf_hashpass" runat="server" ClientIDMode="Static" />
					</div>
					<div class="col-xs-12 col-sm-6">
						<asp:LinkButton ID="lb_justtogetpostback" runat="server" Visible="True" PostBackUrl="~/login_web.aspx">Desenvolvido por NóS</asp:LinkButton>
					</div>
				</div>
			</div>
		</form>
	</div>
	<div class="row" id="weblog">
		<asp:Literal ID="lit_weblog" runat="server"></asp:Literal>
	</div>
</div>
<script>
	function hashpass()
	{
		document.getElementById('hf_hashpass').value = md5(document.getElementById('tb_password').value);
		document.getElementById('tb_password').value = "";
	}
</script>
</asp:Content>

