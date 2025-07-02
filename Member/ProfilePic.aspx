<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MasterPage.master" AutoEventWireup="true" CodeFile="ProfilePic.aspx.cs" Inherits="User_ProfilePic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
       <style type="text/css">
     #ContentPlaceHolder1_bntsubmit {  
  border-radius: 25px;    
     }
      #ContentPlaceHolder1_btncencel {  
  border-radius: 25px;    
     }
 </style>
    
      <style>
        .TxtBoxError {
         border:1px solid red;
         width:430px;
         height:40px;
        }

    </style>


        <!------Msgbox End---->
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
        
                                      
    <div class="page-breadcrumb">
                <div class="row">
                    <div class="col-5 align-self-center">
                        <h4 class="page-title">Profile Pic</h4>
                    </div>
                </div>
            </div>

       
    <div class="container-fluid">
 
     <div class="card">
        
           
            <!-- /.card-header -->
            <div class="card-body" >
                  <div class="form-horizontal">
             
                           
                         <div class="form-group row" >
                           
                  <label class="control-label  col-lg-2"> Upload Your Profile <span  class="text text-danger ">*</span> </label>
                             <div class="col-lg-4">
                                 <label class="text text-danger ">Your Profile</label>
                                 <asp:FileUpload ID="FileUploadChaque" runat="server" ClientIDMode="Static"  onchange="this.form.submit()"/>
                                 <input type="hidden" runat="server" id="hndcheque" />

                </div>
                     
                
        </div>   <br />
                           
                          
                         <div class="form-group row">
                           
                 
                             <div class="col-lg-12">
                                 
                         <img src="../images/PhotoDemi.jpg" runat="server" id="ImgChaque"  style="width:50%"/>
                           
                                   </div>
                             
                            
                             
                </div>  <br />
                       
                 <div class="box-footer">
                     <center>
                 <asp:Button ID="bntsubmit" OnClick="bntsubmit_Click" OnClientClick="return Validate();" runat="server" Text="Save" Width="200px" CssClass=" btn bg-success btn-flat btn-lg text-white"  />  
               
                     
                      </center>                    
                </div>
                
                 </div>
             
          
                       
            </div>

        
                        </div>
      </div>
                                    </div>
                                 
                      
</asp:Content>

