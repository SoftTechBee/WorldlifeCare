<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Member_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="row">

        <div class="col-12 col-lg-6 col-xxl-6 d-flex flex-column mb-3">
            <div class="card rounded-4 w-100">
                <div class="card-body">
                    <div class="d-flex align-items-center justify-content-between mb-1">
                        <div>
                            <p class="mb-1">Referral Link-Left</p>

                        </div>
                        <%--    <div class="wh-42 d-flex align-items-center justify-content-center rounded-circle bg-grd-danger">
                  <span class="material-icons-outlined fs-5 text-white">shopping_cart</span>
                </div>--%>
                    </div>
                    <div class="progress mb-0" style="height: 20px;">
                        &nbsp<asp:Label ID="lbreffsidLeft" CssClass="text-success" runat="server" Text="0"></asp:Label>
                    </div>
                    <div class="d-flex align-items-center mt-3 gap-2">

                        <p class="mb-0 font-13">Refer & Earn</p>

                        <div class="card-lable">

                            <span class="badge badge-sm text-bg-success " onclick="script: myFunction();">Copy</span>

                        </div>

                    </div>
                </div>
            </div>
        </div>
        <div class="col-12 col-lg-6 col-xxl-6 d-flex flex-column">
            <div class="card rounded-4 w-100">
                <div class="card-body">
                    <div class="d-flex align-items-center justify-content-between mb-1">
                        <div>
                            <p class="mb-1">Referral Link-Right</p>

                        </div>

                    </div>

                    <div class="progress mb-0" style="height: 20px;">
                        &nbsp<asp:Label ID="lbreffsidRight" CssClass="text-success" runat="server" Text="0"></asp:Label>
                    </div>
                    <div class="d-flex align-items-center mt-3 gap-2">

                        <p class="mb-0 font-13">Refer & Earn</p>
                        <div class="card-lable">

                            <span class="badge badge-sm text-bg-success " onclick="script: myFunctionRight();">Copy</span>

                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

    <div class="row align-items-center">

        <div class="col-12 col-lg mb-4">
            <h4 class="fw-normal mb-0 text-secondary">Welcome back,  <%=SessionData.Get<string>("name")%> (<%=SessionData.Get<string>("newuser")%>)</h4>
           
        </div>
  
    </div>
    <marquee onmouseover="this.stop()" onmouseout="this.start()">
        <h6>
            <span style="color: #4800ff">Updated News :-
                                       <asp:Label ID="lbhead" Font-Bold="true" Font-Size="Larger" Font-Underline="true" runat="server" Text='<%#Eval("tittle")%>'></asp:Label>
                :
                <asp:Label ID="lbnews" Font-Bold="true" Font-Size="Larger" runat="server" CssClass="text-secondary" Text='<%#Eval("news")%>'>
                </asp:Label></span></h6>

    </marquee>

    <div class="row">
        <div class="col-12 col-lg-6 col-xl-6 mb-4">
            <div class="card adminuiux-card position-relative overflow-hidden bg-theme-1 h-100">
                <div class="position-absolute top-0 start-0 h-100 w-100 z-index-0 coverimg opacity-50">
                    <img src="../assets/img/modern-ai-image/flamingo-4.jpg" alt="">
                </div>
                <div class="card-body z-index-1">
                    <div class="row align-items-center justify-content-center h-100 py-4">
                        <div class="col-11">
                       <%--     <h4 class="fw-normal">Your Available Income</h4>
                            <h1 class="mb-3">₹<asp:Label ID="lbbalance" runat="server" Text="0"></asp:Label></h1>--%>
                            <p>Date Of Join: <span class="badge  badge-sm text-bg-warning">
                                <asp:Label ID="lbDOJ" runat="server" Text="N/A"></asp:Label></span></p>
                            <p>Acount Status: <span class="badge badge-sm text-bg-warning">
                                <asp:Label ID="lbstatus" runat="server" Text="N/A"></asp:Label></span></p>
                            <p>Current Package: <span class="badge badge-sm text-bg-warning">
                                <asp:Label ID="lbpack" runat="server" Text="N/A"></asp:Label></span></p>
                            <p>Mobile: <span class="badge badge-sm text-bg-warning">
                                <asp:Label ID="lbmobile" runat="server" Text="N/A"></asp:Label></span></p>
                            <p>Email: <span class="badge badge-sm text-bg-warning">
                                <asp:Label ID="lbemail" runat="server" Text="N/A"></asp:Label></span></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-12 col-lg-6 col-xl-6 mb-4">
            <div class="card adminuiux-card">
                <div class="row gx-0">
                    <div class="col-12 col-xl-12">
                        <div class="card-header">
                            <h6>Summary</h6>
                        </div>
                        <div class="card-body pb-0">
                            <div class="card adminuiux-card bg-theme-1 mb-3">
                                <div class="card-body">
                                    <h5 class="text-white mb-2"><img src="../assets/images/apps/wallet.png" alt="icon" style="height:30px; width:30px;" class="me-1" />Wallet Balance</h5>
                                    <h4 class="fw-medium">₹ <asp:Label ID="lbwalletbal" runat="server" Text="0"></asp:Label>
                                        <span class="text-white fs-14">
                                            <i class="bi bi-arrow-up-short me-1"></i>
                                        </span>
                                    </h4>
                                </div>
                            </div>
                            <div class="card adminuiux-card bg-theme-1-subtle mb-3">
                                <div class="card-body">
                                    <h5 class="text-secondary mb-2"> <img src="../assets/images/apps/wallet.png" alt="icon" style="height:30px; width:30px;" class="me-1" />Self Business</h5>
                                    <h4 class="fw-medium">₹ <asp:Label ID="lbtotalrepurchase" runat="server" Text="0"></asp:Label>
                                        <span class="text-success fs-14">
                                            <i class="bi bi-arrow-up-short me-1"></i>
                                        </span>
                                    </h4>
                                </div>
                            </div>
                              <div class="card adminuiux-card bg-theme-1-subtle mb-3">
                                <div class="card-body">
                                    <h5 class="text-secondary mb-2"><img src="../assets/images/apps/wallet.png" alt="icon" style="height:30px; width:30px;" class="me-1" />Total Earning</h5>
                                    <h4 class="fw-medium">₹ <asp:Label ID="lbbalance" runat="server" Text="0"></asp:Label><span class="text-success fs-14">
                                        <i class="bi bi-arrow-up-short me-1"></i>
                                    </span></h4>
                                </div>
                            </div>
                            
                     
                        </div>
                    </div>

                </div>
            </div>
        </div>
           <div class="col-xl-6 col-xxl-6 d-flex align-items-stretch mb-3">
            <div class="card adminuiux-card  rounded-4 w-100">
                <div class="card-body">
                    <div class="d-flex align-items-start justify-content-between mb-3">
                        <div class="">
                            <h5 class="mb-0">Team Left/Right</h5>
                        </div>
                        <div class="dropdown">
                            <a href="javascript:;" class="dropdown-toggle-nocaret options dropdown-toggle"
                                data-bs-toggle="dropdown"></a>


                        </div>
                    </div>
                    <div class="table-responsive">
                        <table class="table align-middle mb-0">
                            <thead>
                                <tr>
                                    <th class="fw-bold text-info">Team <i class="me-1 bi   bi-person-add"></i></th>
                                    <th class="fw-bold text-info">Left <i class="me-1 bi   bi-person-add"></i></th>
                                    <th class="fw-bold text-info">Right <i class="me-1 bi   bi-person-add"></i></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <div class="d-flex align-items-center flex-row gap-3">
                                            <div class="">
                                                <h6 class="mb-0">Total Team </h6>
                                          
                                            </div>
                                        </div>
                                    </td>
                                    <td>
                                        <h5 class="mb-0">
                                            <asp:Label ID="lbLeftTeam" runat="server" Text="0"></asp:Label></h5>
                                    </td>
                                    <td>
                                        <h5 class="mb-0">
                                            <asp:Label ID="lbRightTeam" runat="server" Text="0"></asp:Label></h5>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="d-flex align-items-center flex-row gap-3">
                                            <div class="">
                                                <h6 class="mb-0">Active Team</h6>
                                              
                                            </div>
                                        </div>
                                    </td>
                                    <td>
                                        <h5 class="mb-0">
                                            <asp:Label ID="lbActiveleftteam" runat="server" Text="0"></asp:Label></h5>
                                    </td>
                                    <td>
                                        <h5 class="mb-0">
                                            <asp:Label ID="lbActiveRightteam" runat="server" Text="0"></asp:Label></h5>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="d-flex align-items-center flex-row gap-3">
                                            <div class="">
                                                <h6 class="mb-0">Inactive Team</h6>
                                             
                                            </div>
                                        </div>
                                    </td>
                                    <td>
                                        <h5 class="mb-0">
                                            <asp:Label ID="lbInActiveLeftteam" runat="server" Text="0"></asp:Label></h5>
                                    </td>
                                    <td>
                                        <h5 class="mb-0">
                                            <asp:Label ID="lbInActiveRightteam" runat="server" Text="0"></asp:Label></h5>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="d-flex align-items-center flex-row gap-3">
                                            <div class="">
                                                <h6 class="mb-0">Total Direct </h6>
                                     
                                            </div>
                                        </div>
                                    </td>
                                    <td>
                                        <h5 class="mb-0">
                                            <asp:Label ID="lbTotalLeftDirect" runat="server" Text="0"></asp:Label></h5>
                                    </td>
                                    <td>
                                        <h5 class="mb-0">
                                            <asp:Label ID="lbTotalRightDirect" runat="server" Text="0"></asp:Label></h5>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="d-flex align-items-center flex-row gap-3">
                                            <div class="">
                                                <h6 class="mb-0">Active Direct</h6>
                                           
                                            </div>
                                        </div>
                                    </td>
                                    <td>
                                        <h5 class="mb-0">
                                            <asp:Label ID="lbActiveDirectLeft" runat="server" Text="0"></asp:Label></h5>
                                    </td>
                                    <td>
                                        <h5 class="mb-0">
                                            <asp:Label ID="lbActiveDirectRight" runat="server" Text="0"></asp:Label></h5>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="d-flex align-items-center flex-row gap-3">
                                            <div class="">
                                                <h6 class="mb-0">Inactive Direct</h6>
                                            
                                            </div>
                                        </div>
                                    </td>
                                    <td>
                                        <h5 class="mb-0">
                                            <asp:Label ID="lbinActiveDirectLeft" runat="server" Text="0"></asp:Label></h5>
                                    </td>
                                    <td>
                                        <h5 class="mb-0">
                                            <asp:Label ID="lbinActiveDirectRight" runat="server" Text="0"></asp:Label></h5>
                                    </td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
                <div class="col-xl-6 col-xxl-6 d-flex align-items-stretch mb-3">
            <div class="card adminuiux-card  rounded-4 w-100">
              <div class="card-body">
                  <div class="d-flex align-items-start justify-content-between">
                    <div class="">
                      <h5 class="mb-0">Business</h5>
                    </div>
                    <div class="dropdown">
                      <a href="javascript:;" class="dropdown-toggle-nocaret options dropdown-toggle"
                        data-bs-toggle="dropdown">
                        <%--<span class="material-icons-outlined fs-5">more_vert</span>--%>
                      </a>
                     
                    </div>
                  </div>
                <div class="d-flex align-items-center gap-3 mt-4">
                     
                  <div class="mb-4">
                    <h1 class="mb-0"><asp:Label runat="server" ID="lbtotalbusiness" Text="0.0"></asp:Label> <%=SessionData.Get<string>("Currency")%></h1>
                  </div>
                  <div class="d-flex align-items-center align-self-end gap-2">
                    <%--<span class="material-icons-outlined text-success">trending_up</span>--%>
                  </div>
                </div>
                <p class="mb-4">Total Business</p>
                <div class="d-flex flex-column gap-3">
                  <div class="mb-4">
                    <p class="mb-1">Left Side <span class="float-end"><asp:Label runat="server" ID="leftbusiness" Text="0.0"></asp:Label></span> Business</p>
                    <div class="progress" style="height: 5px;">
                      <div class="progress-bar bg-grd-primary" style="width: 100%"></div>
                    </div>
                  </div>
                  <div class="">
                    <p class="mb-1">Right Side <span class="float-end"><asp:Label runat="server" ID="rightbusiness" Text="0.0"></asp:Label></span> Business</p>
                    <div class="progress" style="height: 5px;">
                      <div class="progress-bar bg-grd-warning" style="width: 100%"></div>
                    </div>
                  </div>
                 
                </div>
              </div>
            </div>
                </div>
  


 
        <div class="col-12 col-lg-6 col-xl-6 mb-4">
                                    <div class="card adminuiux-card h-100 rounded-4 w-100">
                                        <div class="card-header">
                                            <h6>Summary</h6>
                                        </div>
                                        <div class="card-body">
                                           <%--   <div class="row ">
                                                <div class="col-6 col-md-6 mb-4">
                                                    <h5 class="text-secondary mb-2">
                                                        <span class="me-1 avatar avatar-10 rounded bg-green"></span>
                                                        Direct Team
                                                    </h5>
                                                    <h4 class="ps-3 fw-medium"><asp:Label ID="lbdirect" runat="server" Text="0"></asp:Label><br> <a href="direct.aspx" class="text-success fs-14 fw-normal">View</a></h4>

                                                </div>
                                                <div class="col-6 col-md-6 mb-4">
                                                    <h5 class="text-secondary mb-2">
                                                        <span class="me-1 avatar avatar-10 rounded bg-yellow"></span>
                                                        All Team
                                                    </h5>
                                                    <h4 class="ps-3 fw-medium"><asp:Label ID="lbteam" runat="server" Text="0"></asp:Label><br><a href="rptdwonline.aspx" class="text-success fs-14 fw-normal">View</a></h4>
                                                </div>
                                           
                                           
                                            </div>--%>
                                            <div class="row ">
                                                <div class="col-6 col-md-6 mb-4">
                                                    <h5 class="text-secondary mb-2">
                                                        <span class="me-1 avatar avatar-10 rounded bg-green"></span>
                                                     Success Withdraw
                                                    </h5>
                                                    <h4 class="ps-3 fw-medium">₹ <asp:Label ID="lbwithdrawapprove" runat="server" Text="0"></asp:Label><br> </h4>

                                                </div>
                                                <div class="col-6 col-md-6 mb-4">
                                                    <h5 class="text-secondary  mb-2">
                                                        <span class="me-1 avatar avatar-10 rounded bg-yellow"></span>
                                                    Pending Withdraw
                                                    </h5>
                                                    <h4 class="ps-3 fw-medium">₹ <asp:Label ID="lbwithdrawpending" runat="server" Text="0"></asp:Label><br></h4>
                                                </div>
                                           
                                           
                                            </div>
                                        </div>
                                    </div>
                                </div>
  
         <div class="col-xl-6 col-xxl-6 d-flex align-items-stretch mb-3">
            <div class="card w-100 rounded-4">
              <div class="card-body">
                <div class="d-flex align-items-start justify-content-between mb-3">
                  <div class="">
                    <h6 class="mb-0 fw-bold">Total SV/Business</h6>
                  </div>
                  <div class="dropdown">
                    <a href="javascript:;" class="dropdown-toggle-nocaret options dropdown-toggle" data-bs-toggle="dropdown">
                      <%--<span class="material-icons-outlined fs-5">more_vert</span>--%>
                    </a>
                   
                  </div>
                 </div>

                  <ul class="list-group list-group-flush">
                    <li class="list-group-item px-0 bg-transparent"> 
                         <div class="d-flex align-items-center gap-3">
    <div class="wh-42 d-flex align-items-center justify-content-center rounded-3 bg-grd-branding">
      <img src="../assets/images/gallery/favicon.png" width="32" alt="">
    </div>
    <div class="flex-grow-1">
      <h6 class="mb-0">Left/Right SV</h6>
    </div>
    <div class="d-flex align-items-center gap-3">
      <p class="mb-0"><asp:Label ID="leftpv" runat="server" Text="0"></asp:Label></p>/
      <p class="mb-0"><asp:Label ID="rightpv" runat="server" Text="0"></asp:Label></p>
    </div>
  </div>
