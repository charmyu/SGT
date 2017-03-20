function drag(o,ot){
 ot.onmousedown=function(a){
  var d=document;if(!a)a=window.event;
  var x=a.layerX?a.layerX:a.offsetX,y=a.layerY?a.layerY:a.offsetY;
  if(ot.setCapture)
   o.setCapture();
  else if(window.captureEvents)
   window.captureEvents(Event.MOUSEMOVE|Event.MOUSEUP);

  d.onmousemove=function(a){
   if(!a)a=window.event;
   if(!a.pageX)a.pageX=a.clientX;
   if(!a.pageY)a.pageY=a.clientY;
   var tx=a.pageX-x,ty=a.pageY-y;
   o.style.left=tx;
   o.style.top=ty;
  };

  d.onmouseup=function(){
   if(o.releaseCapture)
    o.releaseCapture();
   else if(window.captureEvents)
    window.captureEvents(Event.MOUSEMOVE|Event.MOUSEUP);
   d.onmousemove=null;
   d.onmouseup=null;
  };
 };
}


function showwin()
{
//visibility: visible;
 if(document.getElementById('drag').style.visibility!="visible")
 {
  document.getElementById('drag').style.display="block";
  document.getElementById('drag').style.left=((document.body.clientWidth-400)/2);
  document.getElementById('drag').style.top=50;
 }
 
}
function closewin()
{
//visibility: visible;
 if(document.getElementById('drag').style.visibility!="hidden")
 {
  document.getElementById('drag').style.display="none";
  document.getElementById('drag').style.left=((document.body.clientWidth-400)/2);
  document.getElementById('drag').style.top=100;
 }
}
