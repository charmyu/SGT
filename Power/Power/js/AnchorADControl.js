//获取随机数
//下限，上线如randomvalue(1, 5),即摇出1，2，3，4，5
function randomvalue(low, high) {
    low = low - 1;
    high = high - 1;
    return Math.ceil(Math.random() * (1 + high - low) + low);
}

function GetADindex(probability, oddArray) {
    var minNum = 0;
    var maxNum = 0;
    var i = 0;
    var rtn = 0; //返回索引
    for (i = 0; i < oddArray.length; i++) {
        if (i == 0) {
            minNum = 0;
            maxNum = parseInt(oddArray[i]);
        }
        else {
            minNum = minNum + parseInt(oddArray[i - 1]);
            maxNum = maxNum + parseInt((oddArray[i]));
        }
        if (probability > minNum && probability <= maxNum) {
            rtn = i;
            break;
        }
    }
    return rtn;
}

function sendAjax(strUrl) {
    new Ajax.Request(strUrl, {
        method: 'get',
        onSuccess: function(transport) {
        }
    });
}