<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SprigAndSproutGrocery.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="../Asset/lab/Bootstrap/css/css/bootstrap.min.css" />
</head>
<body>
    <div class="container-fluid min-vh-100 d-flex align-items-center justify-content-center">
        <div class="row w-100">
            <div class="col-md-6 d-flex justify-content-center align-items-center">
                <img src="../Asset/Images/grocery.jpg" class="img-fluid" alt="Grocery Image" />
            </div>
            <div class="col-md-6 d-flex justify-content-center align-items-center">
                <div class="w-100" style="max-width: 400px;">
                    <h2 class="text-danger text-center">Sign Up</h2>
                    
                    <form runat="server">
                        <div class="mb-3">
                            <label class="form-label" for="email">Email Address:</label>
                            <input type="email" class="form-control" id="email" name="email" runat="server" required="required">
                        </div>
                        <div class="mb-3">
                            <label for="password" class="form-label">Password:</label>
                            <input type="password" id="password" class="form-control" runat="server" name="password" required="required">
                        </div>
                        <div class="mb-3 form-check d-flex align-items-center">
                            <div class="me-3">
                                <input type="radio" class="form-check-input" id="sellerradio" runat="server" name="role" value="seller">
                                <label class="form-check-label" for="sellerradio">Seller</label>
                            </div>
                            <div class="me-3">
                              
                                <input type="radio" class="form-check-input" style="margin-left:1.5em" runat="server" id="adminradio" name="role" value="admin">
                                <label class="form-check-label" for="adminradio">Admin</label>
                            </div>
                        </div>
                        <div>
                              <label id="loginmsg" runat="server" class="text-danger"></label>
                           <asp:Button Text="Login" class="btn btn-danger w-100 btn-block" runat="server" ID="LoginAdmin" OnClick="LoginAdmin_Click"  />

                           <!-- <button class="btn btn-danger w-100 btn-block" type="submit">Login</button>-->
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
