//-------------------------------------------------------------------
//版权所有：版权所有  2008，Microsoft(China) Co.,LTD
//系统名称：Paas
//文件名称：checkbox_operate.js
//模块名称：OP

//作　　者：袁华慧
//完成日期：04/24/2008
//功能说明：

//-----------------------------------------------------------------
//修改记录：

//修改人：  
//修改时间：

//修改内容：

//---------------------------------------



//对GridView中的checkbox选中处理
function checkAllCheckBox() {
    var checkBoxNames = getCheckBoxNameStringByFuncArg(arguments);
    var checkGroup = checkBoxNames[0];
    var checkBoxTitle = checkBoxNames[1];
    var checkBoxList = document.getElementsByName(checkGroup);
    if (checkBoxList && checkBoxList.length > 0) {
        var checkboxTitleElem = getCheckBoxTitleElement(checkBoxTitle);
        for (var i = 0; i < checkBoxList.length; i++) {
            if (checkboxTitleElem) {
                checkBoxList[i].checked = checkboxTitleElem.checked;
            }
        }
    }
}

function checkEitherCheckBox() {
    var bResult = false;
    var execGetChkContentStatus = "getChkContentStatus(";
    for (var i = 0; i < arguments.length; i++) {
        execGetChkContentStatus += (i == 0 ? ("arguments[" + i + "]") : (", arguments[" + i + "]"));
    }
    execGetChkContentStatus += ");";
    bResult = eval(execGetChkContentStatus);
    var checkBoxNames = getCheckBoxNameStringByFuncArg(arguments);
    var checkBoxTitle = checkBoxNames[1];
    var checkboxTitleElem = getCheckBoxTitleElement(checkBoxTitle);
    if (checkboxTitleElem) {
        checkboxTitleElem.checked = bResult ? true : false;
    }
}

function getChkContentStatus() {
    var bBool = true;
    var checkBoxNames = getCheckBoxNameStringByFuncArg(arguments);
    var checkGroup = checkBoxNames[0]; //chkf_group
    var checkBoxList = document.getElementsByName(checkGroup);

    if (checkBoxList && checkBoxList.length > 0) {
        for (var i = 0; i < checkBoxList.length; i++) {
            if (checkBoxList[i].checked == false) {
                bBool = false;
                break;
            }
        }
    }
    return bBool;

}
//得到chkf_group名称和checkBoxTitle名称
function getCheckBoxNameStringByFuncArg(funcArg) {
    var nameArray = new Array();
    var number = "";
    if (funcArg.length > 0) {
        number = funcArg[0];
    }
    nameArray[0] = "chkf_group" + number;
    nameArray[1] = "checkBoxTitle" + number;
    return nameArray;
}

function getCheckBoxTitleElement(checkBoxTitleString) {
    var checkboxTitleElem = null;
    if (document.getElementById(checkBoxTitleString)) {
        checkboxTitleElem = document.getElementById(checkBoxTitleString);
    }
    else if (document.getElementsByName(checkBoxTitleString)) {
        checkboxTitleElem = document.getElementsByName(checkBoxTitleString)[0];
    }
    return checkboxTitleElem;
}


//对GridView中的checkbox选中处理
function checkAllCheckBox2() {
    checkAllCheckBox("2");
}

function checkEitherCheckBox2() {
    checkEitherCheckBox("2");

}

// 说明：Javascript 控制 CheckBox 的全选与取消全选  parentElement：上级ID
// value=true; or false
function checkAll2(parentElement, value) {
    if (document.getElementById(parentElement) == null) {
        return;
    }

    var elementArray = document.getElementById(parentElement).getElementsByTagName('input');
    for (var i = 0; i < elementArray.length; i++) {
        if (elementArray[i].type == "checkbox" && !elementArray[i].disabled) {
            elementArray[i].checked = value;
        }
    }
}


