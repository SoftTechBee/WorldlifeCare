<%@ Page Title="" Language="C#" MasterPageFile="~/member/MasterPage.master" AutoEventWireup="true" CodeFile="Wrequest.aspx.cs" Inherits="User_withdrrawPlan1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

  

    
    <div class="content-body">
        <div class="content">


            <div class="card-body mb-3">
                <div class="alert border border-danger alert-dismissible fade show text-danger" role="alert" id="danger" runat="server" visible="false">
                    <b>Danger!</b>
                    <asp:Label ID="lbdanger" runat="server" Text=""></asp:Label>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>

                <div class="alert border border-success alert-dismissible fade show text-success" role="alert" id="sccess" runat="server" visible="false">
                    <b>Success!</b>
                    <asp:Label ID="lbsuccess" runat="server" Text=""></asp:Label>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>

                <div class="alert border border-warning alert-dismissible fade show text-warning" role="alert" id="warning" runat="server" visible="false">
                    <b>Warning!</b>
                    <asp:Label ID="lbwarning" runat="server" Text=""></asp:Label>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>

                <div class="alert border border-info alert-dismissible fade show text-info" role="alert" id="info" runat="server" visible="false">
                    <b>Info!</b>
                    <asp:Label ID="lbinfo" runat="server" Text=""></asp:Label>
                    <button type="button" class="btn-close text-info" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>
            </div>
             <a href="cryptoWallet.aspx" runat="server" id="walletlink" visible="false" class="badge badge-danger badge-pill">Wallet Update?</a>
<hr />
            <div class="row">

                <div class="col-12">
                    <div class="card">
                       
                        <div class="card-header with-border">
                            <div class="card-title ">
                                <h3 class="text text-bold text-danger">Withdraw Income</h3>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="form-horizontal">
                               
                                        <div class=" form-group row">
                                           
                                            <label class="control-label col-lg-2">Available Income </label>
                                            <div class="col-lg-4">
                                                <h5>
                                                    ₹<asp:Label CssClass="text-primary" runat="server" ID="lbIncome" Text="0"></asp:Label></h5>
                                            </div>
                                        </div>
                                        <br />
                                
                                      
                                        <div class=" form-group row">
                                          

                                            <label class="control-label col-lg-2">Withdraw </label>
                                            <div class="col-lg-10">
                                                <asp:TextBox ID="txtAmt" required="" OnTextChanged="txtAmt_TextChanged" AutoPostBack="true" runat="server" CssClass="form-control" placeholder="Enter Withdrawal "></asp:TextBox>
                                            </div>
                                            <asp:Label ID="Label1" runat="server" CssClass="text-danger"></asp:Label>
                                        </div>
                                        <br />

                                        <div class=" form-group row">
                                            <label class="control-label col-lg-2 ">Withdrawal Fee 5% </label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtadmincharge" Text="" required="" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>

                                      
                                    <label class="control-label col-lg-2 ">Withdrawal Payout</label>
                                    <div class="col-lg-4">
                                        <asp:TextBox ID="txtTotal" Text="" required="" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>


                                <%--  <div class=" form-group row">
                                            <label class="control-label col-lg-2">Payment Mode</label>
                                            <div class="col-lg-10">
                                                <asp:DropDownList runat="server" ID="paymenttype" AutoPostBack="true" OnTextChanged="paymenttype_TextChanged" CssClass="form-control" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="USDT.BEP20">TRX-Tron</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                         
                                        </div>
                                        <br />--%>

                                      <%--  <div class="row">
                                            <label class="control-label col-lg-2">Wallet Address </label>
                                            <div class="col-lg-10">
                                                <asp:TextBox ReadOnly="true" ID="lbWallet" required="" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />--%>

                                       <div class="row">
                                            <label class="control-label col-lg-2">Transaction Password </label>
                                            <div class="col-lg-10">
                                                <asp:TextBox  placeholder="Enter Transaction Password" ID="txtpassword" required="" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                     
                                <hr />

                               

                                <div class="row">
                                    <center>
                                        <asp:Button ID="btnaction" Visible="true" runat="server" Text="Withdraw" OnClick="butsubmit_Click" CssClass="btn btn-block btn-success" Width="200px" />
                                    </center>
                                </div>
                                <br />

                                <br />
                               <div class="row">
    <label class="control-label text-success col-lg-12">Terms & Conditions</label>
        <label>1) Minimum withdrawal – Rs. 500</label>
        <label>2) Withdrawal Per Month – 1<sup>st</sup> & 16<sup>th</sup> Every Month</label>
        <label>3) Withdrawal Deduction – 5% Service Charge</label>
        <label>4) 24 Hours Support</label>
</div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>




</asp:Content>

