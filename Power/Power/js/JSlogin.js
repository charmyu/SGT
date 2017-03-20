function JSLogin() {
    

        this.ReLogon = function () {
            $.ajax({
                type: "GET",
                url: "/api/Sys_User/GetLoginInfo",
                dataType: "json",
                success: function (result) {
                    if (result != "") {
                        var user = eval("(" + result + ")");
                        return user.UserName;
                    }
                    else {
                        location.href = "../login.html";
                    }
                },
                error: function (error) {
                    location.href = "../login.html";
                }
            });
        };
   
        //function ReLogon(win) {
        //    try {
        //        if (win.top.opener == null) {
        //            win.top.location.href = '../login.html';
        //        }
        //        else {
        //            ReLogon(win.top.opener);
        //            win.top.close();
        //        }
        //    }
        //    catch (e) {
        //        win.top.location.href = '../login.html';
        //    }
        //    finally { }
        //}

       
}