//在做删除等操作时，如果CheckBox一个都没选中，那么就返回False
function validChkIsChecked() {
    var bBool = false;
    var checkBoxNames = getCheckBoxNameStringByFuncArg(arguments);
    var checkGroup = checkBoxNames[0];
    var checkBoxList = document.getElementsByName(checkGroup);
    if (checkBoxList && checkBoxList.length > 0) {
        for (var i = 0; i < checkBoxList.length; i++) {
            if (checkBoxList[i].checked == true) {
                bBool = true;
                break;
            }
        }
    }
    return bBool;
}

//是否只选择了一个
function validChkIsCheckedOverOne() {
    var bBool = true;
    var iCount = 0;

    var checkBoxNames = getCheckBoxNameStringByFuncArg(arguments);
    var checkGroup = checkBoxNames[0]; //chkf_group
    var checkBoxList = document.getElementsByName(checkGroup);
    if (document.getElementsByName(checkGroup) && document.getElementsByName(checkGroup).length > 0) {
        for (var i = 0; i < checkBoxList.length; i++) {
            if (checkBoxList[i].checked == true) {
                var hidEditID = document.getElementById("hidCategoryId");
                if (hidEditID != null) {
                    hidEditID.value = checkBoxList[i].value;
                }
                hidEditID = document.getElementById("editid");
                if (hidEditID != null) {
                    hidEditID.value = checkBoxList[i].value;
                }
                iCount++;
            }
            if (iCount > 1) {
                bBool = false;
                return bBool;
            }
        }
    }
    else {
        //
    }
    return bBool;

}

function DeleteOrUpdateConfirm(Message, operate) {
    if ((operate == null) || (operate.toString().toLocaleLowerCase() != "update")) {
        var strMsg = Message;

        if (Message == null || Message.toString().length == 0) {
            strMsg = "是否删除?";
        }

        var IsValidChk = validChkIsChecked();

        if (!IsValidChk) //没有一个CheckBox被选中
        {
            alert("请选择要处理的记录!");
            return false;
        }

        return confirm(strMsg);
    }
    else {
        var IsValidChk = validChkIsChecked();

        if (!IsValidChk) //没有一个CheckBox被选中
        {
            alert("请选择要处理的记录!");
            return false;
        }

        if (!validChkIsCheckedOverOne()) {
            alert("只能对一项数据进行操作!");
            return false;
        }

        return true;
    }
}
function DeleteOrUpdateConfirm2(Message, operate, AlertMessage) {
    if ((operate == null) || (operate.toString().toLocaleLowerCase() != "update")) {
        var strMsg = Message;

        if (Message == null || Message.toString().length == 0) {
            strMsg = "是否删除?";
        }

        var IsValidChk = validChkIsChecked();

        if (!IsValidChk) //没有一个CheckBox被选中
        {
            alert("请选择要处理的记录!");
            return false;
        }

        return confirm(strMsg);
    }
    else {
        var IsValidChk = validChkIsChecked();

        if (!IsValidChk) //没有一个CheckBox被选中
        {
            alert("请选择要处理的记录!");
            return false;
        }

        if (!validChkIsCheckedOverOne()) {
            alert(AlertMessage);
            return false;
        }

        return true;
    }
}

function DeleteOrUpdate() {
    var IsValidChk = validChkIsChecked();

    if (!IsValidChk) //没有一个CheckBox被选中
    {
        alert("请选择要处理的记录!");
        return false;
    }
    else {
        return true;
    }
}

//根据用户选择的情况和状态值，给出相应的提示（针对 启用、停用、关闭 操作）    
//对用户管理的操作
function ActiveOrStop(Message, MessageDif, flag) {
    var strMsg = Message;
    var strStatus = "";

    var IsValidChk = validChkIsChecked();

    if (!IsValidChk) //没有一个CheckBox被选中
    {
        alert("请选择要处理的记录");
        return false;
    }

    for (i = 0; i < document.getElementsByName("status_group").length; i++) {
        if (i == 0) { strStatus = strStatus + document.getElementsByName("status_group")[i].value; }
        else { strStatus = strStatus + "," + document.getElementsByName("status_group")[i].value; }
    }

    array = strStatus.split(",");
    if (IsContains(flag, array)) {
        alert(MessageDif);
        return false;
    }

    if (Message == null || Message.toString().length == 0) {
        strMsg = "是否删除";
    }

    return confirm(strMsg);
}

