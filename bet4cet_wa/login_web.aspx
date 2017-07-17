<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/web_mp.master" AutoEventWireup="true" CodeBehind="login_web.aspx.cs" Inherits="bet4cet_wa.login_web" %>
<asp:Content ID="cnt_tohead" ContentPlaceHolderID="tohead_web" Runat="Server">
	<script src="/js/md5.min.js"></script>
	<asp:Literal ID="lit_title" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="cnt_tobody" ContentPlaceHolderID="tobody_web" Runat="Server">
	<div class="container">
		<div class="row">
			<form runat="server">
				<div class="col-xs-12 col-sm-4 col-sm-offset-4">
					<h1>Bet 4 Cet - Login</h1>
           			<label for="lbl_username" class="col-2 col-form-label">Utilizador (e-mail)</label>
					<asp:TextBox CssClass="form-control" ID="tb_username" runat="server" ViewStateMode="Disabled"></asp:TextBox>
					<br />
					<label for="lbl_password" class="col-2 col-form-label">Password</label>
					<input id="tb_password" class="form-control" onchange="hashpass()" type="password" />
					<!-- <asp:TextBox CssClass="form-control" ID="tb_password_" runat="server" ViewStateMode="Disabled"></asp:TextBox> -->
					<br/>
					<asp:Button type="button" CssClass="btn btn-primary btn-lg btn-block" id="btn_login" runat="server" Text="" ViewStateMode="Disabled" OnClick="btn_login_Click" />
					<br/>
					<asp:Literal ID="lit_register" runat="server"></asp:Literal>
					<br/>
					<asp:HiddenField ID="hf_hashpass" runat="server" ClientIDMode="Static" />
					<asp:Label CssClass="col-2 col-form-label" id="lbl_erro" runat="server" ViewStateMode="Disabled"></asp:Label>
				</div>
			</form>
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

