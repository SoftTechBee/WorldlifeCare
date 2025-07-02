<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MasterPage.master" AutoEventWireup="true" CodeFile="rptMatchingBinaryIncome.aspx.cs" Inherits="User_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
        
            <div class="alert alert-danger alert-dismissible" id="danger"  runat="server"  visible="false">
              
                <h4><i class="icon fa fa-ban"></i> Alert!</h4>
            <asp:Label ID="lbdanger" runat="server" Text="There is  some thing wrong........."></asp:Label> 
              </div>
      <div class="row">
        <div class="col-lg-12">
     <div class="card">
            <div class="card-header">
              <h5 class="card-title"> Matching Binary Income </h5>
                
            </div>
            <!-- /.card-header -->
            <div class="card-body" >
             <div class=" form-horizontal">
           <div class=" form-group row">
                <label class="col-lg-2 col-md-2 col-xs-6 col-sm-6">Select Form  Date </label>
    <div class="ccol-lg-3 col-md-3 col-xs-6 col-sm-6">
      
            <div class='input-group date' id='datetimepicker6'>
                <asp:TextBox ID="txtfromdate" class="form-control" required="" type="date" runat="server" placeholder="DD-MM-YYYY" ></asp:TextBox>
                 <span class="input-group-addon">
                    <span class="glyphicon glyphicon-calendar"></span>
                </span>
            </div>
      
    </div>
                <label class="col-lg-2 col-md-2 col-xs-6 col-sm-6">Select TO  Date </label>
    <div class="col-lg-3 col-md-3 col-xs-6 col-sm-6">
     
           
            <div class='input-group date' id='datetimepicker7'>
                 <asp:TextBox ID="txttodate" class="form-control" required="" type="date" runat="server" placeholder="DD-MM-YYYY" ></asp:TextBox>
               <span class="input-group-addon">
                    <span class="glyphicon glyphicon-calendar"></span>
                </span>
          
        </div>
    </div>
                 <div class="col-lg-2 col-md-2 col-xs-6 col-sm-6">
      
            <asp:Button ID="btnSeach" runat="server" Text="Search" CssClass="btn btn-block btn-foursquare"   OnClick="btnSeach_Click"/>

      </div>
</div>
               
                    <div class="form-group">
                        <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12" style="overflow:auto;">
           
                  
                <asp:gridview ID="grdData" runat="server" 

AutoGenerateColumns="False" CellPadding="10" PageSize="100"  Font-Size="Large" CssClass="table table-bordered table-striped table-hover"

          GridLines="Both" Width="100%" AllowPaging="True"

            OnPageIndexChanging="grdData_PageIndexChanging"  ShowFooter="true">
           
            <columns>
             

<asp:TemplateField HeaderText="#">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <ItemStyle Width="10%" />
</asp:TemplateField>
                <asp:boundfield DataField="username" HeaderText="UserName"></asp:boundfield>
                <asp:boundfield DataField="date" DataFormatString="{0:d}" HeaderText="Date"></asp:boundfield>
                <asp:boundfield DataField="Remark"  HeaderText="Particular"></asp:boundfield>
                <asp:boundfield DataField="Credit" HeaderText="Credit"></asp:boundfield>
                <asp:boundfield DataField="Debit" HeaderText="Debit"></asp:boundfield>
              
            </columns>
          
           
        </asp:gridview>
            
               
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

    

<!-- page script -->
      
</asp:Content>

