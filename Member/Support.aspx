<%@ Page Title="" Language="C#" MasterPageFile="~/member/MasterPage.master" AutoEventWireup="true" CodeFile="Support.aspx.cs" Inherits="User_Support1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <%--<div class="content-body">
            <!-- Content -->
            <div class="container-fluid">--%>
                        <!-- start page title -->
                        <div class="row">
                            <div class="col-12">
                                <div class="page-title-box d-flex align-items-center justify-content-between">
                                    <h4 class="mb-0">Ticket</h4>

                                   
                                  
                                </div>
                            </div>
                        </div>
                        <!-- end page title -->
           
             
               <!-- Alret-->
              
                                        
                                            <div class="alert alert-success alert-dismissible fade show" role="alert"  id="sccess" runat="server" visible="false" >
                                                <i class="uil uil-check me-2"></i>
                                                <asp:Label ID="lbsuccess" runat="server" Text="Successfully updated................"></asp:Label>  
                                                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close">
                                                
                                                </button>
                                            </div>
                                            <div class="alert alert-danger alert-dismissible fade show" role="alert" id="danger"  runat="server"  visible="false">
                                                <i class="uil uil-exclamation-octagon me-2"></i>
                                                  <asp:Label ID="lbdanger" runat="server" Text="There is  some thing wrong........."></asp:Label> 
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
    
      
   
    
              <div class="card">
      
                                <div class="card-body">
                                      <div class="form-horizontal">
                                  
                                  
                            <div class="form-group row">
                                
                        
                    
                
                          <label class="control-label col-lg-2">Subject </label>
                          <div class="col-lg-6">
                         <asp:TextBox ID="txtSubject"  placeholder="Enter Subject" required="" runat="server" CssClass="form-control"></asp:TextBox>
                         </div>
                          </div>
                                          <br />
                      <div class="form-group row">
                          <label class="control-label col-lg-2">Message </label>
                          <div class="col-lg-6">
                         <asp:TextBox ID="txtmsg"  Height="200px" required="" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                          </div>
                   
                      </div>
                 
             <div class="form-group row mt-2">
                  <div class="col-sm-3">
                      </div>
                  <div class="col-sm-4">

   <asp:Button ID="btnaction" runat="server" Text="Send"  OnClick="Button1_Click" CssClass="btn btn-block btn-success "/>
               

                  </div>
                          
              </div>
              </div>
         </div>
            <%-- </div>
                  </div>--%>

       

</asp:Content>

