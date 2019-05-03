$(function () {

    function popup() {
        var userEmail = prompt("Enter Email", "");
        if (userEmail) {
            $("#useName").text(userEmail);
            $('#user').val(userEmail);
        }
        //    //swal({
        //    //    title: "DC vs MARVEL",
        //    //    text: "<span style='color:#f8bb86;font-weight:700;'>Please enter your Email</span>",
        //    //    type: "input",
        //    //    html: true,
        //    //    showCancelButton: true,
        //    //    closeOnConfirm: true,
        //    //    animation: "slide-from-top",
        //    //    inputPlaceholder: "Your Name"
        //    //},
        //    //    function (inputValue) {
        //    //        userName = inputValue;
        //    //        if (!inputValue) {
        //    //            $("#useName").val("");
        //    //            $('#user').val("");
        //    //            swal.showInputError("You need to type your name!");
        //    //            return false;
        //    //        }
        //    //        else {
        //    //            $("#useName").val(inputValue);
        //    //            $('#user').val(inputValue);
        //    //            return true;
        //    //        }
        //    //    });

    }


    popup();
    
    var poll = $.connection.pollHub;
    poll.client.broadcastMessage = function (dcVoting, marvelVoting, dcVotePercent, marvelVotePercent) {
        $('#dcVoting').text("Votes: " + dcVoting);
        $('#dcVoting').css("width", dcVotePercent + "%");
        $('#marvelVoting').text("Votes: " + marvelVoting);
        $('#marvelVoting').css("width", marvelVotePercent + "%");
    };

    $.connection.hub.start().done(function () {
        poll.server.broadcast();

        $('#marvel').on('click', function () {
            if ($('#user').val()) {
                casteVote("Marvel", $('#user').val());
            }
            else {
                popup();
            }
        });

        $('#dcVote').on('click', function () {
            if ($('#user').val()) {
                casteVote("DC", $('#user').val());
            }
            else {
                popup();
            }
        });

        function casteVote(votedTo, userName) {
            $.ajax({
                'url': "Onlinepoll/Home/CasteVote",
                'type': 'POST',
                'content-Type': 'x-www-form-urlencoded',
                'data': { voteTo: votedTo, userName: userName },
                'dataType': 'json',
                'success': function (result) {
                    if (result) {
                        poll.server.broadcast();
                        $('#dcVote').attr("disabled", true);
                        $('#marvel').attr("disabled", true);
                    }

                },
                'error': function (XMLHttpRequest, textStatus, errorThrown) {
                    //Process error actions
                    alert('Error: ' + errorThrown);
                }
            });
        }
    });

   


});