(function (window) {
    //window.common.load()
    //    .script("../../js/lib/Jquery/jquery-1.7.2.min.js").wait()
    //    .script("../../js/lib/Jquery/jquery-validation/jquery.validate.min.js").wait()
    //    .script("../../js/lib/Jquery/jquery.form.js")
    //    .script("../../js/lib/Jquery/ligerUI/ligerui.all.js").wait()
    //    .script("../../js/lib/Jquery/ligerUI/ligerui.expand.js").wait()
    //    .script("../../js/lib/Jquery/ligerUI/LV.js").wait()
    //    .script("../../js/lib/Jquery/ligerUI/validator.js").wait()
        //.wait(function () {
            FileUploadDo();
      //  });
    function FileUploadDo() {
        $(function () {
            //common.js  getQueryStringByName()
            var attachmentID = getQueryStringByName("attachmentID");
            //var href;
            //href = location.href;
            //var pos = href.indexOf('=');
            //if (pos > -1) {
            //    var attId = href.substring(href.lastIndexOf("=") + 1);
            //    $("#att-id-hide").val(attId);
            //}
            if (attachmentID) {
                $("#att-id-hide").val(attachmentID);
            }

            //选择文件路径填入输入框
            $("#file-up-input").on("change", function () {
                $("#file-up-txt").val($(this).val());
            });

            //上传按钮
            var g_dsForm = $(".picForm");

            $("#file-up-btn").on("click", function () {
                var file_txt = $("#file-up-txt").val();
                if ($.trim(file_txt) === "") {
                    showError("请选择上传的文件.");
                } else {
                    hideError();
                    LV.submitForm(g_dsForm, function (data) {
                        if (data) {
                            //调用父页面函数
                            window.returnValue = data;
                            if (typeof window.opener.IFileUploadCallBack == 'function') {
                                window.opener.IFileUploadCallBack(data);
                            }
                            window.close();
                        } else {
                            //操作失败
                            showError("操作失败.");
                        }
                    });
                }
            });

            showError = function (msg) {
                $("#file-up-err").html(msg).show();
            }

            hideError = function () {
                $("#file-up-err").html("").hide();
            }

        })

    }


})(window)
