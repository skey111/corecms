$(function () {
    var tab = 'account_number';
    // 选项卡切换
    $(".account_number").click(function () {
        $('.tel-warn').addClass('hide');
        tab = $(this).attr('class').split(' ')[0];
        checkBtn();
        $(this).addClass("on");
        $(".message").removeClass("on");
        $(".form2").addClass("hide");
        $(".form1").removeClass("hide");
    });
    // 选项卡切换
    $(".message").click(function () {
        $('.tel-warn').addClass('hide');
        tab = $(this).attr('class').split(' ')[0];
        checkBtn();
        $(this).addClass("on");
        $(".account_number").removeClass("on");
        $(".form2").removeClass("hide");
        $(".form1").addClass("hide");

    });

    $('#num').keyup(function (event) {
        $('.tel-warn').addClass('hide');
        checkBtn();
    });

    $('#pass').keyup(function (event) {
        $('.tel-warn').addClass('hide');
        checkBtn();
    });

    $('#veri').keyup(function (event) {
        $('.tel-warn').addClass('hide');
        checkBtn();
    });

    $('#num2').keyup(function (event) {
        $('.tel-warn').addClass('hide');
        checkBtn();
    });

    $('#veri-code').keyup(function (event) {
        $('.tel-warn').addClass('hide');
        checkBtn();
    });


    function checkAccount(username) {
        if (username == '') {
            $('.num-err').removeClass('hide').find("em").text('请输入账户');
            return false;
        } else {
            $('.num-err').addClass('hide');
            return true;
        }
    }

    function checkPass(pass) {
        if (pass == '') {
            $('.pass-err').removeClass('hide').text('请输入密码');
            return false;
        } else {
            $('.pass-err').addClass('hide');
            return true;
        }
    }

    function checkCode(code) {
        if (code == '') {
            // $('.tel-warn').removeClass('hide').text('请输入验证码');
            return false;
        } else {
            // $('.tel-warn').addClass('hide');
            return true;
        }
    }

    function checkPhone(phone) {
        var status = true;
        if (phone == '') {
            $('.num2-err').removeClass('hide').find("em").text('请输入手机号');
            return false;
        }
        var param = /^1[34578]\d{9}$/;
        if (!param.test(phone)) {
            // globalTip({'msg':'手机号不合法，请重新输入','setTime':3});
            $('.num2-err').removeClass('hide');
            $('.num2-err').text('手机号不合法，请重新输入');
            return false;
        }
        $.ajax({
            url: '/checkPhone',
            type: 'post',
            dataType: 'json',
            async: false,
            data: { phone: phone, type: "login" },
            success: function (data) {
                if (data.code == '0') {
                    $('.num2-err').addClass('hide');
                    // console.log('aa');
                    // return true;
                } else {
                    $('.num2-err').removeClass('hide').text(data.msg);
                    // console.log('bb');
                    status = false;
                    // return false;
                }
            },
            error: function () {
                status = false;
                // return false;
            }
        });
        return status;
    }

    function checkPhoneCode(pCode) {
        if (pCode == '') {
            $('.error').removeClass('hide').text('请输入验证码');
            return false;
        } else {
            $('.error').addClass('hide');
            return true;
        }
    }

    // 登录的回车事件
    $(window).keydown(function (event) {
        if (event.keyCode == 13) {
            $('.log-btn').trigger('click');
        }
    });

});