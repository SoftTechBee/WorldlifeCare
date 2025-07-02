<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="Signup" %>

<!DOCTYPE html>

<html lang="en" class="light-style  customizer-hide" dir="ltr" data-theme="theme-default" data-assets-path="../Loginassets/" data-template="vertical-menu-template-free">

<head  runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0" />

    <title>Signup - Pages |World Life Care </title>

    <meta name="description" content="Success isn't given, it's built. Build yours by starting your business today." />
    <meta name="keywords" content="World Life Care , businessWorld Life Care , login ">
    <!-- Canonical SEO -->
    <link rel="canonical" href="https://themeselection.com/products/sneat-bootstrap-html-admin-template/">

   <link rel="icon" type="image/x-icon" href="../Loginassets/img/logo/favicon.png" />
    <!-- Fonts -->
    <link rel="preconnect" href="https://fonts.googleapis.com/">
    <link rel="preconnect" href="https://fonts.gstatic.com/" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Public+Sans:ital,wght@0,300;0,400;0,500;0,600;0,700;1,300;1,400;1,500;1,600;1,700&amp;display=swap" rel="stylesheet">

    <!-- Icons. Uncomment required icon fonts -->
    <link rel="stylesheet" href="../Loginassets/vendor/fonts/boxicons.css" />



    <!-- Core CSS -->
    <link rel="stylesheet" href="../Loginassets/vendor/css/core.css" class="template-customizer-core-css" />
    <link rel="stylesheet" href="../Loginassets/vendor/css/theme-default.css" class="template-customizer-theme-css" />
    <link rel="stylesheet" href="../Loginassets/css/demo.css" />

    <!-- Vendors CSS -->
    <link rel="stylesheet" href="../Loginassets/vendor/libs/perfect-scrollbar/perfect-scrollbar.css" />

     <link rel="stylesheet" href="../Loginassets/vendor/css/pages/page-auth.css">
    <!-- Helpers -->
    <script src="../Loginassets/vendor/js/helpers.js"></script>
     <script src="../Loginassets/js/config.js"></script>
      <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async="async" src="https://www.googletagmanager.com/gtag/js?id=GA_MEASUREMENT_ID"></script>
     <script>
         function checksPassword(password) {


           <%--  var pattern = /^.*(?=.{8,20})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%&!-_]).*$/;
             if (!pattern.test(password)) {
                 document.getElementById("<%=lbpass.ClientID%>").innerHTML = 'Enter minimum 8 chars with atleast 1 number, lower, upper char'
            } else {
                document.getElementById("<%=lbpass.ClientID%>").innerHTML = '';
             }--%>
         }
         function validatepassword() {
             var password = document.getElementById("<%=txtPassword.ClientID%>").value;

            <%--var pattern = /^.*(?=.{8,20})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%&!-_]).*$/;
            if (!pattern.test(password)) {
                document.getElementById("<%=lbpass.ClientID%>").innerHTML = 'Enter minimum 8 chars with atleast 1 number, lower, upper char'
                return false;
            } else {
                document.getElementById("<%=lbpass.ClientID%>").innerHTML = '';
                
            }--%>

            if (document.getElementById("<%=txtPassword.ClientID%>").value != document.getElementById("<%=txtConfirmPassword.ClientID%>").value) {
                document.getElementById("<%=lbcpass.ClientID%>").innerHTML = 'ConfirmPassword did not match';
                return false;
            }
            else {
                document.getElementById("<%=lbcpass.ClientID%>").innerHTML = '';

             }
             return true;
         }
</script>
     <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;600&display=swap" rel="stylesheet">
  <style>
   

    

    .custom-alert {
      display: none;
      position: fixed;
      top: 0; left: 0;
      width: 100%; height: 100%;
      background-color: rgba(0, 0, 0, 0.4);
      justify-content: center;
      align-items: center;
      z-index: 9999;
    }

    .alert-box {
      background-color: white;
      padding: 20px 30px;
      border-radius: 12px;
      width: 300px;
      box-shadow: 0 10px 25px rgba(0, 0, 0, 0.15);
      text-align: center;
    }

    .alert-box h3 {
      margin-bottom: 10px;
      font-size: 20px;
      color: #333;
    }

    .alert-box p {
      margin-bottom: 20px;
      color: #555;
      font-size: 14px;
    }

    .alert-box button {
      padding: 1px 10px;
      border: none;
      border-radius: 6px;
      background-color: #4a90e2;
      color: white;
      font-weight: 600;
      cursor: pointer;
      transition: background-color 0.2s;
    }

    .alert-box button:hover {
      background-color: #3b7bd6;
    }
  </style>
    <script>
        function showAlert(title, message) {
            document.getElementById("alertTitle").textContent = title;
            document.getElementById("alertMessage").textContent = message;
            document.getElementById("customAlert").style.display = "flex";
        }

        function closeAlert() {
            document.getElementById("customAlert").style.display = "none";
        }
    </script>
