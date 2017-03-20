Date.prototype.pattern = function (fmt) {
    var o = {
        "M+": this.getMonth() + 1, //月份         
        "d+": this.getDate(), //日         
        "h+": this.getHours() % 12 == 0 ? 12 : this.getHours() % 12, //小时         
        "H+": this.getHours(), //小时         
        "m+": this.getMinutes(), //分         
        "s+": this.getSeconds(), //秒         
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度         
        "S": this.getMilliseconds() //毫秒         
    };
    var week = {
        "0": "周日",
        "1": "周一",
        "2": "周二",
        "3": "周三",
        "4": "周四",
        "5": "周五",
        "6": "周六"
    };
    if (/(y+)/.test(fmt)) {
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }
    if (/(E+)/.test(fmt)) {
        fmt = fmt.replace(RegExp.$1, ((RegExp.$1.length > 1) ? (RegExp.$1.length > 2 ? "/u661f/u671f" : "") : "") + week[this.getDay() + ""]);
    }
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(fmt)) {
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
        }
    }
    return fmt;
}

String.prototype.endWith = function (str) {
    if (str == null || str == "" || this.length == 0 || str.length > this.length)
        return false;
    if (this.substring(this.length - str.length) == str)
        return true;
    else
        return false;
    return true;
}

var Wi = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2, 1];    // 加权因子   
var ValideCode = [1, 0, 10, 9, 8, 7, 6, 5, 4, 3, 2];            // 身份证验证位值.10代表X   
function IdCardValidate(idCard) {

    idCard = trim(idCard.replace(/\s+/g, ""));               //去掉字符串头尾空格                     
    if (idCard.length == 15) {
        return isValidityBrithBy15IdCard(idCard);       //进行15位身份证的验证    
    } else if (idCard.length == 18) {
        var a_idCard = idCard.split("");                // 得到身份证数组   
        if (isValidityBrithBy18IdCard(idCard) && isTrueValidateCodeBy18IdCard(a_idCard)) {   //进行18位身份证的基本验证和第18位的验证
            return true;
        } else {
            return false;
        }
    } else {
        return false;
    }
}

/**  
 * 判断身份证号码为18位时最后的验证位是否正确  
 * @param a_idCard 身份证号码数组  
 * @return  
 */
function isTrueValidateCodeBy18IdCard(a_idCard) {
    var sum = 0;                             // 声明加权求和变量   
    if (a_idCard[17].toLowerCase() == 'x') {
        a_idCard[17] = 10;                    // 将最后位为x的验证码替换为10方便后续操作   
    }
    for (var i = 0; i < 17; i++) {
        sum += Wi[i] * a_idCard[i];            // 加权求和   
    }
    valCodePosition = sum % 11;                // 得到验证码所位置   
    if (a_idCard[17] == ValideCode[valCodePosition]) {
        return true;
    } else {
        return false;
    }
}

/**  
  * 验证18位数身份证号码中的生日是否是有效生日  
  * @param idCard 18位书身份证字符串  
  * @return  
  */
function isValidityBrithBy18IdCard(idCard18) {
    var year = idCard18.substring(6, 10);
    var month = idCard18.substring(10, 12);
    var day = idCard18.substring(12, 14);
    var temp_date = new Date(year, parseFloat(month) - 1, parseFloat(day));
    // 这里用getFullYear()获取年份，避免千年虫问题   
    if (temp_date.getFullYear() != parseFloat(year)
          || temp_date.getMonth() != parseFloat(month) - 1
          || temp_date.getDate() != parseFloat(day)) {
        return false;
    } else {
        return true;
    }
}

/**  
 * 验证15位数身份证号码中的生日是否是有效生日  
 * @param idCard15 15位书身份证字符串  
 * @return  
 */
