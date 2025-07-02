<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="User_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
              <div class="alert alert-success alert-dismissible" id="sccess" runat="server"  visible="false">
              
                <h4><i class="icon fa fa-check"></i> Alert!</h4>
                  <asp:Label ID="lbsuccess" runat="server" Text="Successfully updated................"></asp:Label>  
              </div>
           
    <!-----Alert End----->
    <div class="card">
                            <div class="form-horizontal">
                                <div class="card-body">
                                    <h4 class="card-title">Change Password   </h4>
                 <!----form start---->
                            <div class=" form-group row">
                                         <div class="col-md-2"> &nbsp;            
</div></div>
            <div class=" form-group row">
                                         <div class="col-md-2"> &nbsp;            
</div>
                   <div class="col-md-6">               
                    <div class="form-group has-success">
                  <label class="control-label" for="inputSuccess"><i class="fa fa-check"></i>New Password</label>
                   <asp:TextBox ID="txtnewpass" required runat="server"  class="form-control" TextMode="Password" placeholder="Enter New Password"></asp:TextBox>              
                
                </div>
                </div></div>
                  <div class=" form-group row">
                                         <div class="col-md-2"> &nbsp;            
</div>
                   <div class="col-md-6">               
                    <div class="form-group has-success">
                  <label class="control-label" for="inputSuccess"><i class="fa fa-check"></i>Confirm Password</label>
                   <asp:TextBox ID="txtconpass" required runat="server"  class="form-control"  TextMode="Password" placeholder="Enter Confirm Password"></asp:TextBox>              
                 
                </div>
                </div></div>
              <div class="row">
                                         <div class="col-md-2"> &nbsp;       
</div>
                   <div class="col-md-6">   
             <asp:Button ID="bntsubmit" runat="server" Text="Change" class="btn btn-primary"  OnClick="bntsubmit_Click"/>
                           
              </div></div>
           
          </div>
          <!-- /.box -->
            </div>

</asp:Content>





