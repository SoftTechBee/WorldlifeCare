<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

				<div class="row invoice-card-row">
					<div class="col-md-3 mb-3">
								<div class="card coin-card">
									<div class="card-body ">
										<h4 class="card-title" style="font-size:18px;"><b>Total Deposit</b></h4>
										<div class="d-flex align-items-center">
											
											<h2 class="fs-38"><asp:Label ID="lbTotalDeposite" runat="server" Text="0"></asp:Label></h2>
										</div>
									</div>
								</div>
							</div>
		<div class="col-md-3 mb-3">
								<div class="card coin-card">
									<div class="card-body ">
										<h4 class="card-title" style="font-size:18px;"><b>Total Purchase</b></h4>
										<div class="d-flex align-items-center">
											
											<h2 class="fs-38"><asp:Label ID="lbtotapurchasing" runat="server" Text="0"></asp:Label></h2>
										</div>
									</div>
								</div>
							</div>
				<div class="col-md-3 mb-3">
								<div class="card coin-card">
									<div class="card-body ">
										<h4 class="card-title" style="font-size:18px;"><b>Success Withdraw</b></h4>
										<div class="d-flex align-items-center">
											
											<h2 class="fs-38"><asp:Label ID="lbTotalWithdrawal" runat="server" Text="0"></asp:Label></h2>
										</div>
									</div>
								</div>
							</div>
				
				<div class="col-md-3 mb-3">
								<div class="card coin-card">
									<div class="card-body ">
										<h4 class="card-title" style="font-size:18px;"><b>Company Balance</b></h4>
										<div class="d-flex align-items-center">
											
											<h2 class="fs-38"><asp:Label ID="lbCompanyNetBalance" runat="server" Text="0"></asp:Label></h2>
										</div>
									</div>
								</div>
							</div>
				<div class="col-md-3">
								<div class="card coin-card">
									<div class="card-body ">
										<h4 class="card-title" style="font-size:18px;"><b>Pending Withdraw</b></h4>
										<div class="d-flex align-items-center">
											
											<h2 class="fs-38"><asp:Label ID="lbpendingwithdraw" runat="server" Text="0"></asp:Label></h2>
										</div>
									</div>
								</div>
							</div>
				
				
			
				
			
				
	
					<div class="col-md-3 mt-3">
								<div class="card coin-card">
									<div class="card-body ">
										<h4 class="card-title" style="font-size:18px;"><b>Total Member</b></h4>
										<div class="d-flex align-items-center">
											
											<h2 class="fs-38"><asp:Label ID="lbTotalMember" runat="server" Text="0"></asp:Label></h2>
										</div>
									</div>
								</div>
							</div>
				<div class="col-md-3 mt-3">
								<div class="card coin-card">
									<div class="card-body ">
										<h4 class="card-title" style="font-size:18px;"><b>Active Member</b></h4>
										<div class="d-flex align-items-center">
											
											<h2 class="fs-38"><asp:Label ID="lbpaidmember" runat="server" Text="0"></asp:Label></h2>
										</div>
									</div>
								</div>
							</div>
				
				<div class="col-md-3 mt-3">
								<div class="card coin-card">
									<div class="card-body ">
										<h4 class="card-title" style="font-size:18px;"><b>Inactive Member</b></h4>
										<div class="d-flex align-items-center">
											
											<h2 class="fs-38"><asp:Label ID="lbfreemember" runat="server" Text="0"></asp:Label></h2>
										</div>
									</div>
								</div>
							</div>
			
					  <div class="col-xl-6 col-xxl-4 d-flex align-items-stretch">
            <div class="card w-100 rounded-4">
              <div class="card-body">
                <div class="d-flex align-items-start justify-content-between mb-3">
                  <div class="">
                    <h6 class="mb-0 fw-bold">Income Summary</h6>
                  </div>
                  <div class="dropdown">
                    <a href="javascript:;" class="dropdown-toggle-nocaret options dropdown-toggle" data-bs-toggle="dropdown">
                      <span class="material-icons-outlined fs-5">more_vert</span>
                    </a>
                   
                  </div>
                 </div>

                  <ul class="list-group list-group-flush">
         

<li class="list-group-item px-0 bg-transparent"> 
  <div class="d-flex align-items-center gap-3">
    <div class="wh-42 d-flex align-items-center justify-content-center rounded-3 bg-grd-branding">
      <img src="assets/images/gallery/favicon.png" width="32" alt="">
    </div>
    <div class="flex-grow-1">
      <h6 class="mb-0">Direct Income</h6>
    </div>
    <div class="d-flex align-items-center gap-3">
      <p class="mb-0"><asp:Label ID="lblDirectRefer" runat="server" Text="0"></asp:Label> <%=SessionData.Get<string>("Currency")%></p>
      <p class="mb-0 fw-bold text-success"><a href="rptDirectReferIncome.aspx" class="btn-sm">View</a></p>
    </div>
  </div>