function isValidityBrithBy15IdCard(idCard15) {
    var year = idCard15.substring(6, 8);
    var month = idCard15.substring(8, 10);
    var day = idCard15.substring(10, 12);
    var temp_date = new Date(year, parseFloat(month) - 1, parseFloat(day));
    // 对于老身份证中的你年龄则不需考虑千年虫问题而使用getYear()方法   
    if (temp_date.getYear() != parseFloat(year)
            || temp_date.getMonth() != parseFloat(month) - 1
            || temp_date.getDate() != parseFloat(day)) {
        return false;
    } else {
        return true;
    }
}

function checkPhone(str) {
    var re = /^0\d{2,3}-?\d{7,8}$/;
    if (re.test(str)) {
        return true;
    } else {
        return false;
    }
}

//验证手机号码
function checkMobile(str) {
    var re = /^1\d{10}$/
    if (re.test(str)) {
        return true;
    } else {
        return false;
    }
}

//验证邮箱
function checkEmail(str) {
    var re = /^(\w-*\.*)+@(\w-?)+(\.\w{2,})+$/
    if (re.test(str)) {
        return true;
    } else {
        return false;
    }
}

//去掉字符串头尾空格   
function trim(str) {
    return str.replace(/(^\s*)|(\s*$)/g, "");
}

var globaleRegisterObject = new function () { };
var globaleThreeRegisterObject = new function () { };
function registerElement(ElementID, SourceElement, Width) {
    eval("globaleRegisterObject." + ElementID + " = SourceElement");
    eval("globaleRegisterObject." + ElementID + " = globaleRegisterObject." + ElementID + " + ',' +  Width");
}

function registerThreeElement(ElementID, PaddingElementID, SourceElement) {
    eval("globaleThreeRegisterObject." + ElementID + " = PaddingElementID");
    eval("globaleThreeRegisterObject." + ElementID + " = globaleThreeRegisterObject." + ElementID + " + ',' +  SourceElement");
}

function adapterElement() {
    for (var elementID in globaleRegisterObject) {
        var Element = document.getElementById(elementID);
        if (Element) {
            var array = eval("globaleRegisterObject." + elementID).split(",");
            var sourceElement = document.getElementById(array[0]);
            if (sourceElement) {
                var leftWidth = sourceElement.clientWidth - eval(array[1]);
                if (leftWidth > 0)
                    Element.style["width"] = leftWidth + "px";
            }
        }
    }
}

function adapterThreeElement() {
    for (var elementID in globaleThreeRegisterObject) {
        var Element = document.getElementById(elementID);
        if (Element) {
            var array = eval("globaleThreeRegisterObject." + elementID).split(",");
            var paddingElement = document.getElementById(array[0]);
            var sourceElement = document.getElementById(array[1]);
            if (sourceElement && paddingElement) {
                var sourceWidth = GetElemWidth(sourceElement);
                var paddingWidth = GetElemWidth(paddingElement);
                var leftWidth = sourceWidth - paddingWidth;
                if (leftWidth > 0) {
                    Element.style["width"] = leftWidth + "px";
                    //SetElemWidth(Element, leftWidth + "px");
                }
            }
        }
    }
}

function GetElemWidth(elem) {
    if (elem.tagName == "SELECT") {
        return elem.offsetWidth;
    }
    else {
        return elem.clientWidth;
    }
}

function SetElemWidth(elem, width) {
    if (elem.tagName == "SELECT") {
        elem.scrollWidth = width;
    }
    else {
        elem.scrollWidth = width;
    }
}

function bindListener(eventName, functionName) {
    // DOM2
    if (typeof window.addEventListener != "undefined")
        window.addEventListener(eventName, functionName, false);

        // IE 
    else if (typeof window.attachEvent != "undefined") {
        window.attachEvent("on" + eventName, functionName);
    }

    else {
        if (eval("window.on" + eventName) != null) {
            var oldOnload = eval("window.on" + eventName);
            eval("window.on" + eventName + " = function ( e ) { oldOnload( e ); " + functionName + "();}")
        }
        else
            eval("window.on" + eventName + " = " + functionName + ";");
    }
}
bindListener("resize", adapterElement);
bindListener("resize", adapterThreeElement);
//bindListener("load", adapterElement);

