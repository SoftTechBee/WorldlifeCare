<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="setnews.aspx.cs" Inherits="Admin_setnews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
             
              <div class="alert alert-info alert-dismissible" id="info" runat="server"  visible="false">
              
                <h4><i class="icon fa fa-info"></i> Alert!</h4>
               <asp:Label ID="lbinfo" runat="server" Text="Already Inserted........."></asp:Label>  
             
              </div>
            
 
           <div class="card">
                            <div class="form-horizontal">
                                <div class="card-body">
                                    <h3>Set News  </h3>
                                    <div class="form-group row">

               
                                    <div class="col-lg-3"></div>     
                      <div class="col-lg-6"> <div class="form-group has-success">
                  <label class="control-label" for="inputSuccess"><i class="fa fa-check"></i>Enter Tittle</label>
                   <asp:TextBox ID="txthead" runat="server"  class="form-control" placeholder="Enter Tittle"></asp:TextBox>                          
</div></div></div>
                                        
 <div class="form-group row">
                      
                                    <div class="col-lg-3"></div>     
                      <div class="col-lg-6"> <div class="form-group has-success">
                  <label class="control-label" for="inputSuccess"><i class="fa fa-check"></i>Write News Here</label>
                   <asp:TextBox ID="txtnews" runat="server" TextMode="MultiLine"  class="form-control" placeholder="Write News Here"></asp:TextBox>                          
</div></div>

                       
                </div>
                
       <div class="form-group row">
             <div class="col-lg-3"> <div class="form-group has-success"></div>
                 </div>

                   <div class="col-md-6">   
             <asp:Button ID="bntsubmit" runat="server" Text="Save" CssClass="btn btn-block btn-facebook" OnClick="bntsubmit_Click" />
                           
              </div>
             
         </div>

                  
           
       
              <div class="  form-group row">
        <div class="col-lg-12">
           
                
                      <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">

                         <HeaderTemplate>
                              <table class="table table-bordered table-hover table-responsive">
                          <tr><th>#</th>
                              <th>Tittle</th>
                              <th>News</th>
                              <th>Delete</th>
                          </tr>


                         </HeaderTemplate>
                          <ItemTemplate>
                              <tr>
                              <td><%# Container.ItemIndex+1 %></td>
                                  <td>
                                      <asp:Label ID="lbusername" runat="server" Text='<%#Eval("tittle") %>'></asp:Label></td>
                                      <td><asp:Label ID="lbname" runat="server" Text='<%#Eval("news") %>'></asp:Label></td>
                                  <td> <asp:Button ID="Button2" runat="server" Text="Delete" CommandArgument='<%#Eval("id") %>' CommandName="Delete" CssClass="btn btn-block btn-danger" /></td>
                          
                              </tr>
                            
                          </ItemTemplate>
                          <FooterTemplate>
                               </table>
                          </FooterTemplate>
                      </asp:Repeater>
                          
                     
                  </div>
              </div>        
                       
                    </div>
            </div>
                </div>
            </div>
            </div>
        </div>
</asp:Content>

