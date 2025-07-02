<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="TreeCode_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        //<![CDATA[
        var theForm = document.forms['form1'];
        if (!theForm) {
            theForm = document.form1;
        }
        function __doPostBack(eventTarget, eventArgument) {
            if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
                theForm.__EVENTTARGET.value = eventTarget;
                theForm.__EVENTARGUMENT.value = eventArgument;
                theForm.submit();
            }
        }
        //]]>
    </script>
</head>
<body>
    <form id="form1" runat="server">
          <div class="content-wrapper bg-new">
            

<style>
    .pop-up {
        display: none;
        position: absolute;
        width: 280px;
        padding: 10px;
        background: #dddddd;
        color: #000000;
        font-size: 90%;
        z-index: 99999;
        border: 2px solid #0e8ab2;
    }

    a {
        cursor: pointer;
    }
</style>

              <script src="jquery-1.7.1.min.js"></script>
              <div class="content-wrapper bg-new">
            

            
<script>

    $(function () {
        $(".Showdiv").click(function (e) {
            debugger;
            $("#details").text('');
            alert(this.id);
            if (this.id != 0 && this.id > 10) {
                $("#details").show();
                $.ajax({
                    type: "GET",
                    url: "TreeDetails/" + this.id,
                    dataType: "json",
                    success: function (response) {
                        $("#details").html(response);
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
<section class="content-header">
    <h4>My Tree</h4>
    <ol class="breadcrumb">
        <li><a href="/User/Index"><i class="fa fa-dashboard"></i>Home</a></li>
        <li><a href="#">My Tree</a></li>
    </ol>
</section>
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
<section class="content " style="background: white;">
    <div class="row">
        <div class="col-md-12">
           
             
            <div class="col-md-6">
                <div class="box box-info box-solid">
                    <div class="box-header with-border">
                        <h3 class="box-title">Member Status</h3>
                        <div class="box-tools pull-right">
                            <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                            <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                        </div>
                    </div>
                    <div class="box-body">
                        <div class="table-responsive">
                            <table class="table no-margin" >
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th class="text-center">Total Left </th>
                                        <th class="text-center">Total Right</th>
                                    </tr>
                                </thead>
                                <tbody>
                                        <tr>
                                            <td>REGISTRATION </td>
                                            <td class="text-center"></td>
                                            <td class="text-center"></td>
                                        </tr>
                                        <tr>
                                            <td>TOTAL BUSINESS   </td>
                                            <td class="text-center">0</td>
                                            <td class="text-center">0</td>
                                        </tr>
                                        <tr>
                                            <td>TOTAL PV   </td>
                                            <td class="text-center">0</td>
                                            <td class="text-center">0</td>
                                        </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-12" id="divtreestructure">
            <div style="width: auto; overflow-x: auto">
                <div style="margin: 25px 15px;" align="center">
                    <div class="contentbox new-box" style="background:dark; padding: 15px;">
                        <div id="backbtn" onclick="goBack()">
                        </div>
                          <table border="0" cellpadding="0" cellspacing="0" class="m_text" align="center">
                                <tr>
                                    <td align="center">
                                        <img  runat="server" id="Img1" class="Showdiv"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                       
                                        <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server">LinkButton</asp:LinkButton>
                                       <asp:Button runat="server" OnClick="Unnamed_Click" ID="btn1" text="jj" />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../TreeCode/TreeImg/band1.gif" alt="" class="img-responsive" />
                                    </td>
                                </tr>
                            </table>
                            <table border="0" cellpadding="0" cellspacing="0" class="m_text" align="center" width="100%">
                                <tr>
                                    <td align="center">
                                       <img  runat="server" id="Img2" class="Showdiv"/>
                                    </td>
                                    <td align="center">
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
                                    <td align="center">
                                        <img src="../TreeCode/TreeImg/band2.gif" alt="" class="img-responsive" />
                                    </td>
                                    <td align="center">
                                        <img src="../TreeCode/TreeImg/band2.gif" alt="" class="img-responsive" />
                                    </td>
                                </tr>
                            </table>
                            <table border="0" cellpadding="0" cellspacing="0" class="m_text" align="center" width="100%">
                                <tr>
                                    <td align="center" style="width: 25%">
                                       <img  runat="server" id="Img4" class="Showdiv"/>
                                    </td>
                                    <td align="center" style="width: 25%">
                                       <img  runat="server" id="Img5" class="Showdiv"/>
                                    </td>
                                    <td align="center" style="width: 25%">
                                       <img  runat="server" id="Img6" class="Showdiv"/>
                                    </td>
                                    <td align="center" style="width: 25%">
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
                                <tr>
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
                                </tr>
                            </table>
                            <table border="0" cellpadding="0" cellspacing="0" class="m_text" align="center" width="100%">
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
                            </table>
                        </div>
                    <br />
                </div>
            </div>
        </div>
    </div>
</section>

        </div>
   
    

        </div>

       
    

        </form>
    
    <style type="text/css">
        @media (min-width:768px) {
            .modal-dialogalert {
                width: 300px;
                margin: 15% auto;
            }

            .modal-contentalert {
                -webkit-box-shadow: 0 5px 15px rgba(0,0,0,.5);
                box-shadow: 0 5px 15px rgba(0,0,0,.5);
            }

            .modal-smalert {
                width: 300px;
            }

            .modal-headeralert {
                min-height: 100px;
                background: #ea6871;
                padding: 15px;
                border-bottom: 1px solid #ea6871;
            }

                .modal-headeralert .close {
                    margin-top: -2px;
                }

            .modal-titlealert {
                margin: 0;
                font-size: 35pt;
                color: #ffffff;
                text-align: center;
            }

            .modal-bodyalert {
                position: relative;
                padding: 15px;
            }

            .modal-footeralert {
                padding: 15px;
                text-align: center;
                border-bottom: 1px solid #ea6871;
                font-size: 17px;
                font-weight: 500;
                color: #333;
                text-align: center;
            }

                .modal-footeralert .btn + .btn {
                    margin-bottom: 0;
                    margin-left: 5px;
                }

                .modal-footeralert .btn-group .btn + .btn {
                    margin-left: -1px;
                }

                .modal-footeralert .btn-block + .btn-block {
                    margin-left: 0;
                }
        }


        @media (min-width:420px)and (max-width:780px) {
            .modal-dialogalert {
                width: 300px;
                margin: 15% auto;
            }

            .modal-contentalert {
                -webkit-box-shadow: 0 5px 15px rgba(0,0,0,.5);
                box-shadow: 0 5px 15px rgba(0,0,0,.5);
            }

            .modal-smalert {
                width: 300px;
            }

            .modal-headeralert {
                min-height: 100px;
                background: #ea6871;
                padding: 15px;
                border-bottom: 1px solid #ea6871;
            }

                .modal-headeralert .close {
                    margin-top: -2px;
                }

            .modal-titlealert {
                margin: 0;
                font-size: 35pt;
                color: #ffffff;
                text-align: center;
            }

            .modal-bodyalert {
                position: relative;
                padding: 15px;
            }

            .modal-footeralert {
                padding: 15px;
                text-align: center;
                border-bottom: 1px solid #ea6871;
                font-size: 17px;
                font-weight: 500;
                color: #333;
                text-align: center;
            }

                .modal-footeralert .btn + .btn {
                    margin-bottom: 0;
                    margin-left: 5px;
                }

                .modal-footeralert .btn-group .btn + .btn {
                    margin-left: -1px;
                }

                .modal-footeralert .btn-block + .btn-block {
                    margin-left: 0;
                }
        }

        @media (min-width:250px)and (max-width:420px) {
            .modal-dialogalert {
                width: 300px;
                margin: 15% auto;
            }

            .modal-contentalert {
                -webkit-box-shadow: 0 5px 15px rgba(0,0,0,.5);
                box-shadow: 0 5px 15px rgba(0,0,0,.5);
            }

            .modal-smalert {
                width: 300px;
            }

            .modal-headeralert {
                min-height: 100px;
                background: #ea6871;
                padding: 15px;
                border-bottom: 1px solid #ea6871;
            }

                .modal-headeralert .close {
                    margin-top: -2px;
                }

            .modal-titlealert {
                margin: 0;
                font-size: 35pt;
                color: #ffffff;
                text-align: center;
            }

            .modal-bodyalert {
                position: relative;
                padding: 15px;
            }

            .modal-footeralert {
                padding: 15px;
                text-align: center;
                border-bottom: 1px solid #ea6871;
                font-size: 17px;
                font-weight: 500;
                color: #333;
                text-align: center;
            }

                .modal-footeralert .btn + .btn {
                    margin-bottom: 0;
                    margin-left: 5px;
                }

                .modal-footeralert .btn-group .btn + .btn {
                    margin-left: -1px;
                }

                .modal-footeralert .btn-block + .btn-block {
                    margin-left: 0;
                }
        }
    </style>

    <style>
        .lable_input {
            padding-right: 0px;
            font-weight: normal;
            font-size: 12pt;
        }
    </style>
    
</body>
</html>