function ClickElem(element) {
    if (element != null) {
        if (document.all && typeof (document.all) == "object")   //IE
        {
            element.click();
            //elemID.fireEvent("onclick");
        }
        else {
            if (element.tagName.toLowerCase() == "a") {
                eval(element.href);
            }
            else if (element.tagName.toLowerCase() == "input") {
                eval("element.click()");
            }
            else {
                var e = document.createEvent('MouseEvent');
                e.initEvent('click', true, false);
                elemID.dispatchEvent(e);
            }
        }
    }
}

function GetElemPosition(element) {
    var result = new Object();
    result.x = 0;
    result.y = 0;
    result.width = 0;
    result.height = 0;
    if (element.offsetParent) {
        result.x = element.offsetLeft;
        result.y = element.offsetTop;
        var parent = element.offsetParent;
        while (parent) {
            result.x += parent.offsetLeft;
            result.y += parent.offsetTop;
            var parentTagName = parent.tagName.toLowerCase();
            if (parentTagName != "table" &&
                parentTagName != "body" &&
                parentTagName != "html" &&
                parentTagName != "div" &&
                parent.clientTop &&
                parent.clientLeft) {
                result.x += parent.clientLeft;
                result.y += parent.clientTop;
            }
            parent = parent.offsetParent;
        }
    }
    else if (element.left && element.top) {
        result.x = element.left;
        result.y = element.top;
    }
    else {
        if (element.x) {
            result.x = element.x;
        }
        if (element.y) {
            result.y = element.y;
        }
    }
    if (element.offsetWidth && element.offsetHeight) {
        result.width = element.offsetWidth;
        result.height = element.offsetHeight;
    }
    else if (element.style && element.style.pixelWidth && element.style.pixelHeight) {
        result.width = element.style.pixelWidth;
        result.height = element.style.pixelHeight;
    }
    return result;
}

function trim(text) {
    return text.replace(/^\s+|\s+$/g, "");
}

function lTrim(text) {
    return text.replace(/^\s+/g, "");
}

function rTrim(text) {
    return text.replace(/\s+$/g, "");
}

function textValidate(text) {
    var regex = new RegExp("^.*(<+)|(>+)|('.*=)+|(\".*=)+.*$");
    var result = regex.exec(text);
    if (result) {
        return false;
    }
    else {
        return true;
    }
}

function SetFocus(id) {
    try {
        var elem = document.getElementById(id);
        elem.focus();
    }
    catch (e) {
    }
}

///<summary>
/// 判断对象是否为空
///<summary>
function IsNull(o) {
    return ("undefined" == typeof (o) || "unknown" == typeof (o) || null == o);
}

///<summary>
/// 弹出窗体的对话框，主要做了如下事情，1.弹出窗口阻止程序检测；2.刚好处于屏幕的最中央；3.允许弹出多个窗体
///<summary>
///<param name="url">要打开的地址</param>
///<param name="width">打开的窗口的宽度</param>
///<param name="height">打开的窗口的高度</param>
///<param name="scrollbars">是否出现滚动条，yes表示允许，no表示不允许。可以不输入，默认为no</param>
///<param name="resizable">是否允许改变窗口大小，yes表示允许，no表示不允许。可以不输入，默认为no</param>
///<return>窗体的变量</return>
function OpenWindow(url, width, height, scrollbars, resizable) {
    if (IsNull(scrollbars))
        scrollbars = 'yes';
    if (IsNull(resizable))
        resizable = 'yes';
    var windowOpened = null;
    try {
        windowOpened = window.open(url, "_blank", 'width=' + width + ',height=' + height + ',toolbar=no,location=no,directories=no,status=yes,menubar=no,scrollbars=' + scrollbars + ',resizable=' + resizable + ',left=' + (screen.width - width) / 2 + ',top=' + (screen.height - height) / 2);
    }
    catch (e) {
        alert("打开窗口失败，窗体可能已经被打开，请关闭后重试！");
    }
    if (IsNull(windowOpened)) {
        alert("平台窗口无法打开，可能已被弹出窗口阻止程序所阻止。请将该服务地址添加到您的弹出窗口阻止程序允许打开新窗口的站点的列表中：" + window.location.hostname);
    }
    return windowOpened;
}

