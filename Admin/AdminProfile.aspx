<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AdminProfile.aspx.cs" Inherits="Admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
  <!------Msgbox End---->
     <div class="box-body">
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
              <div class="alert alert-success alert-dismissible" id="sccess" runat="server"  visible="false">
              
                <h4><i class="icon fa fa-check"></i> Alert!</h4>
                  <asp:Label ID="lbsuccess" runat="server" Text="Successfully updated................"></asp:Label>  
              </div>
            </div>
    <!-----Alert End----->
    
          
        <div class="card">
                            <div class="form-horizontal">
                                <div class="card-body">
              
         
         
           
                  <div class="form-group row">
                    <div class="col-md-6">
                        
                        <div class="form-group has-success" >
                  <label class="control-label" for="inputSuccess"><i class="fa fa-check"></i> UserName</label>
                   <asp:TextBox ID="txtuname" runat="server"  class="form-control"    placeholder="Enter UserName" ></asp:TextBox>              
                  
                </div> </div>
                   <div class="col-md-6">               
                    <div class="form-group has-success">
                  <label class="control-label" for="inputSuccess"><i class="fa fa-check"></i>Name</label>
                   <asp:TextBox ID="txtname" runat="server"  class="form-control"   placeholder="Enter Name"></asp:TextBox>              
                
                </div></div>
                      
                      </div>              
                  
            <div class="form-group row">
                                         <div class="col-md-6"> 
                                             <div class="form-group has-success">
                  <label class="control-label" for="inputSuccess"><i class="fa fa-check"></i>Email</label>
                   <asp:TextBox ID="txtmail" runat="server"  class="form-control"  ></asp:TextBox>              
                  
                </div>            
</div>
                   <div class="col-md-6">               
                    <div class="form-group has-success">
                  <label class="control-label" for="inputSuccess"><i class="fa fa-check"></i> Mobile</label>
                   <asp:TextBox ID="txtmob" runat="server"  class="form-control"   ></asp:TextBox>              

                </div>
                </div></div>

             
                  <div class="form-group row">

  

                      <div class=" col-lg-auto col-md-3">               
                    
                 <asp:Button ID="bntchange" runat="server" Text="Update" CssClass="btn btn-block btn-success" OnClick="bntchange_Click" />
            
                </div>
                  </div>
           
          </div>
          <!-- /.box -->
             </div></div>


</asp:Content>


