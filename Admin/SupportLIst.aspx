<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="SupportLIst.aspx.cs" EnableEventValidation="true" Inherits="Admin_SupportLIst" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
           <div class="page-content">
                    <div class="container-fluid">

                        <!-- start page title -->
                        <div class="row mb-2">
                            <div class="col-12">
                                <div class="page-title-box d-flex align-items-center justify-content-between">
                                    <h4 class="mb-0">Member Support</h4>

                                    <%--<div class="page-title-right">
                                        <ol class="breadcrumb m-0">
                                             <%--<li class="breadcrumb-item"><a href="javascript: void(0);">Minible</a></li>>
                                            <li class="breadcrumb-item active"><a href="Home.aspx">Home</a>/Member Support</li>
                                        </ol>
                                    </div>--%>

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
      
                          
                                
                        
      
                             
                                <div class="row">
                            <div class="col-12">
      <div class="card ">
                            <div class="form-horizontal">
                                <div class="card-body">
                                   
                       <div class="form-group row">
                   
<div class=" col-sm-offset-4 col-sm-10">
    </div>
 <div class="  col-sm-2">
                   <asp:Button ID="btnExportToExcel" CssClass="btn btn-block btn-success" Text="ExportToExcel" OnClick="btnExportToExcel_Click"  runat="server"/>
                </div>
                 </div>
             
             
     <div class="form-group row">
                 
                    <div class="col-sm-12" style="overflow:auto;">
                          <table class="table table-bordered table-hover " >
      
            <tr>
                  <th>#</th>
                   <th>Date</th>
                   <th>Member</th>
                  <th>Subject</th>
                  <th>Your Message</th>
                  <th>Response</th>
                  <th>New Responsce</th>    
                <th>Action</th>
                
            
            </tr>
       
   
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
      
         <ItemTemplate>
             <tr><td> <%#Container.ItemIndex+1 %> </td>
                 
                <td><%#DataBinder.Eval(Container.DataItem, "DOI", "{0:dd/MM/yyyy}")%></td>           
               <td class="text-info"> <%#Eval("username") %></td>
               <td class="text-info"> <%#Eval("subject") %></td>
               <td class="text-info"> <%#Eval("message") %></td>
               <td class="text-success"> <%#Eval("Response") %></td>              
               <td> <asp:TextBox ID="txtResposnce" CssClass="form-control" runat="server" Text=''></asp:TextBox></td>
                       
                 
                 
                 <td> <asp:Button ID="Button1" runat="server" Text="Approved" CssClass="btn  btn-block  btn-warning" CommandArgument='<%#Eval("sid") %>' CommandName="Click" /> </td>

            
                 </tr>

         </ItemTemplate>
      
    </asp:Repeater>
    
 </table>
</div>

    </div></div></div>
                                </div>
                                    </div>
                        </div>
                        </div>
               </div>
    


</asp:Content>

