function synchronise()
{
	var strUser=getCookie("MybdjobsUN");
	
	
	if(strUser!=null)
	{
		username=strUser.substring(0,strUser.indexOf("#"));
		password=getCookie("MybdjobPS");
		
		
	}
	
	
	myusername=document.getElementById("TXTUSERNAME").value;
	chkRem=document.getElementById("chkRemember");
	if(myusername==username)
	{
		document.getElementById("TXTPASS").value=password;
		chkRem.checked=true;
		
	}
	else
	{
		document.getElementById("TXTPASS").value="";
		chkRem.checked=false;
	}
	
	
	
}

function getCookie(c_name) {
    if (document.cookie.length > 0) {
        c_start = document.cookie.indexOf(c_name + "=");
        if (c_start != -1) {
            c_start = c_start + c_name.length + 1;
            c_end = document.cookie.indexOf(";", c_start);
            if (c_end == -1) {
                c_end = document.cookie.length;
            }
            return unescape(document.cookie.substring(c_start, c_end));
        }
    }
    return "";
}

function rememberId()
{
	ischecked=document.getElementById("chkRemember");
	if(ischecked.checked)
	{
		ischecked.checked=false;
	}
	else
	{
		ischecked.checked=true;
	}
	
}
