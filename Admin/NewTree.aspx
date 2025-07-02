<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="NewTree.aspx.cs" Inherits="User_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

              <div class="content-wrapper "  style="background-color:white;"> 
    

<style>
	
    .pop-up {
        display: none;
        position: absolute;
        width: 200px;
        padding: 10px;
        background: black;
        color: white;
        font-size: 70%;
        z-index: 99999;
        border: 2px solid #0e8ab2;
    }

    a {
        cursor: pointer;
    }
	
	
</style>
         <script src="../TreeCode/jquery-1.7.1.min.js"></script>
            
<script>

    $(function () {
        $(".Showdiv").click(function (e) {
            debugger;
            $("#details").text('');
            var ImgID = this.id;
            var UserId = '';
            if (ImgID == 'ContentPlaceHolder1_Img1') { UserId = $("#ContentPlaceHolder1_hnduserid1").val() }
            else if (ImgID == 'ContentPlaceHolder1_Img2') { UserId = $("#ContentPlaceHolder1_hnduserid2").val() }
            else if (ImgID == 'ContentPlaceHolder1_Img3') { UserId = $("#ContentPlaceHolder1_hnduserid3").val() }
            else if (ImgID == 'ContentPlaceHolder1_Img4') { UserId = $("#ContentPlaceHolder1_hnduserid4").val() }
            else if (ImgID == 'ContentPlaceHolder1_Img5') { UserId = $("#ContentPlaceHolder1_hnduserid5").val() }
            else if (ImgID == 'ContentPlaceHolder1_Img6') { UserId = $("#ContentPlaceHolder1_hnduserid6").val() }
            else if (ImgID == 'ContentPlaceHolder1_Img7') { UserId = $("#ContentPlaceHolder1_hnduserid7").val() }
            //else if (ImgID == 'ContentPlaceHolder1_Img8') { UserId = $("#ContentPlaceHolder1_hnduserid8").val() }
            //else if (ImgID == 'ContentPlaceHolder1_Img9') { UserId = $("#ContentPlaceHolder1_hnduserid9").val() }
            //else if (ImgID == 'ContentPlaceHolder1_Img10') { UserId = $("#ContentPlaceHolder1_hnduserid10").val() }
            //else if (ImgID == 'ContentPlaceHolder1_Img11') { UserId = $("#ContentPlaceHolder1_hnduserid11").val() }
            //else if (ImgID == 'ContentPlaceHolder1_Img12') { UserId = $("#ContentPlaceHolder1_hnduserid12").val() }
            //else if (ImgID == 'ContentPlaceHolder1_Img13') { UserId = $("#ContentPlaceHolder1_hnduserid13").val() }
            //else if (ImgID == 'ContentPlaceHolder1_Img14') { UserId = $("#ContentPlaceHolder1_hnduserid14").val() }
            //else if (ImgID == 'ContentPlaceHolder1_Img15') { UserId = $("#ContentPlaceHolder1_hnduserid15").val() }
            
            //alert();
           
            if (UserId != "0") {
               //alert(UserId);
                $("#details").show();
                $.ajax({
                    type: "POST",
                    url: "NewTree.aspx/TreeDetails",
                    data: JSON.stringify({ UserId: UserId }), //JSON.stringify(SearchObject),
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (response) {
                        var maindata = eval(response.d);
                        var details = '<h6>Member ID: ' + maindata[0].username + '</h6>'
                            + '<h6>Name: ' + maindata[0].name + '</h6>'
                            + '<h6>Reff ID: ' + maindata[0].reffid + '</h6>'
                            + '<h6>Total Left Team: ' + maindata[0].leftteam + '</h6>'
                            + '<h6>Total Right Team: ' + maindata[0].rightteam + '</h6>'
                            + '<h6>Active Left Team: ' + maindata[0].leftactiveteam + '</h6>'
                            + '<h6>Active Right Team: ' + maindata[0].rightactiveteam + '</h6>'
                            + '<h6>Current Left BV: ' + maindata[0].CurrentLeftBus + '</h6>'
                            + '<h6>Current Right BV: ' + maindata[0].CurrentRightBus + '</h6>'
                            + '<h6>Total Left BV: ' + maindata[0].TotalLeftBus + '</h6>'
                            + '<h6>Total Right BV: ' + maindata[0].TotalRightBus + '</h6>'
                            + '<h6>Current Left SV: ' + maindata[0].CurrentLeftPV + '</h6>'
                            + '<h6>Current Right SV: ' + maindata[0].CurrentRightPV + '</h6>'
                            + '<h6>Total Left SV: ' + maindata[0].TotalLeftPV + '</h6>'
                            + '<h6>Total Right SV: ' + maindata[0].TotalRightPV + '</h6>'
                            
                        $("#details").html(details);
                    }
                });
                var o = {
                    left: e.pageX + 2,
                    top: e.pageY + 2
                };
                $("#details").show(1000).offset(o);
            }
        });

        $(".Showdiv").mouseout(function (e) {
            $("#details").hide();
        });
    });
   
