<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="direct.aspx.cs" Inherits="Admin_DirectList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                      <div class="alert alert-danger alert-dismissible" id="danger"  runat="server"  visible="false">
              
                <h4><i class="icon fa fa-ban"></i> Alert!</h4>
            <asp:Label ID="lbdanger" runat="server" Text="There is  some thing wrong........."></asp:Label> 
              </div>

                  <div class="row">
<div  class="col-lg-12">
           <div class="card ">
                            <div class="card-body">
              <h3> Direct Team</h3>
          <div class="form-group row">
                <label class="col-lg-2 col-md-2 col-xs-6 ">Enter UserName </label>
    <div class="ccol-lg-8 col-md-3 col-xs-6">
      
      
                <asp:TextBox ID="txtUname" class="form-control"  runat="server" placeholder="Enter UserName " ></asp:TextBox>
               
      
    </div>
                
                 <div class="col-lg-2 col-md-2 col-xs-6 ">
      
            <asp:Button ID="btnSeach" runat="server" Text="Search" CssClass="btn btn-block btn-danger"   OnClick="btnSeach_Click"/>

      </div>
</div>
<div class="form-group row">
    <div  class="col-lg-12" style="overflow:auto;">
              
            <!-- /.box-header -->
  
<asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
   <table id="example1" class="table table-bordered table-striped table-hover " style="cellspacing:0;width:100%">
                <thead>
                <tr>
                  <tr>   <th >#</th>
                  <th>Sponsor Id</th>
                 
                  <th>Username</th>
                  <th>Name</th>
                 <th>DateOfJoin  </th>
                   <th>DateOfActive  </th>
                  <th>Mobile</th>
                  <th>Side</th>
                  <th>Status</th>
                   <th>Amount</th>
                   <th>Package</th>
                   <th>PV</th>
                  <%-- <th>BV</th>
                   <th>Capping</th>
                   <th>Matching</th>--%>
                   <th>Current Salary</th>
                   <th>Current Reward</th>
                   <th>Blocked Status </th>
                  
                  
                </tr>
                </thead>
                <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td> <%#Container.ItemIndex+1 %> </td>
           <td> <asp:Label ID="lbsponser" runat="server" Text='<%#Eval("reffid") %>'></asp:Label></td>
                  
                  <td><%#Eval("username") %></td>
                  <td><%#Eval("name") %></td>
                  <td><%#DataBinder.Eval(Container.DataItem, "dateofjoin", "{0:dd/MM/yyyy}")%></td>
                     <td><%#DataBinder.Eval(Container.DataItem, "doa", "{0:dd/MM/yyyy}")%></td>
                  <td><%#Eval("mobile") %></td>
                  <td><%#Eval("onSide") %></td>
                  <td><%#Eval("status") %></td>
                   <td><%#Eval("JoinAmount") %></td>
                   <td><%#Eval("PackType") %></td>
                   <td><%#Eval("PV") %></td>
                 <%--  <td><%#Eval("BV") %></td>
                   <td><%#Eval("Capping") %></td>
                   <td><%#Eval("Matching") %></td>--%>
                   <td><%#Eval("salary") %></td>
                   <td><%#Eval("reward") %></td>
                                      <td><%#Eval("loginstatus") %></td>
          
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
               </div>
    
            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->
    

    

<!-- page script -->
      
</asp:Content>



