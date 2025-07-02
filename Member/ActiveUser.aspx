<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MasterPage.master" AutoEventWireup="true" CodeFile="ActiveUser.aspx.cs" Inherits="User_Default"  EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
     
       
                         <div class="alert alert-danger alert-dismissible" id="danger"  runat="server"  visible="false">
              
                <h4><i class="icon fa fa-ban"></i> Alert!</h4>
            <asp:Label ID="lbdanger" runat="server" Text="There is  some thing wrong........."></asp:Label> 
              </div>
            <div class="card">
            <div class="card-header">
              <h5 class="card-title">Active Member Detail</h5>
                
            </div>
            <!-- /.card-header -->
         <div class="card-body">
              <div class="input-group input-group-xlg mt-2" style="margin-bottom:30px;">
           <asp:TextBox ID="txtsearch" CssClass="form-control" runat="server" placeholder="Enter UserName"></asp:TextBox>
               
                    <span class="input-group-btn" style="margin-left:10px;" >
          <asp:Button ID="btnsearch" OnClick="btnsearch_Click1" runat="server" Text="Go!" CssClass="btn btn-info btn-flat btn-lg"  />
                    
                    </span>
              </div>
    <div class="row"  >

<div  class="col-lg-12" style="overflow:auto;">
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand1">
        <HeaderTemplate>
<table class="table table-bordered table-responsive table-hover" >
        <thead>
            <tr>
                <th>#</th>
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
                   <th>BV</th>
                   <th>Capping</th>
                   <th>Matching</th>
                   <th>Current Salary</th>
                   <th>Current Royalty</th>
                   <th>Blocked Status </th>
            </tr>
        </thead>
    <tbody>
        </HeaderTemplate>
         <ItemTemplate>
             <tr>
                <td> <%#Container.ItemIndex+1 %> </td>
               <td>   <asp:Label ID="lbsponser" runat="server" Text='<%#Eval("reffid") %>'></asp:Label></td>
                  
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
                   <td><%#Eval("BV") %></td>
                   <td><%#Eval("Capping") %></td>
                   <td><%#Eval("Matching") %></td>
                   <td><%#Eval("salary") %></td>
                   <td><%#Eval("Royalty") %></td>
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
        
</asp:Content>

