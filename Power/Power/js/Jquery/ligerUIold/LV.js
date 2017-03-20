(function ($)
{

    //全局系统对象
    window['LV'] = {};

    
   

    LV.cookies = (function ()
    {
        var fn = function ()
        {
        };
        fn.prototype.get = function (name)
        {
            var cookieValue = "";
            var search = name + "=";
            if (document.cookie.length > 0)
            {
                offset = document.cookie.indexOf(search);
                if (offset != -1)
                {
                    offset += search.length;
                    end = document.cookie.indexOf(";", offset);
                    if (end == -1) end = document.cookie.length;
                    cookieValue = decodeURIComponent(document.cookie.substring(offset, end))
                }
            }
            return cookieValue;
        };
        fn.prototype.set = function (cookieName, cookieValue, DayValue)
        {
            var expire = "";
            var day_value = 1;
            if (DayValue != null)
            {
                day_value = DayValue;
            }
            expire = new Date((new Date()).getTime() + day_value * 86400000);
            expire = "; expires=" + expire.toGMTString();
            document.cookie = cookieName + "=" + encodeURIComponent(cookieValue) + ";path=/" + expire;
        }
        fn.prototype.remvoe = function (cookieName)
        {
            var expire = "";
            expire = new Date((new Date()).getTime() - 1);
            expire = "; expires=" + expire.toGMTString();
            document.cookie = cookieName + "=" + escape("") + ";path=/" + expire;
            /*path=/*/
        };

        return new fn();
    })();

    
    LV.tip = function (message, millisecond) {
        //右下角的提示框
        //message:消息内容
        //millisecond:消息显示时长,单位:毫秒
        if (LV.wintip) {
            LV.wintip.set('content', message);
            LV.wintip.show();
        }
        else {
            LV.wintip = $.ligerDialog.tip({ content: message });
        }

        if (millisecond) {
            setTimeout(function () {
                LV.wintip.hide()
            }, millisecond);
        } else {
            setTimeout(function () {
                LV.wintip.hide()
            }, 12000);
        }
    };

    //预加载图片
    LV.prevLoadImage = function (rootpath, paths)
    {
        for (var i in paths)
        {
            $('<img />').attr('src', rootpath + paths[i]);
        }
    };
    //显示loading
    LV.showLoading = function (message)
    {
        message = message || "正在加载中...";
        $('body').append("<div class='jloading'>" + message + "</div>");
        $.ligerui.win.mask();
    };
    //隐藏loading
    LV.hideLoading = function (message)
    {
        $('body > div.jloading').remove();
        $.ligerui.win.unmask({ id: new Date().getTime() });
    }
    //显示成功提示窗口
    LV.showSuccess = function (message, callback)
    {
        
        if (typeof (message) == "function" || arguments.length == 0)
        {
            callback = message;
            message = "操作成功!";
        }
        $.ligerDialog.success(message, '提示信息', callback);
    };
    //显示失败提示窗口
    LV.showError = function (message, callback)
    {
     
        if (typeof (message) == "function" || arguments.length == 0)
        {
            callback = message;
            message = "操作失败!";
        }
        $.ligerDialog.error(message, '提示信息', callback);
    };


    //预加载dialog的图片
    LV.prevDialogImage = function (rootPath)
    {
        rootPath = rootPath || "";
        //LV.prevLoadImage(rootPath + 'lib/ligerUI/skins/Aqua/images/win/', ['dialog-icons.gif']);
        //LV.prevLoadImage(rootPath + 'lib/ligerUI/skins/Gray/images/win/', ['dialogicon.gif']);
        LV.prevLoadImage(rootPath + 'js/Jquery/ligerUI/skins/Aqua/images/win/', ['dialog-icons.gif']);
        LV.prevLoadImage(rootPath + 'js/Jquery/ligerUI/skins/Gray/images/win/', ['dialogicon.gif']);
    };

    //提交服务器请求
    //返回json格式
    //1,提交给类 options.type  方法 options.method 处理
    //2,并返回 AjaxResult(这也是一个类)类型的的序列化好的字符串
    LV.ajax = function (options) {
       
        var p = options || {};
        if (!p.url) {
            LV.showError("ajax 请求地址不能为空.");
        }
        $.ajax({
            cache: p.cache || false,
            async: ((typeof (p.async) == 'boolean') && p.async==false)?false:true,
            url: p.url,
            data: p.data,
            dataType: p.dataType || 'json',
            
            type: p.ajaxtype || "post",
            beforeSend: function () {
                LV.loading = true;
                if (p.beforeSend)
                    p.beforeSend();
                else if (!p.showLoading && p.showLoading!=false)
                    LV.showLoading(p.loading);
            },
            complete: function () {
                LV.loading = false;
                if (p.complete)
                    p.complete();
                else if (!p.showLoading && p.showLoading != false)
                    LV.hideLoading();
            },
            success: function (result) {
                //if (!result) return;
                if (p.success) {
                    p.success(result);
                }
            },
            error: function (result, b, c) {
                if (p.error)
                    p.error(result, b, c);
                else
                    LV.tip('请求发生错误 <BR>错误码：' + result.status +
                        '<BR>错误信息：' + result.statusText + ',' + result.responseText);
            }
        });
    };

    //获取当前页面的MenuNo
    //优先级1：如果页面存在MenuNo的表单元素，那么加载它的值
    //优先级2：加载QueryString，名字为MenuNo的值
    LV.getPageMenuNo = function ()
    {
        var menuno = $("#MenuNo").val();
        if (!menuno)
        {
            menuno = getQueryStringByName("MenuNo");
        }
        return menuno;
    };

    //创建按钮
    LV.createButton = function (options)
    {
        var p = $.extend({
            appendTo: $('body')
        }, options || {});
        var btn = $('<div class="button button2 buttonnoicon" style="width:60px"><div class="button-l"> </div><div class="button-r"> </div> <span></span></div>');
        if (p.icon)
        {
            btn.removeClass("buttonnoicon");
            btn.append('<div class="button-icon"> <img src="../' + p.icon + '" /> </div> ');
        }
        //绿色皮肤
        if (p.green)
        {
            btn.removeClass("button2");
        }
        if (p.width)
        {
            btn.width(p.width);
        }
        if (p.click)
        {
            btn.click(p.click);
        }
        if (p.text)
        {
            $("span", btn).html(p.text);
        }
        if (typeof (p.appendTo) == "string") p.appendTo = $(p.appendTo);
        btn.appendTo(p.appendTo);
    };

    //创建过滤规则(查询表单)
    LV.bulidFilterGroup = function (form)
    {
       
        if (!form) return null;
        var group = { op: "and", rules: [] };
        $(":input", form).not(":submit, :reset, :image,:button, [disabled]")
        .each(function ()
        {
          
            if (!this.name) return;
            if (!$(this).hasClass("field")) return;
            if ($(this).val() == null || $(this).val() == "") return;
            var ltype = $(this).attr("ltype");
            var optionsJSON = $(this).attr("ligerui"), options;
            if (optionsJSON)
            {
                options = JSON2.parse(optionsJSON);
            }
            var op = $(this).attr("op") || "like";
            //get the value type(number or date)
            var type = $(this).attr("vt") || "string";
            var value = $(this).val();
            var name = this.name;
            //如果是下拉框，那么读取下拉框关联的隐藏控件的值(ID值,常用与外表关联)
            if (ltype == "select" && options && options.valueFieldID)
            {
                /*update by daihaitao 2014-1-13 start*/
                $("input[name='" + options.valueFieldID + "']").each(function () {
                    if ($(this).attr("value") != "undefined") {
                        value = $(this).val();
                    }
                });

                //value = document.getElementsByName(options.valueFieldID)[document.getElementsByName(options.valueFieldID).length - 1].value;
                //value = $("#" + options.valueFieldID).val();
                /*update by daihaitao 2014-1-13 end*/
               
                name = options.valueFieldID;
                /*当传过来的是空字符串时，不进行过滤 update by zhouyan 2013-7-11 start*/
                if (value === "") {
                    return;
                }
                /*当传过来的是空字符串时，不进行过滤 update by zhouyan 2013-7-11 end*/
            }
            group.rules.push({
                op: op,
                field: name,
                value: value,
                type: type
            });
        });
        return group;
    };

    //附加表单搜索按钮：搜索、高级搜索
    LV.appendSearchButtons = function (form, grid)
    {
        if (!form) return;
        form = $(form);
        //搜索按钮 附加到第一个li  高级搜索按钮附加到 第二个li
        var container = $('<ul><li style="margin-right:8px"></li><li></li></ul><div class="l-clear"></div>').appendTo(form);
        LV.addSearchButtons(form, grid, container.find("li:eq(0)"), container.find("li:eq(1)"));

    };

    //附加表单搜索按钮：搜索、重置
    LV.appendResetButtons = function (form, grid) {
        if (!form) return;
        form = $(form);
        //搜索按钮 附加到第一个li  重置按钮附加到 第二个li
        var container = $('<ul><li style="margin-right:8px"></li><li></li></ul><div class="l-clear"></div>').appendTo(form);
        LV.addResetButtons(form, grid, container.find("li:eq(0)"), container.find("li:eq(1)"));

    };

    //创建表单搜索按钮：搜索、高级搜索
    LV.addSearchButtons = function (form, grid, btn1Container, btn2Container)
    {
        if (!form) return;
        if (btn1Container)
        {
            LV.createButton({
                appendTo: btn1Container,
                width: 80,
                text: '搜索',
                click: function ()
                {
                    var rule = LV.bulidFilterGroup(form);
                    if (rule.rules.length)
                    {
                        grid.set('parms', { where: JSON2.stringify(rule) });
                    } else
                    {
                        grid.set('parms', {});
                    }
                    grid.loadData();
                }
            });
        }
        if (btn2Container)
        {
            LV.createButton({
                appendTo: btn2Container,
                width: 80,
                text: '高级搜索',
                click: function ()
                {
                    grid.showFilter();
                }
            });
        }
    };

    //创建表单搜索按钮：搜索、重置
    LV.addResetButtons = function (form, grid, btn1Container, btn2Container) {
        if (!form) return;
        if (btn1Container) {
            LV.createButton({
                appendTo: btn1Container,
                width: 80,
                text: '搜索',
                click: function () {
                    //if ($.metadata.defaults.name == "validate") {
                    //    if (!Validator.form()) return false;
                    //}
                    var rule = LV.bulidFilterGroup(form);
                    if (rule.rules.length) {
                        grid.set('parms', { where: JSON2.stringify(rule) });
                    } else {
                        grid.set('parms', {});
                    }
                    grid.loadData();
                }
            });
        }
        if (btn2Container) {
            LV.createButton({
                appendTo: btn2Container,
                width: 80,
                text: '重置',
                click: function () {
                    $(form).resetForm();
                    //$("input[class='field l-text-field error']").ligerHideTip();
                    //$("input[class='field l-text-field error']").removeAttr("ligertipid");
                    //$("input[class='field l-text-field error']").removeClass('field l-text-field error').addClass('field l-text-field');
                    var rule = LV.bulidFilterGroup(form);
                    if (rule.rules.length) {
                        grid.set('parms', { where: JSON2.stringify(rule) });
                    } else {
                        grid.set('parms', {});
                    }
                    grid.loadData();
                }
            });
        }
    };

    //快速设置表单底部默认的按钮:保存、取消
    LV.setFormDefaultBtn = function (cancleCallback, savedCallback)
    {
        //表单底部按钮
        var buttons = [];
        if (cancleCallback)
        {
            buttons.push({ text: "取消", onclick: cancleCallback });
        }
        if (savedCallback)
        {
            buttons.push({ text: "保存", onclick: savedCallback });
        }
        LV.addFormButtons(buttons);
    };

    //add by zhouyan 2013-7-19 start
    //定制按钮文字，默认是取消和保存
    LV.setFormSpeBtn = function (cancelText, okText, cancleCallback, savedCallback) {
        var buttons = [];
        if (cancleCallback) {
            buttons.push({ text: cancelText, onclick: cancleCallback });
        }
        if (savedCallback) {
            buttons.push({ text: okText, onclick: savedCallback });
        }
        LV.addFormButtons(buttons);
    }

    LV.setImpleBtn = function (impleSucCallback, impleFailCallback, cancleCallback) {
        var buttons = [];
        if (cancleCallback) {
            buttons.push({ text: "取消", onclick: cancleCallback });
        }
        if (impleFailCallback) {
            buttons.push({ text: "实施失败", onclick: impleFailCallback });
        }
        if (impleSucCallback) {
            buttons.push({ text: "实施完成", onclick: impleSucCallback });
        }              
        LV.addFormButtons(buttons);
    }
    //add by zhouyan 2013-7-19 end

    //add by daiht 2014-1-22 start
    //添加按钮
    //buttons:按钮数组（[{ { text: "按钮显示的文字", click: "按钮绑定的单击方法名称", type: "按钮类型，默认为button", action: "哪些操作显示此按钮，用;区隔，为空则所有操作都显示" }]，）
    //action：操作类型，用于表示当前页面是用于何作用。例如：增加，修改，查看等。
    LV.f_setFormBtn = function (buttons, action) {
        //获取按钮放置的div块
        var toolbar = $(".form-toolbar");
        //如果没有此div 则新建一个
        if (toolbar.length == 0) toolbar = $('<div class="form-toolbar"><div>').appendTo('.form-box');
        //遍历buttons，
        for (var i = 0; i < buttons.length; i++) {
           
            if ((buttons[i].action + "") == "undefined" || buttons[i].action.trim() == "") {
                LV.f_appendButton(buttons[i], toolbar);
            } else {
                var actions = buttons[i].action.split(";");
                for (var j = 0; j < actions.length; j++) {
                    if (actions[j] == action) {
                        LV.f_appendButton(buttons[i], toolbar);
                    }
                }
            }
             
        };
    }

    //
    LV.f_appendButton = function (button, toolbar) {
        if (!button.text) button.text = 'BUTTON';
        if (!button.click) return;
        if (!button.type) button.type = "button";
        var btn = $('<input type="' + button.type + '" value="&nbsp;&nbsp;&nbsp;' + button.text + '&nbsp;&nbsp;&nbsp;" onclick="' + button.click + '()" name="B1" class="form-toolbar-btn" />');
        btn.appendTo(toolbar);
    }
    //修改页面title
    //action：操作类型（必输）
    //obj:自定义操作类型和标题（可选）
    LV.setFormTile = function (action, obj) {
        var title;
        if (obj) {
            title = obj.text;
        } else {
            if (action=="add") {
                title = "新增";
                document.title = title + document.title;
            } else if (action == "update") {
                title = "编辑";
                document.title = title + document.title;
            } else if (action == "view") {
                action = "信息";
                document.title = document.title + title;
            }
        }
    }

    //add by daiht 2014-1-22 end


    //增加表单底部按钮,比如：保存、取消
    LV.addFormButtons = function (buttons)
    {
        if (!buttons) return;
        var formbar = $("body > div.form-bar");
        if (formbar.length == 0)
            formbar = $('<div class="form-bar"><div class="form-bar-inner"></div></div>').appendTo('body');
        if (!(buttons instanceof Array))
        {
            buttons = [buttons];
        }
        $(buttons).each(function (i, o)
        {
            var btn = $('<div class="l-dialog-btn"><div class="l-dialog-btn-l"></div><div class="l-dialog-btn-r"></div><div class="l-dialog-btn-inner"></div></div> ');
            $("div.l-dialog-btn-inner:first", btn).html(o.text || "BUTTON");
            if (o.onclick)
            {
                btn.bind('click', function ()
                {
                    o.onclick(o);
                });
            }
            if (o.width)
            {
                btn.width(o.width);
            }
            $("> div:first", formbar).append(btn);
        });
    };

    //填充表单数据
    LV.loadForm = function (mainform, options, callback)
    {
        options = options || {};
        if (!mainform)
            mainform = $("form:first");
        var p = $.extend({
            async: options.async,
            beforeSend: function ()
            {
                LV.showLoading('正在加载表单数据中...');
            },
            complete: function ()
            {
                LV.hideLoading();
            },
            success: function (data)
            {
                var preID = options.preID || "";
                //根据返回的属性名，找到相应ID的表单元素，并赋值
                for (var p in data)
                {
                    var ele = $("[name=" + (preID + p) + "]", mainform);
                    //针对复选框和单选框 处理
                    if (ele.is(":checkbox,:radio")) {
                        //update by daiht 2014-1-22 start
                        //ele[0].checked = data[p] ? true : false;
                        ele[0].checked = (data[p]+"" == ele[0].value) ? true : false;
                        //update by daiht 2014-1-22 end
                    }
                    else {
                        ele.val(data[p]);
                    }
                }
                //下面是更新表单的样式
                var managers = $.ligerui.find($.ligerui.controls.Input);
                for (var i = 0, l = managers.length; i < l; i++)
                {
                    //改变了表单的值，需要调用这个方法来更新ligerui样式
                    var o = managers[i];
                    o.updateStyle();
                    if (managers[i] instanceof $.ligerui.controls.TextBox)
                        o.checkValue();
                }
                if (callback)
                    callback(data);
                
            },
            error: function (result)
            {
                LV.showError('数据加载失败 <BR>错误码：' + result.status +
                    '<BR>错误信息：' + result.statusText + ',' + result.responseText);
            }
        }, options);
        LV.ajax(p);
    };

    //带验证、带loading的提交
    LV.submitForm = function (mainform, success, error)
    {
       
        if (!mainform)
            mainform = $("form:first");
        
        if (mainform.valid())
        {
            mainform.ajaxSubmit({
                dataType: 'json',
                type: 'post',
                success: success,
                beforeSubmit: function (formData, jqForm, options)
                {
                    //update by zhouyan 2013-7-24 start
                    //针对复选框和单选框 处理
                    $(":checkbox,:radio", jqForm).each(function ()
                    {
                        if (!existInFormData(formData, this.name))
                        {
                            formData.push({ name: this.name, type: this.type, value: "" });
                        }
                    });
                    for (var i = 0, l = formData.length; i < l; i++)
                    {
                        var o = formData[i];
                        if (o.type == "radio")
                        {
                            //o.value = $("[name=" + o.name + "]", jqForm)[0].checked ? "true" : "false";
                            $("[name=" + o.name + "]", jqForm).each(function () {
                                if ($(this).is(":checked")) {
                                    o.value = $(this).val();
                                }
                            });
                        }
                        if (o.type == "checkbox") {
                            var checkValue = "";
                            $("[name=" + o.name + "]", jqForm).each(function () {
                                if ($(this).is(":checked")) {
                                    checkValue += $(this).val() + ";";
                                }
                            })
                            o.value = checkValue.substring(0, checkValue.length - 1);
                        }
                    }
                    //update by zhouyan 2013-7-24 end
                },
                beforeSend: function (a, b, c)
                {
                    LV.showLoading('正在保存数据中...');

                },
                complete: function (hm,ff,gg)
                {
                    LV.hideLoading();
                },
                error: function (result)
                {
                    //modify by chenlong
                    LV.showError('请求发生错误：' + result.responseText);
                    //LV.showError('请求发生错误 <BR>错误码：' + result.status +
                    //    '<BR>错误信息：' + result.statusText + ',' + result.responseText);
                }
            });
        }
        else
        {
            //alert(typeof (error));
            if (error) {
                if (document.getElementById(error.fromId).currentStyle) { // for IE
                    var borderColor = document.getElementById(error.fromId).currentStyle.borderColor;// 空字符串""
                    if (typeof (error) == "object") {
                        $("#" + error.fromId).css("border-color", borderColor);
                    }
                } else if (window.getComputedStyle) { // for FF

                    var obj = document.getElementById(error.fromId);
                    var borderColor = window.getComputedStyle(obj, null).getPropertyValue('border-top-color')
                    if (typeof (error) == "object") {
                        $("#" + error.setId).css("border-color", borderColor);
                    }
                }
            } else {
                LV.showInvalid();
            }
           
        }

        function existInFormData(formData, name)
        {
            for (var i = 0, l = formData.length; i < l; i++)
            {
                var o = formData[i];
                if (o.name == name) return true;
            }
            return false;
        }
    };

    //提示 验证错误信息
    LV.showInvalid = function (validator)
    {
        validator = validator || LV.validator;
        if (!validator) return;
        var message = '<div class="invalid">存在' + validator.errorList.length + '个字段验证不通过，请检查!</div>';
        //top.LV.tip(message);
        $.ligerDialog.error(message);
    };

    //表单验证
    LV.validate = function (form, options) {
       
        //设置表单验证的metadata
        $.metadata.setType("attr", "validate");
        if (typeof (form) == "string")
            form = $(form);
        else if (typeof (form) == "object" && form.NodeType == 1)
            form = $(form);
        var msgType = form.attr("msgtype");
        options = $.extend({
            errorPlacement: function (lable, element) {

                //定义错误message显示样式，默认在图标上显示.
                //msgtext:显示在元素的后面，tip:显示在元素的上边
                var errMsg = lable.html();
                var ele = element.next();
                //add by daiht 2014-1-27 start
                //当有元素在页面没有显示，确需要验证时，通过弹出框的形式提示用户
                if (element.attr("hidden") == "hidden" || element.attr("type") == "hidden" || element.css("display") == "none") {
                    if (element.attr("displayName") && errMsg) {
                        LV.showError(element.attr("displayName") + errMsg.substring(1));
                        return;
                    }
                }
                //add by daiht 2014-1-27 end
                ele.find(".validatemsg").css("background-position", "-60px 0");
                switch (msgType) {
                    case "msgtext":
                        ele.find("#" + element.attr("name") + "_msg").html(errMsg);
                        break;
                    case "tip":
                        if (!element.attr("id"))
                            element.attr("id", new Date().getTime());
                        if (element.hasClass("l-textarea")) {
                            element.addClass("l-textarea-invalid");
                        }
                        else if (element.hasClass("l-text-field")) {
                            element.parent().addClass("l-text-invalid");
                        }
                        $(element).removeAttr("title").ligerHideTip();
                        
                        //add by daiht 2014-1-27 start 
                        var distanceXAndIsRight = f_returnXAndIsRight(element);
                        //add by daiht 2014-1-27 end 

                        $(element).attr("title", lable.html()).ligerTip({
                            distanceX: distanceXAndIsRight[0],
                            distanceY: 0,
                            auto: true,
                            isRight: distanceXAndIsRight[1]
                        });
                        break;
                    default:
                        var tipEle = ele.find(".validatemsg");
                        tipEle.removeAttr("title").ligerHideTip();
                        tipEle.attr("title", errMsg).ligerTip({
                            distanceX: 5,
                            distanceY: -3,
                            auto: true
                        });
                        break;
                }
            },
            success: function (lable) {
                var element = $("[name='" + lable.attr("for") + "']") || $("[name='" + lable.attr("for") + "']");
                if (!lable.attr("for")) return;
                if (msgType != "tip") {
                    var ele = element.next();
                    ele.find(".validatemsg").css("background-position", "-30px 0");
                }
                if (element.hasClass("l-textarea")) {
                    element.removeClass("l-textarea-invalid");
                }
                else if (element.hasClass("l-text-field")) {
                    element.parent().removeClass("l-text-invalid");
                }
            }
        }, options || {});

        LV.validator = form.validate(options);

        //生成表单元素后的说明文字(根据元素中的validate属性查找)
        //msgTxt:控件后的说明文字
        //msgHtml:要拼接到控件后的元素
        //rules:验证规则
        $("[validate]", form).each(function () {
            
            var msgTxt = "", msgHtml = "", formEle = $(this),
                validate = formEle.attr("validate"),
                msg = $.validator.messages,
                rules = formEle.rules();
            if (!rules || !msg) { return; }
            //根据元素的验证规则生成说明文字
            for (var p in rules) {
                var rule = { method: p, parameters: rules[p] };
                if (formEle.metadata().messages) {
                    var customMsg = formEle.metadata().messages[rule.method];
                }
                
                var message = customMsg ? customMsg : $.validator.messages[rule.method], theregex = /\$?\{(\d+)\}/g;
                if (typeof message == "function") {
                    message = message.call($.validator, rule.parameters, formEle[0]);
                } else {
                    message = $.format(message.replace(theregex, '{$1}'), rule.parameters);
                }
                msgTxt = msgTxt + message + ",";
            }
            msgTxt = msgTxt.substring(0, msgTxt.length - 1);

            //在表单上定义说明文字的表示方式,默认在元素后的图标上提示
            //tip:在表单元素上提示,msgtip:直接显示在元素的后面
            //add bu daiht 2014-1-27 start 
            var distanceXAndIsRight = f_returnXAndIsRight($(this));
            //add bu daiht 2014-1-27 end 
            switch (msgType) {
                case "tip":
                    formEle.attr("title", msgTxt).ligerTip({
                        distanceX: distanceXAndIsRight[0],
                        distanceY: -3,
                        auto: true,
                        isRight: distanceXAndIsRight[1]
                    });
                    // msgHtml = "<span style='position:absolute; margin-top:17px;'><span class='validatemsg'></span></span>";
                    // $(this).after(msgHtml);
                    break;
                case "msgtext":
                    msgHtml = "<span style='position:absolute; margin-top:17px;'><span class='validatemsg'></span><span id='"
                        + formEle.attr("name") + "_msg'>" + msgTxt + "</span></span>";
                    formEle.after(msgHtml);
                    break;
                default:
                    msgHtml = "<span style='position:absolute; margin-top:17px;'><span class='validatemsg'></span></span>";
                    formEle.after(msgHtml);
                    formEle.next().find(".validatemsg").attr("title", msgTxt).ligerTip({
                        distanceX: 5,
                        distanceY: -3,
                        auto: true
                    });
            }
        });

        //add by daiht 2014-1-27 start
        //返回distanceX和isRight的值
        function f_returnXAndIsRight(element) {
            if (element.offset().left + element.width() + 170 > $(window).width()) {
                return [-(element.width() + 170), true];
            } else {
                return [0,false];
            }
        }
        //add by daiht 2014-1-27 start
        return LV.validator;
    };


    LV.validateShowMessage="";

    LV.loadToolbar = function (grid, toolbarBtnItemClick)
    {
        var MenuNo = LV.getPageMenuNo();
        LV.ajax({
            loading: '正在加载工具条中...',
            type: 'AjaxSystem',
            method: 'GetMyButtons',
            data: { HttpContext: true, MenuNo: MenuNo },
            success: function (data)
            {
                if (!grid.toolbarManager) return;
                if (!data || !data.length) return;
                var items = [];
                for (var i = 0, l = data.length; i < l; i++)
                {
                    var o = data[i];
                    items[items.length] = {
                        click: toolbarBtnItemClick,
                        text: o.BtnName,
                        img: rootPath + o.BtnIcon,
                        id: o.BtnNo
                    };
                    items[items.length] = { line: true };
                }
                grid.toolbarManager.set('items', items);
            }
        });
    };

    //关闭Tab项,如果tabid不指定，那么关闭当前显示的
    LV.closeCurrentTab = function (tabid)
    {
        if (!tabid)
        {
            tabid = $("#framecenter > .l-tab-content > .l-tab-content-item:visible").attr("tabid");
        }
        if (tab)
        {
            tab.removeTabItem(tabid);
        }
    };

    //关闭Tab项并且刷新父窗口
    LV.closeAndReloadParent = function (tabid, parentMenuNo)
    {
        LV.closeCurrentTab(tabid);
        var menuitem = $("#mainmenu ul.menulist li[menuno=" + parentMenuNo + "]");
        var parentTabid = menuitem.attr("tabid");
        var iframe = window.frames[parentTabid];
        if (tab)
        {
            tab.selectTabItem(parentTabid);
        }
        if (iframe && iframe.f_reload)
        {
            iframe.f_reload();
        }
        else if (tab)
        {
            tab.reload(parentTabid);
        }
    };

    //覆盖页面grid的loading效果
    LV.overrideGridLoading = function ()
    {
        $.extend($.ligerDefaults.Grid, {
            onloading: function ()
            {
                LV.showLoading('正在加载表格数据中...');
            },
            onloaded: function ()
            {
                LV.hideLoading();
            }
        });
    };

    //根据字段权限调整 页面配置
    LV.adujestConfig = function (config, forbidFields)
    {
        if (config.Form && config.Form.fields)
        {
            for (var i = config.Form.fields.length - 1; i >= 0; i--)
            {
                var field = config.Form.fields[i];
                if ($.inArray(field.name, forbidFields) != -1)
                    config.Form.fields.splice(i, 1);
            }
        }
        if (config.Grid && config.Grid.columns)
        {
            for (var i = config.Grid.columns.length - 1; i >= 0; i--)
            {
                var column = config.Grid.columns[i];
                if ($.inArray(column.name, forbidFields) != -1)
                    config.Grid.columns.splice(i, 1);
            }
        }
        if (config.Search && config.Search.fields)
        {
            for (var i = config.Search.fields.length - 1; i >= 0; i--)
            {
                var field = config.Search.fields[i];
                if ($.inArray(field.name, forbidFields) != -1)
                    config.Search.fields.splice(i, 1);
            }
        }
    };

    //查找是否存在某一个按钮
    LV.findToolbarItem = function (grid, itemID)
    {
        if (!grid.toolbarManager) return null;
        if (!grid.toolbarManager.options.items) return null;
        var items = grid.toolbarManager.options.items;
        for (var i = 0, l = items.length; i < l; i++)
        {
            if (items[i].id == itemID) return items[i];
        }
        return null;
    }

    //当前行数据
    LV.gridCurrentRowData = null;

    //设置grid的双击事件(带权限控制)
    LV.setGridDoubleClick = function (grid, btnID, btnItemClick)
    {
        btnItemClick = btnItemClick || toolbarBtnItemClick;
        if (!btnItemClick) return;
        grid.bind('dblClickRow', function (rowdata)
        {
            //add by daihaitao 2014-01-13
            //当前行数据赋值
            LV.gridCurrentRowData = rowdata;

            var item = LV.findToolbarItem(grid, btnID);
            if (!item) return;
            //update by zhouyan 2013-09-18 start
            if (!grid.isSelected(rowdata)) {
                grid.select(rowdata);
            }
            //update by zhouyan 2013-09-18 end
            btnItemClick(item);
        });
    }

    //设置grid的header格式
    LV.headerRender = function (column) {
        if (!column) { return; }
        return "<div style='text-align:" + column.align + ";width:" + (column.width -3)
            + "px;margin-left:3px'>" + column.headerName + "</div>";
    }

})(jQuery);
