<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MasterPage.master" AutoEventWireup="true" CodeFile="NotActiveUser.aspx.cs" Inherits="User_Default"  EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
     
       
                         <div class="alert alert-danger alert-dismissible" id="danger"  runat="server"  visible="false">
              
                <h4><i class="icon fa fa-ban"></i> Alert!</h4>
            <asp:Label ID="lbdanger" runat="server" Text="There is  some thing wrong........."></asp:Label> 
              </div>
            <div class="card">
            <div class="card-header">
              <h5 class="card-title">Not Active Member Detail</h5>
                
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
                <th>Member</th>
                <th>Name</th>
                <th>Sponser ID</th>               
                <th>Sponser Name</th>               
                <th>Date Of Joining</th>
                <%--<th>Amount</th>--%>
                <th>Status</th>
                  <th>Active</th>
            </tr>
        </thead>
    <tbody>
        </HeaderTemplate>
         <ItemTemplate>
             <tr>
                <td> <%#Container.ItemIndex+1 %> </td>
                <td><%#Eval("UserName") %></td>
                <td><%#Eval("Name") %></td>
                <td><asp:label ID="lbsponser" runat="server"  Text='<%#Eval("ReffID") %>'></asp:label></td>
                <td><asp:label ID="lbsponsername" runat="server"  Text='<%#Eval("Reffname") %>'></asp:label></td>
             
                <td><%#DataBinder.Eval(Container.DataItem, "DateOFJOining", "{0:dd/MM/yyyy}")%></td>
                <%--<td><%#Eval("JoinAmount") %></td>--%>
                    <td><%#Eval("Status") %></td>
                 <td> <asp:Button ID="Button1" runat="server" Text="Active" CssClass="btn  btn-block btn-danger" CommandArgument='<%#Eval("username") %>' CommandName="Click" /> </td>
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

