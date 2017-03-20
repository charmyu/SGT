function sAlert(){  
    var   msgw,msgh,bordercolor;     
    msgw=450;//提示窗口的宽度     
    msgh=200;//提示窗口的高度     
    titleheight=25   //提示窗口标题高度     
    bordercolor="#336699";//提示窗口的边框颜色     
    titlecolor="#99CCFF";//提示窗口的标题颜色     
       
    var   sWidth,sHeight;     
    sWidth=document.body.offsetWidth;//浏览器工作区域内页面宽度     
    sHeight=document.body.offsetHeight;//屏幕高度（垂直分辨率）     
   
   
    //背景层（大小与窗口有效区域相同，即当弹出对话框时，背景显示为放射状透明灰色）     
    var   bgObj=document.createElement("div");//创建一个div对象（背景层）     
        
    //定义div属性，即相当于     
    // <div   id="bgDiv"   style="position:absolute;   top:0;   background-color:#777;   filter:progid:DXImagesTransform.Microsoft.Alpha(style=3,opacity=25,finishOpacity=75);   opacity:0.6;   left:0;   width:918px;   height:768px;   z-index:10000;"> </div>     
    
    bgObj.setAttribute("id","bgDiv");    
    //alert("***********")    
    bgObj.style.position="absolute";     
    bgObj.style.top="0";     
    bgObj.style.background="#777";     
    bgObj.style.filter="progid:DXImageTransform.Microsoft.Alpha(style=3,opacity=25,finishOpacity=75)";     
    bgObj.style.opacity="0.6";     
    bgObj.style.left="0";     
    bgObj.style.width=sWidth   +  "px";     
    bgObj.style.height=sHeight   +  "px";     
    bgObj.style.zIndex   =  "10000";     
    document.body.appendChild(bgObj);//在body内添加该div对象     
   
   	document.getElementById("msgDiv").style.display="";

   	var linkURL = document.getElementById("ctl00_ContentPlaceHolderPage_txtLinkURL");

   	if (linkURL) {
   	    linkURL.value = "http://";
   	}
} 

function   removeObj(){//点击标题栏触发的事件     
    document.body.removeChild(document.getElementById("bgDiv"));//删除背景层Div     
    document.getElementById("msgDiv").style.display="none";        
}   

function updateMsgbox(){  
    var   msgw,msgh,bordercolor;     
    msgw=450;//提示窗口的宽度     
    msgh=200;//提示窗口的高度     
    titleheight=25   //提示窗口标题高度     
    bordercolor="#336699";//提示窗口的边框颜色     
    titlecolor="#99CCFF";//提示窗口的标题颜色     
       
    var   sWidth,sHeight;     
    sWidth=document.body.offsetWidth;//浏览器工作区域内页面宽度     
    sHeight=document.body.offsetHeight;//屏幕高度（垂直分辨率）     
   
   
    //背景层（大小与窗口有效区域相同，即当弹出对话框时，背景显示为放射状透明灰色）     
    var   bgObj=document.createElement("div");//创建一个div对象（背景层）     
        
    //定义div属性，即相当于     
    // <div   id="bgDiv"   style="position:absolute;   top:0;   background-color:#777;   filter:progid:DXImagesTransform.Microsoft.Alpha(style=3,opacity=25,finishOpacity=75);   opacity:0.6;   left:0;   width:918px;   height:768px;   z-index:10000;"> </div>     
    
    bgObj.setAttribute("id","bgDiv");    
    //alert("***********")    
    bgObj.style.position="absolute";     
    bgObj.style.top="0";     
    bgObj.style.background="#777";     
    bgObj.style.filter="progid:DXImageTransform.Microsoft.Alpha(style=3,opacity=25,finishOpacity=75)";     
    bgObj.style.opacity="0.6";     
    bgObj.style.left="0";     
    bgObj.style.width=sWidth   +  "px";     
    bgObj.style.height=sHeight   +  "px";     
    bgObj.style.zIndex   =  "10000";     
    document.body.appendChild(bgObj);//在body内添加该div对象     
   
   	document.getElementById("updateMsgDiv").style.display="";
    
}

function removeUpdateObj(){//点击标题栏触发的事件     
    document.body.removeChild(document.getElementById("bgDiv"));//删除背景层Div     
    document.getElementById("updateMsgDiv").style.display="none";        
}   
