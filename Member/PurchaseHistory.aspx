<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MasterPage.master" AutoEventWireup="true" CodeFile="PurchaseHistory.aspx.cs" Inherits="User_TopUpWallet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
          
     <div class="page-body">
         <div class="box-body">
             
               <div class="alert alert-danger dark alert-dismissible fade show" role="alert" id="danger"  runat="server"  visible="false">
         
          <p>  
              <asp:Label ID="lbdanger" runat="server" Text="There is  some thing wrong........."></asp:Label> </p>
                    <button class="btn-close" type="button" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>
          <div class="alert alert-info dark alert-dismissible fade show" role="alert" id="info"  runat="server"  visible="false">
         
          <p>  
              <asp:Label ID="lbinfo" runat="server" Text="There is  some thing wrong........."></asp:Label> </p>
                    <button class="btn-close" type="button" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>
               <div class="alert alert-warning dark alert-dismissible fade show" role="alert" id="warning"  runat="server"  visible="false">
         
          <p>  
              <asp:Label ID="lbwarning" runat="server" Text="There is  some thing wrong........."></asp:Label> </p>
                    <button class="btn-close" type="button" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>
             
              <div class="alert alert-success dark alert-dismissible fade show" id="sccess" runat="server"  visible="false">
          
                <p><i class="icon fa fa-check"></i> Alert!
                  <asp:Label ID="lbsuccess" runat="server" Text="Successfully updated................"></asp:Label>  
                    </p>
                        <button type="button" class="btn-close" data-dismiss="alert" aria-hidden="true"></button>
              </div>
             
           </div>
              
                <div class="row">
                    <div class="col-12 align-self-center">
                        <h5 class="page-title">My Cart</h5>
                    </div>
                 
                </div>

 
        
       
   
        <div class="container-fluid">
       <div class="row">
<div  class="col-lg-12">
           <div class="card " >
      
                            <div class="card-body">
            
 Your Fund : <i class="fa  fa-rupee" ></i><asp:Label ID="txtbalance"  runat="server"  CssClass="control-label"></asp:Label>
           <hr />
<div class="form-group row">
            <div class="col-lg-12" style="overflow:auto">
                <table id="example1" class="table table-bordered table-striped table-hover " style="cellspacing:0;width:100%">
                <thead>
                <tr>
                    <th >#</th>
                  <th> Name</th>
                   <th> MRP</th>
                    <th> Discount</th>
                   <th> DP</th>
                  
                     <th> SV</th>
                     <th>Remove</th>
                    <%-- <th>Delivery Type</th>--%>
                  
                  
                </tr>
                </thead>
                <tbody>
<asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >
   
    <ItemTemplate>
        <tr>
            <td> <%# Container.ItemIndex+1 %></td>
             <td> <%#Eval("Product") %></td>
             <td> <%#Eval("MRP") %></td>
            <td> <%#Eval("Discount") %></td>
             <td> <%#Eval("Price") %></td>
             
               <td> <%#Eval("BV") %></td>
            <td> <asp:Button ID="Button1" runat="server" Text="Remove" CssClass="btn  btn-sm btn-danger" CommandArgument='<%#Eval("pid") %>' CommandName="remove" /> </td>
           
            <%-- <td> <%#Eval("HSNCODE") %></td>--%>
        </tr>
    </ItemTemplate>

