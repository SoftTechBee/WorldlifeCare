<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="rptAccount.aspx.cs" Inherits="Admin_rptAccount" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
   
       
            <div class="alert alert-danger alert-dismissible" id="danger"  runat="server"  visible="false">
              
                <h4><i class="icon fa fa-ban"></i> Alert!</h4>
            <asp:Label ID="lbdanger" runat="server" Text="There is  some thing wrong........."></asp:Label> 
              </div>
     <div class="card">
      <div class="form-horizontal">
                                <div class="card-body">
                     <h3> Member Main Wallet Balance </h3>
                 
              
              <div class="form-group row">
                     <div class=' col-lg-3'>
        <div class="form-group row">
            <label class="control-label col-lg-4">UserName</label>
            <div class="input-group date col-lg-8" >
                <asp:TextBox ID="txtusername" class="form-control"  runat="server" placeholder="Enter User Name" ></asp:TextBox>
                 <span class="input-group-addon">
                    <span class="glyphicon glyphicon-calendar"></span>
                </span>
            </div>
        </div>
    </div>
                     <div class='  col-lg-3'>
        <div class="form-group row">
            <label class="control-label col-lg-4">FromDate</label>
            <div class="input-group date col-lg-8" id='datetimepicker6'>
                <asp:TextBox ID="txtfromdate" class="form-control"  type="date" runat="server" placeholder="DD-MM-YYYY" ></asp:TextBox>
                 <span class="input-group-addon">
                    <span class="glyphicon glyphicon-calendar"></span>
                </span>
            </div>
        </div>
    </div>
    <div class='col-lg-3'>
        <div class="form-group row">
            <label class="control-label col-lg-4">ToDate</label>
            <div class="input-group date col-lg-8" id="datetimepicker7">
                 <asp:TextBox ID="txttodate" class="form-control"  type="date" runat="server" placeholder="DD-MM-YYYY" ></asp:TextBox>
               <span class="input-group-addon">
                    <span class="glyphicon glyphicon-calendar"></span>
                </span>
            </div>
        </div>
    </div>
                 <div class="col-lg-2" >
        <div class="form-group row">
             <div class=" col-lg-offset-4 col-lg-8 " >
            <asp:Button ID="btngenrate" runat="server" Text="Search" CssClass="btn btn-block btn-danger"   OnClick="btngenrate_Click"/>
</div>
        </div></div>
                   
                     </div>
                <div class="form-group row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div style="overflow:auto;">
                <table id="example1" class="table table-bordered table-striped table-hover " style="cellspacing:0;width:100%">
                <thead>
                <tr>
                    <th>#</th>
                  <th>DOJ</th>
                    <th >Member</th>
                  <th>Name</th>
                 <th>Total Income</th>
                  
                  
                </tr>
                </thead>
                <tbody>
<asp:Repeater ID="Repeater1" runat="server" >
   
    <ItemTemplate>
        <tr>
            <td> <%# Container.ItemIndex+1 %></td>
             
            <td><%#DataBinder.Eval(Container.DataItem, "dateofjoin", "{0:dd/MM/yyyy}")%></td>
            <td> <%#Eval("username") %></td>
             <td> <%#Eval("name") %></td>
               <td> <%#Eval("totalincome") %></td>
        </tr>
    </ItemTemplate>

</asp:Repeater>
         </tbody>
                <tfoot>
                <tr>
                       <th >#</th>
                 <th ></th>
                 
                  <th>Total</th>
                  <th>     </th>
                               <th><asp:Label ID="lbtotal" runat="server" Text=""></asp:Label>
   </th>
                  
                </tr>
                </tfoot>
              </table>  
                </div>
            </div>
               </div>
                    </div>
            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->
      
    <!-- /.content -->

    

<!-- page script -->

</asp:Content>

