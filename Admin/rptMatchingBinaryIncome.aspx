<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="rptMatchingBinaryIncome.aspx.cs" Inherits="Admin_rptMachingIncome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

            <div class="alert alert-danger alert-dismissible" id="danger"  runat="server"  visible="false">
              
                <h4><i class="icon fa fa-ban"></i> Alert!</h4>
            <asp:Label ID="lbdanger" runat="server" Text="There is  some thing wrong........."></asp:Label> 
              </div>
    <div class="card">
                            <div class="form-horizontal">
                                <div class="card-body">
                                       <div class=" form-group row">
                                           <div class=" col-lg-10">
                                    <h2 class="card-title">Binary Income </h2>
                                           </div>
                                             
 <div class="  col-lg-2">
                   <asp:Button ID="btnExportToExcel" CssClass="btn btn-block  btn-dark" Text="ExportToExcel" OnClick="btnExportToExcel_Click"  runat="server"/>
                </div>
                                           </div>
                                     <div class="form-group row">
                   
                   

  
                 </div>
                 <!----form start---->
                                      <div class=" form-group row">
                                          <label class="   control-label col-lg-3 col-md-3 col-xs-6 ">Enter UserName</label>
                                          <label class="  control-label  col-lg-3 col-md-3 col-xs-6 ">Select FromDate</label>
                                          <label class="  control-label col-lg-3 col-md-3 col-xs-6 ">Select ToDate</label>



                                          </div>
                            <div class=" form-group row">
                   <div class="col-lg-3 col-md-3 col-xs-6 ">

                     <asp:TextBox ID="txtsearch" CssClass="form-control" runat="server" placeholder="Enter UserName"></asp:TextBox>
          
                </div>
    <div class="ccol-lg-3 col-md-3 col-xs-6 ">
      
            <div class='input-group date' id='datetimepicker6'>
                <asp:TextBox ID="txtfromdate" class="form-control"  type="date" runat="server" placeholder="Select Form  Date " ></asp:TextBox>
                 <span class="input-group-addon">
                    <span class="glyphicon glyphicon-calendar"></span>
                </span>
            </div>
      
    </div>
             
    <div class="col-lg-3 col-md-3 col-xs-6 ">
     
           
            <div class='input-group date' id='datetimepicker7'>
                 <asp:TextBox ID="txttodate" class="form-control"  type="date" runat="server" placeholder="Select TO  Date " ></asp:TextBox>
               <span class="input-group-addon">
                    <span class="glyphicon glyphicon-calendar"></span>
                </span>
          
        </div>
    </div>
                 <div class="col-md-2 col-xs-6 col-lg-3">
      
            <asp:Button ID="btnSeach" runat="server" Text="Search" Height="40px" Width="150px" CssClass="btn btn-block btn-success"   OnClick="btnsearch_Click"/>

      </div>
</div>
                
               
                    <div class="form-group">
                        <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12" style="overflow:auto;">
             
                <table id="example1" class="table table-bordered table-striped table-hover " >
                <thead>
                <tr>
                    <th >#</th>
                  <th>DOJ</th>
                  <th>DOA</th>
                    <th >UserName</th>
                  <th>Name</th>
                 <th>Total Income</th>
                 <th>View Income</th>
                  
                  
                </tr>
                </thead>
                <tbody>
<asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >
   
    <ItemTemplate>
        <tr>
            <td> <%# Container.ItemIndex+1 %></td>
             
            <td><%#DataBinder.Eval(Container.DataItem, "dateofjoin", "{0:dd/MM/yyyy}")%></td>
            <td><%#DataBinder.Eval(Container.DataItem, "DOA", "{0:dd/MM/yyyy}")%></td>
            <td> <%#Eval("username") %></td>
             <td> <%#Eval("name") %></td>
               <td> <%#Eval("totalincome") %></td>
             <td> <asp:Button ID="Button1" runat="server" Height="40px" Width="100px" Text="View" CssClass="btn  btn-block  btn-warning" CommandArgument='<%#Eval("username") %>' CommandName="View" /> </td>
           

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
                   <th>     </th> 
                </tr>
                </tfoot>
              </table>  
                
            </div>
               </div>
            </div>
         </div>
            <!-- /.card-body -->
          </div>
          <!-- /.card -->
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->
    </section>
    <!-- /.content -->

    

<!-- page script -->
</asp:Content>

