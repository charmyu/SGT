//-------------------------------------------------------------------
//版权所有：版权所有(C) 2008，Microsoft(China) Co.,LTD
//系统名称：公用Form验证模块
//文件名称：form_validator.js
//模块名称：公用Form验证模块

//模块编号：

//作　　者：Hu LiJun
//完成日期：
//功能说明：公用Form验证模块

//-----------------------------------------------------------------
//修改记录：

//修改人：  
//修改时间：

//修改内容：





///CSS定义区
var infoboxOkClass="OkMsg";
var infoboxWarningClass="WarningMsg";
var infoboxErrorClass="ErrorMsg";
var infoboxHintClass="HintMsg";
var inputWarningClass="Warning";
var inputErrorClass="Error";
var inputOkClass="Ok";
var inputNormalClass="Normal";


function initForm(){
	var infobox;
	var x=document.getElementById("Content");
	if(!x)return;
	var y=x.getElementsByTagName("input");
	for(var i=0;i<y.length;i++){
		if(y[i].type=='text'||y[i].type=='password'){
			initStatus(y[i],true);
			setFiledWidth(y[i]);
			y[i].onfocus=getFocus;
			y[i].onblur=lostFocus;
			y[i].onkeyup=showMyStatus;
		}
		if(y[i].type=="checkbox"){
			initStatus(y[i],false);
			y[i].onfocus=getFocus;
			y[i].onblur=lostFocus;
			y[i].onkeyup=showMyStatus;
		}
	}
}


function initStatus(obj,isInput){
	if(isInput){
		if(isRequired(obj))showStatus(obj,"Warning");
		else showStatus(obj,"Normal");
	}
	var infobox=getInfobox(obj);
	var errorCode=getInitStatus(obj);
	if(infobox&&infobox.innerHTML==""){
			if(!errorCode||errorCode==0){
				infobox.className=infoboxHintClass;
				infobox.innerHTML=getErrorMsg(obj,0);
			}
		if(errorCode>0){
			infobox.className=infoboxErrorClass;
			infobox.innerHTML=getErrorMsg(obj,errorCode);
		}
	}
}


function isIE(){if(document.all)return true;return false;}


function setFiledWidth(obj){obj.style.width=(19/3)*obj.size+11;}


function formEle(required,datatype,parameter,infobox,errormsg,combine,status){
	this.r=required;
	this.d=datatype;
	this.p=parameter;
	this.i=infobox;
	this.e=errormsg;
	this.c=combine;
	this.s=status;
}


function isRequired(obj){
	if(obj.id){
		if(eval(obj.id).r)
			return eval(obj.id).r;
		}
	return false;
}


function isCombine(obj){
	if(obj.id){
		if(eval(obj.id).c)return eval(obj.id).c;
	}
	return false;
}


function getDatatype(obj){
	if(obj.id){
		if(eval(obj.id).d)return eval(obj.id).d;
	}
	return false;
}


function getInfobox(obj){
	if(obj&&obj.id&&window[obj.id]&&window[obj.id].i){
		var oi=window[obj.id].i;
		var o=document.getElementById(oi);
		if(o){return o;}
	}
	return;
}


function getErrorMsg(obj,errorCode){
	if(obj.id){
		if(eval(obj.id).e[errorCode])return eval(obj.id).e[errorCode];
	}
	return;
}


function getHintMsg(obj){
	if(obj.id){
		if(eval(obj.id).e[0])return eval(obj.id).e[0];
	}
	return;
}


function getInitStatus(obj){
	if(obj.id){
		if(eval(obj.id).s||eval(obj.id).s==0)return eval(obj.id).s;
	}
	return;}


function getAttrName(str){var s=str.split("=");return s[0];}


function getAttrValue(str){var s=str.split("=");return s[1];}


function getAttrValueByName(obj,str){
	var para;
	if(obj.id){
		if(eval(obj.id).p)para=eval(obj.id).p;else return;
	}
	else{return;}
	var s=para.split(",");
	for(var i=0;i<s.length;i++){
		if(getAttrName(s[i])==str)
		{
			if(getAttrValue(s[i]))
				return getAttrValue(s[i]);
			else
				return;
		}
	}
	return;
}