///<summary>
/// 弹出模态窗体的对话框，主要做了如下事情，1.弹出窗口阻止程序检测；2.刚好处于屏幕的最中央；3.允许弹出多个窗体
///<summary>
///<param name="url">要打开的地址</param>
///<param name="width">打开的窗口的宽度</param>
///<param name="height">打开的窗口的高度</param>
///<param name="scrollbars">是否出现滚动条，yes表示允许，no表示不允许。可以不输入，默认为no</param>
///<param name="resizable">是否允许改变窗口大小，yes表示允许，no表示不允许。可以不输入，默认为no</param>
///<return>窗体的变量</return>
//function OpenModelWindow(url, width, height, scrollbars, resizable) {
//    var windowOpened = null;
//    try {
//        windowOpened = window.showModalDialog(url, 'newwindow', 'dialogWidth=' + width + 'px;dialogHeight=' + height + 'px;scroll:yes;');
//        if (windowOpened != null) {
//            window.location.reload();
//        }
//    }
//    catch (e) {
//        alert("打开窗口失败，窗体可能已经被打开，请关闭后重试！");
//    }
//    if (IsNull(windowOpened)) {
//        alert("平台窗口无法打开，可能已被弹出窗口阻止程序所阻止。请将该服务地址添加到您的弹出窗口阻止程序允许打开新窗口的站点的列表中：" + window.location.hostname);
//    }
//    return windowOpened;
//}

/*********************************************************************************/
/*********Update password begin***************************************************/
/*********************************************************************************/
/*********************************************************************************/
/*---------------For Update password begin----------------*/
function PasswordStrength(showed) {
    this.showed = (typeof (showed) == "boolean") ? showed : true;
    this.styles = new Array();
    this.styles[0] = { backgroundColor: "#EBEBEB", borderLeft: "solid 1px #FFFFFF", borderRight: "solid 1px #BEBEBE", borderBottom: "solid 1px #BEBEBE", textAlign: "center" };
    this.styles[1] = { backgroundColor: "#FF4545", borderLeft: "solid 1px #FFFFFF", borderRight: "solid 1px #BB2B2B", borderBottom: "solid 1px #BB2B2B", textAlign: "center" };
    this.styles[2] = { backgroundColor: "#FFD35E", borderLeft: "solid 1px #FFFFFF", borderRight: "solid 1px #E9AE10", borderBottom: "solid 1px #E9AE10", textAlign: "center" };
    this.styles[3] = { backgroundColor: "#95EB81", borderLeft: "solid 1px #FFFFFF", borderRight: "solid 1px #3BBC1B", borderBottom: "solid 1px #3BBC1B", textAlign: "center" };

    this.labels = ["弱", "中", "强"];

    this.divName = "pwd_div_" + Math.ceil(Math.random() * 100000);
    this.minLen = 5;

    this.width = "150px";
    this.height = "16px";

    this.content = "";

    this.selectedIndex = 0;

    this.init();
}

PasswordStrength.prototype.init = function () {
    var s = '<table cellpadding="0" id="' + this.divName + '_table" cellspacing="0" style="width:' + this.width + ';height:' + this.height + ';text-align:center !important">';
    s += '<tr>';
    for (var i = 0; i < 3; i++) {
        s += '<td id="' + this.divName + '_td_' + i + '" width="33%" align="center"><span style="font-size:1px">&nbsp;</span><span id="' + this.divName + '_label_' + i + '" style="display:none;font-family: Courier New, Courier, mono;font-size: 12px;color: #000000; text-align:center">' + this.labels[i] + '</span></td>';
    }
    s += '</tr>';
    s += '</table>';
    this.content = s;
    if (this.showed) {
        document.write(s);
        this.copyToStyle(this.selectedIndex);
    }
}

