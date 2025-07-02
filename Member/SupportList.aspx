<%@ Page Title="" Language="C#" MasterPageFile="~/member/MasterPage.master" AutoEventWireup="true" CodeFile="SupportList.aspx.cs" Inherits="User_SupportList1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <%-- <div class="content-body">
            <!-- Content -->
            <div class="container-fluid">--%>
                        <!-- start page title -->
                        <div class="row">
                            <div class="col-12">
                                <div class="page-title-box d-flex align-items-center justify-content-between">
                                    <h4 class="mb-0">Ticket List</h4>

                                   

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
                        <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12" style="overflow:auto;">
                 <div class="table-responsive">
                                            <table class="table ">
                <thead>
                <tr>
                    <th >#</th>
                 
                  <th>Date</th>
                  <th>Subject</th>
                  <th>Your Message</th>
                  <th>Response</th>
                 
                  
                  
                </tr>
                </thead>
                <tbody>
<asp:Repeater ID="Repeater1" runat="server" >
   
    <ItemTemplate>
        <tr>
            <td> <%# Container.ItemIndex+1 %></td>
             
            <td><%#DataBinder.Eval(Container.DataItem, "DOI", "{0:dd/MM/yyyy}")%></td>           
               <td class="text-info"> <%#Eval("subject") %></td>
               <td class="text-info"> <%#Eval("message") %></td>
               <td class="text-success"> <%#Eval("Response") %></td>
            
        </tr>
    </ItemTemplate>

</asp:Repeater>
         </tbody>
                  
              </table>  
                
            
               </div>
                        </div>
         
                </div>
                                    
           
        
           </div>
    </div>
           </div>
                      <%--  </div>
           </div>--%>
    
    

    

      
</asp:Content>



