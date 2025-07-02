<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="withdrawPending.aspx.cs" EnableEventValidation="true" Inherits="Admin_WREquest" %>

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
              <div class="alert alert-success alert-dismissible" id="sccess" runat="server" visible="false" >
              
                <h4><i class="icon fa fa-check"></i> Alert!</h4>
                  <asp:Label ID="lbsuccess" runat="server" Text="Successfully updated................"></asp:Label>  
              </div>
   
   <div class="card">
                            <div class="form-horizontal">
                                <div class="card-body">
                                    <h4 class="card-title">Withdraw Payment Request List  </h4>
                 <!----form start---->
                       <div class="form-group row">
                   
<div class=" col-sm-offset-4 col-sm-10">
    </div>
 <div class="  col-sm-2">
                   <asp:Button ID="btnExportToExcel" CssClass="btn btn-block btn-success" Text="ExportToExcel" OnClick="btnExportToExcel_Click"  runat="server"/>
                </div>
                 </div>
              
             
       <div class="form-group row">
                 
                    <div class="col-sm-12" style="overflow:auto;">
                          <table class="table table-bordered " >
      
            <tr>
                  <th>#</th>
                  <th>Type</th>                  
                  <th>Member</th>                  
                  <th>Name</th>                  
                  <th>Mobile</th>                  
                 
               
                 <th>Amount</th>
                
                 <th>AdminCharge</th>            
                 <%--<th>TDS</th>--%>            
                  <th>Payout</th>
                
                  <th>Date</th>
              
                 <th>Status</th>
                
                
                
                <th>Approved</th>
                <th>Cencel</th>
              <%--  <th>Hold</th>--%>
            </tr>
       
   
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
      
         <ItemTemplate>
             <tr><td> <%#Container.ItemIndex+1 %> </td>
                 <td>
                 <asp:Label ID="lbpacktype" runat="server" Text='<%#Eval("packtype") %>'></asp:Label></td>

                  <td>
                 <asp:Label ID="lbuname" runat="server" Text='<%#Eval("username") %>'></asp:Label></td>
               <td><%#Eval("name") %></td>
                  <td> <asp:Label ID="lbmobile" runat="server" Text='<%#Eval("mobile") %>'></asp:Label></td>                   

               
                  <td> <asp:Label ID="lbamt" runat="server" Text='<%#Eval("Amount") %>'></asp:Label></td>
                    
                  <td> <asp:Label ID="Label2" runat="server" Text='<%#Eval("AdminCharge") %>'></asp:Label></td>                   
                  <%--<td> <asp:Label ID="Label12" runat="server" Text='<%#Eval("TDS") %>'></asp:Label></td>--%>                   
                  <td> <asp:Label ID="lbpayout" runat="server" Text='<%#Eval("Payout") %>'></asp:Label></td>
                  <td><%#DataBinder.Eval(Container.DataItem, "DOR", "{0:M/d/yy}")%></td>
               
                  <td><%#Eval("status") %></td>
              
                 <td> <asp:Button ID="Button1" runat="server" Text="Approved" CssClass="btn  btn-block  btn-warning" CommandArgument='<%#Eval("Rid") %>' CommandName="Click" /> </td>
              <td> <asp:Button ID="Button2" runat="server" Text="Cencel" CssClass="btn  btn-block  btn-danger" CommandArgument='<%#Eval("Rid") %>' CommandName="delete" /> </td>
            <%--  <td> <asp:Button ID="Button12" runat="server" Text="Hold" CssClass="btn  btn-block  btn-success" CommandArgument='<%#Eval("Rid") %>' CommandName="Hold" /> </td>
          --%>
                 </tr>

         </ItemTemplate>
      
    </asp:Repeater>
    
 </table>
</div>

    </div></div></div>
         </div>
</asp:Content>