//获取所有选中记录的value值（以","相隔)   

function GetSelectItems() {
    var checkBoxNames = getCheckBoxNameStringByFuncArg(arguments);
    var checkGroup = checkBoxNames[0]; //chkf_group
    var checkBoxList = document.getElementsByName(checkGroup);

    var strStatus = "";
    if (checkBoxList && checkBoxList.length > 0) {
        for (i = 0; i < checkBoxList.length; i++) {
            if (checkBoxList[i].checked) {
                strStatus += checkBoxList[i].value + ",";
            }
        }
    } return strStatus;
}
//记录用户选中的企业的状态（选中多个时返回字符串，中间用"-"隔开）
function CheckedIsClose(chk, isChecked) {
    var hidStrChk = document.getElementById("hidStrChecked");
    if (hidStrChk != null) {
        if (chk.checked) {
            if (hidStrChk.value == "")
            { hidStrChk.value = isChecked; }
            else
            { hidStrChk.value = hidStrChk.value + "-" + isChecked; }
        }
        else {
            var x = hidStrChk.value.indexOf(isChecked);
            var y = hidStrChk.value.indexOf("-");

            if (x == "0") {
                if (y == "-1")
                { hidStrChk.value = hidStrChk.value.replace(isChecked, ""); }
                else
                { hidStrChk.value = hidStrChk.value.replace(isChecked + "-", ""); }
            }
            else
            { hidStrChk.value = hidStrChk.value.replace("-" + isChecked, ""); }
        }
    }
}
//记录用户选中的沙箱的分配状态（选中多个时返回字符串，中间用"-"隔开）
function CheckedIsAssigned(chk, isChecked) {
    var hidStrChk = document.getElementById("hidStrAssigned");
    if (hidStrChk != null) {
        if (chk.checked) {
            if (hidStrChk.value == "")
            { hidStrChk.value = isChecked; }
            else
            { hidStrChk.value = hidStrChk.value + "-" + isChecked; }
        }
        else {
            var x = hidStrChk.value.indexOf(isChecked);
            var y = hidStrChk.value.indexOf("-");

            if (x == "0") {
                if (y == "-1")
                { hidStrChk.value = hidStrChk.value.replace(isChecked, ""); }
                else
                { hidStrChk.value = hidStrChk.value.replace(isChecked + "-", ""); }
            }
            else
            { hidStrChk.value = hidStrChk.value.replace("-" + isChecked, ""); }
        }
    }
}
//根据用户选择的情况和状态值，给出相应的提示（针对 启用、停用、关闭 操作）    
//对企业管理的操作
function ConfirmStatusArray(msgTip, msgError, flag) {
    var s, array;
    s = document.getElementById("hidStrChecked").value;
    array = s.split("-");

    if (array.length > 1) {
        if (IsContains("3", array)) { alert("您选择的企业中，包含了状态已经关闭的企业！\r\n请将其从选择中去除之后再进行其他操作。"); return false; }
        else if (IsContains("2", array) && "2" == flag) { alert("您选择的企业中，包含了状态已经停用的企业！\r\n请将其从选择中去除之后再进行停用操作。"); return false; }
        else if (IsContains("0", array) && "0" == flag) { alert("您选择的企业中，包含了状态已经启用的企业！\r\n请将其从选择中去除之后再进行启用操作。"); return false; }
    }
    else {
        switch (s) {
            case "0":
                if ("0" == flag) { alert("重复操作，该企业状态已经启用！"); return false; }
                break;
            case "2":
                if ("2" == flag) { alert("重复操作，该企业状态已经停用！"); return false; }
                break;
            case "3":
                alert(msgError); return false;
                break;
            default: break;
        }
    }
    return DeleteOrUpdateConfirm(msgTip);
}

