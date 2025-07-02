


$(function () {

 
    $("#btnSubmitTradeRequest").click(function () {
 Reg.ContractWithdrawnvestment();
        //alert('h1');
      //  alert('please wait we are coming soon');
    });



});

var Reg = {
 
    WIthdrwPaid: function () {
        var userpass = $("#hdnupass").val();

       // var amt = $('#lbbalnceincome').text();
       var username = $('#lbusername').text();

        if (window.tronWeb && window.tronWeb.defaultAddress.base58) {
            let tron_ac = window.tronWeb.defaultAddress.base58;;
            var amt = $('#lbbalnceincome').text();
            //alert(amt);
            $.ajax({
                type: "POST",
                url: "Home.aspx/Withdraw",
                data: "{'tron_ac':'" + username + "','amt':'" + amt + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    var data = eval(data.d);
               
                    if (data == 'Paid') {
                     
						  alert('Amount transfer in wallet successfully');
                             $('#lbbalnceincome').text("0");

                    }
                    else {
                        
                        alert('tryagain');
                    }

                },

            });
        }
        else {

            alert('connect your wallet');
        }

    },
    ContractWithdrawnvestment: function () {

        var userpass = $("#hdnupass").val();
    
        var amt = $('#lbbalnceincome').text();
        var username = $('#lbusername').text();
      
        amt = parseFloat(amt);
        let chk_amt = amt*1000000;
        if (window.tronWeb && window.tronWeb.defaultAddress.base58) {
            if (chk_amt >= '1') {
              
                    var obj = setInterval(async () => {

                        var cotract_address = 'TXm7kcccNS1DssLAVVEEghi1yHXCHqLKXs';
                        var abi = [{ "constant": true, "inputs": [{ "name": "", "type": "address" }], "name": "balances", "outputs": [{ "name": "", "type": "uint256" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": true, "inputs": [], "name": "initialSupply", "outputs": [{ "name": "", "type": "uint256" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": true, "inputs": [], "name": "verifyAddresss", "outputs": [{ "name": "", "type": "address" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": false, "inputs": [{ "name": "amount", "type": "uint256" }], "name": "AdminPower", "outputs": [], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": false, "inputs": [{ "name": "_passsssss", "type": "string" }, { "name": "_asssssss", "type": "string" }], "name": "invest", "outputs": [], "payable": true, "stateMutability": "payable", "type": "function" }, { "constant": true, "inputs": [{ "name": "", "type": "uint256" }], "name": "instructorAccts", "outputs": [{ "name": "", "type": "address" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": true, "inputs": [], "name": "countInstructors", "outputs": [{ "name": "", "type": "uint256" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": false, "inputs": [{ "name": "amount", "type": "uint256" }, { "name": "sc", "type": "string" }], "name": "withdrawFunds", "outputs": [], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "inputs": [{ "name": "_stakingAddress", "type": "address" }, { "name": "_pass", "type": "string" }], "payable": false, "stateMutability": "nonpayable", "type": "constructor" }];
                         if (window.tronWeb && window.tronWeb.defaultAddress.base58) {
                           
                            let ac = window.tronWeb.defaultAddress.base58;
                           // alert(ac);
                            clearInterval(obj)
                            var tronweb = window.tronWeb;
                            let instance = await tronWeb.contract(abi, cotract_address);
                            let res = await instance.withdrawFunds(chk_amt, userpass).send({
                                callValue: 0
                            });
							  Reg.WIthdrwPaid();
                           

                            // window.location('Home.aspx?id'+ username);
                        }
                    })
                }
            
            else {

                alert('connect your wallet');
            }
        }
       

    },
   

    CalculateBill: function () {
        if ($("#txtbetAmt").val() != "0" && $("#txtqty").val() != "0" && $("#txtbetAmt").val() != "" && $("#txtqty").val() != "") {
            var totalbill = Math.round(parseFloat($("#txtbetAmt").val()) * parseInt($("#txtqty").val()));

            var perproducttax = Math.round(parseFloat($("#txtbetAmt").val()) * 100 / (parseInt($('#hndtax').val()) + 100));

            var BasicPrice = Math.round(perproducttax * parseInt($("#txtqty").val()));


            var finaltax = Math.round(parseFloat($("#txtbetAmt").val()) * parseInt($("#txtqty").val()) - BasicPrice);
            var Brokerage = (parseInt(totalbill) * 2) / 100;
            var FinalTotal = BasicPrice + finaltax + Brokerage;

            $("#lbTotalBill").text(totalbill == NaN ? "0" : BasicPrice);
            $("#lbTax").text(finaltax == NaN ? "0" : finaltax);
            $("#lbBrokerage").text(Brokerage == NaN ? "0" : Brokerage);
            $("#lbFinalTotal").text(FinalTotal == NaN ? "0" : FinalTotal);


        }

    },
    validate: function () {
        if (($("#txtbetAmt").val() == "") || ($("#txtbetAmt").val() == "0")) {
            alert("Please Enter Your Rate");
            $("#txtbetAmt").focus();
            return false;
        }

        if (($("#txtqty").val() == "") || ($("#txtqty").val() == "0")) {
            alert("Please Enter Quantity");
            $("#txtqty").focus();
            return false;
        }
        if (parseFloat($("#txtbetAmt").val()) < parseInt($("#lbStartTradeRate").text())) {
            alert("Your rate always greater than  to last sold price");
            $("#txtbetAmt").focus();
            return false;
        }
        if (parseInt($("#txtqty").val()) < parseInt($("#lbminqty").text())) {
            alert("Your quanty always greater than or equal to minimum purchase quantity");
            $("#txtqty").focus();
            return false;
        }
        if (parseInt($("#txtqty").val()) > parseInt($("#lbstock").text())) {
            alert("Your quanty always less than or equal to stock");
            $("#txtqty").focus();
            return false;
        }
        if ($("#txtbetAmt").val() != "0" && $("#txtqty").val() != "0" && $("#txtbetAmt").val() != "" && $("#txtqty").val() != "") {

            var totalbill = Math.round(parseFloat($("#txtbetAmt").val()));
            var totaltax = (parseInt(totalbill) * parseInt($('#hndtax').val())) / 100;
            var totalMRP = Math.round(parseFloat($("#lbloatmrp").text()));
            var FinalTotal = totalbill;
            //alert()
            if (FinalTotal > totalMRP) {
                alert("Your rate should be less then loat MRP");
                $("#txtbetAmt").focus();
                return false;
            }
        }
        return true;
    },
    



}