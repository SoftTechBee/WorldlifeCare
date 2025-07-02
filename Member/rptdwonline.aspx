<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MasterPage.master" AutoEventWireup="true" CodeFile="rptdwonline.aspx.cs" Inherits="User_rptdwonline" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
 
    <%--<div class=" container">--%>
        <div class="card">
            <div class="card-header">
              <h5 class="card-title">Downline Member Detail</h5>
                
            </div>
            <!-- /.card-header -->
            <div class="card-body">
    <div style="overflow:auto;color:#000000; ">
       
      <asp:gridview ID="grdData" runat="server" AutoGenerateColumns="False" CellPadding="10" PageSize="100"  Font-Size="Large" CssClass="table table-bordered  " 

          GridLines="Both" Width="100%" AllowPaging="True"   OnPageIndexChanging="grdData_PageIndexChanging"  >
           
            <columns>
             

<asp:TemplateField HeaderText="#">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <ItemStyle Width="10%" />
</asp:TemplateField>
               <asp:BoundField DataField="Level" HeaderText="LevelNo" />
               <asp:BoundField DataField="username" HeaderText="Distributor" />
<asp:BoundField DataField="Name" HeaderText="Name" />
<asp:BoundField DataField="reffid" HeaderText="Sponsor ID" />
<asp:BoundField DataField="onside" HeaderText="OnSide" />
<asp:BoundField DataField="JoinAmount" HeaderText="Purchase Package" />
<asp:BoundField DataField="PackType" HeaderText="Package Type" />
<asp:BoundField DataField="Status" HeaderText="Account Status" />
<asp:BoundField DataField="dateofjoining" DataFormatString="{0:dd/MM/yyyy}" HeaderText="DateofJoining" />
<asp:BoundField DataField="mobile" HeaderText="Mobile Number" />
<asp:BoundField DataField="PV" HeaderText="PV" />
<%--<asp:BoundField DataField="BV" HeaderText="BV" />--%>
<%--<asp:BoundField DataField="Capping" HeaderText="Capping" />--%>
<%--<asp:BoundField DataField="Matching" HeaderText="Matching" />--%>
<asp:BoundField DataField="salary" HeaderText="Salary" />
<asp:BoundField DataField="Royalty" HeaderText="Royalty" />
<asp:BoundField DataField="loginstatus" HeaderText="Login Status" />
            </columns>
          
           
        </asp:gridview>
            
       </div></div></div>
       </div>
   <%-- </div>--%>
</asp:Content>

