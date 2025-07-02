<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="rptViewIncome.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script src="../assets/extra-libs/multicheck/datatable-checkbox-init.js"></script>
    <script src="../assets/extra-libs/multicheck/jquery.multicheck.js"></script>
    <script src="../assets/extra-libs/DataTables/datatables.min.js"></script>
  
     
        
            <div class="alert alert-danger alert-dismissible" id="danger"  runat="server"  visible="false">
              
                <h4><i class="icon fa fa-ban"></i> Alert!</h4>
            <asp:Label ID="lbdanger" runat="server" Text="There is  some thing wrong........."></asp:Label> 
              </div>
    
      <div class="card ">
                            <div class="card-body">
                                <h5 class="card-title">Report Income </h5>
                                <div class="table-responsive">
            <!-- /.box-header -->
            <div class="box-body">
                
                <div style="overflow:auto;">
                <table id="example1" class="table table-bordered table-striped table-hover " style="cellspacing:0;width:100%">
                <thead>
                <tr>
                    <th >#</th>
                  <th>UserName</th>
                  <th>Date</th>
                  <th>Particular</th>
                 <th>Credit</th>
                 
                  
                </tr>
                </thead>
                <tbody>
<asp:Repeater ID="Repeater1" runat="server" >
   
    <ItemTemplate>
        <tr>
            <td> <%# Container.ItemIndex+1 %></td>
             <td> <%#Eval("username") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, "date", "{0:dd/MM/yyyy}")%></td>
             <td> <%#Eval("Remark") %></td>
               <td> <%#Eval("Debit") %></td>
           
        </tr>
    </ItemTemplate>

</asp:Repeater>
         </tbody>
                <tfoot>
                <tr>
                       <th >#</th>
                 <th ></th>
                  <th></th>
                  <th>Total</th>
                  <th> <asp:Label ID="lbcredit" runat="server" Text=""></asp:Label>
    </th>
                            
                </tr>
                </tfoot>
              </table>  
                
            </div>
               
            </div>
            <!-- /.box-body -->
          </div>
                                </div>
          </div>
         
      
</asp:Content>