//根据用户选择的情况和状态值，给出相应的提示（针对 启用、停用、关闭 操作）
//对用户管理的操作
function ConfirmUsersStatus(msgTip, msgError, flag) {
    var s, array;
    s = document.getElementById("hidStrChecked").value;
    array = s.split("-");
    if (array.length > 1) {
        if (IsContains("3", array)) { alert("您选择的用户中，包含了状态已经关闭的用户！\r\n请将其从选择中去除之后再进行其他操作。"); return false; }
        else if (IsContains("2", array) && "2" == flag) { alert("您选择的用户中，包含了状态已经停用的用户！\r\n请将其从选择中去除之后再进行停用操作。"); return false; }
        else if (IsContains("0", array) && "0" == flag) { alert("您选择的用户中，包含了状态已经启用的用户！\r\n请将其从选择中去除之后再进行启用操作。"); return false; }
    }
    else {
        switch (s) {
            case "0":
                if ("0" == flag) { alert("重复操作，该用户状态已经启用！"); return false; }
                break;
            case "2":
                if ("2" == flag) { alert("重复操作，该用户状态已经停用！"); return false; }
                break;
            case "3":
                alert(msgError); return false;
                break;
            default: break;
        }
    }
    return DeleteOrUpdateConfirm(msgTip);
}
//根据沙箱选择的情况和状态值，给出相应的提示（针对 启用、停用、关闭 操作）
//对沙箱管理的操作
function ConfirmSandBoxStatus(msgTip, msgError, flag) {
    if (document.getElementById("hidStrAssigned").value.indexOf("True") >= 0) {
        alert("您选择的沙箱中，包含了已经分配的沙箱，不能进行该操作!");
        return false;
    }
    var s, array;
    s = document.getElementById("hidStrChecked").value;
    array = s.split("-");
    if (array.length > 1) {
        if (IsContains("C", array)) { alert("您选择的沙箱中，包含了状态已经关闭的沙箱！\r\n请将其从选择中去除之后再进行其他操作。"); return false; }
        else if (IsContains("D", array) && "2" == flag) { alert("您选择的沙箱中，包含了状态已经停用的沙箱！\r\n请将其从选择中去除之后再进行停用操作。"); return false; }
        else if (IsContains("N", array) && "0" == flag) { alert("您选择的沙箱中，包含了状态已经启用的沙箱！\r\n请将其从选择中去除之后再进行启用操作。"); return false; }
    }
    else {
        switch (s) {
            case "N":
                if ("0" == flag) { alert("重复操作，该沙箱状态已经启用！"); return false; }
                break;
            case "D":
                if ("2" == flag) { alert("重复操作，该沙箱状态已经停用！"); return false; }
                break;
            case "C":
                alert(msgError); return false;
                break;
            default: break;
        }
    }
    return DeleteOrUpdateConfirm(msgTip);
}

//对Org管理的操作  删除
function ConfirmOrgStatus(msgTip) {
    if (document.getElementById("hidStrAssigned").value.indexOf("True") >= 0) {
        alert("您选择的Org中，包含了已经绑定到沙箱的Org，不能删除!");
        return false;
    }
    var s, array;
    s = document.getElementById("hidStrChecked").value;
    array = s.split("-");
    if (array.length > 1) {
        if (IsContains("D", array)) { alert("您选择的Org中，包含了已经删除的Org，不能操作！"); return false; }
    }
    else {
        switch (s) {
            case "D":
                alert("重复操作，该Org已经删除！"); return false;
                break;
            default: break;
        }
    }
    return DeleteOrUpdateConfirm(msgTip);
}

