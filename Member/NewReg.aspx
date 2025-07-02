<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MasterPage.master" AutoEventWireup="true" CodeFile="NewReg.aspx.cs" Inherits="User_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
          <!-- Container-fluid starts-->
    <!-- this page js -->
            <div class="box-body">

                <div class="alert alert-danger alert-dismissible" id="danger" runat="server" visible="false">
              
                <h4><i class="icon fa fa-ban"></i>Alert!</h4>
                <asp:Label ID="lbdanger" runat="server" Text="There is  some thing wrong........."></asp:Label>
            </div>
            <div class="alert alert-info alert-dismissible" id="info" runat="server" visible="false">
              
                <h4><i class="icon fa fa-info"></i>Alert!</h4>
                <asp:Label ID="lbinfo" runat="server" Text="ere is  some thing wrong........."></asp:Label>

            </div>
            <div class="alert alert-warning alert-dismissible" id="warning" runat="server" visible="false">
              
                <h4><i class="icon fa fa-warning"></i>Alert!</h4>
                <asp:Label ID="lbwarning" runat="server" Text=" Try Again............"></asp:Label>

            </div>
            <div class="alert alert-success alert-dismissible" id="sccess" runat="server" visible="false">
              
                <h4><i class="icon fa fa-check"></i>Alert!</h4>
                <asp:Label ID="lbsuccess" runat="server" Text="Successfully updated................"></asp:Label>
            </div>
                </div>
              
    

               <div class="row">
               <div class="col-lg-4">
    <div class="card">
                            <div class="form-horizontal">
                                <div class="card-body">
                                    <h4 class="card-title">Admission Detail For Testing </h4>
                 <!----form start---->
                            <div class=" form-group row">
                        
           
                <label class="col-lg-12">Member</label>
                 <div class="col-lg-12">
                      <asp:Label ID="lbUserName" runat="server" Text="" CssClass="form-control"></asp:Label>   
                </div>
                  </div><br />
                          <div class="form-group row">
                <label class="col-lg-12">Sponsor ID</label>
                 <div class="col-lg-12">
                 <asp:TextBox ID="lbSponser" AutoPostBack="true" OnTextChanged="drpSponser_SelectedIndexChanged" runat="server" Text="" placeholder="Enter Sponsor ID" required="" CssClass="form-control"></asp:TextBox>          
                 <h5> <asp:Label runat="server" ID="lbSponserName" Text="" CssClass="label  label-success"></asp:Label>
                </h5> 
                     </div>
                 

                          </div>
                          
                     
                        
                </div>
                     <div class="box-footer"></div>
                
                     </div>
                      </div>
                 
             </div>
             <div class="col-lg-8">
                  <div class="card">
            <div class="form-horizontal">
                                <div class="card-body">
                                    <h4 class="card-title text-primary">Personal Detail For</h4>
                                    <br />
                 <!----form start---->
                            <div class=" form-group row">
                  <label class="control-label  col-lg-2">First Name</label>
                             <div class="col-lg-10">
                   <asp:TextBox ID="txtFirstName" runat="server"  required=""  class="form-control" placeholder="Enter First Name"></asp:TextBox>              
                </div>
                             
                </div>
                    <br />  
             <div class=" form-group row">
                           
                  <label class="control-label  col-lg-2"> Mobile </label>
                             <div class="col-lg-10">
                   <asp:TextBox ID="txtMobile" required="" runat="server"  MaxLength="10" class="form-control" placeholder="Enter Mobile"></asp:TextBox>              
                </div>
                              
                          
                </div>
<br />
                         <div class="form-group row">
                                      
                      <label class="control-label  col-lg-2">Email </label>
                             <div class="col-lg-10">
                   <asp:TextBox ID="txtEmail" runat="server" required=""    class="form-control" placeholder="Enter Email"></asp:TextBox>              
                </div> 
                            
                         </div>
                      <br /> <div class="form-group row">
                                      
                      <label class="control-label  col-lg-2">Select Side </label>
                             <div class="col-lg-10">
                                 <asp:DropDownList runat="server" ID="drpside" CssClass="form-control">
                                     <asp:ListItem Value="Left">Left</asp:ListItem>
                                     <asp:ListItem Value="Right">Right</asp:ListItem>
                                 </asp:DropDownList>
                </div> 
                            
                         </div>
                      <br />
                         <div class="form-group row">
                           
                  <label class="control-label  col-lg-2"> Password </label>
                             <div class="col-lg-10">
                   <asp:TextBox ID="txtPassword" runat="server" required=""   class="form-control" placeholder="Enter Password "></asp:TextBox>              
                </div>
                              
                </div>
                     
                <br />
                <br />
                          
                          <div class="box-footer">
                              <center>
                 <asp:Button ID="bntsubmit" OnClick="bntsubmit_Click" OnClientClick="return Validate();" runat="server" Text="Register" Width="200px" CssClass=" btn bg-success btn-flat btn-lg"  />  
               
                      
                      </center>          
                </div>
                </div>
                 </div>
             
          </div>
                       
            </div>

      </div>
      
    
</asp:Content>