</asp:Repeater>
         </tbody>
                <tfoot>
                <tr>
                       <th >Total</th>
                 <th ><asp:Label ID="lbqty" runat="server" Text=""></asp:Label> Products</th>
                  <th><asp:Label ID="totalmrp" runat="server" Text=""></asp:Label></th>
                       <th> <asp:Label ID="totaldiscount" runat="server" Text=""></asp:Label></th>
                  <th><asp:Label ID="totaldp" runat="server" Text=""></asp:Label></th>
               
                   <th><asp:Label ID="totalbv" runat="server" Text=""></asp:Label></th>
                  
                </tr>
                </tfoot>
              </table> 
                
                  
            
                
            </div>
    </div>
                                <div class="row" style="justify-content:right">
                                    <div class="cart-sub-total  total">
						Total SV: <span><asp:Label ID="lbtotalBV" runat="server" Text="0"></asp:Label></span>
                                          <hr />
					</div>
                                  
                   <div class="cart-sub-total total">
						<span>Payment Status:</span> <span><asp:Label ID="lbpaystatus" runat="server" Text="Un-Paid"></asp:Label></span>
					</div>
 <div class="cart-sub-total total">
    <span>Delivery Type:<br /></span>
                                    <hr />
    <span>
        <asp:RadioButtonList ID="rblDeliveryType" runat="server" OnSelectedIndexChanged="rblDeliveryType_SelectedIndexChanged" AutoPostBack="true"  CssClass="mt-2 text-primary fw-bold "  RepeatDirection="Horizontal" 
                             RepeatLayout="Flow">
            <asp:ListItem Selected="true" Value="Self Pickup">&nbsp Self Pickup &nbsp&nbsp</asp:ListItem>
            <asp:ListItem Value="By Courier">&nbsp By Courier </asp:ListItem>
        </asp:RadioButtonList>
    </span>
</div>
<br />
                    <div class="col-md-4 col-sm-12 cart-shopping-total">
	<table class="table">
		<thead>
			<tr>
				<th>
					
					
					<div class="cart-sub-total  total" style="text-align:right">
						Total DP: &nbsp&nbsp&nbsp&nbsp <span class="inner-left-md"><i class="fa  fa-rupee" style="color:forestgreen"></i><asp:Label ID="lbgrandtotal" CssClass="text-success" runat="server" Text="0"></asp:Label></span>
					</div>
                   <div class="cart-sub-total  total" style="text-align:right">
						Shipping Charges :&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp <span class="inner-left-md">+<i class="fa  fa-rupee" style="color:forestgreen"></i><asp:Label ID="lbshipping" CssClass="text-success" runat="server" Text="0"></asp:Label></span>
					</div>
                  <div class="cart-sub-total  total" style="text-align:right">
						Grand Total: &nbsp&nbsp&nbsp&nbsp<span class="inner-left-md"><i class="fa  fa-rupee" style="color:forestgreen"></i><asp:Label ID="lbtotalpayout" CssClass="text-success" runat="server" Text="0"></asp:Label></span>
					</div>

				</th>
			</tr>
		</thead>
	
	</table>
                       <!-- /table -->
</div>
                </div>
                              <br />  
                 <div class="col-sm-12" style="text-align:right;">
               
                            
                                  <div class="col-sm-12">
                                  <asp:Button ID="btncheckout" OnClick="btncheckout_Click" OnClientClick="return confirmAction();"  runat="server" Text="Pay Now"   class=" btn btn-warning btn-sm" />
               </div>
                        <hr /><p style="color: red;font-size:100% ">
                                    <%--Note1: For Home Delivery, an additional charge of ₹100/- should be applied.<br />--%>
  Note2: Home Delivery selected?. Please make sure your address is complete. Go to Edit Profile to add or update it before making the purchase.
</p>
</div>
            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->
        </div>
        <!-- /.col -->
      </div>
           
</div>
</div>

    <script>
        // The function below will start the confirmation dialog
        function confirmAction() {
            let confirmAction = confirm("Are you Sure to purchase now?");

            if (confirmAction) {
                // alert("Action Successfully executed");
                return true;
            }
            else {
                //alert("Action Cancelled");
                return false;
            }
        }
        function confirmReject(){
            let confirmAction = confirm("Are you Sure to Reject this Request?");

            if (confirmAction) {
                // alert("Action Successfully executed");
                return true;
            }
            else {
                alert("Action Cancelled");
                return false;
            }
        }
    </script>

<!-- page script -->
      
</asp:Content>