</head>

<body id="top" data-theme-color="color-yellow"  style="background-image:url(bg.jpg); background-size:cover; background-position:center">
    <form id="form1" runat="server">
  
  

  <div class="custom-alert" id="customAlert">
    <div class="alert-box">
      <h3 id="alertTitle">Alert</h3>
      <p id="alertMessage">Message goes here</p>
      <button onclick="closeAlert()">OK</button>
    </div>
  </div>

  
 <!-- Content -->

    <div class="container-xxl">
        <div class="authentication-wrapper authentication-basic container-p-y">
            <div class="authentication-inner">
                <!-- Register -->
                <div class="card">
                   <div class="card-body" style=" -webkit-box-shadow: 0px 0px 10px 5px rgba(255,255,255,1); -moz-box-shadow: 0px 0px 10px 5px rgba(255,255,255,1); box-shadow: 0px 0px 10px 5px #000000;">
                    
                        <!-- Logo -->
                        <div class="app-brand justify-content-center">
                               <a href="index.html" class="app-brand-link gap-2">
                                    <center>   <span class="app-brand-logo demo ">

                                   <img src="Loginassets/img/logo/logo.png" width="50%" />

                                </span></center>
                            </a>
                        </div>
                        <!-- /Logo -->
                      <%--<h4 class="mb-2">Welcome to UPTO!  </h4>--%>
                        <p class="mb-4">Please sign-up to your account and start the adventure</p>
                            <asp:Label ID="lbmsg" Text="" CssClass="text-danger" runat="server"></asp:Label>
                      
                        <div id="formAuthentication" class="mb-3" ">
                                                <input type="hidden" id="hndsponser" runat="server" />
                                                <input type="hidden" id="hndsponsername" runat="server" />
                            <div class="mb-1 row">
                                 <div class="col-md-6">
                                      <label for="email" class="form-label">Sponsor ID</label>
                               <asp:TextBox ID="lbsponserid"  placeholder="Enter Sponsor ID"  AutoPostBack="true" OnTextChanged="lbsponserid_TextChanged" required="" runat="server" class="form-control" ></asp:TextBox>
      
                                     </div>
                                 <div class="col-md-6">
                                      <label for="email" class="form-label">Sponsor Name</label>
                               <asp:TextBox ID="lbSponsermsg" ReadOnly="true"     required="" runat="server" class="form-control" ></asp:TextBox>

                       </div>
        </div>
                           
                            <asp:Label ID="msg" Text="" CssClass=" text-danger " runat="server"></asp:Label>
                              <div class="mb-1">
                                <label for="email" class="form-label">Select Side</label>
                                 <asp:DropDownList runat="server" CssClass="form-control text-bg-primary" ID="drpside">
                                     <asp:ListItem Value="Choose Position">Select Side</asp:ListItem>
                                     <asp:ListItem Value="Left">Left</asp:ListItem>
                                     <asp:ListItem Value="Right">Right</asp:ListItem>
                                 </asp:DropDownList> </div>
                            
                             <div class="mb-1">
                                <label for="email" class="form-label">Full Name</label>
                                  <asp:TextBox ID="txtName"  required="" runat="server" class="form-control" placeholder="Full Name"></asp:TextBox>
                            </div>
                            
                             <div class="mb-1 mb-2">
                                <label for="email" class="form-label">Country</label>
                                    <asp:DropDownList ID="drpcountry"   class="form-control" runat="server" DataTextField="Country" DataValueField="CID" AutoPostBack="true" OnSelectedIndexChanged="drpcountry_SelectedIndexChanged">

                                     </asp:DropDownList>
                            </div>
                             <div class="mb-1 row">
                                 <div class="col-lg-3">
                                 <asp:TextBox ID="drpcode"   required=""  runat="server" class="form-control" Text="+1" ReadOnly="true"></asp:TextBox>
                                 </div>
                                  <div class="col-lg-9">
                                 <asp:TextBox ID="txtMobile"  onkeypress="if ( isNaN(this.value + String.fromCharCode(event.keyCode) )) return false;"  onkeyup="doKeyUpValidation(this)"    required="" MaxLength="10" runat="server" class="form-control" placeholder="Enter Mobile"></asp:TextBox>
         </div>
                            </div>
                             <asp:Label ID="lbmobileMsg" runat="server" Visible="false" CssClass=" text-warning"></asp:Label>
                           <div class="mb-1">
                                <label for="email" class="form-label">Email</label>
                                <asp:TextBox ID="txtemail" Type="email"  required=""   runat="server" class="form-control" placeholder="Enter Email"></asp:TextBox>
                                 
                            </div>
                            <asp:Label ID="lbEmailMsg" runat="server" Visible="false" CssClass=" text-warning"></asp:Label>
                             
                           
                          <div class="mb-1 form-password-toggle">
                                <div class="d-flex justify-content-between">
                                    <label class="form-label" for="password">Password</label>
                                    
                                </div>
                                <div class="input-group input-group-merge">
                                    <asp:TextBox ID="txtPassword" runat="server" onkeyup="checksPassword(this.value)" TextMode="Password" CssClass="form-control" placeholder="*********"></asp:TextBox>
                                     <span class="input-group-text cursor-pointer"><i class="bx bx-hide"></i></span> </div>
                                 <asp:Label ID="lbpass" Text="" CssClass="text-warning" runat="server"></asp:Label>
                            </div>
                            <div class="mb-1 form-password-toggle">
                                <div class="d-flex justify-content-between">
                                    <label class="form-label" for="password">Confirm Password</label>
                                    
                                </div>
                                <div class="input-group input-group-merge">
                                    <asp:TextBox ID="txtConfirmPassword" TextMode="Password"  required=""  runat="server" class="form-control" placeholder="Enter Confirm Password"></asp:TextBox>
                                <span class="input-group-text cursor-pointer"><i class="bx bx-hide"></i></span>
                                </div>
                                 <asp:Label ID="lbcpass" Text="" CssClass="text-warning" runat="server"></asp:Label>
                            </div>
                            
                            <div class="mb-3">
                                 <asp:Button runat="server" ID="btnRegister" OnClientClick="return validatepassword();" OnClick="btnRegister_Click"  CssClass="btn btn-primary d-grid w-100"  Text="Register" />
                          
                           
                               
                            </div>
                        </div>

                        <p class="text-center">
                            <span>Already on our World Life Care ?</span>
                            <a href="login.aspx">
                                <span>Login an account</span>
                            </a>
                        </p>
                    </div>
                </div>
                <!-- /Register -->
            </div>
        </div>
    </div>

    <!-- / Content -->
