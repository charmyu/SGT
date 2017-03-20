////////// JS theme file for PopCalendarXP 9.0 /////////
// This file is totally configurable. You may remove all the comments in this file to minimize the download size.
// Since the plugins are loaded after theme config, sometimes we would redefine(override) some theme options there for convenience.
////////////////////////////////////////////////////////

// ---- PopCalendar Specific Options ----
var gsSplit="-";	// separator of date string. If set it to empty string, then giMonthMode and gbPadZero will be fixed to 0 and true.
var giDatePos=2;	// date format sequence  0: D-M-Y ; 1: M-D-Y; 2: Y-M-D
var gbPadZero=true;	// whether to pad the digits with 0 in the left when less than 10.
var giMonthMode=0;	// month format 0: digits ; 1: full name from gMonths; >2: abbreviated month name in specified length.
var gbShortYear=false;   // year format   true: 2-digits; false: 4-digits
var gbAutoPos=true;	// enable auto-adpative positioning or not
var gbPopDown=true;	// true: pop the calendar below the dateCtrl; false: pop above if gbAutoPos is false.
var gbAutoClose=true;	// whether to close the calendar after selecting a date.
var gPosOffset=[0,0];	// Offsets used to adjust the pop-up postion, [leftOffset, topOffset].
var gbFixedPos=false;	// true: pop the calendar absolutely at gPosOffset; false: pop it relatively.

// ---- Common Options ----
var gMonths=["一月","二月","三月","四月","五月","六月","七月","八月","九月","十月","十一月","十二月"];
var gWeekDay=["日","一","二","三","四","五","六"];	// weekday caption from Sunday to Saturday

var gBegin=[1949,1,1];	// calendar date range begin from [Year,Month,Date]. Using gToday here will make it start from today.
var gEnd=[2015,12,31];	// calendar date range end at [Year,Month,Date]
var gsOutOfRange="对不起，你选择的日期超出了范围";	// out-of-date-range error message. If set to "", no alerts will popup on such error.
var guOutOfRange=null;	// the background image url for the out-range dates. e.g. "outrange.gif"

var giFirstDOW=0;	// indicates the first day of week. 0:Sunday; 1-6:Monday-Saturday.

var gcCalBG="#c4d8f2";	// the background color of the outer calendar panel.
var guCalBG=null;	//  the background image url for the inner table.
var gcCalFrame="#8ca8d8";	// the background color of the inner table, showing as a frame.
var gsInnerTable="border=0 cellpadding=2 cellspacing=1";	// HTML tag properties of the inner <table> tag, which holds all the calendar cells.
var gsOuterTable=NN4?"border=1 cellpadding=3 cellspacing=0":"border=0 cellpadding=0 cellspacing=2";	// HTML tag properties of the outmost container <table> tag, which holds the top, middle and bottom sections.

var gbHideTop=false;	// true: hide the top section; false: show it according to the following settings
var giDCStyle=0;	// the style of month-controls in top section.	0: use predefined html dropdowns & gsNavPrev/Next; 1: use gsCalTitle & gsNavPrev/Next; 2: use only gsCalTitle;
var gsCalTitle="gMonths[gCurMonth[1]-1]+' '+gCurMonth[0]";	// dynamic statement to be eval()'ed as the title when giDCStyle>0.
var gbDCSeq=true;	// (effective only when giDCStyle is 0) true: show month box before year box; false: vice-versa;
var gsYearInBox="i";	// dynamic statement to be eval()'ed as the text shown in the year box. e.g. "'A.D.'+i" will show "A.D.2001"
var gsNavPrev="<INPUT id='navPrev' type='button' value='&lt;' class='MonthNav' onmousedown='showPrevMon()' onmouseup='stopShowMon()' onmouseout='stopShowMon();if(this.blur)this.blur()'>";	// the content of the left month navigator
var gsNavNext="<INPUT id='navNext' type='button' value='&gt;' class='MonthNav' onmousedown='showNextMon()' onmouseup='stopShowMon()' onmouseout='stopShowMon();if(this.blur)this.blur()'>";	// the content of the right month navigator

