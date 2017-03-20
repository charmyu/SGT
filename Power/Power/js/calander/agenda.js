//////////////////// Agenda file for CalendarXP 9.0 /////////////////
// This file is totally configurable. You may remove all the comments in this file to minimize the download size.
/////////////////////////////////////////////////////////////////////

//////////////////// Define agenda events ///////////////////////////
// Usage -- fAddEvent(year, month, day, message, action, bgcolor, fgcolor, bgimg, boxit, html);
// Notice:
// 1. The (year,month,day) identifies the date of the agenda.
// 2. In the action part you can use any javascript statement, or use " " for doing nothing.
// 3. Assign "null" value to action will result in a line-through effect(can't be selected).
// 4. html is the HTML string to be shown inside the agenda cell, usually an <img> tag.
// 5. fgcolor is the font color for the specific date. Setting it to ""(empty string) will make the fonts invisible and the date unselectable.
// 6. bgimg is the url of the background image file for the specific date.
// 7. boxit is a boolean that enables the box effect using the bgcolor when set to true.
// ** REMEMBER to enable respective flags of the gAgendaMask option in the theme, or it won't work.
/////////////////////////////////////////////////////////////////////




///////////// Dynamic holiday calculations /////////////////////////
// This function provides you a flexible way to make holidays of your own. (It's optional.)
// Once defined, it'll be called every time the calendar engine renders the date cell;
// With the date passed in, just do whatever you want to validate whether it is a desirable holiday;
// Finally you should return an agenda array like [message, action, bgcolor, fgcolor, bgimg, boxit, html] 
// to tell the engine how to render it. (returning null value will make it rendered as default style)
// ** REMEMBER to enable respective flags of the gAgendaMask option in the theme, or it won't work.
////////////////////////////////////////////////////////////////////
function fHoliday(y,m,d) {
	var rE=fGetEvent(y,m,d), r=null;

	// you may have sophisticated holiday calculation set here, following are only simple examples.
	if (m==1&&d==1)
		r=[" 1月 1号 "+y+"年 \n 元旦! ",gsAction,"skyblue","red"];
	else if (m==2&&d==14)
		r=[" 2月 14号 "+y+"年 \n 情人节! ",gsAction,"skyblue","red"];
	else if (m==3&&d==8)
		r=[" 3月 8号 "+y+"年 \n 妇女节! ",gsAction,"skyblue","red"];
	else if (m==5&&d==1)
		r=[" 5月 1号 "+y+"年 \n 劳动节 ",gsAction,"skyblue","red"];
	else if (m==6&&d==1)
		r=[" 6月 1号 "+y+"年 \n 儿童节 ",gsAction,"skyblue","red"];
	else if (m==7&&d==1)
		r=[" 7月 1号 "+y+"年 \n 建党节 ",gsAction,"skyblue","red"];
	else if (m==8&&d==1)
		r=[" 8月 1号 "+y+"年 \n 建军节 ",gsAction,"skyblue","red"];
	else if (m==9&&d==10)
		r=[" 9月 10号 "+y+"年 \n 教师节 ",gsAction,"skyblue","red"];
	else if (m==10&&d==1)
		r=[" 10月 1号 "+y+"年 \n 国庆节 ",gsAction,"skyblue","red"];
	else if (m==12&&d==25)
		r=[" 12月 25号 "+y+"年 \n 圣诞节 ",gsAction,"skyblue","red"];
	
	return rE?rE:r;	// favor events over holidays
}