PasswordStrength.prototype.copyToObject = function (o1, o2) {
    for (var i in o1) {
        o2[i] = o1[i];
    }
}

PasswordStrength.prototype.copyToStyle = function (id) {
    this.selectedIndex = id;
    for (var i = 0; i < 3; i++) {
        if (i == id - 1) {
            this.$(this.divName + "_label_" + i).style.display = "inline";
        } else {
            this.$(this.divName + "_label_" + i).style.display = "none";
        }
    }
    for (var i = 0; i < id; i++) {
        this.copyToObject(this.styles[id], this.$(this.divName + "_td_" + i).style);
    }
    for (; i < 3; i++) {
        this.copyToObject(this.styles[0], this.$(this.divName + "_td_" + i).style);
    }
}

PasswordStrength.prototype.$ = function (s) {
    return document.getElementById(s);
}

PasswordStrength.prototype.setSize = function (w, h) {
    this.width = w;
    this.height = h;
}

PasswordStrength.prototype.setMinLength = function (n) {
    if (isNaN(n)) {
        return;
    }
    n = Number(n);
    if (n > 1) {
        this.minLength = n;
    }
}

PasswordStrength.prototype.setStyles = function () {
    if (arguments.length == 0) {
        return;
    }
    for (var i = 0; i < arguments.length && i < 4; i++) {
        this.styles[i] = arguments[i];
    }
    this.copyToStyle(this.selectedIndex);
}

PasswordStrength.prototype.write = function (s) {
    if (this.showed) {
        return;
    }
    var n = (s == 'string') ? this.$(s) : s;
    if (typeof (n) != "object") {
        return;
    }
    n.innerHTML = this.content;
    this.copyToStyle(this.selectedIndex);
}

PasswordStrength.prototype.update = function (s) {
    if (s.length < this.minLen) {
        this.copyToStyle(0);
        return;
    }
    var ls = -1;
    if (s.match(/[a-z]/ig)) {
        ls++;
    }
    if (s.match(/[0-9]/ig)) {
        ls++;
    }
    if (s.match(/(.[^a-z0-9])/ig)) {
        ls++;
    }
    if (s.length < 6 && ls > 0) {
        ls--;
    }
    switch (ls) {
        case 0:
            this.copyToStyle(1);
            break;
        case 1:
            this.copyToStyle(2);
            break;
        case 2:
            this.copyToStyle(3);
            break;
        default:
            this.copyToStyle(0);
    }
}
/*------------for update password end---------*/

/*--select color---*/
function getMyColor(elem, selectColorID) {
    var selectColorElem = document.getElementById(selectColorID);
    var old_color = (selectColorElem.value.indexOf('#') == 0) ? '?' + selectColorElem.value.substr(1) : '?' + selectColorElem.value;
    var color = showModalDialog("../../js/SelectColor/ColorSelector.htm" + old_color + "", "", "dialogWidth:300px; dialogHeight:250px; status:no; resizable:no");
    if (color != null && selectColorElem != null) {
        selectColorElem.value = color;
        elem.style["background"] = color;
    }
    else {
        elem.focus();
    }
    return true;
}
/*--end select color----*/

/*--------- the verify code utility function ---------*/
var verifyCodeUpdateTime = new Date();
function ChangeVerifyCode(imgID) {
    var imageElem = document.getElementById(imgID);
    if (imageElem && imageElem.src != null) {
        var imgSrc = imageElem.src.replace(/\?time\=.*/, "");
        imgSrc += "?time=" + Math.random();
        imageElem.src = imgSrc;
        verifyCodeUpdateTime = new Date();
    }
}