var gbHideBottom=false;	// true: hide the bottom section; false: show it with gsBottom.
var gsBottom=(NN4?"":"<DIV class='BottomDiv'>")+"<A href='javascript:void(0)' class='BottomAnchor' onclick='if(this.blur)this.blur();if(!fSetDate(gToday[0],gToday[1],gToday[2]))alert(\"不能选择今天的日期!\");return false;' onmouseover='return true;' >今天</A>&nbsp;&nbsp;&nbsp;<A class='BottomAnchor' href='javascript:void(0)' onclick='if(this.blur)this.blur();fClearSelected();return false;' onmouseover='return true;'>清除</A>"+(NN4?"":"</DIV>");

var giCellWidth=18;	// calendar cell width;
var giCellHeight=14;	// calendar cell height;
var giHeadHeight=14;	// calendar head row height;
var giWeekWidth=14;	// calendar week-number-column width;
var giHeadTop=1;	// calendar head row top offset;
var giWeekTop=0;	// calendar week-number-column top offset;

var gcCellBG="#ffffff";	// default background color of the cells. Use "" for transparent!!!
var gsCellHTML="";	// default HTML contents for days without any agenda, usually an image tag.
var guCellBGImg="";	// url of default background image for each calendar cell.
var gsAction=" ";	// default action to be eval()'ed on everyday except the days with agendas, which have their own actions defined in agendas.
var gsDays="dayNo";	// the dynamic statement to be eval()'ed into each day cell.

var giWeekCol=-1;	// -1: disable week-number-column;  0~7: show week numbers at the designated column.
var gsWeekHead="#";	// the text shown in the table head of week-number-column.
var gsWeeks="weekNo";	// the dynamic statement to be eval()'ed into the week-number-column. e.g. "'week '+weekNo" will show "week 1", "week 2" ...

var gcWorkday="black";	// Workday font color
var gcSat="black";	// Saturday font color
var gcSatBG="#c5ddff";	// Saturday background color
var gcSun="black";	// Sunday font color
var gcSunBG="#c5ddff";	// Sunday background color

var gcOtherDay="silver";	// the font color of days in other months; It's of no use when giShowOther is set to hide.
var gcOtherDayBG=gcCellBG;	// the background color of days in other months. when giShowOther set to hiding, it'll substitute the gcOtherDay.
var giShowOther=2;	// control the look of days in OTHER months. 1: show date & agendas effects; 2: show selected & today effects; 4: hide days in previous month; 8: hide days in next month; 16: when set with 4 and/or 8, the days will be visible but not selectable.  NOTE: values can be added up to create mixed effects.

var gbFocus=true;	// whether to enable the gcToggle highlight whenever mouse pointer focuses over a calendar cell.
var gcToggle="yellow";	// the highlight color for the focused cell

var gcFGToday="red";	// the font color for today 
var gcBGToday="#e7f1fd";	// the background color for today 
var guTodayBGImg="";	// url of image as today's background
var giMarkToday=1+2; // Effects for today - 0: nothing; 1: set background color with gcBGToday; 2: draw a box with gcBGToday; 4: bold the font; 8: set font color with gcFGToday; 16: set background image with guTodayBGImg; - they can be added up to create mixed effects.
var gsTodayTip="Today";	// tooltip for today

var gcFGSelected="white";	// the font color for the selected date
var gcBGSelected="#DB5141";	// the background color for the selected date
var guSelectedBGImg="";	// url of image as background of the selected date
var giMarkSelected=2;	// Effects for selected date - 0: nothing; 1: set background color with gcBGSelected; 2: draw a box with gcBGSelected; 4: bold the font; 8: set font color with gcFGSelected; 16: set background image with guSelectedBGImg; - they can be added up to create mixed effects.
var gsSelectedTip="";	// tooltip for selected dates

var gbBoldAgenda=true;	// whether to boldface the dates with agendas.
var gbInvertBold=false;	// true: invert the boldface effect set by gbBoldAgenda; false: no inverts.
var gbShrink2fit=true;	// whether to hide the week line if none of its day belongs to the current month.
var gdSelect=[0,0,0];	// default selected date in format of [year, month, day]; [0,0,0] means no default date selected.
var giFreeDiv=0;	// The number of absolutely positioned layers you want to customize, they will be named as "freeDiv0", "freeDiv1"...
var gAgendaMask=[-1,-1,-1,null,null,-1,null];	// [message, action, bgcolor, fgcolor, bgimg, boxit, html] - Set the relevant bit to -1 to keep the original agenda/event value of that bit intact. Any other value will be used to override the original one defined in agenda.js. Check the tutorial for details.

