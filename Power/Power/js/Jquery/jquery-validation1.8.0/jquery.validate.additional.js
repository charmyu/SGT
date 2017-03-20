(function ($) {
    jQuery.validator.addMethod("commonChar", function (value, element) {
        return this.optional(element) || /^[a-zA-Z0-9]+$/.test(value);
    }, "只能包括英文字母和数字.");

    //手机号码验证
    jQuery.validator.addMethod("isMobile", function (value, element) {
        var length = value.length;
        //var mobile = /^(((13[0-9]{1})|(15[0-9]{1}))+\d{8})$/;
        var mobile = /^1[0-9][0-9]\d{4,8}$/;
        return this.optional(element) || (length == 11 && mobile.test(value));
    }, "请正确填写手机号码");

    // 电话号码验证 
    jQuery.validator.addMethod("isTel", function (value, element) {
        var tel = /^\d{3,4}-?\d{7,9}$/; //电话号码格式010-12345678 
        return this.optional(element) || (tel.test(value));
    }, "请正确填写您的电话号码");

    // 传真验证 
    jQuery.validator.addMethod("isFax", function (value, element) {
        var tel = /^\d{3,4}-?\d{7,9}$/; //传真号码格式010-12345678 
        return this.optional(element) || (tel.test(value));
    }, "请正确填写您的传真号码");

    // 邮政编码验证 
    jQuery.validator.addMethod("isZipCode", function (value, element) {
        var tel = /^[0-9]{6}$/;
        return this.optional(element) || (tel.test(value));
    }, "请正确填写您的邮政编码");

    // IP地址验证   
    jQuery.validator.addMethod("ip", function (value, element) {
        var ip = /^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$/;
        return this.optional(element) || (ip.test(value) && (RegExp.$1 < 256 && RegExp.$2 < 256 && RegExp.$3 < 256 && RegExp.$4 < 256));
    }, "Ip地址格式错误");

    //半角英文数字下划线
    jQuery.validator.addMethod("generalChar", function (value, element) {
        return this.optional(element) || /^[a-zA-Z0-9_]+$/.test(value);
    }, "只能包括半角英文数字下划线.");

    //身份证号码
    jQuery.validator.addMethod("isIdCardNo", function (value, element) {
        function isIdCardNo(num) {
            var factorArr = new Array(7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2, 1);
            var parityBit = new Array("1", "0", "X", "9", "8", "7", "6", "5", "4", "3", "2");
            var varArray = new Array();
            var intValue;
            var lngProduct = 0;
            var intCheckDigit;
            var intStrLen = num.length;
            var idNumber = num;
            // initialize
            if ((intStrLen != 15) && (intStrLen != 18)) {
                return false;
            }
            // check and set value
            for (i = 0; i < intStrLen; i++) {
                varArray[i] = idNumber.charAt(i);
                if ((varArray[i] < '0' || varArray[i] > '9') && (i != 17)) {
                    return false;
                } else if (i < 17) {
                    varArray[i] = varArray[i] * factorArr[i];
                }
            }

            if (intStrLen == 18) {
                //check date
                var date8 = idNumber.substring(6, 14);
                if (isDate8(date8) == false) {
                    return false;
                }
                // calculate the sum of the products
                for (i = 0; i < 17; i++) {
                    lngProduct = lngProduct + varArray[i];
                }
                // calculate the check digit
                intCheckDigit = parityBit[lngProduct % 11];
                // check last digit
                if (varArray[17] != intCheckDigit) {
                    return false;
                }
            }
            else {        //length is 15
                //check date
                var date6 = idNumber.substring(6, 12);
                if (isDate6(date6) == false) {
                    return false;
                }
            }
            return true;
        }
        function isDate6(sDate) {
            if (!/^[0-9]{6}$/.test(sDate)) {
                return false;
            }
            var year, month, day;
            year = sDate.substring(0, 4);
            month = sDate.substring(4, 6);
            if (year < 1700 || year > 2500) return false
            if (month < 1 || month > 12) return false
            return true
        }

        function isDate8(sDate) {
            if (!/^[0-9]{8}$/.test(sDate)) {
                return false;
            }
            var year, month, day;
            year = sDate.substring(0, 4);
            month = sDate.substring(4, 6);
            day = sDate.substring(6, 8);
            var iaMonthDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31]
            if (year < 1700 || year > 2500) return false
            if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0)) iaMonthDays[1] = 29;
            if (month < 1 || month > 12) return false
            if (day < 1 || day > iaMonthDays[month - 1]) return false
            return true
        }

        return this.optional(element) || isIdCardNo(value);
    }, "请正确输入您的身份证号码");

    //[u4e00 - u9fa5]
    jQuery.validator.addMethod("cn", function (value, element) {
        return !(this.optional(element) || /^[u4e00 - u9fa5]/.test(value));
    }, "只能输入中文");

    jQuery.validator.addMethod("notSpace", function (value, element) {
        return !(this.optional(element) || /^^[^ ]+ /.test(value));
    }, "不能包含空格");

    jQuery.validator.addMethod("notnull", function (value, element) {
        if (!value) return true;
        return !$(element).hasClass("l-text-field-null");
    }, "不能为空");

    //字母数字
    jQuery.validator.addMethod("alnum", function (value, element) {
        return this.optional(element) || /^[a-zA-Z0-9]+$/.test(value);
    }, "只能包括英文字母和数字");

    // 手机号码验证   
    jQuery.validator.addMethod("cellphone", function (value, element) {
        var length = value.length;
        return this.optional(element) || (length == 11 && /^(1\d{10})$/.test(value));
    }, "请正确填写手机号码");

    // 电话号码验证   
    jQuery.validator.addMethod("telephone", function (value, element) {
        var tel = /^(\d{3,4}-?)?\d{7,9}$/g;
        return this.optional(element) || (tel.test(value));
    }, "请正确填写电话号码");

    // 邮政编码验证
    jQuery.validator.addMethod("zipcode", function (value, element) {
        var tel = /^[0-9]{6}$/;
        return this.optional(element) || (tel.test(value));
    }, "请正确填写邮政编码");

    // 汉字
    jQuery.validator.addMethod("chcharacter", function (value, element) {
        var tel = /^[\u4e00-\u9fa5]+$/;
        return this.optional(element) || (tel.test(value));
    }, "请输入汉字");

    // QQ
    jQuery.validator.addMethod("qq", function (value, element) {
        var tel = /^[1-9][0-9]{4,}$/;
        return this.optional(element) || (tel.test(value));
    }, "请输入正确的QQ");

    // 用户名
    jQuery.validator.addMethod("username", function (value, element) {
        return this.optional(element) || /^[a-zA-Z][a-zA-Z0-9_]+$/.test(value);
    }, "用户名格式不正确");

    //日期格式字符串
    jQuery.validator.addMethod("dateFormat", function (value, element) {
        return this.optional(element) || /^(y|yy|yyyy)*M{0,4}d{0,4}h{0,2}H{0,2}m{0,2}s{0,2}$/.test(value);
    }, "日期格式字符串不正确");

    jQuery.validator.addMethod("isDate", function (value) {

        var reg = /^(\d{4})-(\d{2})-(\d{2})$/;

        var r = value.match(reg);

        if (r == null) return false;

        var d = new Date(r[1], r[2] - 1, r[3], 0, 0, 0);

        return (d.getFullYear() == r[1] && (d.getMonth() + 1) == r[2] && d.getDate() == r[3] && d.getHours() == 0 && d.getMinutes() == 0 && d.getSeconds() == 0);

    }, "日期格式错误,正确示例:2014-01-31");


    jQuery.validator.addMethod("isDateTime", function (value) {

        var reg = /^(\d{4})(-|\/)(\d{1,2})\2(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})$/;

        var r = value.match(reg);

        if (r == null) return false;

        var d = new Date(r[1], r[3] - 1, r[4], r[5], r[6], r[7]);

        return (d.getFullYear() == r[1] && (d.getMonth() + 1) == r[3] && d.getDate() == r[4] && d.getHours() == r[5] && d.getMinutes() == r[6] && d.getSeconds() == r[7]);

    }, "时间格式错误,正确示例:2014-01-31 01:20:01");

    jQuery.validator.addMethod("isDateT", function (value, element, param) {
        var deadlinetime = $('[validateid=' + param + ']').val() || $('[name=' + param + ']').val();
        var reg = new RegExp('-', 'g');
        assigntime = value.replace(reg, '/');//正则替换
        deadlinetime = deadlinetime.replace(reg, '/');
        assigntime = new Date(parseInt(Date.parse(assigntime), 10));
        deadlinetime = new Date(parseInt(Date.parse(deadlinetime), 10));
        if (assigntime > deadlinetime) {
            return false;
        } else {
            return true;
        }
    }, "时间必须小于时间");

})(jQuery);