//根据通讯录选择的情况和状态值，给出相应的提示（针对 启用、停用、关闭 操作）
//对用户管理的操作
function ConfirmCommnotesStatus(msgTip, msgError, flag) {
    var s, array;
    s = document.getElementById("hidStrChecked").value;
    array = s.split("-");
    if (array.length > 1) {
        if (IsContains("3", array)) { alert("您选择的记录中，包含了状态已经关闭的记录！\r\n请将其从选择中去除之后再进行其他操作。"); return false; }
        else if (IsContains("2", array) && "2" == flag) { alert("您选择的记录中，包含了状态已经停用的记录！\r\n请将其从选择中去除之后再进行停用操作。"); return false; }
        else if (IsContains("0", array) && "0" == flag) { alert("您选择的记录中，包含了状态已经启用的记录！\r\n请将其从选择中去除之后再进行启用操作。"); return false; }
    }
    else {
        switch (s) {
            case "0":
                if ("0" == flag) { alert("重复操作，该用户状态已经启用！"); return false; }
                break;
            case "2":
                if ("2" == flag) { alert("重复操作，该用户状态已经停用！"); return false; }
                break;
            case "3":
                alert(msgError); return false;
                break;
            default: break;
        }
    }
    return DeleteOrUpdateConfirm(msgTip);
}

//点击全选时，取得状态的字符串
function GetAllChkString(chk) {
    var i;
    var hidStrChk = document.getElementById("hidStrChecked");

    if (document.getElementById("status_group")) {
        if (document.getElementsByName("status_group") != "undefined" && document.getElementsByName("status_group").length > 1) {
            if (chk.checked) {
                hidStrChk.value = "";
                for (i = 0; i < document.getElementsByName("status_group").length; i++) {
                    if (!document.getElementsByName("status_group")[i].disabled) {
                        if (i == 0) {
                            hidStrChk.value = document.getElementsByName("status_group")[i].value;
                        }
                        else {
                            hidStrChk.value = hidStrChk.value + "-" + document.getElementsByName("status_group")[i].value;
                        }
                    }
                }
            }
            else {
                hidStrChk.value = "";
            }
        }
        else {
            if (chk.checked) {
                hidStrChk.value = document.getElementById("status_group").value;
            }
            else {
                hidStrChk.value = "";
            }
        }
    }
}
//点击全选时，取得沙箱分配状态的字符串
function GetAllAssignedString(chk) {
    var i;
    var hidStrChk = document.getElementById("hidStrAssigned");

    if (document.getElementById("Assigned_group")) {
        if (document.getElementsByName("Assigned_group") != "undefined" && document.getElementsByName("Assigned_group").length > 1) {
            if (chk.checked) {
                hidStrChk.value = "";
                for (i = 0; i < document.getElementsByName("Assigned_group").length; i++) {
                    if (!document.getElementsByName("Assigned_group")[i].disabled) {
                        if (i == 0) { hidStrChk.value = hidStrChk.value + document.getElementsByName("Assigned_group")[i].value; }
                        else { hidStrChk.value = hidStrChk.value + "-" + document.getElementsByName("Assigned_group")[i].value; }
                    }
                }
            }
            else {
                hidStrChk.value = "";
            }
        }
        else {
            if (chk.checked) {
                hidStrChk.value = document.getElementsByName("Assigned_group").value;
            }
            else {
                hidStrChk.value = "";
            }
        }
    }
}

/*
*
*   判断在数组中是否含有给定的一个变量值
*   参数：
*   needle：需要查询的值
*   haystack：被查询的数组
*   在haystack中查询needle是否存在，如果找到返回true，否则返回false。
*   此函数只能对字符和数字有效
*
*/
function IsContains(needle, haystack) {
    // 得到needle的类型
    var type = typeof needle;

    if (type == 'string' || type == 'number') {
        for (var i in haystack) {
            if (haystack[i] == needle) {
                return true;
            }
        }
    }
    return false;
}