var giResizeDelay=KO3?150:50;	// delay in milliseconds before resizing the calendar panel. Calendar may have incorrect initial size if this value is too small.
var gbFlatBorder=false;	// flat the .CalCell css border of any agenda date by setting it to solid style. NOTE: it should always be set to false if .CalCell has no explicit border size.
var gbInvertBorder=false;	// true: invert the effect caused by gbFlatBorder; false: no change.
var gbShareAgenda=false;	// if set to true, a global agenda store will be created and used to share across calendars. Check tutorials for details.
var gsAgShared="gContainer._cxp_agenda";	// shared agenda store name used when gbShareAgenda is true.
var gbCacheAgenda=false;	// false: will prevent the agenda url from being cached; true: cached as normal js file.
var giShowInterval=250;	// interval time in milliseconds that controls the auto-traverse speed.

/////////////////// Plug-in file for CalendarXP 9.0 /////////////////
// This file is totally configurable. You may remove all the comments in this file to minimize the download size.
/////////////////////////////////////////////////////////////////////

///////////// Calendar Onchange Handler ////////////////////////////
// It's triggered whenever the calendar gets changed to y(ear),m(onth),d(ay)
// d = 0 means the calendar is about to switch to the month of (y,m); 
// d > 0 means a specific date [y,m,d] is about to be selected.
// e is a reference to the triggering event object
// Return a true value will cancel the change action.
// NOTE: DO NOT define this handler unless you really need to use it.
////////////////////////////////////////////////////////////////////
// function fOnChange(y,m,d,e) {}


///////////// Calendar AfterSelected Handler ///////////////////////
// It's triggered whenever a date gets fully selected.
// The selected date is passed in as y(ear),m(onth),d(ay)
// e is a reference to the triggering event object
// NOTE: DO NOT define this handler unless you really need to use it.
////////////////////////////////////////////////////////////////////
function fAfterSelected(y,m,d,e) {if(parent.CalanderAfterSelected) parent.CalanderAfterSelected(y,m,d,e);}


///////////// Calendar Cell OnDrag Handler ///////////////////////
// It triggered when you try to drag a calendar cell. (y,m,d) is the cell date. 
// aStat = 0 means a mousedown is detected (dragstart)
// aStat = 1 means a mouseover between dragstart and dragend is detected (dragover)
// aStat = 2 means a mouseup is detected (dragend)
// e is a reference to the triggering event object
// NOTE: DO NOT define this handler unless you really need to use it.
//       If you use fRepaint() here, fAfterSelected() will be ignored.
////////////////////////////////////////////////////////////////////

// function fOnDrag(y,m,d,aStat,e) {}



////////////////// Calendar OnResize Handler ///////////////////////
// It's triggered after the calendar panel has finished drawing.
// NOTE: DO NOT define this handler unless you really need to use it.
////////////////////////////////////////////////////////////////////
// function fOnResize() {}


////////////////// Calendar fOnWeekClick Handler ///////////////////////
// It's triggered when the week number is clicked.
// NOTE: DO NOT define this handler unless you really need to use it.
////////////////////////////////////////////////////////////////////
// function fOnWeekClick(year, weekNo) {}

////////////////// Calendar fOnDoWClick Handler ///////////////////////
// It's triggered when the week head (day of week) is clicked.
// dow ranged from 0-6 while 0 denotes Sunday, 6 denotes Saturday.
// NOTE: DO NOT define this handler unless you really need to use it.
////////////////////////////////////////////////////////////////////
// function fOnDoWClick(year, month, dow) {}


////////////////// Calendar fIsSelected Callback ///////////////////////
// It's triggered for every date passed in as y(ear) m(onth) d(ay). And if 
// the return value is true, that date will be rendered using the giMarkSelected,
// gcFGSelected, gcBGSelected and guSelectedBGImg theme options.
// NOTE: If NOT defined here, the engine will create one that checks the gdSelect only.
////////////////////////////////////////////////////////////////////
// function fIsSelected(y,m,d) {
//		return gdSelect[2]==d&&gdSelect[1]==m&&gdSelect[0]==y;
// }