<%-- <div class="buy-now">
        <a href="index.html" target="_blank" class="btn btn-danger btn-buy-now">Back To V-DESK</a>
    </div>--%>
         <script type="text/javascript">
             function doKeyUpValidation(text) {
                 var validationRegex = /[0-9]/g;
                 if (!validationRegex.test(text.value)) {
                     text.value = '';
                     //alert('Please enter only numbers.');
                 }
             }
         </script>
          </form>
    <!-- Core JS -->
    <!-- build:js assets/vendor/js/core.js -->
    <script src="../Loginassets/vendor/libs/jquery/jquery.js"></script>
    <script src="../Loginassets/vendor/libs/popper/popper.js"></script>
    <script src="../Loginassets/vendor/js/bootstrap.js"></script>
    <script src="../Loginassets/vendor/libs/perfect-scrollbar/perfect-scrollbar.js"></script>

    <script src="../Loginassets/vendor/js/menu.js"></script>
    <!-- endbuild -->
    <!-- Vendors JS -->
    <!-- Main JS -->
    <script src="../Loginassets/js/main.js"></script>

    <!-- Page JS -->
    <!-- Place this tag in your head or just before your close body tag. -->
    <script async defer src="../../../buttons.github.io/buttons.js"></script>
  
   
</body>
</html>
