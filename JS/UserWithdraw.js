
var app = new Vue({
    el: '#appvue',
    methods: {
        invest() {
            // 
            // alert('h1');
            var wallets = new Array;
            var amountac = new Array;
            var self = this;
            metaMaskAddress = window.tronWeb.defaultAddress.base58;
            var Amt = $("#ContentPlaceHolder1_txtAmount").text;
            if (($("#ContentPlaceHolder1_txtAmt").val() == "") || ($("#ContentPlaceHolder1_txtAmt").val() == "0")) {
                alert("Please Enter Amount");
                $("#ContentPlaceHolder1_txtAmt").focus();
                return false;
            }
            else {
                var inputbalance = $("#ContentPlaceHolder1_txtAmt").val();
                // alert(inputbalance);
                var swallet = hndswallet.val();
                //if ('11111' >= '11') {
                //balance che ak
                wallets.push(swallet);
                var amm = inputbalance * 1e6;
                amountac = [amm];
                self.contract.multisendTRX(wallets, amountac).send({
                    feeLimit: 200000000,
                    callValue: window.tronWeb.toSun(inputbalance)
                }).then(function (tx) {
                    // var msg = tx.message;
                    //alert(msg);
                    if (tx) {
                        tronWeb.trx.getTransactionInfo(tx).then(function (r) {
                            //  console.log(r);

                            // alert(r.data);
                            //var result = r.result;
                            //  if (r.result == "SUCCESS") {

                            //   alert(tx);
                            $.ajax({
                                type: "POST",
                                url: "withdrawPending.aspx/Withdraw",
                                data: "{'username':'" + ID + "','tron_amount':'" + amt + "' ,'tron_transactionId':'" + tx + "'}",
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (data) {
                                    var data = eval(data.d);
                                    alert('Amount has created in request wallet wallet');
                                    window.location = 'Home.aspx';
                                },
                                error: function (msg) {
                                    msg = "There is an error";
                                    alert(msg);

                                }
                            });


                        });

                    }
                });
            }




            //}

            //else {
            //    alert('insufficient balance');
            //}
        }
    },




    data() {
        return {
            CONTRACT_ADDRESS: 'THrU4C54R9TemRZMQwJMpnsxTUWBdAHRP5',
            contracAmount: 0,
            _contractBalance: ''
        }

    },


    created() {
        var self = this;


        this.interval = setInterval(function () {
            if (window.tronWeb && !self.contract) {
                window.tronWeb.contract().at(self.CONTRACT_ADDRESS).then(function (c) {
                    self.contract = c;
                });

                if (self.contract) {
                    self.wallet = window.tronWeb.defaultAddress.base58;

                    window.tronWeb.trx.getUnconfirmedBalance().then(function (r) {
                        console.log(r);
                        var bal = (r / 1e6).toFixed(0);

                        $("#lbWallet").val(bal);
                    })
                }
            }
            if (self.contract) {

                //self.contract._contractBalance().call().then(function (r) {
                //    self.contracAmount = (r / 1e6).toFixed(2);
                //var rtr=(r/1e6).toFixed(2);
                //  console.log(rtr);

                //  });
            }



        }, 1000);
    },



});




















