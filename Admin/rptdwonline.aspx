<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="rptdwonline.aspx.cs" Inherits="Adminmain_rptdwonline" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      
           <div class="card ">
              <div class="form-horizontal">
                            <div class="card-body">
              <h3> Downline Team</h3>
                                        <div class="form-group row">
                <label class="col-lg-2 col-md-2 col-xs-6 ">Enter Distributor  </label>
        <div class="col-lg-6 col-md-3 col-xs-6"> 
                   <asp:TextBox ID="txtuname" runat="server" placeholder="Please Enter User Name For Search"  class="form-control" ></asp:TextBox>              
                  
                </div>
 <div class="col-lg-2 col-md-2 col-xs-6 ">
      
            <asp:Button ID="btnSeach" runat="server" Text="Search" CssClass="btn btn-block btn-danger"   OnClick="btnSeach_Click"/>

      </div>
</div><%--           <div class="form-group row">
                <label class="col-lg-2 col-md-2 col-xs-6 ">Select Side </label>
    <div class="col-lg-3 col-md-3 col-xs-6">
      
           <asp:DropDownList runat="server" ID="drpside"  CssClass="form-control">
                  <asp:ListItem Value="0"> Select</asp:ListItem>
                                  <asp:ListItem Value="A">All</asp:ListItem>
                                  <asp:ListItem Value="L">Left</asp:ListItem>
                                  <asp:ListItem Value="R">Right</asp:ListItem>
                                
                                
                              </asp:DropDownList>
                
      
    </div>
                <label class="col-lg-2 col-md-2 col-xs-6 ">Select Account Status </label>
    <div class="col-lg-3 col-md-3 col-xs-6 ">
     
        
                 <asp:DropDownList runat="server" ID="drpstatus"  CssClass="form-control">
                                   <asp:ListItem Value="0"> Select</asp:ListItem>
                                  <asp:ListItem Value="3">All</asp:ListItem>
                                  <asp:ListItem Value="1">Paid</asp:ListItem>
                                  <asp:ListItem Value="2">Un-Paid</asp:ListItem>                              
                                
                          </asp:DropDownList>
                 
          
        </div>
 --%>
                
<div class="form-group row">
    <div class="col-lg-12" style="overflow:auto; ">
       
      
                  <asp:gridview ID="grdData" runat="server" AutoGenerateColumns="False" CellPadding="10" PageSize="50"  Font-Size="Large" CssClass="table table-bordered table-striped table-hover"

          GridLines="Both" Width="100%" AllowPaging="True"   OnPageIndexChanging="grdData_PageIndexChanging"  >
           
            <columns>
             

<asp:TemplateField HeaderText="#">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <ItemStyle Width="10%" />
</asp:TemplateField>
               <asp:BoundField DataField="username" HeaderText="Distributor" />
<asp:BoundField DataField="Name" HeaderText="Name" />
<asp:BoundField DataField="reffid" HeaderText="Sponsor ID" />
<asp:BoundField DataField="onside" HeaderText="OnSide" />
<asp:BoundField DataField="JoinAmount" HeaderText="Purchase Package" />
<asp:BoundField DataField="PackType" HeaderText="Package Type" />
<asp:BoundField DataField="Status" HeaderText="Account Status" />
<asp:BoundField DataField="dateofjoining" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date of Joining (DOJ)" />
<asp:BoundField DataField="mobile" HeaderText="Mobile Number" />
<asp:BoundField DataField="PV" HeaderText="PV" />
<%--<asp:BoundField DataField="BV" HeaderText="BV" />
<asp:BoundField DataField="Capping" HeaderText="Capping" />
<asp:BoundField DataField="Matching" HeaderText="Matching" />--%>
<%--<asp:BoundField DataField="salary" HeaderText="Salary" />--%>
<asp:BoundField DataField="Royalty" HeaderText="Royalty" />
<asp:BoundField DataField="loginstatus" HeaderText="Login Status" />

            </columns>
          
           
        </asp:gridview>
       </div></div>


                            </div>
               </div>
    </div>
         
</asp:Content>