function ShowTheVerifyCode(inputElem, imgID) {
    verifyCodeUpdateTime = new Date();
    var imageElem = document.getElementById(imgID);
    if (imageElem && imageElem.style['display'] != null) {
        if (imageElem.style['display'] == 'none') {
            imageElem.style['display'] = 'block';
        }
        inputElem.value = "";
        ChangeVerifyCode(imgID);
    }
}

function VerifyCodeSubmitCheck(imgID, txtVerifyCodeID) {
    var different = (new Date()).getTime() - verifyCodeUpdateTime.getTime();
    different = Math.floor(different / (1000 * 60));
    if (different > 20) {
        window.alert("您填写的验证码已经过期，请重新填写！");
        var verifyCodeInput = document.getElementById(txtVerifyCodeID);
        if (verifyCodeInput) {
            verifyCodeInput.value = "";
            SetFocus(txtVerifyCodeID);
            ChangeVerifyCode(imgID);
        }
        return false;
    }
    else {
        return true;
    }
}

//获取QueryString的数组
function getQueryString() {
    var result = location.search.match(new RegExp("[\?\&][^\?\&]+=[^\?\&]+", "g"));
    if (result == null) {
        return "";
    }
    for (var i = 0; i < result.length; i++) {
        result[i] = result[i].substring(1);
    }
    return result;
}

//根据QueryString参数名称获取值
function getQueryStringByName(name) {
    var result = location.search.match(new RegExp("[\?\&]" + name + "=([^\&]+)", "i"));
    if (result == null || result.length < 1) {
        return "";
    }
    return result[1];
}

//根据QueryString参数索引获取值
function getQueryStringByIndex(index) {
    if (index == null) {
        return "";
    }
    var queryStringList = getQueryString();
    if (index >= queryStringList.length) {
        return "";
    }
    var result = queryStringList[index];
    var startIndex = result.indexOf("=") + 1;
    result = result.substring(startIndex);
    return result;
}

//根据DictionaryCode获取其下子节点
function getDictionaryByCode(codes) {
    var dic;
    $.ajax({
        ajaxtype: "get",
        loading: '正在加载中...',
        url: "/api/SysDictionary/GetChildByCode",
        async: false,
        data: { code: codes },
        success: function (d) {
            dic = d;
        },
        error: function (error) {
           
        }
    });

    return dic;
}

//下拉框动态绑定
function bindDrapDownList(data, controls) {
    var aControl = controls.split(';');
    for (var j = 0; j < aControl.length; j++) {
        var options = "<option selected='selected' value=''>请选择...</option>";
        for (var i = 0; i < data.length; i++) {
            options += "<option value='" + data[i].DICTIONARYID + "'>" + data[i].NAME + "</option>";
        }
        $("#" + aControl[j]).html(options);
    }
}

//根据DictionaryID获取节点信息
function getDictionaryByID(id, control) {
    $.ajax({
        ajaxtype: "get",
        loading: '正在加载中...',
        url: "/api/SysDictionary/GetChildByID",
        async: false,
        data: { dictionaryID: id },
        success: function (d) {
            var options = "<option selected='selected' value=''>请选择...</option>";
            for (var i = 0; i < d[id].length; i++) {
                options += "<option value='" + d[id][i].DICTIONARYID + "'>" + d[id][i].NAME + "</option>";
            }
            $("#" + control).html(options);
        },
        error: function (error) {

        }
    });
}

//生成年份的下拉框
function getYearDropDownList(control) {
    var currentDate = new Date();
    var currentYaer = currentDate.getFullYear();
    var options = "<option selected='selected' value=''>请选择...</option>";
    for (var i = 0; i < 10; i++) {
        options += "<option value='" + (currentYaer - i) + "'>" + (currentYaer - i) + "</option>";
    }

    $("#" + control).html(options);
}

