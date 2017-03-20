<!--
var bColor='#fbdda2'; //定义颜色,为单击时显示的颜色
var fColor='#000000'; //定义颜色,为单击时字体所显示的颜色
function tdOver(td)
{
	if(td.style.backgroundColor!=bColor)//当这一列的背景颜色不为以上定义的颜色时
	{
		td.setAttribute('DtBg',td.style.backgroundColor);//得到这列的背景颜色并且设置为DtBg
		td.setAttribute('DtCo',td.style.color);//得到这列的字体颜色并且设置为DtCo
		
		td.style.color='#000000';//设置鼠标移上时列里的字体颜色为#ff99ff
		//td.style.cursor='hand';//设置鼠标的形状为手状
		td.style.backgroundColor='#E1D6FB';//设置该列的背景颜色为#66cc66
	}
}
function tdOut(td)
{
	if(td.style.backgroundColor!=bColor)//当这一列的背景颜色不为以上定义的颜色时
	{
		td.style.backgroundColor=td.getAttribute('DtBg');//设置该列的背景颜色为以上得到的颜色,即DtBg
		td.style.color=td.getAttribute('DtCo');//设置该列的背景颜色为以上得到的颜色,即DtCo
	}
}
function clearTdColor(tdc)
{
	var tdColl=document.all.tags('TR');//得到所有的行
	bc=tdc.getAttribute('Dtbg');//得到该列的背景颜色(在tdOver方法中setAttribute)
	cc=tdc.getAttribute('DtCo');//得到该列的字体颜色(在tdOver方法中setAttribute)
	for(i=0;i<tdColl.length;i++)//循环行
	{
		whichTD = tdColl[i];//得到当前的行
		if(whichTD.style.backgroundColor==bColor)//如果该单元格为开始时设置的颜色,即bColor
		{
			//说明:如果你的DataGrid不分普通列和交替列,则使用以下代码,清除颜色
			whichTD.style.backgroundColor=bc;//设置该单元格的颜色为得到的颜色
			whichTD.style.color=cc;//设置该单元格的字体颜色为得到的颜色
			whichTD.style.fontWeight='';
			break;
			
			//如果你的DataGrid分普通列和交替列,而且交替列有颜色,则使用以下代码,清除颜色
			
			/*if(i%2!=0)
			{
				whichTD.style.backgroundColor="";
				whichTD.style.color="";
				whichTD.style.fontWeight='';
				break;
			}
			else
			{
				whichTD.style.backgroundColor="#CCFFFF"; //#CCFFFF为设置的DataGrid交替项的颜色(可以根据自己的需要修改)
				whichTD.style.color="";
				whichTD.style.fontWeight='';
				break;
			}
			*/
		}
	}
}
function tdColor(tdc)
{
	clearTdColor(tdc);//首先清楚所有的颜色
	bc=tdc.getAttribute('Dtbg');//得到该列的背景颜色(在tdOver方法中setAttribute)
	cc=tdc.getAttribute('DtCo');//得到该列的字体颜色(在tdOver方法中setAttribute)
	tdcs=tdc.style.backgroundColor;//得到该列当前的颜色(即鼠标移至单元格时的颜色)
	//if(event.srcElement.tagName!='A')//event.srcElement.tagName就是触发的单元格的名称,即TD
	//{
		if(tdcs!=bColor)//如果该列的当前颜色不等于开始是定义的颜色时
		{
			tdc.style.backgroundColor=bColor;//设置背景颜色为开始定义的颜色
			tdc.style.color=fColor;//设置背景颜色为开始定义的字体颜色
			tdc.style.fontWeight='500';
		}
		else
		{
			tdc.style.backgroundColor=bc;//设置背景颜色(为在tdOver方法中setAttribute)
			tdc.style.color=cc;//设置背景颜色为(在tdOver方法中setAttribute)
			tdc.style.fontWeight='';
		}
	//}
	
	//单击选中 add By Andy Luo 20090622
	if(window.event.srcElement.type == "checkbox"  || window.event.srcElement.type == "radio"  )
	   return;
	   
    try
    {
        if((tdc.cells[0].firstChild.type == "checkbox" || tdc.cells[0].firstChild.type == "radio") && !tdc.cells[0].firstChild.disabled)
        {
            if(tdc.cells[0].firstChild.checked)
                tdc.cells[0].firstChild.checked = false;
            else
                tdc.cells[0].firstChild.checked = true;
        }
     }
     catch(e)
     {}

	//end add
}
function tdColorDbl(tdc)//清除该列的颜色
{
	clearTdColor(tdc);
}
-->
