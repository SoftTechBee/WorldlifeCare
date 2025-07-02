<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="withdrawRejectList.aspx.cs" EnableEventValidation="true" Inherits="Admin_withdrawRejectList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
       
             
         <div class="alert alert-danger alert-dismissible" id="danger"  runat="server"  visible="false">
                
                <h4><i class="icon fa fa-ban"></i> Alert!</h4>
            <asp:Label ID="lbdanger" runat="server" Text="There is  some thing wrong........."></asp:Label> 
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
   <div class="card">
                            <div class="form-horizontal">
                                <div class="card-body">
                                    <h4 class="card-title">Reject List  </h4>

                 <!----form start---->
                                  

                       <div class="form-group row">
                   

                   
<div class=" col-sm-offset-4 col-sm-10">
    </div>
 <div class="  col-sm-2">
                   <asp:Button ID="btnExportToExcel" CssClass="btn btn-block btn-success" Text="ExportToExcel" OnClick="btnExportToExcel_Click"  runat="server"/>
                </div>
                 </div>
                                      <div class="form-group row">
                 <div class="input-group input-group-xlg" style="margin-top:30px;">
           <asp:TextBox ID="txtsearch" CssClass="form-control" runat="server" placeholder="Enter Distributor"></asp:TextBox>
               
                    <span class="input-group-btn">
          <asp:Button ID="btnsearch" runat="server" Text="Go!"    OnClick="btnsearch_Click" CssClass="btn btn-info btn-flat btn-lg"  />
                    
                    </span>
              </div>
                 </div>

               </div>
           <div class="card-body">  
    <div class="form-group row" >
<div  class="col-lg-12"  style="overflow:auto;"> 
    <asp:Repeater ID="Repeater1" runat="server" >
        <HeaderTemplate>
<table class="table table-bordered table-responsive table-hover" >
        <thead>
            <tr>
                  <th>#</th>
                  <th>Member</th>                  
                  <th>MODE</th>
               
                 <th>Amount</th>
                
                 <th>AdminCharge</th>
                 <th>TDS</th>
                 <th>FundWallet</th>
                  <th>Payout</th>
                
                  <th>DateOfRequest</th>
                  <th>DateOfReject</th>
                   <th>Bank</th>
                           <th>Branch</th>
                           <th>IFSC</th>
                           <th>AccNo</th>
                           <th>AccHolder</th>
                 <th>Status</th>
                
                
                
            </tr>
        </thead>
    <tbody>
        </HeaderTemplate>
         <ItemTemplate>
             <tr><td> <%#Container.ItemIndex+1 %> </td>
                  <td>
                 <asp:Label ID="lbuname" runat="server" Text='<%#Eval("username") %>'></asp:Label></td>
               <td><%#Eval("Packtype") %></td>
                  <td> <asp:Label ID="lbamt" runat="server" Text='<%#Eval("Amount") %>'></asp:Label></td>
                    
                 <td> <asp:Label ID="Label2" runat="server" Text='<%#Eval("AdminCharge") %>'></asp:Label></td>                   
                  <td> <asp:Label ID="Label3" runat="server" Text='<%#Eval("TDS") %>'></asp:Label></td>                   
                  <td> <asp:Label ID="Label4" runat="server" Text='<%#Eval("WalletFund") %>'></asp:Label></td>                   
                
                  <td> <asp:Label ID="Label1" runat="server" Text='<%#Eval("Payout") %>'></asp:Label></td>
                  <td><%#DataBinder.Eval(Container.DataItem, "DOR", "{0:dd/MM/yyyy}")%></td>
                  <td><%#DataBinder.Eval(Container.DataItem, "DOA", "{0:dd/MM/yyyy}")%></td>
                    <td><%#Eval("bankname") %></td>
                           <td><%#Eval("branchname") %></td>
                           <td><%#Eval("ifsc") %></td>
                           <td>'<%#Eval("accno") %></td>
                           <td><%#Eval("holdername") %></td>
                  <td><%#Eval("status") %></td>
                 
                 
                 </tr>

         </ItemTemplate>
        <FooterTemplate>
            </tbody>
 </table>
        </FooterTemplate>
    </asp:Repeater>
    
   
</div>

    </div></div></div></div>
        
</asp:Content>

