<%@ Page Language="C#"  EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SaifLogic.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <meta http-equiv="X-UA-Compatible" content="ie=edge">
  <title>Login - SaifLogic</title>
  <!-- plugins:css -->
  <link rel="stylesheet" href="Themes/Portal/V1/assets/vendors/mdi/css/materialdesignicons.min.css">
  <link rel="stylesheet" href="Themes/Portal/V1/assets/vendors/css/vendor.bundle.base.css">
  <!-- endinject -->
  <!-- Plugin css for this page -->
  <!-- End plugin css for this page -->
  <!-- Layout styles -->
  <link rel="stylesheet" href="Themes/Portal/V1/assets/css/demo/style.css">
  <!-- End layout styles -->
  <link rel="shortcut icon" href="Themes/Portal/V1/assets/images/favicon.png" />
</head>
<body>
<script src="Themes/Portal/V1/assets/js/preloader.js"></script>
    <form runat="server">
  <div class="body-wrapper">
    <div class="main-wrapper">
      <div class="page-wrapper full-page-wrapper d-flex align-items-center justify-content-center">
        <main class="auth-page">
          <div class="mdc-layout-grid">
            <div class="mdc-layout-grid__inner">
              <div class="stretch-card mdc-layout-grid__cell--span-4-desktop mdc-layout-grid__cell--span-1-tablet"></div>
              <div class="mdc-layout-grid__cell stretch-card mdc-layout-grid__cell--span-4-desktop mdc-layout-grid__cell--span-6-tablet">
                <div class="mdc-card">
                  <form>
                    <div class="mdc-layout-grid">
                      <div class="mdc-layout-grid__inner">
                        <div class="mdc-layout-grid__cell stretch-card mdc-layout-grid__cell--span-12">
                          <div class="mdc-text-field w-100">
                            <input class="mdc-text-field__input" runat="server" id="txtUserName">
                            <div class="mdc-line-ripple"></div>
                             <label for="text-field-hero-input"  class="mdc-floating-label">Login ID</label>
<%--                              <input type="text" class="mdc-floating-label" placeholder="Username" runat="server" id="txtUserName"> --%>
<%--                              <asp:TextBox runat="server" ID="txtUserName" class="mdc-floating-label" placeholder="Username"></asp:TextBox>--%>
                          </div>
                        </div>
                        <div class="mdc-layout-grid__cell stretch-card mdc-layout-grid__cell--span-12">
                          <div class="mdc-text-field w-100">
                            <input class="mdc-text-field__input" type="password" runat="server" id="txtPassword">
                            <div class="mdc-line-ripple"></div>
                            <label for="text-field-hero-input"  class="mdc-floating-label">Password</label>
                          </div>
                        </div>
                        <div class="mdc-layout-grid__cell stretch-card mdc-layout-grid__cell--span-6-desktop">
                          <div class="mdc-form-field">
                            <div class="mdc-checkbox">
                              <input type="checkbox"
                                      class="mdc-checkbox__native-control"
                                      id="checkbox-1"/>
                              <div class="mdc-checkbox__background">
                                <svg class="mdc-checkbox__checkmark"
                                      viewBox="0 0 24 24">
                                  <path class="mdc-checkbox__checkmark-path"
                                        fill="none"
                                        d="M1.73,12.91 8.1,19.28 22.79,4.59"/>
                                </svg>
                                <div class="mdc-checkbox__mixedmark"></div>
                              </div>
                            </div>
                            <label for="checkbox-1">Remember me</label>
                          </div>
                        </div>
                        <div class="mdc-layout-grid__cell stretch-card mdc-layout-grid__cell--span-6-desktop d-flex align-items-center justify-content-end">
                          <a href="#">Forgot Password</a>
                        </div>
                        <div class="mdc-layout-grid__cell stretch-card mdc-layout-grid__cell--span-12">
                          <%--<a href="../../index.html" class="mdc-button mdc-button--raised w-100">
                            Login
                          </a>--%>
                            <asp:Button ID="cmdLogin" runat="server" Text="Login" class="mdc-button mdc-button--raised w-100" OnClick="cmdLogin_Click"/>
                        </div>
                          <center><asp:Label ID="lblException" Font-Bold="true" runat="server"></asp:Label></center>
                      </div>
                    </div>
                  </form>
                </div>
              </div>
              <div class="stretch-card mdc-layout-grid__cell--span-4-desktop mdc-layout-grid__cell--span-1-tablet"></div>
            </div>
          </div>
        </main>
      </div>
    </div>
  </div>
        </form>
  <!-- plugins:js -->
  <script src="Themes/Portal/V1/assets/vendors/js/vendor.bundle.base.js"></script>
  <!-- endinject -->
  <!-- Plugin js for this page-->
  <!-- End plugin js for this page-->
  <!-- inject:js -->
  <script src="Themes/Portal/V1/assets/js/material.js"></script>
  <script src="Themes/Portal/V1/assets/js/misc.js"></script>
  <!-- endinject -->
  <!-- Custom js for this page-->
  <!-- End custom js for this page-->
</body>
</html>