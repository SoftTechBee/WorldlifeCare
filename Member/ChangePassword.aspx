<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="User_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- Content body -->
   
    	<div class="row">
		<div class="col-12">
     <!------Msgbox End---->
     <div class="card-body">
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

   
          <div class="card card-primary">
              <div class="card-header with-border">
                  <div class="card-title">
                      <h3 class="text text-bold text-danger">Change Password Here</h3>
                  </div>
              </div>
              <div class="card-body">
                  <div class="form-horizontal">
                      <div class="form-group">
                          <label class="control-label col-sm-2">New Password </label>
                          <div class="col-sm-6">
                         <asp:TextBox ID="txtnew" TextMode="Password" required="" runat="server" CssClass="form-control"></asp:TextBox>
                         </div>
                          </div>
                      <div class="form-group">
                          <label class="control-label col-sm-2">Confirm Password </label>
                          <div class="col-sm-6">
                         <asp:TextBox ID="txtconfirm" TextMode="Password" required="" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                          </div>
                   
                      </div>
                  </div>
              <div class="card-footer">
                  <div class="col-sm-offset-3 col-sm-4">

   <asp:Button ID="btnaction" runat="server" Text="Change"  OnClick="Button1_Click" CssClass="btn btn-block btn-warning btn-lg"/>
               

                  </div>
                          
              </div>
              </div>   
            </div>
             
           
          
       


</asp:Content>

