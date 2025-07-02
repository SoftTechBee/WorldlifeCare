<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MasterPage.master" AutoEventWireup="true" CodeFile="WalletActionList.aspx.cs" Inherits="Member_WalletApprovedList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
             <div class="content-body">
            <!-- Content -->
            <div class="content">
           
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
            
         
                        <!-- start page title -->
                        <div class="row">
                            <div class="col-12">
                                <div class="page-title-box d-flex align-items-center justify-content-between">
                                    <h6 class="mb-0">Fund Status</h6>

                                  

                                </div>
                            </div>
                        </div>
                <br />
                        <!-- end page title -->

 
    <div class="card">
                            <div class="form-horizontal">
                                <div class="card-body">
                                   
                             

  
               
                    
                
               
                   <div class=" form-group row">   
                                   
                <div class="col-lg-12" style="overflow:auto;">
<asp:Repeater ID="Repeater1" runat="server" >
    <HeaderTemplate>
   <table id="example1" class="table table-bordered primary-table-bordered table-striped table-hover" >
                <thead>
                <tr>
                  <tr>   <th >#</th>
                  <th>UserName</th>
                 
                  <th>Amount</th>
                 <th>Status</th>
                 <th>Pyment Mode</th>
                 <th>TXID/HASHCODE</th>
                      <th>Receipt</th>
                  <th>Date Of Request</th>
                  <th>Date Of Action</th>
                   
                     
                </tr>
                </thead>
                <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td> <%#Container.ItemIndex+1 %> </td>           
            
             <td>
          <asp:Label ID="lbname" runat="server" Text='<%#Eval("UserName") %>'></asp:Label> </td>
                <td>
          <asp:Label ID="lbamount" runat="server" Text='<%#Eval("Amount") %>'></asp:Label> </td>
         
             <td> <%#Eval("[Status]") %></td>
             <td> <%#Eval("[PaymentMode]") %></td>
             <td> <%#Eval("[ClientRemark]") %></td>
           <td> <a href='<%#Eval("Receipt") %>'><img src='<%#Eval("Receipt") %>' height="50" width="100" /></a></td>
            
          <td><%#DataBinder.Eval(Container.DataItem, "DOR", "{0:dd/MM/yyyy}")%></td>
          <td><%#DataBinder.Eval(Container.DataItem, "DOD", "{0:dd/MM/yyyy}")%></td>
          
   
            </tr>
    </ItemTemplate>
<FooterTemplate>

     </tbody>
               
              </table>
</FooterTemplate>
</asp:Repeater>
             </div> 
                
            </div>
               
            </div>
            <!-- /.box-body -->
         
          <!-- /.box -->
        </div>
        <!-- /.col -->
   </div>
   </div>
   </div>
    <!-- /.content -->

    

<!-- page script -->
      
</asp:Content>