</li>

<li class="list-group-item px-0 bg-transparent"> 
  <div class="d-flex align-items-center gap-3">
    <div class="wh-42 d-flex align-items-center justify-content-center rounded-3 bg-grd-branding">
      <img src="assets/images/gallery/favicon.png" width="32" alt="">
    </div>
    <div class="flex-grow-1">
      <h6 class="mb-0">Matching Income</h6>
    </div>
    <div class="d-flex align-items-center gap-3">
      <p class="mb-0"><asp:Label ID="lbbinary" runat="server" Text="0"></asp:Label> <%=SessionData.Get<string>("Currency")%></p>
      <p class="mb-0 fw-bold text-success"><a href="rptMatchingBinaryIncome.aspx"class="btn-sm">View</a></p>
    </div>
  </div>
</li>

<li class="list-group-item px-0 bg-transparent"> 
  <div class="d-flex align-items-center gap-3">
    <div class="wh-42 d-flex align-items-center justify-content-center rounded-3 bg-grd-branding">
      <img src="assets/images/gallery/favicon.png" width="32" alt="">
    </div>
    <div class="flex-grow-1">
      <h6 class="mb-0">Reward Income</h6>
    </div>
    <div class="d-flex align-items-center gap-3">
      <p class="mb-0"><asp:Label ID="lbrewardincome" runat="server" Text="0"></asp:Label> <%=SessionData.Get<string>("Currency")%></p>
      <p class="mb-0 fw-bold text-success"><a href="rptRewardIncome.aspx" class="btn-sm">View</a></p>
    </div>
  </div>
</li>

<%--<li class="list-group-item px-0 bg-transparent"> 
  <div class="d-flex align-items-center gap-3">
    <div class="wh-42 d-flex align-items-center justify-content-center rounded-3 bg-grd-branding">
      <img src="assets/images/gallery/favicon.png" width="32" alt="">
    </div>
    <div class="flex-grow-1">
      <h6 class="mb-0">Salary Income</h6>
    </div>
    <div class="d-flex align-items-center gap-3">
      <p class="mb-0"><asp:Label ID="lbsalary" runat="server" Text="0"></asp:Label> <%=SessionData.Get<string>("Currency")%></p>
      <p class="mb-0 fw-bold text-success"><a href="rptSalaryIncome.aspx" class="btn-sm">View</a></p>
    </div>
  </div>
