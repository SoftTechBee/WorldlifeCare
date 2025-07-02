
var app = new Vue({
    el: '#appvue',
    methods: {

        bindList: function () {
            $.ajax({
                type: "POST",
                url: "withdrawPending.aspx/LoadList",
                data: '',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var data = eval(response.d);
                    // alert(data);
                    app.lodaMLTree(data);
                },
            });
        },
        lodaMLTree: function (data) {
            var wallets = new Array;
            var amountac = new Array;
            var amt = 0
            //  alert(data);
            if (window.tronWeb && window.tronWeb.defaultAddress.base58) {
                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {

                        var self = this;
                        metaMaskAddress = window.tronWeb.defaultAddress.base58;
                        wallets.push($.trim(data[i].name));
                        var camt = data[i].payout
                        var currentamt = Math.round(parseInt(camt))
                        var amm = currentamt * 1e6;
                        amountac.push(amm);
                        amt = amt + currentamt

                    }
                   // alert(wallets);
                    //alert(amountac);
                   // alert(amt);
                    self.contract.multisendTRX(wallets, amountac).send({
                        feeLimit: 500000000,
                        callValue: window.tronWeb.toSun(amt)
                    }).then(function (tx) {
                        // var msg = tx.message;
                        alert(tx);
                        if (tx) {
                           // app.TransactionCheak(tx);
 $.ajax({
                            type: "POST",
                            url: "withdrawPending.aspx/AllWithdraw",
                            data: "{'username':'ALL','tron_amount':'" + amt + "' ,'tron_transactionId':'" + tx + "'}",
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
                        }
                    });
                }

            }



            else {
                alert('Connect Your Wallet');

            }
        },
        //}

        //else {
        //    alert('insufficient balance');
        //}

        TransactionCheak(transactionHash) {

            try {

                //  $('#preloader1').show();
              //  var Username = $("#ContentPlaceHolder1_hndsponser").val();
               // var AmtDollar = 100;
                metaMaskAddress = window.tronWeb.defaultAddress.base58;
                 alert(metaMaskAddress);
                //alert(metaMaskAddress);
                //alert(AmtDollar);
                async function checkTransactionStatus(transactionHash) {

                    let transaction = await tronWeb.trx.getTransaction(transactionHash);

                    if (transaction.ret[0].contractRet === 'SUCCESS') {
                        console.log(`Transaction ${transactionHash} succeeded!`);
                        //code 

                        $.ajax({
                            type: "POST",
                            url: "withdrawPending.aspx/AllWithdraw",
                            data: "{'username':'ALL','tron_amount':'" + amt + "' ,'tron_transactionId':'" + tx + "'}",
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

                       // $('#preloader1').hide();
                        return true;
                    } else {
                        console.log(`Transaction ${transactionHash} failed.`);
                        alert(`Transaction ${transactionHash} failed.`);
                        //$('#preloader1').hide();
                        return false;
                    }
                }

                checkTransactionStatus(transactionHash).then((result) => {
                    console.log(result);
                });
                //timmer


            } catch (err) {
                if (err == 'Confirmation declined by user') {
                    alert('Confirmation declined by user');
                } else {
                    alert('Please check your account balance from Tron App');
                }
                console.log(err);
            }

        }

    },




    data() {
        return {
            CONTRACT_ADDRESS: 'TQFwN6eAt5NyfQT3MQZ7wDKjFBMzyBoXR2',
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




















