<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ADDProduct.aspx.cs" Inherits="Admin_Accountmaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
       <div class="">
          <!-- Container-fluid starts-->
         <%-- <div class="container-fluid dashboard-default-sec">--%>
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
       
     <div class="page-breadcrumb">
                <div class="row">
                    <div class="col-5 align-self-center">
                        <h2 class="page-title">Product Adding</h2>
                    </div>
                    <div class="col-7 align-self-center">
                        <div class="d-flex align-items-center justify-content-end">
                            <nav aria-label="breadcrumb">
                                <ol class="breadcrumb">
                                    <li class="breadcrumb-item">
                                        <a href="Home.aspx">Home</a>
                                    </li>
                                    <%--<li class="breadcrumb-item active" aria-current="page">Product Adding</li>--%>
                                </ol>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
       
 
   
    <div class="card">
                            <div class="form-horizontal">
                                <div class="card-body">
                             <!----form start---->
                                     <div class=" form-group row">
                    
                
                          <label class="control-label col-lg-2">Product Name </label>
                          <div class="col-lg-4">
                         <asp:TextBox ID="txtproductname"  placeholder="Enter Product Name"    runat="server" CssClass="form-control"></asp:TextBox>
                          
                          </div>
                          <label class="control-label col-lg-2">Product MRP </label>
<div class="col-lg-4">
                         <asp:TextBox ID="txtmrp"  placeholder="Enter Product MRP"    runat="server" CssClass="form-control"></asp:TextBox>
                          
                          </div>
                          </div>
                                    <div class=" form-group row">
                    
                
                          <label class="control-label col-lg-2">Product DP </label>
                          <div class="col-lg-4">
                               <asp:TextBox ID="lbproductamt" OnTextChanged="lbproductamt_TextChanged" AutoPostBack="true" placeholder="Enter Product DP"   runat="server" CssClass="form-control"></asp:TextBox>
                         
                         
                          </div>
                          <label class="control-label col-lg-2">Product Discount </label>
<div class="col-lg-4">
                         <asp:Label ID="lbdiscount"   runat="server" Text="0" CssClass="form-control"></asp:Label>
                          
                          </div>
                          </div>
                                     <div class=" form-group row">
                    
                
                          <label class="control-label col-lg-2">Product SV </label>
                          <div class="col-lg-4">
                         <asp:TextBox ID="txtbv"  placeholder="Enter Product SV"   runat="server" CssClass="form-control"></asp:TextBox>
                          
                          </div>
                          <label class="control-label col-lg-2">Product Description </label>
<div class="col-lg-4">
                         <asp:TextBox ID="txtdesc" placeholder="Enter Product Description"   runat="server" CssClass="form-control"></asp:TextBox>
                          
                          </div>
                          </div>
                                <%--     <div class=" form-group row">
                    
                
                          <label class="control-label col-lg-2">Direct Commision</label>
                          <div class="col-lg-4">
                         <asp:TextBox ID="txtdirect"  placeholder="Enter Direct Commision"   runat="server" CssClass="form-control"></asp:TextBox>
                          
                          </div>
      
                          </div>--%>
                                     <div class=" form-group row">
                    
                
                         <label class="control-label  col-lg-2"> Upload Product Image <span  class="text text-danger ">*</span> </label>
                             <div class="col-lg-4">
                                 <asp:FileUpload ID="FileUploadChaque" runat="server" ClientIDMode="Static"  onchange="this.form.submit()"/>
                                 <input type="hidden" runat="server" id="hndcheque" />

                </div>
                                          <div class="col-lg-6">
                                 
                         <img src="../images/PhotoDemi.jpg" runat="server" id="ImgChaque"  style="width:50%"/>
                           
                                   </div>
                         
                          </div>

                            <div class="form-group row">
                 <center>
                  <div class="col-sm-3">

   <asp:Button ID="btnaction" runat="server" Text="Submit"  OnClick="Button1_Click" CssClass="btn btn-block btn-warning btn-sm"/>
               

                  </div>
                     </center>
                          
              </div>
                                    <br />
                                    <h5>Product LIST</h5>
                                    <div class="  form-group row">
        <div class="col-lg-12"style="overflow:auto;">
                        
                
                                <table class="table table-bordered table-hover table-responsive  small " >

                         
      
                          <tr>
                              <th>#</th>
                               <th>Remove</th>
                              <th>Edit</th>
                              <th>ProductName</th>
                              <th>MRP</th>
                              <th>DP</th>
                              <th>DISCOUNT</th>
                              <th>SV</th>
                              <%--<th>DirectCommision</th>--%>
                              <th>Description</th>
                              <th>Img</th>
                              <th>View</th>
                             
                          </tr>


                      <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                       
                          <ItemTemplate>
                              <tr>
                              <td><%# Container.ItemIndex+1 %></td>
                                  <td> <asp:Button ID="Button2" runat="server" Text="Remove" CommandArgument='<%#Eval("pid") %>' CommandName="Delete" CssClass=" btn btn-xxs btn-danger" /></td>
                                  <td> <asp:Button ID="Button0" runat="server" Text="Edit" CommandArgument='<%#Eval("pid") %>' CommandName="Edit" CssClass=" btn btn-xxs btn-danger" /></td>

                                  <td><asp:Label  ID="lbname" runat="server"  Text='<%#Eval("Product") %>'></asp:Label></td>
                                  <td><asp:Label  ID="lbmrp" runat="server"  Text='<%#Eval("MRP") %>'></asp:Label></td>
                                  <td><asp:Label  ID="lbdp" runat="server"  Text='<%#Eval("DP") %>'></asp:Label></td>
                                  <td><asp:Label  ID="lbdiscount" runat="server"  Text='<%#Eval("DISCOUNT") %>'></asp:Label></td>
                                  <td><asp:Label  ID="lbbv" runat="server"  Text='<%#Eval("Soldrate") %>'></asp:Label></td>
                                  <%--<td><asp:Label  ID="lbdirect" runat="server"  Text='<%#Eval("DirectCommision") %>'></asp:Label></td>--%>
                                  <td><asp:Label  ID="lbdesc" runat="server"  Text='<%#Eval("Descrption") %>'></asp:Label></td>
                           <td> <img id="lbimg" runat="server" src='<%#Eval("Imgurl") %>' height="50" width="100" /></td>
                                                    <td><a href='<%#Eval("Imgurl") %>'><i class="fa fa-eye fa-lg"></i></a></td>
        
                          
                              </tr>
                            
                          </ItemTemplate>
                      </asp:Repeater>
                         
                               </table>
                          
                          
                     
                  </div>
              </div>
                                   
                   
                      </div>
                                
                  </div> <br />
             
                   
           <asp:HiddenField ID="hndlid" runat="server"  />
                          
                     
      
</div>    
               
                                   
                        </div>
                       

</asp:Content>