////////////////// Calendar fParseInput Handler ///////////////////////
// Once defined, it'll be used to parse the input string stored in gdCtrl.value.
// It's expected to return an array of [y,m,d] to indicate the parsed date,
// or null if the input str can't be parsed as a date.
// NOTE: If NOT defined here, the engine will create one matching fParseDate().
////////////////////////////////////////////////////////////////////
// function fParseInput(str) {}


////////////////// Calendar fFormatInput Handler ///////////////////////
// Once defined, it'll be used to format the selected date - y(ear) m(onth) d(ay)
// into gdCtrl.value.
// It's expected to return a formated date string.
// NOTE: If NOT defined here, the engine will create one matching fFormatDate().
////////////////////////////////////////////////////////////////////
// function fFormatInput(y,m,d) {}


////////////////// Calendar fOnload Handler ///////////////////////
// It's triggered when the calendar engine is fully loaded by the browser.
// NOTE: DO NOT define this handler unless you really need to use it.
////////////////////////////////////////////////////////////////////
function fOnload() {
	fInitLayer();
}


// ====== predefined utility functions for use with agendas. ========

// load an url in the window/frame designated by "framename".
function popup(url,framename) {	
	var w=parent.open(url,framename,"top=200,left=200,width=400,height=200,scrollbars=1,resizable=1");
	if (w&&url.split(":")[0]=="mailto") w.close();
	else if (w&&!framename) w.focus();
}

// ====== Following are self-defined and/or custom-built functions! =======


var _startc,_endc;
function fStartPop(startc,endc) {
  _startc=startc;
  _endc=endc;
  var sd=fParseInput(endc.value); 
  if (!sd) sd=gEnd;
  fPopCalendar(startc, [gBegin,sd,sd]);
}

function fEndPop(startc,endc) {
  _startc=startc;
  _endc=endc;
  var sd=fParseInput(startc.value);
  if (!sd) sd=gBegin; 
  fPopCalendar(endc, [sd,gEnd,sd]);
}

function fClearSelected() { // clear the date field and reset the dynamic range.
  if(_startc != null)
  _startc.value="";
  if(_endc != null)
  _endc.value="";
  fUpdSelect(0,0,0);
  gRange=[gBegin,gEnd];
  gdBegin=new Date(gBegin[0],gBegin[1]-1,gBegin[2]);
  gdEnd=new Date(gEnd[0],gEnd[1]-1,gEnd[2]);
  fRepaint();
}




// ======= the following plugin is coded for the artificial internal dropdown seletors ========
// You may change the left,top in the fPopMenu() to adjust the popup position.
// Other Settings
var _highlite_background="black";	// highlight background color
var _highlite_fontColor="white";	// highlight font color
var _pop_length=7;	// how many months to be shown
var _pop_width=80;	// pixels of the popup width

// Override the gsCalTitle option to popup a date-selector layer. Remember to keep it as an expression or a function returning a string.
gsCalTitle="fGetCalTitle()";
function fGetCalTitle() {
	return "&nbsp;<a class='PopAnchor' href='javascript:void(0);' onclick='if(this.blur)this.blur();fPopMenu(this,event);return false;'>"+gMonths[gCurMonth[1]-1]+(NN4?" ":"</a> <a id='yearAnchor' class='PopAnchor' href='javascript:void(0)' onclick='fToggleLayer(1,true);fGetById(document,\"yearInput\").focus();return false;'>")+gCurMonth[0]+"</a>";
}
if(NN4)_nn4_css.push("YearBox"); // work around NN4 bug
giFreeDiv=2;
function fInitLayer() { // gets called from within fOnload()
	if (NN4) return;
	var lyr=fGetById(document,"freeDiv1");
	lyr.style.top=(SA?2:IE&&!MAC?0:6)+"px"; lyr.style.left=(SA?63:65)+"px"; lyr.style.border=0;
	fDrawLayer(1,"<input class='YearBox' id='yearInput' value='' maxlength=4 size=4 onkeyup='if(this.value.length==4){if(!isNaN(this.value))fSetCal(this.value,gCurMonth[1],0,true,event);this.select();this.blur()}' onblur='fToggleLayer(1,false);if(SA)this.blur()' onfocus='this.value=gCurMonth[0];this.select()' onclick='this.select()' onselectstart='event.cancelBubble=true'>");
}


