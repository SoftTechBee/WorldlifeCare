<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Packages.aspx.cs" Inherits="Member_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
     <!-- Content body -->
        <div class="content-body">
            <!-- Content -->
               <!------Msgbox End---->
     <div class="card-body ">
              <div class="alert alert-danger alert-dismissible" id="danger"  runat="server"  visible="false">
              
            <asp:Label ID="lbdanger" runat="server" Text="There is  some thing wrong........."></asp:Label> 
              </div>
              <div class="alert alert-info alert-dismissible" id="info" runat="server"  visible="false">
              
               <asp:Label ID="lbinfo" runat="server" Text="ere is  some thing wrong........."></asp:Label>  
             
              </div>
              <div class="alert alert-warning alert-dismissible" id="warning" runat="server"  visible="false">
              
               <asp:Label ID="lbwarning" runat="server" Text=" Try Again............"></asp:Label> 
            
              </div>
              <div class="alert alert-success alert-dismissible" id="sccess" runat="server" visible="false" >
              
                  <asp:Label ID="lbsuccess" runat="server" Text="Successfully updated................"></asp:Label>  
              </div>
            </div>
    <!-----Alert End----->
       
          
             <!-- layout modes selection -->
            <div class="row mb-3">
                <div class="col-12">
                    <h6 class="mb-0">Packages For ID: <asp:Label ID="lbActiveMember"  runat="server"  ></asp:Label></h6>
                </div>
            </div>
            
            
                   
         
  
            
   
    <!-- Panel Content --> 
                    <!-- Content -->
            <div class="content">
           
               
 
                

    
      <div class="row">
             
        <div class="col-lg-12">
          <div class="card  mb-4    shadow-lg" style="border:1px solid blue;" >
           
              <div class="card-body">
                  <div class="form-horizontal">
                         <h5 class="text-warning " style="text-align: right; padding-right: 20px;" runat="server" visible="false" id="lbfund"><a class=" btn  btn-success" href="WalletRecharge.aspx">Add Fund</a></h5>
                       <div class="mb-3 row">
                         
            
                          <label class="control-label col-sm-3">Cuurent Package </label>
                         <div class="col-sm-3">
                      
              <h6><asp:Label ID="txtcurrentpack" runat="server" Text="NONE"></asp:Label> (<asp:Label ID="txtcurrentamt" CssClass="text-warning" runat="server" Text="0"></asp:Label>)</h6>

             
            </div>
            </div>
                       
           
             

        </div>
        </div>
        </div>
         

  
 
</div>
</div>

              <div class="row">

                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="repPack_ItemCommand" >
        <ItemTemplate>
            <div class="col-12 col-xl-4">
             <div class="card border-top border-4 border-primary">
               <div class="card-body p-4">
                 <div class="px-2 py-1 fw-medium bg-warning bg-opacity-10 text-warning text-uppercase w-50 text-center rounded">PACKAGE</div>
                 <div class="my-4">
                    <h6 class="mb-2"><asp:Label runat="server" ID="lbpack" Text='<%#Eval("product") %>'></asp:Label></h6>
                    
                 </div>
                
                 <div class="price-tag d-flex align-items-center justify-content-center gap-2 ">
                   <h6 class="mb-0 align-self-end text-warning">₹</h6>
                   <h4 class="mb-0 lh-1  text-primary"><asp:Label runat="server" ID="lbamount" Text='<%#Eval("MRP") %>'></asp:Label></h4>
               </div>
                   <hr />
                <div class="pricing-content d-flex flex-column ">
                  <p>PV/BV : <asp:Label runat="server" ID="Label1" CssClass="text-warning" Text='<%#Eval("PV") %>'></asp:Label>/<asp:Label runat="server" ID="Label2"  CssClass="text-warning" Text='<%#Eval("BV") %>'></asp:Label></p>
                  <p>Matching Perday : ₹<asp:Label runat="server"  CssClass="text-warning" ID="Label3" Text='<%#Eval("Matching") %>'></asp:Label></p>
                  <p>Income Capping : ₹<asp:Label runat="server"  CssClass="text-warning" ID="Label4" Text='<%#Eval("Capping") %>'></asp:Label></p>
                 </div>
                 <div class="d-grid">
                     <asp:Button ID="btnsend" runat="server" Text="Buy Now" CssClass="btn btn-lg btn-primary" CommandArgument='<%#Eval("packid") %>' CommandName="Click" />
               
                 </div>
               </div>
             </div>
           </div>
			
              </ItemTemplate>
    </asp:Repeater>
					</div> <!-- end row -->
                <script>

                    function Processclick() {
                        swal({
                            title: "Processing.......!",
                            text: "Note: Do Not press back or close the app? It will close in few seconds.",
                            imageUrl: "../SoftImg/refresh.gif",
                            timer: 2000000,
                            showConfirmButton: false
                        });
                    }
                    function Successclick() {
                        swal("Succesfully", "Packages Purchased successfully!", "success")
                    }
                    function dangerlick() {
                        swal("Oops...!", "Something went wrong! Try Again", "error")
                    }
                    function Warninglick() {
                        swal("Oops...!", "You have already buy this Package ,please buy another packages!", "warning")
                    }
                    function fundlick() {
                        swal("Oops...!", "Balance is less then to require amount,Please Add Fund! Check Minimum And Maxmum Amount", "warning")
                    }
                    function PrePackBuy() {
                        swal("Oops...!", "you can't buy this packages! Please Buy previous packages SequenceWise", "error")
                    }
                    function Direct() {
                        swal("Oops...!", "you can't buy this packages! Required 2 Direct For Buy a Packages?", "error")
                    }
      function Active() {
          swal("Oops...!", "you can't buy this packages! Your account already active?", "error")
                    }
     //function NotActive() {
     //    swal("Oops...!", "Your Account Is Not-Active ...! Please Active Your Account(Buy JOIN PAKAGE)", "error")
     //}
                </script>
            <script src="https://common.olemiss.edu/_js/sweet-alert/sweet-alert.min.js"></script>
<link rel="stylesheet" type="text/css" href="https://common.olemiss.edu/_js/sweet-alert/sweet-alert.css">
    

       </div>
</asp:Content>

