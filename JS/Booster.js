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
            tronWeb.trx.getBalance(metaMaskAddress).then(function (walletbalance) {


                var BasicPrice = 100;// document.getElementById("lbtotaltrx").innerHTML;
                var AmtDollar = 100;// $("#txtamt").val();
                var IDAmt = 100;//document.getElementById("lbtotaltrx").innerHTML;
                 alert(BasicPrice);
                //alert(AmtDollar);
                // alert('h1');
                var BasicPrice = 1;// Math.round(parseInt(BasicPrice) + 20);
                if (AmtDollar >= 1) {
                    var requiredbalance = (BasicPrice * 1000000);
                    // alert(walletbalance);
                    //alert(IDAmt);
                    if (walletbalance >= requiredbalance) {
                        wallets.push("TXs9d6jbhtvBC4vMr97mLyr2RkeTzJW1AB");
                        // wallets.push(reffWalletAddress);
                        //var BasicPrice = Math.round(parseInt(AmtDollar));
                        var AdAmt = 100 * 1e6;
                        //var SponAmt = 11.25 * 1e6;
                        //var TotatlAmt = inputbalance * 1e6;
                        amount = [AdAmt];
                        self.contract.multisendTRX(wallets, amount).send({
                            feeLimit: 200000000,
                            callValue: window.tronWeb.toSun(IDAmt)
                        }).then(function (tx) {
                            if (tx) {
                              //  app.TransactionCheak(tx);
								  $('#preloader1').show();
                                setInterval(app.TransactionCheak(tx), 5000);
                            }
                        });

                    }

                    else {
                        alert('insufficient balance');
                        alert('please maintain more than 10 TRX in your wallet');
                    }
                }
                else {
                    alert('Amount should be greater than 110 TRX ');

                }
            });
        },

        TransactionCheak(transactionHash) {

            try {

               // $('#preloader1').show();
                var Username = $("#ContentPlaceHolder1_hndsponser").val();
                var AmtDollar = 100;
                metaMaskAddress = window.tronWeb.defaultAddress.base58;
               // alert(Username);
                //alert(metaMaskAddress);
                //alert(AmtDollar);
                async function checkTransactionStatus(transactionHash) {

                    let transaction = await tronWeb.trx.getTransaction(transactionHash);

                    if (transaction.ret[0].contractRet === 'SUCCESS') {
                        console.log(`Transaction ${transactionHash} succeeded!`);
                        //code 

                        $.ajax({
                            type: "POST",
                            url: "BoostingBoard.aspx/NewBooster",
                            data: "{'Username':'" + Username + "' ,'HashCode':'" + transactionHash + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (data) {
                                var data = eval(data.d);
                               // alert('successfully buy Booster Board ');
                                window.location = 'Home.aspx';
                            },
                            error: function (msg) {
                                msg = "There is an error";
                                alert(msg);

                            }
                        });
                        $('#preloader1').hide();
                        return true;
                    } else {
                        console.log(`Transaction ${transactionHash} failed.`);
                        alert(`Transaction ${transactionHash} failed.`);
                        $('#preloader1').hide();
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


















