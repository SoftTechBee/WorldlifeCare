<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillPrint.aspx.cs" Inherits="Admin_BillPrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="author" content="pixelstrap">
    <link rel="icon" href="../-logo.png" type="image/x-icon">
    <link rel="shortcut icon" href="../-logo.png" type="image/x-icon">
    <title>Bill Of Supply</title>

<!--favicon-->
  <link rel="icon" href="../assets/images/favicon-32x32.png" type="image/png">
  <!-- loader-->
	<link href="../assets/css/pace.min.css" rel="stylesheet">
	<script src="../assets/js/pace.min.js"></script>
  <!--plugins-->
  <link href="../assets/plugins/perfect-scrollbar/css/perfect-scrollbar.css" rel="stylesheet">
  <link rel="stylesheet" type="text/css" href="../assets/plugins/metismenu/metisMenu.min.css">
  <link rel="stylesheet" type="text/css" href="../assets/plugins/metismenu/mm-vertical.css">
  <link rel="stylesheet" type="text/css" href="../assets/plugins/simplebar/css/simplebar.css">
  <!--bootstrap css-->
  <link href="../assets/css/bootstrap.min.css" rel="stylesheet">
  <link href="https://fonts.googleapis.com/css2?family=Noto+Sans:wght@300;400;500;600&amp;display=swap" rel="stylesheet">
  <link href="https://fonts.googleapis.com/css?family=Material+Icons+Outlined" rel="stylesheet">
  <!--main css-->
  <link href="../assets/css/bootstrap-extended.css" rel="stylesheet">
  <link href="../sass/main.css" rel="stylesheet">
  <link href="../sass/dark-theme.css" rel="stylesheet">
  <link href="../sass/blue-theme.css" rel="stylesheet">
  <link href="../sass/semi-dark.css" rel="stylesheet">
  <link href="../sass/bordered-theme.css" rel="stylesheet">
  <link href="../sass/responsive.css" rel="stylesheet">