//        function goToEdit(obj,url,parameter,openWindowPara){
//            var elementArray=document.getElementById("<%=gvUsers.ClientID %>").getElementsByTagName('input');
//            //var elementArray=GetInputElemtent("<%=form1.ClientID %>","checkbox","<%=gvUsers.ClientID %>");
//            for(var i=0;i<elementArray.length;i++){
//                if(elementArray[i].type=="checkbox"){
//                    if(elementArray[i].checked){
//                        alert(elementArray[i].value);
//                    }
//                }
//            }
//            var newWindow=window.open('UserEdit.aspx','',openWindowPara);
//        }





//<!-- 


//CheckBox操作Js，使用方法可以参照"WebUI\Portal\EC\CompanyManager\TenantCompanyMgmt.aspx"文件




// 说明：Javascript 控制 CheckBox 的全选与取消全选(胡李俊修改)    parentElement：上级ID
function checkAll(parentElement, obj) {
    var elementArray = document.getElementById(parentElement).getElementsByTagName('input');
    for (var i = 0; i < elementArray.length; i++) {
        if (elementArray[i].type == "checkbox" && !elementArray[i].disabled) {
            elementArray[i].checked = obj.checked;
        }
    }
}

//统计已选择的个数(胡李俊)
//返回一对象数组，其中第一个元素为：被选中的CheckBox个数，以后的各元素为被选中的值
function countCheck(parentElement) {
    var countAry = new Array();
    countAry[0] = 0;
    var j = 1;
    var elementArray = document.getElementById(parentElement).getElementsByTagName('input');
    for (var i = 1; i < elementArray.length; i++) {
        if (elementArray[i].type == "checkbox") {
            if (elementArray[i].checked) {
                countAry[0]++;
                countAry[j++] = elementArray[i].value;
            }
        }
    }
    return countAry;
}

//统计已选择的个数(胡李俊)
//返回一对象数组，其中第一个元素为：被选中的CheckBox个数，以后的各元素为被选中的值
function countCheck2(parentElement) {
    var countAry = new Array();
    countAry[0] = 0;
    if (document.getElementById(parentElement) == null) {
        return countAry;
    }
    var j = 1;
    var elementArray = document.getElementById(parentElement).getElementsByTagName('input');
    for (var i = 0; i < elementArray.length; i++) {
        if (elementArray[i].type == "checkbox") {
            if (elementArray[i].checked) {
                countAry[0]++;
                countAry[j++] = elementArray[i].value;
            }
        }
    }
    return countAry;
}

//算法有待优化(胡李俊　2008-4-30)
function reverseCheck(parentElement, obj) {
    var elementCount = 0;
    var elementArray = document.getElementById(parentElement).getElementsByTagName('input');
    //除去第一个CheckBox
    for (var i = 1; i < elementArray.length; i++) {
        if (elementArray[i].type == "checkbox") {
            if (elementArray[i].checked) {
                elementCount++;
            }
        }
    }
    if (elementCount == elementArray.length) {
        elementArray[0].checked = true;
    } else {
        elementArray[0].checked = false;
    }
}

//投票选项判断
function SelectItem(obj) {
    var itemname = obj.name;
    var hid = "hid" + obj.name;
    var htitle = "ht" + obj.name; n
    var id = document.getElementById(hid);
    var namegroup = document.getElementByName(itemname);
    var count = 0;
    for (var i = 0; i < namegroup.length; i++) {
        if (namegroup[i].checked) {
            count++;
            id.value = namegroup[i].value;
        }
        if (i == namegroup.length - 1 && count == 0) {
            id.value = "";
        }
    }
}

//判断每个问题至少选中一个
function AllSelectAboveOne() {
    var elementArray = document.getElementsByTagName('input');
    for (var i = 0; i < elementArray.length; i++) {
        if (elementArray[i].type == "hidden") {

            var hidvalue = elementArray[i].value
            var htitleID = elementArray[i]
            if (hidvalue.length == 0) {
                alert('');
            }
        }
    }
}
//--> 