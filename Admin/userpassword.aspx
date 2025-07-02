<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="userpassword.aspx.cs" Inherits="Admin_userpassword" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  

    <div class="row">
         <div class="col-lg-12">

         <div class="input-group input-group-xlg" style="margin-bottom:30px;">
           <asp:TextBox ID="txtsearch" CssClass="form-control" runat="server" placeholder="Enter UserName"></asp:TextBox>
               
                    <span class="input-group-btn" style="margin-left:10px;">
          <asp:Button ID="btnsearch" OnClick="btnsearch_Click" runat="server" Text="Go!" CssClass="btn btn-info btn-flat btn-lg"  />
                    
                    </span>
              </div>
        </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
               
                    <div class="card">
                            <div class="form-horizontal">
                                <div class="card-body " style="overflow:auto">


          
    
                                     <asp:gridview ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="10" PageSize="10"  Font-Size="Large" CssClass="table table-bordered table-striped table-hover"

          GridLines="Both" Width="100%" AllowPaging="True"    OnPageIndexChanging="grdData_PageIndexChanging"   >
           
            <columns>
             

<asp:TemplateField HeaderText="#">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <ItemStyle Width="10%" />
</asp:TemplateField>
                <asp:boundfield DataField="username" HeaderText="UserName"></asp:boundfield>
                <asp:boundfield DataField="Name" HeaderText="Name"></asp:boundfield>
                <asp:boundfield DataField="mobile" HeaderText="Mobile"></asp:boundfield>
                <asp:boundfield DataField="password"  HeaderText="Password"></asp:boundfield>
                <asp:boundfield DataField="transpassword" HeaderText="Trans Password"></asp:boundfield>
               
            </columns>
          
           
        </asp:gridview>
 
                  </div>
        </div>
        </div>
        </div>
        </div>
  
</asp:Content>