</li>

 <li class="list-group-item px-0 bg-transparent"> 
                         <div class="d-flex align-items-center gap-3">
    <div class="wh-42 d-flex align-items-center justify-content-center rounded-3 bg-grd-branding">
      <img src="../assets/images/gallery/favicon.png" width="32" alt="">
    </div>
    <div class="flex-grow-1">
      <h6 class="mb-0">Left/Right Business</h6>
    </div>
    <div class="d-flex align-items-center gap-3">
      <p class="mb-0"><asp:Label ID="leftBV" runat="server" Text="0"></asp:Label></p>/
      <p class="mb-0"><asp:Label ID="rightBV" runat="server" Text="0"></asp:Label></p>
    </div>
  </div>
</li>



         </ul>

              </div>
            </div>
          </div> 
        <div class="col-xl-6 col-xxl-6 d-flex align-items-stretch mb-3">
            <div class="card w-100 rounded-4">
                <div class="card-body">
                    <div class="d-flex align-items-start justify-content-between mb-3">
                        <div class="">
                            <h6 class="mb-0 fw-bold">Available SV/Business</h6>
                        </div>

                    </div>

                    <ul class="list-group list-group-flush">
                        <li class="list-group-item px-0 bg-transparent">
                            <div class="d-flex align-items-center gap-3">
                                <div class="wh-42 d-flex align-items-center justify-content-center rounded-3 bg-grd-branding">
                                    <img src="../assets/images/favicon.png" width="32" alt="">
                                </div>
                                <div class="flex-grow-1">
                                    <h6 class="mb-0">Left/Right SV</h6>
                                </div>
                                <div class="d-flex align-items-center gap-3">
                                    <p class="mb-0">
                                        <asp:Label ID="Availableleftpv" runat="server" Text="0"></asp:Label>
                                    </p>
                                    /
                             <p class="mb-0">
                            <asp:Label ID="Availablerightpv" runat="server" Text="0"></asp:Label>
                                    </p>
                                </div>
                            </div>
                        </li>

                        <li class="list-group-item px-0 bg-transparent">
                            <div class="d-flex align-items-center gap-3">
                                <div class="wh-42 d-flex align-items-center justify-content-center rounded-3 bg-grd-branding">
                                    <img src="../assets/images/favicon.png" width="32" alt="">
                                </div>
                                <div class="flex-grow-1">
                                    <h6 class="mb-0">Left/Right Business</h6>
                                </div>
                                <div class="d-flex align-items-center gap-3">
                                    <p class="mb-0">
                                        <asp:Label ID="AvailableleftBV" runat="server" Text="0"></asp:Label>
                                    </p>
                                    /
                            <p class="mb-0">
                         <asp:Label ID="AvailablerightBV" runat="server" Text="0"></asp:Label>
                                     </p>
                                </div>
                            </div>
                        </li>



                    </ul>

                </div>
            </div>
        </div>

                                    </div>
        <div class="row">

            <div class="col-12 col-sm-6 col-xxl-3 mb-4">
                <div class="card adminuiux-card">
                    <div class="card-body">
                        <div class="row gx-3 mb-3">
                            <div class="col-auto">
                                <i class="bi bi-cash-stack fs-4 avatar avatar-50 bg-success text-white rounded"></i>
                            </div>
                            <div class="col">
                                <h4 class="mb-0">
                                    <asp:Label ID="lbdirectIncome" runat="server" Text="0"></asp:Label>
                                    <%=SessionData.Get<string>("Currency")%></h4>
                                <h6 class="small opacity-75">Direct Income</h6>
                            </div>
                        </div>

                        <div class="progress height-10 mb-2" role="progressbar" aria-label="Basic example" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100">
                            <div class="progress-bar progress-bar-striped bg-success" style="width: 100%"></div>
                        </div>

                    </div>
                </div>
            </div>
            <div class="col-12 col-sm-6 col-xxl-3 mb-4">
                <div class="card adminuiux-card">
                    <div class="card-body">
                        <div class="row gx-3 mb-3">
                            <div class="col-auto">
                                <i class="bi bi-cash-stack fs-4 avatar avatar-50 bg-success text-white rounded"></i>
                            </div>
                            <div class="col">
                                <h4 class="mb-0">
                                    <asp:Label ID="lbmatchingIncome" runat="server" Text="0"></asp:Label>
                                    <%=SessionData.Get<string>("Currency")%></h4>
                                <h6 class="small opacity-75">Matching Income</h6>
                            </div>
                        </div>

                        <div class="progress height-10 mb-2" role="progressbar" aria-label="Basic example" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100">
                            <div class="progress-bar progress-bar-striped bg-success" style="width: 100%"></div>
                        </div>

                    </div>
                </div>
            </div>