</li>--%>

         </ul>

              </div>
            </div>
          </div>
             
              <div class="col-xl-6 col-xxl-4 d-flex align-items-stretch">
            <div class="card w-100 rounded-4">
              <div class="card-body">
                <div class="d-flex align-items-start justify-content-between mb-3">
                  <div class="">
                    <h6 class="mb-0 fw-bold">Team Left/Right</h6>
                  </div>
                  <div class="dropdown">
                    <a href="javascript:;" class="dropdown-toggle-nocaret options dropdown-toggle" data-bs-toggle="dropdown">
                      <span class="material-icons-outlined fs-5">more_vert</span>
                    </a>
                   
                  </div>
                 </div>

                  <ul class="list-group list-group-flush">
                      <li class="list-group-item px-0 bg-transparent">
                        <div class="d-flex align-items-center gap-3">
                          <div class="wh-42 d-flex align-items-center justify-content-center rounded-3 bg-grd-primary">
                         <img src="assets/images/apps/user.png" width="32" alt="">
                          </div>
                          <div class="flex-grow-1">
                            <h6 class="mb-0">Total Team</h6>
                          </div>
                          <div class="d-flex align-items-center gap-3">
                            <p class="mb-0"><asp:Label ID="lbLeftTeam" runat="server" Text="0"></asp:Label></p>/
      <p class="mb-0"><asp:Label ID="lbRightTeam" runat="server" Text="0"></asp:Label></p>
                          </div>
                        </div>
                      </li>
                     <li class="list-group-item px-0 bg-transparent">
                        <div class="d-flex align-items-center gap-3">
                          <div class="wh-42 d-flex align-items-center justify-content-center rounded-3 bg-grd-warning">
                         <img src="assets/images/apps/user.png" width="32" alt="">
                          </div>
                          <div class="flex-grow-1">
                            <h6 class="mb-0">Active Team</h6>
                          </div>
                          <div class="d-flex align-items-center gap-3">
                            <p class="mb-0"><asp:Label ID="lbActiveleftteam" runat="server" Text="0"></asp:Label></p>/
      <p class="mb-0"><asp:Label ID="lbActiveRightteam" runat="server" Text="0"></asp:Label></p>
                          </div>
                        </div>
                      </li>
                       <li class="list-group-item px-0 bg-transparent">
                        <div class="d-flex align-items-center gap-3">
                          <div class="wh-42 d-flex align-items-center justify-content-center rounded-3 bg-grd-branding">
                           <img src="assets/images/apps/user.png" width="32" alt="">
                          </div>
                          <div class="flex-grow-1">
                            <h6 class="mb-0">InActive Team</h6>
                          </div>
                          <div class="d-flex align-items-center gap-3">
                            <p class="mb-0"><asp:Label ID="lbInActiveLeftteam" runat="server" Text="0"></asp:Label></p>/
      <p class="mb-0"><asp:Label ID="lbInActiveRightteam" runat="server" Text="0"></asp:Label></p>
                          </div>
                        </div>
                      </li>
                   
                     
                     
                  </ul>

              </div>
            </div>
          </div>
                          <div class="col-xl-6 col-xxl-6 d-flex align-items-stretch">
            <div class="card w-100 rounded-4">
              <div class="card-body">
                  <div class="d-flex align-items-start justify-content-between">
                    <div class="">
                      <h5 class="mb-0">Business</h5>
                    </div>
                    <div class="dropdown">
                      <a href="javascript:;" class="dropdown-toggle-nocaret options dropdown-toggle"
                        data-bs-toggle="dropdown">
                        <span class="material-icons-outlined fs-5">more_vert</span>
                      </a>
                     
                    </div>
                  </div>
                <div class="d-flex align-items-center gap-3 mt-4">
                     
                  <div class="mb-4">
                    <h1 class="mb-0"><asp:Label runat="server" ID="lbtotalbusiness" Text="0.0"></asp:Label> <%=SessionData.Get<string>("Currency")%></h1>
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
          
     
                       <div class="col-xl-6 col-xxl-4 d-flex align-items-stretch">
            <div class="card w-100 rounded-4">
              <div class="card-body">
                <div class="d-flex align-items-start justify-content-between mb-3">
                  <div class="">
                    <h6 class="mb-0 fw-bold">Total SV/BV</h6>
                  </div>
                  <div class="dropdown">
                    <a href="javascript:;" class="dropdown-toggle-nocaret options dropdown-toggle" data-bs-toggle="dropdown">
                      <span class="material-icons-outlined fs-5">more_vert</span>
                    </a>
                   
                  </div>
                 </div>

                  <ul class="list-group list-group-flush">
                    <li class="list-group-item px-0 bg-transparent"> 
                         <div class="d-flex align-items-center gap-3">
    <div class="wh-42 d-flex align-items-center justify-content-center rounded-3 bg-grd-branding">
      <img src="assets/images/gallery/favicon.png" width="32" alt="">
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
      <img src="assets/images/gallery/favicon.png" width="32" alt="">
    </div>
    <div class="flex-grow-1">
      <h6 class="mb-0">Left/Right BV</h6>
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
            <div class="col-xl-6 col-xxl-4 d-flex align-items-stretch">
            <div class="card w-100 rounded-4">
              <div class="card-body">
                <div class="d-flex align-items-start justify-content-between mb-3">
                  <div class="">
                    <h6 class="mb-0 fw-bold">Available SV/BV</h6>
                  </div>
                  <div class="dropdown">
                    <a href="javascript:;" class="dropdown-toggle-nocaret options dropdown-toggle" data-bs-toggle="dropdown">
                      <span class="material-icons-outlined fs-5">more_vert</span>
                    </a>
                   
                  </div>
                 </div>

                  <ul class="list-group list-group-flush">
                    <li class="list-group-item px-0 bg-transparent"> 
                         <div class="d-flex align-items-center gap-3">
    <div class="wh-42 d-flex align-items-center justify-content-center rounded-3 bg-grd-branding">
      <img src="assets/images/gallery/favicon.png" width="32" alt="">
    </div>
    <div class="flex-grow-1">
      <h6 class="mb-0">Left/Right SV</h6>
    </div>
    <div class="d-flex align-items-center gap-3">
      <p class="mb-0"><asp:Label ID="Availableleftpv" runat="server" Text="0"></asp:Label></p>/
      <p class="mb-0"><asp:Label ID="Availablerightpv" runat="server" Text="0"></asp:Label></p>
    </div>
  </div>
</li>

 <li class="list-group-item px-0 bg-transparent"> 
                         <div class="d-flex align-items-center gap-3">
    <div class="wh-42 d-flex align-items-center justify-content-center rounded-3 bg-grd-branding">
      <img src="assets/images/gallery/favicon.png" width="32" alt="">
    </div>
    <div class="flex-grow-1">
      <h6 class="mb-0">Left/Right BV</h6>
    </div>
    <div class="d-flex align-items-center gap-3">
      <p class="mb-0"><asp:Label ID="AvailableleftBV" runat="server" Text="0"></asp:Label></p>/
      <p class="mb-0"><asp:Label ID="AvailablerightBV" runat="server" Text="0"></asp:Label></p>
    </div>
  </div>
</li>



         </ul>

              </div>
            </div>
          </div> 
                    
							
				

						
				</div>
           
</asp:Content>

