

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
 function SaveAllSelectedHiddenGroup(chk,hiddenFieldName,selectedHiddenFieldName)
{
	if (hiddenFieldName == null ||
	    hiddenFieldName == "undefined" ||	
	    selectedHiddenFieldName == null ||
	    selectedHiddenFieldName =="undefined") 
	{
		return;
	}
	
    var selectedHidden = document.getElementById(selectedHiddenFieldName);
	if (selectedHidden == "undefined")
	{
		return;
	}
	
	selectedHidden.value = "";
	var hidGroup = document.getElementsByName(hiddenFieldName);
    if(hidGroup.length == 0 || hidGroup.length == "undefined" || chk.checked == false)
    {
        return;
    }
    
	for( var i=0; i<hidGroup.length;i++)
	{
		if(! hidGroup[i].disabled)
		{
			if(i == 0) 
			{
				selectedHidden.value = selectedHidden.value + hidGroup[i].value;
			}
			else   
			{
				selectedHidden.value = selectedHidden.value + "-" + hidGroup[i].value;
			}
		}
	}    
} 

function SaveCurrentSelectedHiddenGroup(chk,currentHiddenValue,selectedHiddenFieldName)
{
	if (selectedHiddenFieldName == null || selectedHiddenFieldName =="")
	{
		return;
	}
	
    var SelectedHiddenField =document.getElementById(selectedHiddenFieldName);
    if(SelectedHiddenField == null || SelectedHiddenField == "undefined" )
    {
		return;
	}
	
	// when Current CheckBox is selected, Form need  append the current Status
	if(chk.checked)
	{
		if(SelectedHiddenField.value == "")
		{
			SelectedHiddenField.value = currentHiddenValue;
		}
		else
		{
			SelectedHiddenField.value = SelectedHiddenField.value + "-" + currentHiddenValue;
		}
		
		return;
	} 

	// when unSelect current CheckBox
	var x = SelectedHiddenField.value.indexOf(currentHiddenValue);
	var y = SelectedHiddenField.value.indexOf("-");

	if(x == "0")
	{
		if(y == "-1")
		{
			SelectedHiddenField.value = SelectedHiddenField.value.replace(currentHiddenValue,"");
		}
		else
		{
			SelectedHiddenField.value = SelectedHiddenField.value.replace(currentHiddenValue+"-","");
		}
	}
	else
	{
		SelectedHiddenField.value = SelectedHiddenField.value.replace("-"+currentHiddenValue,"");
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
        if (hiddenStatusArray[i] != "Test")
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
   	
    var hidSelectedTemplateOnSandBoxID = document.getElementById("hidSelectedTemplateOnSandBoxID");
    if (hidSelectedTemplateOnSandBoxID == "undefined")
    {
        return false;
    }

    var sandBoxID = hidSelectedTemplateOnSandBoxID.value;
    if (sandBoxID != "0")
    {
	    alert("无法执行模板导入操作，当前模板已经在测试沙箱中。");
        return false;
    }	
    return true;
}

function VerifyExportOperation()
{
    if (! SelectSingleItem())
    {
       return false;
    }
   
    var hidSelectedTemplateOnSandBoxID = document.getElementById("hidSelectedTemplateOnSandBoxID");
    if (hidSelectedTemplateOnSandBoxID == "undefined")
    {
        return false;
    }

    var sandBoxID = hidSelectedTemplateOnSandBoxID.value;
    if (sandBoxID == "0")
    {
	    alert("无法执行模板导出操作，当前模板必须在测试沙箱中！");
        return false;
    }
    
	return true;
}


function VerifyIssueSubmitOperation()
{
   if (! SelectSingleItem())
   {
       return false;
   }
   
   	var statusVerifyResult = VerifyTemplateStatus();
	if (! statusVerifyResult)
	{
	    alert("无法执行测试意见提交操作，接受的模板实例状态必须为待测试。");
	    return false;
	}
	
	return  true;
}

		
function VerifyTestAuditOperation()
{
   if (! SelectSingleItem())
   {
       return false;
   }
   
   	var statusVerifyResult = VerifyTemplateStatus();
	if (! statusVerifyResult)
	{
	    alert("无法执行测试审核提交操作，接受的模板实例状态必须为待测试！");
	    return false;
	}
	
	return true;
}