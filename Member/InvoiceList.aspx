<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MasterPage.master" AutoEventWireup="true" CodeFile="InvoiceList.aspx.cs" Inherits="User_TopUpWallet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
          
     <div class="page-body">
         <div class="alert alert-danger dark alert-dismissible fade show" role="alert" id="danger"  runat="server"  visible="false">
         
          <p>  
              <asp:Label ID="lbdanger" runat="server" Text="There is  some thing wrong........."></asp:Label> </p>
                    <button class="btn-close" type="button" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>
              
                <div class="row">
                    <div class="col-12 align-self-center">
                        <h5 class="page-title">My Invoice List</h5>
                    </div>
                 
                </div>

 
        
       
   
        <div class="container-fluid">
       <div class="row">
<div  class="col-lg-12">
           <div class="card " >
      
                            <div class="card-body">
            
   <asp:Label ID="lbname" runat="server" Text="" Visible="false"></asp:Label>
           
<div class="form-group row">
            <div class="col-lg-12" style="overflow:auto">
                <table id="example1" class="table table-bordered table-striped table-hover " style="cellspacing:0;width:100%">
                <thead>
                <tr>
                    <th >#</th>
                  <th>UserName</th>
                  <th>InvoiceDate</th>
                   <th>InvoiceNumber</th>
                   <%--<th>Total Product</th>--%>
                   <th>Total MRP</th>
                    <th>Total DP</th>
                    <th>Total Discount</th>
                      <th>Total SV</th>
                      <th>View</th>
                  
                  
                </tr>
                </thead>
                <tbody>
<asp:Repeater ID="Repeater1" runat="server"  OnItemCommand="Repeater1_ItemCommand">
   
    <ItemTemplate>
        <tr>
            <td> <%# Container.ItemIndex+1 %></td>
                 <td><asp:label ID="lbusername" runat="server" Text='<%#Eval("UserName") %>'></asp:label></td>
              <td><%#DataBinder.Eval(Container.DataItem, "DOI", "{0:dd/MM/yyyy}")%></td>
             <td> <%#Eval("InvoiceNo") %></td>
             <%--<td> <%#Eval("qty") %></td>--%>

             <td> <%#Eval("TotalAmt") %></td>
             <td> <%#Eval("PaidAmt") %></td>
               <td> <%#Eval("DiscountAmt") %></td>
               <td> <%#Eval("TotalBV") %></td>
             <td> <asp:Button ID="Button1" runat="server" Text="Invoice" CssClass="btn  btn-block btn-danger" CommandArgument='<%#Eval("InvoiceNo") %>' CommandName="View" /> </td>
           
        </tr>
    </ItemTemplate>

</asp:Repeater>
         </tbody>
               
              </table> 
                
                  
            
                
            </div>
    </div>
                                
                 
            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->
        </div>
        <!-- /.col -->
      </div>
           
</div>
</div>

    

<!-- page script -->
      
</asp:Content>