</script>

<div id="details" class="pop-up">


</div>
<section class="content-header" style="padding-top:5px;padding-left:10px; ">
    <h4 style="color:black;">My Tree</h4>
   
</section>
                    <div class="form-group row align-items-center mb-3" style="padding-top:10px;padding-left:10px; ">
                <div class="col-lg-12">
                    <div class="input-group">
                        <asp:TextBox ID="txtsearch" CssClass="form-control" runat="server" placeholder="Enter UserName"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="btnsearch" OnClick="btnsearch_Click" runat="server" Text="Search" CssClass="btn btn-primary w-lg" />
                        </span>
                    </div>
                </div>
            </div>
                  <input type="hidden" id="hnduserid1" runat="server" />
                  <input type="hidden" id="hnduserid2" runat="server" />
                  <input type="hidden" id="hnduserid3" runat="server" />
                  <input type="hidden" id="hnduserid4" runat="server" />
                  <input type="hidden" id="hnduserid5" runat="server" />
                  <input type="hidden" id="hnduserid6" runat="server" />
                  <input type="hidden" id="hnduserid7" runat="server" />
                  <input type="hidden" id="hnduserid8" runat="server" />
                  <input type="hidden" id="hnduserid9" runat="server" />
                  <input type="hidden" id="hnduserid10" runat="server" />
                  <input type="hidden" id="hnduserid11" runat="server" />
                  <input type="hidden" id="hnduserid12" runat="server" />
                  <input type="hidden" id="hnduserid13" runat="server" />
                  <input type="hidden" id="hnduserid14" runat="server" />
                  <input type="hidden" id="hnduserid15" runat="server" />