//转换成日期
function convertToDate(value) {
   return new Date(value.toString().substr(0, 4),//year
                parseInt(value.toString().substr(5, 2), 10) - 1, //month
                value.toString().substr(8, 2), //date
                value.toString().substr(11, 2), //hours
                value.toString().substr(14, 2), //minutes
                value.toString().substr(17, 2) //seconds
                );
}

//设置html中input,select,textarea标签为readonly和disabled（使用： 在html底部调用该方法）
function setTagReadonlyOrDisabled(mainform) {
    if (!mainform) {
        mainform = $("form:first");
    }

    $(":input", mainform).each(function () {
        $(this).attr("disabled", "disabled");
    });

    $(":text", mainform).each(function () {
        $(this).attr("readonly", "readonly").removeAttr("disabled");
    });

    $(":checkbox,:radio,:button,:submit,:reset,:file", mainform).each(function () {
        $(this).attr("disabled", "disabled");
    });
}

function download(ATTACHMENTID) {
    win = $.ligerDialog.open({
        url: "/api/SysAttachment/Download?attachmentID=" + ATTACHMENTID,
        title: "下载", cls: "field", height: 270, width: 600, name: '',
        isResize: true
    });
    win.hide();
}

///金额格式化100,000.00
///obj值对象
///n保留的小数位
function moneyFormat(obj) {
    if (obj.value == null || obj.value.length == 0) {
        return "";
    }
    var reNum = /^\d*$/;
    var flag = reNum.test(ReplaceAll(obj.value, ',', ''));
    if (flag) {
        var n = 2;
        obj.value = parseFloat((obj.value + "").replace(/[^\d\.-]/g, "")).toFixed(n) + "";//更改这里n数也可确定要保留的小数位  
        var l = obj.value.split(".")[0].split("").reverse(),
        r = obj.value.split(".")[1];
        t = "";
        for (i = 0; i < l.length; i++) {
            t += l[i] + ((i + 1) % 3 == 0 && (i + 1) != l.length ? "," : "");
        }

        obj.value = t.split("").reverse().join("");
    }
}

function mFormat(val) {
    if (!val && val != 0) {
        return "";
    }

    var n = 2;
    val = parseFloat((val + "").replace(/[^\d\.-]/g, "")).toFixed(n) + "";//更改这里n数也可确定要保留的小数位  
    var l = val.split(".")[0].split("").reverse(),
    r = val.split(".")[1];
    t = "";
    for (i = 0; i < l.length; i++) {
        t += l[i] + ((i + 1) % 3 == 0 && (i + 1) != l.length ? "," : "");
    }

    return val = t.split("").reverse().join("");
}

function ReplaceAll(str, sptr, sptr1) {
    while (str.indexOf(sptr) >= 0) {
        str = str.replace(sptr, sptr1);
    }
    return str;
}


//date 扩展 ----------------------------------------------------------------date start