function fPopMenu(dc,e) {
	var lyr=NN4?document.freeDiv0:fGetById(document,"freeDiv0");
	var bv=NN4?lyr.visibility=="show":lyr.style.visibility=="visible";
	if (bv) { fToggleLayer(0,false); return; }
	fSetDPop(gCurMonth[0],gCurMonth[1]);
	if (NN4) with (lyr) {
		left=25;
		top=22;
	} else with (lyr.style) {
		left=25+"px";
		top=4+"px";
	}
	fToggleLayer(0,true);
}

var _tmid=null;
function fSetDPop(y,m) {
	var mi=_pop_length;
	var wd=_pop_width;
	var sME=NN4||IE4?"":" onmouseover='fToggleColor(this,0)' onmouseout='fToggleColor(this,1)' ";	// menu-item focus background-color
	var padstr="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
	var cm=fCalibrate(y,m);
	var a=[NN4||IE4||IE&&MAC?"<table border=1 cellspacing=0 cellpadding=0><tr><td>":"","<div onmouseover='clearTimeout(_tmid)' onmouseout='_tmid=setTimeout(\"fToggleLayer(0,false)\",100)'><table class='PopMenu' border=0 cellspacing=0 cellpadding=0>"];
	if(!fBfRange(cm[0],cm[1]))a.push("<tr><td align='center' class='PopMenuItem' nowrap width=",wd,sME," onclick='fSetDPop(",cm[0],",",cm[1]-mi,")'><a class='PopMenuItem' href='javascript:void(0)' onclick='if(NN4)fSetDPop(",cm[0],",",cm[1]-mi,");return false;'>",padstr,"-",padstr,"</a></td></tr>");
	for (var i=0;i<mi;i++) {
		var lm=fCalibrate(cm[0],cm[1]+i);
		if (!fIsOutRange(lm[0],lm[1]))
			a.push("<tr><td align='center' class='PopMenuItem' nowrap width=",wd,sME," onclick='fToggleLayer(0,false);fSetCal(",lm[0],",",lm[1],",0,true,event);'><a class='PopMenuItem' href='javascript:void(0)' onclick='if(NN4)fSetCal(",lm[0],",",lm[1],",0,true,event);return false;'>",gMonths[lm[1]-1]," ",lm[0],"</a></td></tr>");
	}
	if(!fAfRange(lm[0],lm[1]))a.push("<tr><td align='center' class='PopMenuItem' nowrap width=",wd,sME," onclick='fSetDPop(",cm[0],",",cm[1]+mi,")'><a class='PopMenuItem' href='javascript:void(0)' onclick='if(NN4)fSetDPop(",cm[0],",",cm[1]+mi,");return false;'>",padstr,"+",padstr,"</a></td></tr>")
	a.push("</table></div>",NN4||IE4||IE&&MAC?"</td></tr></table>":"");
	fDrawLayer(0,a.join(''));
}

var _cPair=[];
function fToggleColor(obj,n) {
	if (NN4||IE4) return;
	if (n==0) { // mouseover
		_cPair[0]=obj.style.backgroundColor;
		obj.style.backgroundColor=_highlite_background;
		_cPair[1]=obj.firstChild.style.color;
		obj.firstChild.style.color=_highlite_fontColor;
	} else {
		obj.style.backgroundColor=_cPair[0];
		obj.firstChild.style.color=_cPair[1];
	}
}

function fToggleLayer(id,bShow) {
	var lyr=NN4?eval("document.freeDiv"+id):fGetById(document,"freeDiv"+id);
	if (NN4) lyr.visibility=bShow?"show":"hide";
	else lyr.style.visibility=bShow?"visible":"hidden";
}

function fDrawLayer(id,html) {
	var lyr=NN4?eval("document.freeDiv"+id):fGetById(document,"freeDiv"+id);
	if (IE4||IE&&MAC) lyr.style.border="0px";
	if (NN4) with (lyr.document) {
		clear(); open();
		write(html);
		close();
	} else {
		lyr.innerHTML=html+"\n";
	}
}


// ======= end of dropdown plugin ========