</head>
<body onload="print();">
    <form id="form1" runat="server">
        <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" />
        <style>
            .TxtBoxError {
                border: 1px solid red;
                width: 250px;
                height: 30px;
            }

            @media print {
                body {
                    width: 26cm;
                    height: 100%;
                    margin: 0mm 0mm 0mm 0mm;
                    /* change the margins as you want them to be. */
                }
            }

            .main-table {
            }

            @media print {
                body {
                    -webkit-print-color-adjust: exact;
                }

                .main-table {
                    display: flex !important;
                }
            }
        </style>
        <style>
            .mrpamt {
                color: red;
                font-weight: bold;
                font-size: 12px;
            }

            .amt {
                color: black;
                font-weight: bold;
                font-size: 12px;
            }

            .tax {
                justify-content: left;
                display: flex;
                height: 30px;
                line-height: 30px;
                padding: 5px 15px;
                font-size: 12px;
                color: black;
            }

            .total {
                display: flex;
                justify-content: space-between;
                height: 30px;
                line-height: 30px;
                padding: 5px 15px;
                font-size: 14px;
                color: #212121;
            }

            .editbtn {
                width: 42% !important;
                height: 28px !important;
                font-size: 9px !important;
                background-color: darkgreen !important;
            }
        </style>
        <style type="text/css">
            #ContentPlaceHolder1_bntsubmit {
                border-radius: 25px;
            }

            #ContentPlaceHolder1_btncencel {
                border-radius: 25px;
            }



            body {
                margin-top: 20px;
                color: #484b51;
            }

            .text-secondary-d1 {
                color: #728299 !important;
            }

            .page-header {
                margin: 0 0 1rem;
                padding-bottom: 1rem;
                padding-top: .5rem;
                border-bottom: 1px dotted #e2e2e2;
                display: -ms-flexbox;
                display: flex;
                -ms-flex-pack: justify;
                justify-content: space-between;
                -ms-flex-align: center;
                align-items: center;
            }

            .page-title {
                padding: 0;
                margin: 0;
                font-size: 1.75rem;
                font-weight: 300;
            }

            .brc-default-l1 {
                border-color: #dce9f0 !important;
            }

            .ml-n1, .mx-n1 {
                margin-left: -.25rem !important;
            }

            .mr-n1, .mx-n1 {
                margin-right: -.25rem !important;
            }

            .mb-4, .my-4 {
                margin-bottom: 1.5rem !important;
            }

            hr {
                margin-top: 1rem;
                margin-bottom: 1rem;
                border: 0;
                border-top: 1px solid rgba(0,0,0,.1);
            }

            .text-grey-m2 {
                color: #888a8d !important;
            }

            .text-success-m2 {
                color: #86bd68 !important;
            }

            .font-bolder, .text-600 {
                font-weight: 600 !important;
            }

            .text-110 {
                font-size: 110% !important;
            }

            .text-blue {
                color: #478fcc !important;
            }

            .pb-25, .py-25 {
                padding-bottom: .75rem !important;
            }

            .pt-25, .py-25 {
                padding-top: .75rem !important;
            }

            .bgc-default-tp1 {
                background-color: rgba(121,169,197,.92) !important;
            }

            .bgc-default-l4, .bgc-h-default-l4:hover {
                background-color: #f3f8fa !important;
            }

            .page-header .page-tools {
                -ms-flex-item-align: end;
                align-self: flex-end;
            }

            .btn-light {
                color: #757984;
                background-color: #f5f6f9;
                border-color: #dddfe4;
            }

            .w-2 {
                width: 1rem;
            }

            .text-120 {
                font-size: 120% !important;
            }

            .text-primary-m1 {
                color: #4087d4 !important;
            }

            .text-danger-m1 {
                color: #dd4949 !important;
            }

            .text-blue-m2 {
                color: #68a3d5 !important;
            }

            .text-150 {
                font-size: 150% !important;
            }

            .text-60 {
                font-size: 60% !important;
            }

            .text-grey-m1 {
                color: #7b7d81 !important;
            }

            .align-bottom {
                vertical-align: bottom !important;
            }
        </style>
        <!-- jQuery 3 -->


        <!------Msgbox End---->
            <!-- Container-fluid starts-->
            <%-- <div class="container-fluid dashboard-default-sec">--%>








                <div class="row">

                    <div class="col-lg-12">
                        <div class="card " style="background-image: url(../images/background/bg-3.jpg); background-position: center">
                            <div class="form-horizontal">

                                <div class="card-body">
                                    <div class=" form-group row ">
                                        <div class="col-sm-12 text-center">

                                            <h6 class="card-title text-success"><b>PRODUCT INVOICE</b></h6>

                                        </div>




                                    </div>

                                    <div class=" form-group row ">
                                        <div class="col-sm-6">
                                            <h8 class="card-title" style="font-size: 27px">
                                                <img src="../assets/images/logo.png" width="180px" /></h8>

                                        </div>
                                        <div class="col-sm-6">
                                            <%--    <h6 class="card-title" style="text-align:right"><b>Bill Of Supply</b></h6>--%>
                                            <h6 class="card-title" style="text-align: right; font-size: 10px">Original For Recipient</h6>
                                            <h6 class="card-title" style="text-align: right; font-size: 10px">Invoice No:
                                                <asp:Label runat="server" ID="lbinvoice"></asp:Label></h6>
                                            <h6 class="card-title" style="text-align: right; font-size: 10px">Invoice Date :
                                                <asp:Label runat="server" ID="lbdated"></asp:Label></h6>
                                            <h6 class="card-title" style="text-align: right; font-size: 10px">Delivery Type :
                                                <asp:Label runat="server" ID="lbdelivertype"></asp:Label></h6>

                                        </div>




                                    </div>

                                    <!----form start---->

                                    <div class=" form-group row ">


                                        <%--<div class="container px-0">
                                            <div class="row mt-4">--%>
                                        <div class="col-12 col-lg-12">
                                            <%--<div class="row">
                                                <div class="col-12">
                                                    <div class="text-center ">
                                                        <i class="fa fa-calendar fa-x text-success-m2 mr-1"></i>
                                                        <h8 class="card-title" style="text-align: center"><b>DATE :
                                                            <asp:Label runat="server" ID="lbdate"></asp:Label></b></h8>
                                                    </div>
                                                </div>
                                            </div>--%>
                                            <!-- .row -->

                                            <%--  <br />--%>

                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <div>
                                                    <span class="text-sm text-danger align-middle"><b>BILL FROM:</b></span><br />
                                                    <span class="text-600 text-110 text-blue align-middle">World Life Care Enterprises Address:-</span>
                                                </div>
                                                <div class="text-grey-m2">
                                                    <div class="my-1">
                                                      addressssssssssssssssssssssssssssssssssss<br />
                                                        <i class="fa fa-envelope fa-flip-horizontal text-secondary"></i><b class="text-600">info@worldlifecareenterprises.com</b>
                                                    </div>



                                                </div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div>
                                                        <span class="text-sm text-danger align-middle"><b>BILL TO:</b></span><br />
                                                        <span class="text-600 text-110 text-blue align-middle">NAME :
                                                            <asp:Label runat="server" ID="lbname"></asp:Label></span>
                                                        
                                                        <span class="text-600 text-110 text-blue align-middle">Address :
                                                            <asp:Label runat="server" ID="lbaddressUser"></asp:Label></span>
                                                    </div>
                                                    <div class="text-grey-m2">
                                                        <div class="my-1">
                                                            <b>UserName :
                                                                <asp:Label runat="server" ID="lbusername"></asp:Label></b>
                                                        </div>
                                                        <div class="my-1">
                                                            <b>
                                                                <asp:Label runat="server" ID="lbaddress"></asp:Label></b>
                                                            <br />
                                                            <i class="fa fa-phone fa-flip-horizontal text-secondary"></i><b class="text-600">+91-<asp:Label runat="server" ID="lbmobile"></asp:Label></b>
                                                        </div>

                                                    </div>
                                                </div>
                                                <!-- /.col -->

                                            </div>
                                            <br />

                                            <hr class="row brc-default-l1 mx-n1 mb-4" />

                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <div>
                                                    <span class="text-sm text-danger align-middle"><b>SHIP FROM:</b></span><br />
                                                    <span class="text-600 text-110 text-blue align-middle">World Life Care Enterprises Address:-</span>
                                                </div>
                                                <div class="text-grey-m2">
                                                    <div class="my-1">
                                                       adrrsfghjjhgfesssssssssssssssssssssssssssssssssssssssssssss<br />
                                                        <i class="fa fa-envelope fa-flip-horizontal text-secondary"></i><b class="text-600">info@worldlifecareenterprises.com</b>
                                                    </div>

                                                </div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div>
                                                        <span class="text-sm text-danger align-middle"><b>SHIP TO : </b></span>
                                                        <br />
                                                        <span class="text-600 text-110 text-blue align-middle">NAME :
                                                            <asp:Label runat="server" ID="lbshipname"></asp:Label></span>
                                                    </div>
                                                    <div class="text-grey-m2">
                                                        <div class="my-1">
                                                            <b>UserName :
                                                                <asp:Label runat="server" ID="lbshiusername"></asp:Label></b>
                                                        </div>
                                                        <div class="my-1">
                                                            <b>
                                                                <asp:Label runat="server" ID="lbaddress2"></asp:Label></b>
                                                            <br />
                                                            <i class="fa fa-phone fa-flip-horizontal text-secondary"></i><b class="text-600">+91-<asp:Label runat="server" ID="lbmobille2"></asp:Label></b>
                                                        </div>

                                                    </div>
                                                </div>
                                                <!-- /.col -->

                                            </div>
                                            <br />

                                            <hr class="row brc-default-l1 mx-n1 mb-4" />
                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12" style="overflow: auto;">

                                                    <table id="example1" class="table table-bordered table-striped table-hover ">
                                                        <thead>
                                                            <tr class="text-white bgc-default-tp1">
                                                                <th>#</th>
                                                                <th>Product Item</th>
                                                                <th>MRP</th>
                                                                  <th>Discount</th>
                                                                <th>DP</th>

                                                              
                                                                <th>BV</th>






                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <asp:Repeater ID="Repeater1" runat="server">

                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td><%# Container.ItemIndex+1 %></td>
                                                                        <td><%#Eval("Product") %></td>
                                                                         <td><%#Eval("Discount") %></td>
                                                                        <td><%#Eval("MRP") %></td>
                                                                        <td><%#Eval("Price") %></td>
                                                                       
                                                                        <td><%#Eval("BV") %></td>

                                                                    </tr>
                                                                </ItemTemplate>

                                                            </asp:Repeater>
                                                        </tbody>
                                                        <tfoot>
                                                            <tr>
                                                                <th>Total</th>
                                                                <th>
                                                                    <asp:Label ID="lbqty" runat="server" Text=""></asp:Label>
                                                                    Products</th>
                                                                <th>
                                                                    <asp:Label ID="totalmrp" runat="server" Text=""></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="totaldp" runat="server" Text=""></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="totaldiscount" runat="server" Text=""></asp:Label></th>
                                                                <th>
                                                                    <asp:Label ID="totalbv" runat="server" Text=""></asp:Label></th>

                                                            </tr>
                                                        </tfoot>
                                                    </table>

                                                </div>
                                            </div>
                                            <br />

                                            <hr class="row brc-default-l1 mx-n1 mb-4" />

                                            <div class="row" style="justify-content: right">
                                                <%--<div class="col-md-8 col-sm-12 cart-shopping-total">
                                                    <h6 class="card-title" style="text-align: left"><b>Payments Details : </b></h6>
                                                    <h5 class="card-title" style="text-align: left; font-size: 10px">Bank : Ujjivan Small Finance Bank</h5>
                                                    <h5 class="card-title" style="text-align: left; font-size: 10px">Holder Name : Vesnav Safal India</h5>
                                                    <h5 class="card-title" style="text-align: left; font-size: 10px">Bank Acount : 2242120040000145</h5>
                                                    <h5 class="card-title" style="text-align: left; font-size: 10px">IFSC CODE : UJVN0002242</h5>
                                                    <!-- /table -->
                                                </div>--%>
                                                <div class="col-md-4 col-sm-12 cart-shopping-total">
                                                    <table class="table">
                                                        <thead>
                                                            <tr>
                                                                <th>

                                                                    <div class="cart-sub-total total">
                                                                        <span>Total SV:</span> <span>
                                                                            <asp:Label ID="lbtotalBV" runat="server" Text="0"></asp:Label></span>
                                                                    </div>
                                                                    <div class="cart-sub-total total">
                                                                        Total DP:<span class="inner-left-md"><i class="fa  fa-rupee" style="color: forestgreen"></i><asp:Label ID="lbgrandtotal" CssClass="text-success" runat="server" Text="0"></asp:Label></span>
                                                                    </div>
                                                                    <div class="cart-sub-total total">
                                                                        Shipping Charges :<span class="inner-left-md"><i class="fa  fa-rupee" style="color: forestgreen"></i><asp:Label ID="lbshipping" CssClass="text-success" runat="server" Text="0"></asp:Label></span>
                                                                    </div>
                                                                    <div class="cart-sub-total total">
                                                                        Grand Total:<span class="inner-left-md"><i class="fa  fa-rupee" style="color: forestgreen"></i><asp:Label ID="lbtotalpayout" CssClass="text-success" runat="server" Text="0"></asp:Label></span>
                                                                    </div>

                                                                </th>
                                                            </tr>
                                                        </thead>

                                                    </table>
                                                    <div class="cart-sub-total total">
                                                        <span>Payment Status:</span> <span>
                                                            <asp:Label ID="lbpaystatus" runat="server" Text=""></asp:Label></span>
                                                    </div>
                                                    <!-- /table -->
                                                </div>
                                            </div>
                                            <br />
                                            <hr class="row brc-default-l1 mx-n1 mb-4" />

                                            <div class="row" style="margin-bottom: -19px;">

                                                <div class="text-black bgc-default-tp1 col-sm-12" style="background-color: rgb(217 222 225 / 92%)!important">
                                                    <br />
                                                    <h7 class="card-title" style="text-align: left"><b>Terms & Condition : </b></h7>
                                                    <h6 class="card-title" style="text-align: left; font-size: 13px">E.&O.E</h6>
                                                    <h8 class="card-title" style="text-align: left; font-size: 13px; color: red">1. Goods once sold shall not be accepted back.</h8><br />
                                                    <h8 class="card-title" style="text-align: left; font-size: 13px; color: red">2. All disputes subject to Hyderabad Jurisdiction Only.</h8>
                                                    <h6 class="card-title" style="text-align: right">For <b>World Life Care Enterprises. </b></h6>
                                                    <h6 class="card-title" style="text-align: right; font-size: 13px">Authorized Signatory</h6>
                                                </div>

                                            </div>


                                        </div>
                                        <%--</div>
    </div>--%>
                                    </div>

                                    <!----form End---->


                                </div>
                            </div>

                        </div>

                    </div>


                </div>



            <%-- </div>--%>
    </form>
      <!--bootstrap js-->
  <script src="../assets/js/bootstrap.bundle.min.js"></script>

  <!--plugins-->
  <script src="../assets/js/jquery.min.js"></script>
  <!--plugins-->
  <script src="../assets/plugins/perfect-scrollbar/js/perfect-scrollbar.js"></script>
  <script src="../assets/plugins/metismenu/metisMenu.min.js"></script>
  <script src="../assets/plugins/apexchart/apexcharts.min.js"></script>
  <script src="../assets/plugins/simplebar/js/simplebar.min.js"></script>
  <script src="../assets/plugins/peity/jquery.peity.min.js"></script>
  <script>
    $(".data-attributes span").peity("donut")
  </script>
  <script src="../assets/js/main.js"></script>
  <script src="../assets/js/dashboard1.js"></script>
  <script>
	   new PerfectScrollbar(".user-list")
  </script>
</body>
</html>