///获取邮件服务器地址
function getMailServer(str){str=str.trim();return str.substr(str.indexOf("@")+1);}

///获取邮件用户名
function getMailAccount(str){str=str.trim();return str.substr(0,str.indexOf("@"));}



///数据判断
function isNumber(str){
	var patn=new RegExp("^\\d{1,15}$");
	if(patn.test(str)){
		return true;
	}else{
		return false;
	}
}


	//////////////////////

///字符串空格处理(有待修改)
//String.prototype.trim=function(){
//	return this.replace(/(^\s*)|(\s*$)/g,"");
//}

function getFocus(evnt){
		var obj;
		if(isIE()){
			obj=event.srcElement;
		}else{
			obj=evnt.target;
		}
		showInfo(obj,0);
	}
	
	
function lostFocus(evnt){
	var obj;
	if(isIE()){
		obj=event.srcElement;
	}else{
		obj=evnt.target;
	}
	showInfo(obj,-1);
}



function showInfo(obj,errorCode,forcible){
	var infobox=getInfobox(obj);
	if(infobox){
		if(infobox.className!=infoboxErrorClass||forcible){
			if(errorCode==0){
				infobox.className=infoboxWarningClass;infobox.innerHTML=getErrorMsg(obj,errorCode);
			}
		    if(errorCode>0){
			    infobox.className=infoboxErrorClass;
			    infobox.innerHTML=getErrorMsg(obj,errorCode);
		    }
		    if(errorCode<0){
			    infobox.className=infoboxHintClass;
		    }
	    }
    }
}


function showMyStatus(evnt){
	var obj,errorCode;
	if(isIE()){
		obj=event.srcElement;
	}else{
		obj=evnt.target;
	}
	errorCode=validateValue(obj);
	if(errorCode==0){
		showStatus(obj,"Ok");
	}
	if(errorCode>=1){
		showStatus(obj,"Error");
	}
	if(errorCode<0){
		showStatus(obj,"Normal");
	}
}


function showStatus(obj,stat){
	switch(stat){
		case"Warning":
			obj.className=inputWarningClass;
			break;
		case"Error":
			obj.className=inputErrorClass;
			break;
		case"Ok":
			obj.className=inputOkClass;
			break;
		default:
			sobj.className=inputNormalClass;
			break;
	}
}


function validateValue(obj){
	var patn=/(^\s)|(\s$)/;
	if(patn.test(obj.value))obj.value=obj.value.trim();
	var errorCode=-1;
	switch(getDatatype(obj)){
		case"username":
			errorCode=validateUsername(obj);
			break;
		case"password":
			errorCode=validatePassword(obj);
			break;
		case"safepassword":
			errorCode=validateSafePassword(obj);
			break;
		case"email":
			errorCode=validateEmail(obj);
			break;
		case"mirror":
			errorCode=validateMirror(obj);
			break;
		case"num":
			errorCode=validateNum(obj);
			break;
		case"mobile":
			errorCode=validateMobile(obj);
			break;
		case"checkcode":
			errorCode=validateCheckCode(obj);
			break;
		default:
			errorCode=-1;
			break;
	}
	return errorCode;
}



///验证页所有INPUT素，需再行修改(或其它开发它员自行调用单个控件验证)
///错误信息显示CSS：
function validateAll(formObj)
	{var obj,infobox,pass;
	pass=true;
	var x=formObj;
	if(!x)return;
	var y=x.getElementsByTagName("input");
	for(var i=0;i<y.length;i++){
		obj=y[i];
		obj.value=obj.value.trim();
		infobox=getInfobox(y[i]);
		if(obj.type=='text'||obj.type=='password'){
			//空值判断
			if(!isRequired(obj)&&obj.value==""){continue;}
			if(isRequired(obj)&&obj.value==""){
				pass=false;
				obj.focus();
				showStatus(obj,"Error");
				if(infobox){
					infobox.className=infoboxErrorClass;
					infobox.innerHTML=requireErrorInfo+getErrorMsg(obj,0);
					}
				if(isCombine(obj))break;continue;}
				if(validateValue(obj)>0){
					pass=false;
					obj.focus();
					showStatus(obj,"Error");
					showInfo(obj,validateValue(obj),true);
					if(isCombine(obj))break;continue;
				}
				if(validateValue(obj)==0){
					showStatus(obj,"Ok");
					if(infobox){
						infobox.className=infoboxHintClass;
						infobox.innerHTML=validatedInfo;
					}
				continue;
			}
		}
	}
	return pass;
}