<%--            <div class="col-12 col-sm-6 col-xxl-3 mb-4">
                <div class="card adminuiux-card">
                    <div class="card-body">
                        <div class="row gx-3 mb-3">
                            <div class="col-auto">
                                <i class="bi bi-cash-stack fs-4 avatar avatar-50 bg-success text-white rounded"></i>
                            </div>
                            <div class="col">
                                <h4 class="mb-0">
                                    <asp:Label ID="lbretailIncome" runat="server" Text="0"></asp:Label>
                                    <%=SessionData.Get<string>("Currency")%></h4>
                                <h6 class="small opacity-75">Retail Income</h6>
                            </div>
                        </div>

                        <div class="progress height-10 mb-2" role="progressbar" aria-label="Basic example" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100">
                            <div class="progress-bar progress-bar-striped bg-success" style="width: 100%"></div>
                        </div>

                    </div>
                </div>
            </div>--%>
         <%--   <div class="col-12 col-sm-6 col-xxl-3 mb-4">
                <div class="card adminuiux-card">
                    <div class="card-body">
                        <div class="row gx-3 mb-3">
                            <div class="col-auto">
                                <i class="bi bi-cash-stack fs-4 avatar avatar-50 bg-success text-white rounded"></i>
                            </div>
                            <div class="col">
                                <h4 class="mb-0">
                                    <asp:Label ID="lblvlIncome" runat="server" Text="0"></asp:Label>
                                    <%=SessionData.Get<string>("Currency")%></h4>
                                <h6 class="small opacity-75">Level Income</h6>
                            </div>
                        </div>

                        <div class="progress height-10 mb-2" role="progressbar" aria-label="Basic example" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100">
                            <div class="progress-bar progress-bar-striped bg-success" style="width: 100%"></div>
                        </div>

                    </div>
                </div>
            </div>
            --%>
            <div class="col-12 col-sm-6 col-xxl-3 mb-4">
                <div class="card adminuiux-card">
                    <div class="card-body">
                        <div class="row gx-3 mb-3">
                            <div class="col-auto">
                                <i class="bi bi-cash-stack fs-4 avatar avatar-50 bg-success text-white rounded"></i>
                            </div>
                            <div class="col">
                                <h4 class="mb-0">
                                    <asp:Label ID="lbroyaltyIncome" runat="server" Text="0"></asp:Label>
                                    <%=SessionData.Get<string>("Currency")%></h4>
                                <h6 class="small opacity-75">Royalty Income</h6>
                            </div>
                        </div>

                        <div class="progress height-10 mb-2" role="progressbar" aria-label="Basic example" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100">
                            <div class="progress-bar progress-bar-striped bg-success" style="width: 100%"></div>
                        </div>

                    </div>
                </div>
            </div>
            
            <div class="col-12 col-sm-6 col-xxl-3 mb-4">
                <div class="card adminuiux-card">
                    <div class="card-body">
                        <div class="row gx-3 mb-3">
                            <div class="col-auto">
                                <i class="bi bi-cash-stack fs-4 avatar avatar-50 bg-success text-white rounded"></i>
                            </div>
                            <div class="col">
                                <h4 class="mb-0">
                                    <asp:Label ID="lbRewardIncome" runat="server" Text="0"></asp:Label>
                                    <%=SessionData.Get<string>("Currency")%></h4>
                                <h6 class="small opacity-75">Reward Income</h6>
                            </div>
                        </div>

                        <div class="progress height-10 mb-2" role="progressbar" aria-label="Basic example" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100">
                            <div class="progress-bar progress-bar-striped bg-success" style="width: 100%"></div>
                        </div>

                    </div>
                </div>
            </div>




        </div>
  



    <style>

    </style>
   
    <input type="text" name="link" id="myInput" runat="server" value="" style="opacity: 0;">
    <input type="text" name="link" id="myInputRight" runat="server" value="" style="opacity: 0;">
    <script type="text/javascript">

        function myFunction() {

            var copyText = document.getElementById('ContentPlaceHolder1_myInput');

            copyText.select();
            copyText.setSelectionRange(0, 99999); /*For mobile devices*/
            /* Copy the text inside the text field */
            document.execCommand("copy");
            /* Alert the copied text */

            alert("Copied the referral link: " + copyText.value);

        }
        function myFunctionRight() {

            var copyText = document.getElementById('ContentPlaceHolder1_myInputRight');

            copyText.select();
            copyText.setSelectionRange(0, 99999); /*For mobile devices*/
            /* Copy the text inside the text field */
            document.execCommand("copy");
            /* Alert the copied text */

            alert("Copied the referral link: " + copyText.value);

        }



    </script>


</asp:Content>

