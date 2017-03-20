

function SyncCheckBoxTilte()
{
    var checkBoxTitle = document.getElementById("checkBoxTitle");
    if (checkBoxTitle == "undefined")
    {
        return;
    }
    
    var checkBoxGroup = document.getElementsByName("chkf_group");   
    if (checkBoxGroup.length == 0 || checkBoxGroup.length =="undefined")
    {
       checkBoxTitle.checked = false;
    }
    
    for (var i in checkBoxGroup)
    {
       if ( ! checkBoxGroup[i].checked)
       {
           checkBoxTitle.checked = false;
           return;
       }
    }
    
    checkBoxTitle.checked = true;
}

function CheckAllCheckBox()
{	

    var checkBoxTitle = document.getElementById("checkBoxTitle");
    if (checkBoxTitle == "undefined")
    {
        return;
    }
    
    var selectedCheckBox = document.getElementsByName("chkf_group");
    if( selectedCheckBox.length == "undefined" || selectedCheckBox.length == 0)
    {
        return false;
    }

	for (var i = 0; i < selectedCheckBox.length;i++)
	{
		selectedCheckBox[i].checked = checkBoxTitle.checked;
	}
}

//点击全选时，取得状态的字符串
 function SaveAllStatusGroup(chk)
{
    var hidSelectedTemplateStatus = document.getElementById("hidSelectedTemplateStatus");
	if (hidSelectedTemplateStatus == "undefined")
	{
		return;
	}
	
	hidSelectedTemplateStatus.value = "";
	var hidStatus_group = document.getElementsByName("status_group");
    if(hidStatus_group.length == 0 || hidStatus_group.length == "undefined" || chk.checked == false)
    {
        return;
    }
    
	for( var i=0; i<hidStatus_group.length;i++)
	{
		if(! hidStatus_group[i].disabled)
		{
			if(i == 0) 
			{
				hidSelectedTemplateStatus.value = hidSelectedTemplateStatus.value + hidStatus_group[i].value;
			}
			else   
			{
				hidSelectedTemplateStatus.value = hidSelectedTemplateStatus.value + "-" + hidStatus_group[i].value;
			}
		}
	}    
} 


function SaveStatusGroup(chk,currentStatus)
{
    var hidStatus_group =document.getElementById("hidSelectedTemplateStatus");
    if(hidStatus_group == null || hidStatus_group == "undefined" )
    {
		return;
	}
	
	// when Current CheckBox is selected, Form need  append the current Status
	if(chk.checked)
	{
		if(hidStatus_group.value == "")
		{
			hidStatus_group.value = currentStatus;
		}
		else
		{
			hidStatus_group.value = hidStatus_group.value + "-" + currentStatus;
		}
		
		return;
	} 

	// when unSelect current CheckBox
	var x = hidStatus_group.value.indexOf(currentStatus);
	var y = hidStatus_group.value.indexOf("-");

	if(x == "0")
	{
		if(y == "-1")
		{
			hidStatus_group.value = hidStatus_group.value.replace(currentStatus,"");
		}
		else
		{
			hidStatus_group.value = hidStatus_group.value.replace(currentStatus+"-","");
		}
	}
	else
	{
		hidStatus_group.value = hidStatus_group.value.replace("-"+currentStatus,"");
	}
}

function VerifyTemplateStatus()
{  
    var hidSelectedTemplateStatus = document.getElementById("hidSelectedTemplateStatus");
    if (hidSelectedTemplateStatus == "undefined")
    {
        return false;
    }
    
    var element = hidSelectedTemplateStatus.value;
    var hiddenStatusArray = element.split("-");

	for (var i in hiddenStatusArray)
	{
        if (hiddenStatusArray[i] != "Dev")
        {
           return false;
        }
	}
	
    return true;
}

function VerifyImportTemplateStatus()
{  
    var hidSelectedTemplateStatus = document.getElementById("hidSelectedTemplateStatus");
    if (hidSelectedTemplateStatus == "undefined")
    {
        return false;
    }
    
    var element = hidSelectedTemplateStatus.value;
    var hiddenStatusArray = element.split("-");

	for (var i in hiddenStatusArray)
	{
        if (hiddenStatusArray[i] != "Dev" && hiddenStatusArray[i] != "Fail")
        {
           return false;
        }
	}
	
    return true;
}

function SelectSingleItem()
{
	var checkedElementCount = 0;
    var checkBoxs = document.getElementsByName("chkf_group");
	if(checkBoxs.length == 0 || checkBoxs.length =="undefined")
	{
	    alert("没有要处理的记录");
		return false;
	}
	
	for (var i = 0; i < checkBoxs.length; i++)
	{
		if (checkBoxs[i].type == "checkbox")
		{
			if (checkBoxs[i].checked)
			{
				checkedElementCount ++;
			}
		}
	}

	if (checkedElementCount == 0)
	{
		alert("请选择要处理的记录");
		return false;
	}

	if (checkedElementCount > 1)
	{
		alert("只能对一项数据进行操作");
		return false;
	}
				
	return true;
}

function SelectMultipleItems()
{
	var checkedElementCount = 0;
    var checkBoxs = document.getElementsByName("chkf_group");
	if(checkBoxs.length == 0 || checkBoxs.length =="undefined")
	{
		return false;
	}
	
	for (var i = 0; i < checkBoxs.length; i++)
	{
		if (checkBoxs[i].type == "checkbox")
		{
			if (checkBoxs[i].checked)
			{
				checkedElementCount ++;
			}
		}
	}

	if (checkedElementCount == 0)
	{
		alert("请选择要处理的记录");
		return false;
	}
	
	return true;	
}

function VerifyImportOperation()
{
   if (! SelectSingleItem())
   {
       return false;
   }
   
   	var statusVerifyResult = VerifyImportTemplateStatus();
	if (! statusVerifyResult)
	{
	    alert("模板实例状态为开发中或测试未通过的才可以进行导入！");
	    return false;
	}
	
	return confirm('导入模板将会花费很长时间，是否继续？');
}

function VerifyEditOperation()
{
   if (! SelectSingleItem())
   {
       return false;
   }
   
   	var statusVerifyResult = VerifyTemplateStatus();
	if (! statusVerifyResult)
	{
	    alert("无法执行此操作，模板实例状态为开发中的才可以进行编辑！");
	    return false;
	}
	
	return  true;
}

		
function VerifySubmitOperation()
{
   if (! SelectSingleItem())
   {
       return false;
   }
   
   	var statusVerifyResult = VerifyTemplateStatus();
	if (! statusVerifyResult)
	{
	    alert("无法执行此操作，模板实例状态为开发中的才可以进行提交！");
	    return false;
	}
	
	return true;
}

function VerifyDeleteOperation()
{
   if (! SelectMultipleItems())
   {
       return false;
   }
   
	var statusVerifyResult = VerifyTemplateStatus();
	if (! statusVerifyResult)
	{
	    alert("无法执行此操作，模板实例状态为开发中的才可以进行删除！");
	    return false;
	}
			
	return confirm("确定删除操作?");
}