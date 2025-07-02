<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Popup.aspx.cs" Inherits="Admin_Popup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    



   <div class="panel-body">
             
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
              <div class="alert alert-success alert-dismissible" id="sccess" runat="server"  visible="false">
                <h4><i class="icon fa fa-check"></i> Alert!</h4>
                  <asp:Label ID="lbsuccess" runat="server" Text="Successfully updated................"></asp:Label>  
              </div>
            
            </div>
     
     
        
            <div class="alert alert-danger alert-dismissible" id="danger"  runat="server"  visible="false">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <h4><i class="icon fa fa-ban"></i> Alert!</h4>
            <asp:Label ID="lbdanger" runat="server" Text="There is  some thing wrong........."></asp:Label> 
              </div>
         <div class="page-content">
                   
          <div class="col-lg-12">
            <div class=" panel  ">
                 <div class="panel-header with-border">
                     <h4>Home Add Images</h4>
                 </div>
                <hr />
                 <!----form start---->
             
              
                  

                     <div class="panel-body">
                            
                 <div class="form-horizontal">
                        <div class="form-group row">
                            <%-- <label class="control-label col-lg-2">Member Name </label>
                          <div class="col-lg-4">
                                <asp:TextBox ID="txtname" placeholder="Enter Member Name" runat="server" CssClass=" form-control"></asp:TextBox>
                        
                        </div>--%>
                             <label class="control-label col-lg-2">Image Title </label>
                          <div class="col-lg-4">
                                <asp:TextBox ID="txttitle"   placeholder="Enter Image Title" runat="server" CssClass=" form-control"></asp:TextBox>
                        
                        </div>
                        </div>
                       
                          <div class="form-group row">
                            
                  <label class="control-label  col-lg-2">Upload Image </label>
                             <div class="col-lg-4">
                                 <asp:FileUpload ID="FileUploadPan" runat="server" ClientIDMode="Static"  onchange="this.form.submit()"/>
                                 <input type="hidden" runat="server" id="hndPan" />
                                  <input type="hidden" runat="server" id="hndPID" />
                </div>
                              <div class="col-lg-6">
                         <img src="../images/PhotoDemi.jpg" runat="server" id="ImgPan"  style="width:100%" />
                           
                                   </div>
                              
        </div>
                     <br />
                           
                        
                             
                </div> 
                     <br />
                        
                 <div class="panel-footer">
                       <center>
                 <asp:Button ID="bntsubmit" OnClick="bntsubmit_Click" OnClientClick="return Validate();" runat="server" Text="Submit" Width="200px" CssClass=" btn btn-block btn-success"  />  
               
               
                      </center>                 
                </div>
                
               
             
          
                       
            </div>
       
                  
        </div>
        </div>
  <div class="panel-body" style="overflow:auto;">
                  <asp:gridview ID="grdData" runat="server"  OnRowCommand="grdData_RowCommand"

AutoGenerateColumns="False" CellPadding="10" PageSize="10"  Font-Size="Large" CssClass="table table-bordered table-striped table-hover"

          GridLines="Both" Width="100%" AllowPaging="True"

            OnPageIndexChanging="grdData_PageIndexChanging"  >
           
            <columns>
             

<asp:TemplateField HeaderText="#">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <ItemStyle Width="5%" />
</asp:TemplateField>
                        
               
             <asp:TemplateField HeaderText="Upload Images">
                <ItemTemplate>
                    <img src='<%#Eval("IMG") %>' style="height:100px; width:300px;" />
                   </ItemTemplate>
                  </asp:TemplateField>
             <%--    <asp:boundfield DataField="name" HeaderText="Name"></asp:boundfield>--%>
                 <asp:boundfield DataField="doi" HeaderText="Date"></asp:boundfield>
                 <asp:boundfield DataField="Title" HeaderText="Tittle"></asp:boundfield>
                
                
                <asp:TemplateField HeaderText="Remove">
                <ItemTemplate>
                <asp:LinkButton runat="server" ID="btnupdate"  Text="Remove" CssClass="btn btn-block btn-danger"  CommandArgument='<%#Eval("pid") %>' CommandName="Remove"></asp:LinkButton>
    </ItemTemplate>
                  </asp:TemplateField>
                </columns>
          
           
        </asp:gridview>
                  
            
                  </div>
            
</div>
        </div>
  
</asp:Content>



