function isIeFearture() 
{
	if (typeof isIeFearture.support != "undefined")
		return isIeFearture.support;
	
	var ie55 = /msie 5\.[56789]/i.test( navigator.userAgent );
	
	isIeFearture.support = (typeof document.implementation != "undefined" &&
			document.implementation.hasFeature( "html", "1.0" ) || ie55)
			
	if (ie55) 
	{
		document._getElementsByTagName = document.getElementsByTagName;
		document.getElementsByTagName = function (strTagName) {
			if (strTagName == "*")
				return document.all;
			else
				return document._getElementsByTagName(strTagName);
		};
	}

	return isIeFearture.support;
}

function WebFXTabPane( elem, bUseCookie ) 
{
	if (!isIeFearture()) return;
	if (elem == null) return;
	
	this.element = elem;
	this.element.tabPane = this;
	this.pages = [];
	this.selectedIndex = null;
	
	this.element.className = this.classNameTag + " " + this.element.className;
	
	this.tabRow = document.createElement( "div" );
	this.tabRow.className = "tab-row";
	elem.insertBefore( this.tabRow, elem.firstChild );

	var tabIndex = 0;

	this.selectedIndex = tabIndex;
	
	var childnodes = elem.childNodes;
	var n;
	for (var i = 0; i < childnodes.length; i++) 
	{
		if (childnodes[i].nodeType == 1 && childnodes[i].className == "tab-page") 
		{
			this.addTabPage( childnodes[i] );
		}
	}
}

WebFXTabPane.prototype.classNameTag = "dynamic-tab-pane-control";

WebFXTabPane.prototype.setSelectedIndex = function ( iIndex ){
	if (this.selectedIndex != iIndex) 
	{
		if (this.selectedIndex != null && this.pages[ this.selectedIndex ] != null )
			this.pages[ this.selectedIndex ].hide();
		this.selectedIndex = iIndex;
		this.pages[ this.selectedIndex ].show();
	}
};
	
WebFXTabPane.prototype.getSelectedIndex = function () {
	return this.selectedIndex;
};
	
WebFXTabPane.prototype.addTabPage = function ( oElement ) {
	if (!isIeFearture()) return;
	
	if (oElement.tabPage == this) return oElement.tabPage;

	var len = this.pages.length;
	this.pages[len] = new HtmlTabPage(oElement, this, len);
	var tabpage = this.pages[len];
	tabpage.tabPane = this;
	
	this.tabRow.appendChild(tabpage.tab);
			
	if (len == this.selectedIndex)
		tabpage.show();
	else
		tabpage.hide();
		
	return tabpage;
};
	
WebFXTabPane.prototype.dispose = function () {
	this.element.tabPane = null;
	this.element = null;		
	this.tabRow = null;
	
	for (var i = 0; i < this.pages.length; i++)
	{
		this.pages[i].dispose();
		this.pages[i] = null;
	}
	this.pages = null;
};

function HtmlTabPage( elem, tabPane, nIndex ) 
{
	if ( !isIeFearture() || elem == null ) return;
	
	this.element = elem;
	this.element.tabPage = this;
	this.index = nIndex;
	
	var childnodes = elem.childNodes;
	for (var i = 0; i < childnodes.length; i++) 
	{
		if (childnodes[i].nodeType == 1 && childnodes[i].className == "tab") 
		{
			this.tab = childnodes[i];
			break;
		}
	}

	var oThis = this;
	this.tab.onclick = function () {
        oThis.select(); 
    };

	this.tab.onmouseover = function () { HtmlTabPage.tabOver( oThis ); };
	this.tab.onmouseout = function () { HtmlTabPage.tabOut( oThis ); };
}

HtmlTabPage.prototype.show = function () 
{
	var el = this.tab;
	var s = el.className + " selected";
	s = s.replace(/ +/g, " ");
	el.className = s;
	
	this.element.style.display = "block";
};

HtmlTabPage.prototype.hide = function () 
{
	var el = this.tab;
	var s = el.className;
	s = s.replace(/ selected/g, "");
	el.className = s;

	this.element.style.display = "none";
};
	
HtmlTabPage.prototype.select = function () 
{
	this.tabPane.setSelectedIndex( this.index );
};
	
HtmlTabPage.prototype.dispose = function () 
{
	this.element.tabPage = null;
	this.tab.onclick = null;
	this.tab.onmouseover = null;
	this.tab.onmouseout = null;
	this.tab = null;
	this.tabPane = null;
	this.element = null;
};

HtmlTabPage.tabOver = function ( tabpage ) 
{
	var el = tabpage.tab;
	var s = el.className + " hover";
	s = s.replace(/ +/g, " ");
	el.className = s;
};

HtmlTabPage.tabOut = function ( tabpage ) 
{
	var el = tabpage.tab;
	var s = el.className;
	s = s.replace(/ hover/g, "");
	el.className = s;
};


// This function initializes all uninitialized tab panes and tab pages
function setupAllTabs() 
{
	if ( !isIeFearture() ) return;

	var all = document.getElementsByTagName( "*" );
	var l = all.length;
	var tabPaneRex = /tab\-pane/;
	var tabPageRex = /tab\-page/;
	var classname, elem;
	var parentTabPane;
	
	for (var i = 0; i < l; i++) 
	{
		elem = all[i]
		classname = elem.className;

		if (classname == "") continue;
		
		if (tabPaneRex.test(classname) && !elem.tabPane)
		{
			new WebFXTabPane(elem,false);
		}
		else if (tabPageRex.test(classname) && !elem.tabPage && tabPaneRex.test(elem.parentNode.className)) 
		{
			elem.parentNode.tabPane.addTabPage(elem);			
		}
	}
}

function disposeAllTabs() 
{
	if ( !isIeFearture() ) return;
	
	var all = document.getElementsByTagName( "*" );
	var l = all.length;
	var tabPaneRex = /tab\-pane/;
	var clsName, elem;
	var tabPanes = [];
	
	for (var i = 0; i < l; i++) 
	{
		elem = all[i]
		clsName = elem.className;

		if (clsName == "") continue;
		
		if (tabPaneRex.test(clsName) && elem.tabPane)
			tabPanes[tabPanes.length] = elem.tabPane;
	}
	
	for (var i = tabPanes.length - 1; i >= 0; i--) 
	{
		tabPanes[i].dispose();
		tabPanes[i] = null;
	}
}

if (typeof window.addEventListener != "undefined")
	window.addEventListener("load", setupAllTabs, false);
else if (typeof window.attachEvent != "undefined") 
{
    window.attachEvent("onload", setupAllTabs);
    window.attachEvent("onunload", disposeAllTabs);
}
else 
{
	if (window.onload != null) 
	{
		var oldOnload = window.onload;
		window.onload = function (e) {
			oldOnload(e);
			setupAllTabs();
		};
	}
	else 
		window.onload = setupAllTabs;
}