// 对Date的扩展，将 Date 转化为指定格式的String   
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符，   
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字)   
// 例子：   
// (new Date()).format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423   
// (new Date()).format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18   
//调用事例：
//var time1 = new Date().format("yyyy-MM-dd hh:mm:ss");     
//var time2 = new Date().format("yyyy-MM-dd");
Date.prototype.format = function (fmt) { //author: meizz   
    var o = {
        "M+": this.getMonth() + 1,                 //月份   
        "d+": this.getDate(),                    //日   
        "h+": this.getHours(),                   //小时 
        "H+": this.getHours(), //小时  
        "m+": this.getMinutes(),                 //分   
        "s+": this.getSeconds(),                 //秒   
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度   
        "S": this.getMilliseconds()             //毫秒   
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}

/**       
 * 对Date的扩展，将 Date 转化为指定格式的String       
 * 月(M)、日(d)、12小时(h)、24小时(H)、分(m)、秒(s)、周(E)、季度(q) 可以用 1-2 个占位符       
 * 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字)       
 * eg:       
 * (new Date()).pattern("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423       
 * (new Date()).pattern("yyyy-MM-dd E hh:mm:ss") ==> 2009-03-10 二 20:09:04       
 * (new Date()).pattern("yyyy-MM-dd EE hh:mm:ss") ==> 2009-03-10 周二 08:09:04       
 * (new Date()).pattern("yyyy-MM-dd EEE hh:mm:ss") ==> 2009-03-10 星期二 08:09:04       
 * (new Date()).pattern("yyyy-M-d h:m:s.S") ==> 2006-7-2 8:9:4.18       
 */
Date.prototype.pattern = function (fmt) {
    var o = {
        "M+": this.getMonth() + 1, //月份         
        "d+": this.getDate(), //日         
        "h+": this.getHours(), //小时    
        "H+": this.getHours(), //小时  
        "m+": this.getMinutes(), //分         
        "s+": this.getSeconds(), //秒         
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度         
        "S": this.getMilliseconds() //毫秒         
    };
    var week = {
        "0": "周日",
        "1": "周一",
        "2": "周二",
        "3": "周三",
        "4": "周四",
        "5": "周五",
        "6": "周六"
    };
    if (/(y+)/.test(fmt)) {
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }
    if (/(E+)/.test(fmt)) {
        fmt = fmt.replace(RegExp.$1, ((RegExp.$1.length > 1) ? (RegExp.$1.length > 2 ? "/u661f/u671f" : "") : "") + week[this.getDay() + ""]);
    }
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(fmt)) {
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
        }
    }
    return fmt;
}

/**       
 * 增加小时    
 * eg:       
 * (new Date()).addHours(2) ==> 增加2小时         
 */
Date.prototype.addHours = function (value) {   
    var dtNew = new Date(this.getTime() + value * 60 * 60 * 1000);
    return dtNew;
}

/**       
 * 增加天数    
 * eg:       
 * (new Date()).addDays(2) ==> 增加2天         
 */
Date.prototype.addDays = function (value) {  
    var dtNew = new Date(this.getTime() + value * 24 * 60 * 60 * 1000);
    return dtNew;
}
//date 扩展 ----------------------------------------------------------------date start

//string 扩展 ----------------------------------------------------------------string start
/**       
 * 把日期字符串‘yyyy-MM-dd hh:mm:ss’或者‘yyyy-MM-dd’ 如 ‘2015-12-01 10:09:11’转换成 new Date() 对象       
 * '2015-12-01 10:09:11'.toString().toDate()返回Date对象
 */
String.prototype.toDate = function () {
    if (this.length == 0)
        return false;
    if (this.length > 10) {
        return new Date(this.substr(0, 4),//year
                    parseInt(this.substr(5, 2), 10) - 1, //month
                    this.substr(8, 2), //date
                    this.substr(11, 2), //hours
                    this.substr(14, 2), //minutes
                    this.substr(17, 2) //seconds
                    );
    }
    else {
        return new Date(this.substr(0, 4),//year
                    parseInt(this.substr(5, 2), 10) - 1, //month
                    this.substr(8, 2), //date
                    0, //hours
                    0, //minutes
                    0 //seconds
                    );
    }
}

/**       
 * 是否以某字符串结尾，true--是；false--否       
 * 'abc'toString().endWith('c')返回true
 */
String.prototype.endWith = function (str) {
    if (str == null || str == "" || this.length == 0 || str.length > this.length)
        return false;
    if (this.substring(this.length - str.length) == str)
        return true;
    else
        return false;
    return true;
}


//string 扩展 ----------------------------------------------------------------string start


//Array 扩展 ----------------------------------------------------------------Array start
//数组是否含有指定值
//Array.prototype.contains = function (item) {    
//    for (i = 0; i < this.length; i++) {
//        if (this[i] == item) { return true; }
//    }
//    return false;
//}

//Array 扩展 ----------------------------------------------------------------Array start

//备案应用internet地址
g_BeianAppInternetUrl = "http://hnbeian.icityfree.cn";