function validateUsername(obj){
		var str=obj.value;
		var patn=/^[^\s]*$/;
		if(patn.test(str)){
			if(checkByteLength(str,5,20))return 0;
		}
		return 1;
}
	//////////////////////////
	




function validatePassword(obj){
	var str=obj.value;
	var patn=/.{6,16}/;
	if(patn.test(str))return 0;
	return 1;
}

function validateSafePassword(obj){
	var str=obj.value;
	var rank=0;
	try{
		rank=PwdIntensity(str);
		printIntensity(rank);
	}catch(er){}
	if(validatePassword(obj)>0)return 1;
	if(str==document.getElementById("username").value)return 2;
	for(var i=0;i<str.length;i++){
		if(str.charAt(0)!=str.charAt(i))break;
	}
	if(i==str.length)return 3;
	var seqStr="01234567890";
	if(seqStr.indexOf(str)!=-1)return 4;
	var seqStr="abcdefghijklmnopqrstuvwxyz";
	if(seqStr.indexOf(str)!=-1)return 5;
	var seqStr="ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	if(seqStr.indexOf(str)!=-1)return 6;
	if(rank==1){}
	return 0;
}


function validateEmail(obj){
	var str=obj.value;
	str=quanjiao2Banjiao(str);
	var patn=/^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
	if(patn.test(str)){
		var blocklist=eval(obj.id).p;
		if(blocklist.length>0){
			for(var i=0;i<blocklist.length;i++){
				if(getMailServer(obj.value)==blocklist[i])return 2;
			}
		}
		return 0;
	}else{
		return 1;
	}
}



function validateNum(obj){
	var str=obj.value;
	var patn=new RegExp("\\d{"+getAttrValueByName(obj,"minlen")+","+getAttrValueByName(obj,"maxlen")+"}");
	if(patn.test(str))return 0;return 1;
}


function validateMobile(obj){
	var str=obj.value;
	var patn=/^13\d{9}$/;
	if(patn.test(str))return 0;return 1;
}
function validateCheckCode(obj){
	var str=obj.value;
	str=quanjiao2Banjiao(str);
	var patn=/^[0-9a-zA-Z]{4}$/;
	if(patn.test(str))return 0;return 1;
}


function validateMirror(obj){
	if(validateSameAs(obj)){
		var sameobj=document.getElementById(getAttrValueByName(obj,"sameas"));
		var sameobj_dt;
		if(eval(sameobj.id).d)
			sameobj_dt=eval(sameobj.id).d;
		else 
			return-1;
		if(sameobj_dt!="mirror"){
			if(validateValue(sameobj)==0)
				return 0;
			else 
				return 2;
		}
	}
	return 1;
}



function validateSameAs(obj){
	var v1,v2;
	if(!getAttrValueByName(obj,"sameas"))return true;
	v1=obj.value;
	v2=document.getElementById(getAttrValueByName(obj,"sameas")).value;
	if(v1==v2)return true;
	return false;
}


function checkByteLength(str,minlen,maxlen){
	if(str==null)return false;
	var l=str.length;
	var blen=0;
	for(i=0;i<l;i++){
		if((str.charCodeAt(i)&0xff00)!=0){blen++;}
		blen++;
	}
	if(blen>maxlen||blen<minlen){return false;}
	return true;
}


function quanjiao2Banjiao(str){
	var i;
	var result='';
	for(i=0;i<str.length;i++){
		code=str.charCodeAt(i);
		if(code>=65281&&code<65373){
			result+=String.fromCharCode(str.charCodeAt(i)-65248);
		}
		else{
			result+=str.charAt(i);
		}
	}
	return result;
}