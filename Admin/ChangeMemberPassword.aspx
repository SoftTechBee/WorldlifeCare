<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ChangeMemberPassword.aspx.cs" Inherits="Admin_ChangeMemberPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
              <div class="page-content">
                    <div class="container-fluid">

                        <!-- start page title -->
                        <div class="row">
                            <div class="col-12">
                                <div class="page-title-box d-flex align-items-center justify-content-between">
                                    <h4 class="mb-0">Member Login Password Change</h4>

                                    <div class="page-title-right">
                                        <ol class="breadcrumb m-0">
                                             <%--<li class="breadcrumb-item"><a href="javascript: void(0);">Minible</a></li>--%>
                                            <li class="breadcrumb-item active"><a href="Home.aspx">Home</a>/Member Login Password Change</li>
                                        </ol>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <!-- end page title -->
           
             
               <!-- Alret-->
              
                                        
                                            <div class="alert alert-success alert-dismissible fade show" role="alert"  id="sccess" runat="server" visible="false" >
                                                <i class="uil uil-check me-2"></i>
                                                <asp:Label ID="lbsuccess" runat="server" Text=" Password has changed"></asp:Label>  
                                                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close">
                                                
                                                </button>
                                            </div>
                                            <div class="alert alert-danger alert-dismissible fade show" role="alert" id="danger"  runat="server"  visible="false">
                                                <i class="uil uil-exclamation-octagon me-2"></i>
                                                  <asp:Label ID="lbdanger" runat="server" Text=" Password has not changed"></asp:Label> 
                                                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close">
                                                
                                                </button>
                                            </div>
                                            <div class="alert alert-warning alert-dismissible fade show" role="alert"  id="warning" runat="server"  visible="false">
                                                <i class="uil uil-exclamation-triangle me-2"></i>
                                                 <asp:Label ID="lbwarning" runat="server" Text=" Try Again............"></asp:Label> 
                                                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close">
                                                
                                                </button>
                                            </div>
                                            <div class="alert alert-info alert-dismissible fade show mb-0" role="alert"  id="info" runat="server"  visible="false">
                                                <i class="uil uil-question-circle me-2"></i>
                                                <asp:Label ID="lbinfo" runat="server" Text="ere is  some thing wrong........."></asp:Label>  
                                                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close">
                                                
                                                </button>
                                            </div>
      
                   <!-- end Alert title -->
      
                         <input type="hidden"  id="hndusername" runat="server" value=""/>
                                
                        
      
                             
                                <div class="row">
                            <div class="col-12">
      <div class="card ">                 <div class="form-horizontal">
                                <div class="card-body">
                                 
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
                </div></div><br />
                  <div class=" form-group row">
                                         <div class="col-md-2"> &nbsp;            
</div>
                   <div class="col-md-6">               
                    <div class="form-group has-success">
                  <label class="control-label" for="inputSuccess"><i class="fa fa-check"></i>Confirm Password</label>
                   <asp:TextBox ID="txtconpass" required runat="server"  class="form-control"  TextMode="Password" placeholder="Enter Confirm Password"></asp:TextBox>              
                 
                </div>
                </div></div>
                                    <br />
              <div class="row">
                                         <div class="col-md-2"> &nbsp;       
</div>
                   <div class="col-md-6">   
             <asp:Button ID="bntsubmit" runat="server" Text="Change" class="btn btn-primary"  OnClick="bntsubmit_Click"/>
                           
              </div></div>
           
          </div>
          <!-- /.box -->
            </div>
          </div>
                                </div>
                                    </div>
                        </div>
                  </div>
    
       
</asp:Content>