<div class="col-md-12" id="divtreestructure">
    <div style="width: auto; overflow-x: auto">
        <div style="margin: 25px 15px;" align="center">
            <div class="contentbox new-box" style="background:dark; padding: 15px;">
                <div id="backbtn" onclick="goBack()">
                </div>
                  <table border="0" cellpadding="0" cellspacing="0" class="m_text" align="center"  width="800px">
                        <tr>
                            <td align="center"  width="800px">
                                <img  runat="server" id="Img1" class="Showdiv"/>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                               
                                <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server">LinkButton</asp:LinkButton>
                               <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" width="800px">
                                <img src="../TreeCode/TreeImg/band1.gif" alt="" class="img-responsive" />
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellpadding="0" cellspacing="0"  align="center" width="800px">
                        <tr>
                            <td align="center" style="width:400px">
                               <img  runat="server" id="Img2" class="Showdiv"/>
                            </td>
                            <td align="center" style="width:400px">
                                <img  runat="server" id="Img3" class="Showdiv"/>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                 <asp:LinkButton ID="LinkButton2" CauseValidation="false"  OnClick="LinkButton2_Click" runat="server"></asp:LinkButton>
                               
                                <br />
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton3" OnClick="LinkButton3_Click" runat="server"></asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width:400px">
                                <img src="../TreeCode/TreeImg/band2.gif" alt=""  />
                            </td>
                            <td align="center" style="width:400px">
                                <img src="../TreeCode/TreeImg/band2.gif" alt=""  />
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellpadding="0" cellspacing="0" class="m_text" align="center" width="800px">
                        <tr>
                            <td align="center" style="width:200px">
                               <img  runat="server" id="Img4" class="Showdiv"/>
                            </td>
                            <td align="center" style="width:200px">
                               <img  runat="server" id="Img5" class="Showdiv"/>
                            </td>
                            <td align="center" style="width:200px">
                               <img  runat="server" id="Img6" class="Showdiv"/>
                            </td>
                            <td align="center" style="width:200px">
                               <img  runat="server" id="Img7" class="Showdiv"/>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                 <asp:LinkButton ID="LinkButton4" OnClick="LinkButton4_Click" runat="server"></asp:LinkButton>
                                <br />
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton5" OnClick="LinkButton5_Click" runat="server"></asp:LinkButton>
                                <br />
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton6" OnClick="LinkButton6_Click" runat="server"></asp:LinkButton>
                                <br />
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton7" OnClick="LinkButton7_Click" runat="server"></asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="center">
                                <img src="../TreeCode/TreeImg/band3.gif" alt="" class="img-responsive" />
                            </td>
                            <td align="center">
                                <img src="../TreeCode/TreeImg/band3.gif" alt="" class="img-responsive" />
                            </td>
                            <td align="center">
                                <img src="../TreeCode/TreeImg/band3.gif" alt="" class="img-responsive" />
                            </td>
                            <td align="center">
                                <img src="../TreeCode/TreeImg/band3.gif" alt="" class="img-responsive" />
                            </td>
                        </tr>--%>
                    </table>
                    <%--<table border="0" cellpadding="0" cellspacing="0" class="m_text" align="center" width="100%">
                        <tr>
                            <td align="center">
                               <img  runat="server" id="Img8" class="Showdiv"/>
                            </td>
                            <td align="center">
                                <img  runat="server" id="Img9" class="Showdiv"/>
                            </td>
                            <td align="center">
                                <img  runat="server" id="Img10" class="Showdiv"/>
                            </td>
                            <td align="center">
                               <img  runat="server" id="Img11" class="Showdiv"/>
                            </td>
                            <td align="center">
                               <img  runat="server" id="Img12" class="Showdiv"/>
                            </td>
                            <td align="center">
                               <img  runat="server" id="Img13" class="Showdiv"/>
                            </td>
                            <td align="center">
                               <img  runat="server" id="Img14" class="Showdiv"/>
                            </td>
                            <td align="center">
                               <img  runat="server" id="Img15" class="Showdiv"/>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 100px; font-size: 9pt;">
                                 <asp:LinkButton ID="LinkButton8" OnClick="LinkButton8_Click" runat="server"></asp:LinkButton>
                                <br />
                            </td>
                            <td align="center" style="width: 100px; font-size: 9pt;">
                                <asp:LinkButton ID="LinkButton9" OnClick="LinkButton9_Click" runat="server"></asp:LinkButton>
                                <br />
                            </td>
                            <td align="center" style="width: 100px; font-size: 9pt;">
                                 <asp:LinkButton ID="LinkButton10" OnClick="LinkButton10_Click" runat="server"></asp:LinkButton>
                                <br />
                            </td>
                            <td align="center" style="width: 100px; font-size: 9pt;">
                                <asp:LinkButton ID="LinkButton11" OnClick="LinkButton11_Click" runat="server"></asp:LinkButton>
                                <br />
                            </td>
                            <td align="center" style="width: 100px; font-size: 9pt;">
                                <asp:LinkButton ID="LinkButton12" OnClick="LinkButton12_Click" runat="server"></asp:LinkButton>
                                <br />
                            </td>
                            <td align="center" style="width: 100px; font-size: 9pt;">
                                 <asp:LinkButton ID="LinkButton13" OnClick="LinkButton13_Click" runat="server"></asp:LinkButton>
                                <br />
                            </td>
                            <td align="center" style="width: 100px; font-size: 9pt;">
                                <asp:LinkButton ID="LinkButton14" OnClick="LinkButton14_Click" runat="server"></asp:LinkButton>
                                <br />
                            </td>
                            <td align="center" style="width: 100px; font-size: 9pt;">
                                <asp:LinkButton ID="LinkButton15" OnClick="LinkButton15_Click" runat="server"></asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                    </table>--%>
                </div>
            <br />
<input type="button" value="Get back to previous ID" onclick="window.history.back()" />

        </div>
    </div>
</div>

        </div>
  
	
	
	
 
    
</asp:Content>

