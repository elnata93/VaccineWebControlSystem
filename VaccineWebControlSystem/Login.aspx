<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VaccineWebControlSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-sm-6 col-md-4 col-md-offset-4">
                <h1 class="text-center login-title">Sign in to Account</h1>
                <div class="account-wall">
                    <img class="profile-img" src="https://lh5.googleusercontent.com/-b0-k99FZlyE/AAAAAAAAAAI/AAAAAAAAAAA/eu7opA4byxI/photo.jpg?sz=120" alt="" />
                    <form id="form1" runat="server" class="form-signin">
                        <asp:TextBox ID="UserNameTextBox" CssClass="form-control" placeholder="Username" required="required" autofocus="autofocus" runat="server" MaxLength="20"></asp:TextBox>
                        <asp:TextBox ID="PasswordTextBox" CssClass="form-control" placeholder="Password" required="required" runat="server" TextMode="password" MaxLength="20"></asp:TextBox><br />
                        <asp:Button ID="IniciarSesionButton" CssClass="btn btn-lg btn-primary btn-block" runat="server" Text="Sign in" OnClick="IniciarSesionButton_Click" />
                        <label class="checkbox pull-left">
                            <asp:CheckBox ID="RememberCheckBox" runat="server" />Remember me
                        </label>
                    </form>
                </div>
                <div>
                    <a href="/Registros/Registro_Usuarios.aspx" class="text-center new-account">Sign up now</a>
                </div>

            </div>
        </div>
    </div>
    >
</body>
</html>
