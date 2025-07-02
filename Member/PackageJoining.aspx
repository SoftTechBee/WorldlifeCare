<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MasterPage.master" AutoEventWireup="true" CodeFile="PackageJoining.aspx.cs" Inherits="Member_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Content body -->
    <div class="content-body">
        <!-- Content -->
        <!------Msgbox End---->
        <div class="card-body ">
            <div class="alert alert-danger alert-dismissible" id="danger" runat="server" visible="false">

                <asp:Label ID="lbdanger" runat="server" Text="There is  some thing wrong........."></asp:Label>
            </div>
            <div class="alert alert-info alert-dismissible" id="info" runat="server" visible="false">

                <asp:Label ID="lbinfo" runat="server" Text="ere is  some thing wrong........."></asp:Label>

            </div>
            <div class="alert alert-warning alert-dismissible" id="warning" runat="server" visible="false">

                <asp:Label ID="lbwarning" runat="server" Text=" Try Again............"></asp:Label>

            </div>
            <div class="alert alert-success alert-dismissible" id="sccess" runat="server" visible="false">

                <asp:Label ID="lbsuccess" runat="server" Text="Successfully updated................"></asp:Label>
            </div>
        </div>
        <!-----Alert End----->


        <!-- layout modes selection -->
        <div class="row mb-3">
            <div class="col-12">
                <h6 class="mb-0">Joining Packages For ID:
                    <asp:Label ID="lbActiveMember" runat="server"></asp:Label></h6>
            </div>
        </div>

        <!-- Panel Content -->
        <!-- Content -->

            <div class="row">

                <div class="col-lg-12">
                    <div class="card  mb-4    shadow-lg" style="border: 1px solid blue;">

                        <div class="card-body">
                            <div class="form-horizontal">
                                <h5 class="text-warning " style="text-align: right; padding-right: 20px;" runat="server" visible="false" id="lbfund"><a class=" btn  btn-success" href="WalletRecharge.aspx">Add Fund</a></h5>
                                <div class="mb-3 row">
                                    <label class="control-label col-sm-3">Fund Balance </label>
                                    <div class="col-sm-3">

                                        <h6>₹
                                            <asp:Label ID="txtbalance" runat="server" Text="0"></asp:Label></h6>


                                    </div>

                                    <label class="control-label col-sm-3">Current Package </label>
                                    <div class="col-sm-3">

                                        <h6>
                                            <asp:Label ID="txtcurrentpack" runat="server" Text="NONE"></asp:Label>
                                            (<asp:Label ID="txtcurrentamt" CssClass="text-warning" runat="server" Text="0"></asp:Label>)</h6>


                                    </div>
                                </div>




                            </div>
                        </div>
                    </div>




                </div>
            </div>

            <div class="row">

                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="repPack_ItemCommand">
                    <ItemTemplate>



                        <div class="col-12 col-xl-4">
                            <div class="card adminuiux-card  rounded-4">
                                <div class="card-body">
                                    <div class=" g-0 align-items-center">
                                        <div class="col-md-12" >
                                            <img src='<%#Eval("imgUrl") %>' class="card-img" alt="...">
                                        </div>
                                        <div class="col-md-12">
                                            <div class="my-4">
                                            
                                                <h3 class="mb-0 fw-bold ">
                                                    <asp:Label runat="server" ID="lbpack" Text='<%#Eval("product") %>'></asp:Label></h3>
                                            </div>
                                           
                                            <div class="price-tag d-flex align-items-center justify-content-center gap-2 my-5">
                                                <h1 class="mb-0 lh-1 price-amount text-warning fw-bold">₹ <asp:Label runat="server" ID="lbinvest" Text='<%#Eval("max") %>'></asp:Label></h1>

                                            </div>
                                            <div class="price-tag d-flex align-items-center justify-content-center gap-2 my-5">
                                                <h1 class="mb-0 lh-1 price-amount text-warning fw-bold">SV- <asp:Label runat="server" ID="lbpv" Text='<%#Eval("min") %>'></asp:Label></h1>

                                            </div>
                                             <h5 class="mb-2 fw-bold text-danger">
                                                    <asp:Label runat="server" ID="lbpack1" Text='<%#Eval("descrption") %>'></asp:Label></h5>
                                            <div class="price-tag d-flex align-items-center justify-content-center gap-2 my-5">

                                                <h1 class="mb-0 lh-1 price-amount text-primary"></h1>
                                            </div>
                                            <!-- end card-body-->
                                        </div>
                                        <!-- end col -->
                                        <div class="d-grid">
                                            <asp:Button ID="btnsend" runat="server" Text="Buy Now" OnClientClick="return confirmAction();" CssClass="btn btn-sm btn-success" CommandArgument='<%#Eval("packid") %>' CommandName="Click" />
                                           <%-- <a href="SelfActive.aspx?id=<%=SessionData.Get<string>("ActiveUser") %>&Packid=<%#Eval("packid") %>" class="waves-effect waves-light btn mb-5 bg-gradient-info">Go Now?</a>--%>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>
            <!-- end row -->
            <script>

                function Processclick() {
                    swal({
                        title: "Processing.......!",
                        text: "Note: Do Not press back or close the app? It will close in few seconds.",
                        imageUrl: "../SoftImg/refresh.gif",
                        timer: 2000000,
                        showConfirmButton: false
                    });
                }
                function Successclick(title,msg) {
                    swal(title, msg, "success")
                }
                function dangerlick() {
                    swal("Oops...!", "Something went wrong! Try Again", "error")
                }
                function Warninglick() {
                    swal("Oops...!", "You have already buy this Package ,please buy another packages!", "warning")
                }
                function fundlick() {
                    swal("Oops...!", "Balance is less then to require amount,Please Add Fund! Check Minimum And Maxmum Amount", "warning")
                }
                function PrePackBuy() {
                    swal("Oops...!", "you can't buy this packages! Please Buy previous packages SequenceWise", "error")
                }
                function Direct() {
                    swal("Oops...!", "you can't buy this packages! Required 2 Direct For Buy a Packages?", "error")
                }
     function NotActive() {
         swal("Oops...!", "Your Account Is Not-Active ...! Please Active Your Account(Buy JOIN PAKAGE)", "error")
     }
      function Active() {
         swal("Oops...!", "Your Account Is Active ...! Please Upgrade Your Packages", "error")
     }
            </script>

                 <script>
                     // The function below will start the confirmation dialog
                     function confirmAction() {
                         let confirmAction = confirm("Are you sure to execute this action?");

                         if (confirmAction) {
                            // alert("Action Successfully executed");
                             return true;
                         }
                         else {
                             alert("Action Canceled");
                             return false;
                         }
                     }
                 </script>
            <script src="https://common.olemiss.edu/_js/sweet-alert/sweet-alert.min.js"></script>
<link rel="stylesheet" type="text/css" href="https://common.olemiss.edu/_js/sweet-alert/sweet-alert.css">
        </div>
</asp:Content>

