// -------------------------------------------------------------------
// DHTML Modal window- By Dynamic Drive, available at: http://www.dynamicdrive.com
// v1.0: Script created Feb 27th, 07'
// v1.01 May 5th, 07' Minor change to modal window positioning behavior (not a bug fix)
// v1.1: April 16th, 08' Brings it in sync with DHTML Window widget. See changelog.txt for the later for changes.
// REQUIRES: DHTML Window Widget (v1.01 or higher): http://www.dynamicdrive.com/dynamicindex8/dhtmlwindow1/
// -------------------------------------------------------------------

if (typeof dhtmlwindow1=="undefined")
alert('ERROR: Modal Window script requires all files from "DHTML Window widget" in order to work!')

var dhtmlmodal1={
veilstack: 0,
open:function(t, contenttype, contentsource, title, attr, recalonload){
	var d=dhtmlwindow1 //reference dhtmlwindow1 object
	this.interVeil=document.getElementById("interVeil") //Reference "veil" div
	this.veilstack++ //var to keep track of how many modal windows are open right now
	this.loadveil()
	if (recalonload=="recal" && d.scroll_top==0)
		d.addEvent(window, function(){dhtmlmodal1.adjustveil()}, "load")
	var t=d.open(t, contenttype, contentsource, title, attr, recalonload)
	t.controls.firstChild.style.display="none" //Disable "minimize" button
	t.controls.onclick=function(){dhtmlmodal1.close(this._parent, true)} //OVERWRITE default control action with new one
	//t.show=function(){dhtmlmodal1.show(this)} //OVERWRITE default t.show() method with new one
	t.hide=function(){dhtmlmodal1.close(this)} //OVERWRITE default t.hide() method with new one
return t
},


loadveil:function(){
	var d=dhtmlwindow1
	d.getviewpoint()
	this.docheightcomplete=(d.standardbody.offsetHeight>d.standardbody.scrollHeight)? d.standardbody.offsetHeight : d.standardbody.scrollHeight
	this.interVeil.style.width=d.docwidth+"px" //set up veil over page
	this.interVeil.style.height=this.docheightcomplete+"px" //set up veil over page
	this.interVeil.style.left=0 //Position veil over page
	this.interVeil.style.top=0 //Position veil over page
	this.interVeil.style.visibility="visible" //Show veil over page
	this.interVeil.style.display="block" //Show veil over page
},

adjustveil:function(){ //function to adjust veil when window is resized
	if (this.interVeil && this.interVeil.style.display=="block") //If veil is currently visible on the screen
		this.loadveil() //readjust veil
},

closeveil:function(){ //function to close veil
	this.veilstack--
	if (this.veilstack==0) //if this is the only modal window visible on the screen, and being closed
		this.interVeil.style.display="none"
},


close:function(t, forceclose){ //DHTML modal close function
	//t.contentDoc=(t.contentarea.datatype=="iframe")? window.frames["_iframe-"+t.id].document : t.contentarea //return reference to modal window DIV (or document object in the case of iframe
	if (typeof forceclose!="undefined")
		t.onclose=function(){return true}
	if (dhtmlwindow1.close(t)) //if close() returns true
		this.closeveil()
},


show:function(t){
	dhtmlmodal1.veilstack++
	dhtmlmodal1.loadveil()
	dhtmlwindow1.show(t)
}
} //END object declaration


document.write('<div id="interVeil"></div>')
dhtmlwindow1.addEvent(window, function(){if (typeof dhtmlmodal1!="undefined") dhtmlmodal1.adjustveil()}, "resize")