<%@ Page Title="" Language="C#" MasterPageFile="~/member/MasterPage.master" AutoEventWireup="true" CodeFile="RechargeWellectWithAccount.aspx.cs" Inherits="User_wallectRecharge111" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

            <!-- Content -->
      
     <div class="alert alert-danger alert-dismissible" id="Div1"  runat="server"  visible="false">
              
                <h4><i class="icon fa fa-ban"></i> Alert!</h4>
            <asp:Label ID="Label1" runat="server" Text="There is  some thing wrong........."></asp:Label> 
              </div>
    <div class="page-breadcrumb">
                <div class="row">
                    <div class="col-5 align-self-center">
                        <h4 class="page-title">Fund Wallet Recharge</h4>
                    </div>
                    <div class="col-7 align-self-center">
                        <div class="d-flex align-items-center justify-content-end">
                           
                        </div>
                    </div>
                </div>
            </div>
     
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                                     <Triggers>
                                              
                                       <%--  <asp:AsyncPostBackTrigger ControlID="txttransPassword" EventName="TextChanged" />
                                  --%>
                                           <asp:AsyncPostBackTrigger ControlID="txtAmt" EventName="TextChanged" />
                                        
                                         <asp:AsyncPostBackTrigger ControlID="btnaction" EventName="Click" />
                                     </Triggers>
                                     <ContentTemplate>
    
     <div class="box-body">
              <div class="alert alert-danger alert-dismissible" id="danger"  runat="server"  visible="false">
              
                <h4><i class="icon fa fa-ban"></i> Alert!</h4>
            <asp:Label ID="lbdanger" runat="server" Text="There is  some thing wrong........."></asp:Label> 
              </div>
              <div class="alert alert-info alert-dismissible" id="info" runat="server"  visible="false">
              
                <h4><i class="icon fa fa-info"></i> Alert!</h4>
               <asp:Label ID="lbinfo" runat="server" Text="ere is  some thing wrong........."></asp:Label>  
             
              </div>
              <div class="alert alert-warning alert-dismissible" id="warning" runat="server"  visible="false">
              
                <h4><i class="icon fa fa-warning"></i> Alert!</h4>
               <asp:Label ID="lbwarning" runat="server" Text=" Try Again............"></asp:Label> 
            
              </div>
              <div class="alert alert-success alert-dismissible" id="sccess" runat="server" visible="false" >
              
                <h4><i class="icon fa fa-check"></i> Alert!</h4>
                  <asp:Label ID="lbsuccess" runat="server" Text="Successfully updated................"></asp:Label>  
              </div>
            </div>
    <!-----Alert End----->


      <div class="row">
             
        <div class="col-lg-12">
              <div class="card">
         <div class="form-horizontal">
                                <div class="card-body">
                                  
                 <!----form start---->
                                   
                            <div class="form-group row">
                                
                          
                                 <label class="control-label col-lg-3">Available Income  </label>
                          <div class="col-lg-4">
                             <h1> <asp:Label CssClass="label label-success font-weight-bold " runat="server" ID="lbIncome" ></asp:Label>
                             </h1>
                                 </div>
                          </div>
                           
      
           
                      <div class="form-group row">
                          <label class="control-label col-lg-3">Enter transfer Amount </label>
                          <div class="col-lg-6">
                         <asp:TextBox ID="txtAmt" required="" OnTextChanged="txtAmt_TextChanged"  AutoPostBack="true" runat="server" CssClass="form-control" ></asp:TextBox>
                         </div>
                          </div>
                       <div class="form-group row">
                                              
                         <label class="control-label col-lg-3 ">Admin Charge(10%) </label>     

                        <div class="col-lg-6">
                         <asp:TextBox ID="txtadmincharge" Text="" required="" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                         </div>
                            
                          </div>
                        
                      <div class="form-group row">
                          <label class="control-label col-lg-3">Transfer Amount in Fund Wallet </label>
                          <div class="col-lg-6">
                         <asp:TextBox ID="txtTotal" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                          </div>
 
                       <div class=" form-group row">
                           
                  <label class="control-label  col-lg-3">Enter  Transaction Password<span  class="text text-danger ">*</span></label>
                             <div class="col-lg-6">
                   <asp:TextBox ID="txttransPassword" runat="server" required="" TextMode="Password"   class="form-control" placeholder="Enter  Transaction Password"></asp:TextBox>              
                </div>
                          
                </div>

                                      
                     <div class="form-group row">
                             <div class="col-sm-offset-3 col-lg-4">
                                 </div>
                             <div class="col-sm-offset-3 col-lg-4">

   <asp:Button ID="btnaction" runat="server" Text="Transfer"  OnClick="butsubmit_Click" CssClass="btn btn-block  btn-success btn-lg"/>
               

                  </div>  
       
            
          </div>
          <!-- /.box -->
                    
                      </div>

                  </div>
            
            </div>
          </div>
          </div>
    </ContentTemplate>
         </asp:UpdatePanel>


</asp:Content>

