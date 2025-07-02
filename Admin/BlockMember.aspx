<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="BlockMember.aspx.cs" Inherits="Admin_BlockMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
         <div class="alert alert-danger alert-dismissible" id="Div1"  runat="server"  visible="false">
              
                <h4><i class="icon fa fa-ban"></i> Alert!</h4>
            <asp:Label ID="Label1" runat="server" Text="There is  some thing wrong........."></asp:Label> 
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
           
    <!-----Alert End----->
           <div class="alert alert-danger alert-dismissible" id="danger"  runat="server"  visible="false">
              
                <h4><i class="icon fa fa-ban"></i> Alert!</h4>
            <asp:Label ID="lbdanger" runat="server" Text="There is  some thing wrong........."></asp:Label> 
              </div>
            <div class="card ">
                            <div class="form-horizontal">
                                <div class="card-body">
                                    <h4 class="card-title mb-2">Blocked Distributor Detail </h4>
                 <!----form start---->
                                        <div class=" form-group row"  >

<div  class="col-lg-12" >
              <div class="input-group input-group-sm" style="margin-bottom:30px;">
           <asp:TextBox ID="txtsearch" CssClass="form-control" runat="server" placeholder="Enter UserName"></asp:TextBox>
               
                    <span class="input-group-btn" style="margin-left:10px;">
          <asp:Button ID="btnsearch" OnClick="btnsearch_Click" runat="server" Text="Go!" CssClass="btn btn-info btn-flat btn-lg"  />
                    
                    </span>
              </div>
    </div>
                                        </div>
                            <div class=" form-group row">
<div  class="col-lg-12" style="overflow:auto;">
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand1">
        <HeaderTemplate>
<table class="table table-bordered table-responsive table-hover" >
        <thead>
            <tr>
                  <th>#</th>
                 <th>Sponser Id</th>
                 
                  <th>Distributor</th>
                  <th>Name</th>
                  <th>Mobile</th>
                  <th>Statue</th>
                <th>JoiningAmount</th>
               
                  <th>Action</th>
            </tr>
        </thead>
    <tbody>
        </HeaderTemplate>
         <ItemTemplate>
             <tr>
                 <td> <%#Container.ItemIndex+1 %> </td>
                  <td>
                    <asp:Label ID="lbsponser" runat="server" Text='<%#Eval("reffid") %>'></asp:Label></td>
                  
                  <td><%#Eval("username") %></td>
                  <td><%#Eval("name") %></td>
                  <td><%#Eval("mobile") %></td>
                  <td><%#Eval("status") %></td>
                 <td> <asp:Label ID="lbAmount" runat="server" Text='<%#Eval("JoinAmount") %>'></asp:Label></td>
                
                 <td> <asp:Button ID="Button1" runat="server" Text="Active" CssClass="btn  btn-block btn-success" CommandArgument='<%#Eval("username") %>' CommandName="Click" /> </td>
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

        
</asp:Content>


