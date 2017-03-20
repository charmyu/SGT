function correctPNG() 
{
    try{
        for(var i=0; i<document.images.length; i++) 
        { 
           var img = document.images[i];
           var imgName = img.src.toUpperCase();
           if (imgName.substring(imgName.length-3, imgName.length) == "PNG") 
           { 
                var imgID = (img.id) ? "id='" + img.id + "' " : ""; 
                var imgClass = (img.className) ? "class='" + img.className + "' " : "" ;
                var imgTitle = (img.title) ? "title='" + img.title + "' " : "title='" + img.alt + "' " ;
                var imgStyle = "display:inline-block;" + img.style.cssText ;
                if (img.align == "left") imgStyle = "float:left;" + imgStyle ;
                if (img.align == "right") imgStyle = "float:right;" + imgStyle ;
                if (img.parentElement.href) imgStyle = "cursor:hand;" + imgStyle ;  
                var strNewHTML = "<span " + imgID + imgClass + imgTitle ;
                + " style=\"" + "width:" + img.width + "px; height:" + img.height + "px;" + imgStyle + ";" 
               + "filter:progid:DXImageTransform.Microsoft.AlphaImageLoader" 
                + "(src=\'" + img.src + "\', sizingMethod='scale');\"></span>" ;
                img.outerHTML = strNewHTML ;
                i = i-1 ;
           } 
        }
    }
    catch(e)
    {
    }
}

function bindWindowsListener(eventName, functionName)
{
    // DOM2
    if ( typeof window.addEventListener != "undefined" )
      window.addEventListener( eventName, functionName, false );

    // IE 
    else if ( typeof window.attachEvent != "undefined" ) {
      window.attachEvent( "on" + eventName, functionName );
    }

    else {
      if ( eval("window.on" + eventName) != null ) {
        var oldOnload = eval("window.on" + eventName);
        eval("window.on" + eventName + " = function ( e ) { oldOnload( e ); " + functionName + "();}")
      }
      else 
        eval("window.on" + eventName + " = " + functionName + ";");
    }
}

bindWindowsListener("load", correctPNG);