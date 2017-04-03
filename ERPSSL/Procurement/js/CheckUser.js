Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
function BeginRequestHandler(sender, args) {
    var state = document.getElementById('loadingdiv').style.display;
    if (state == 'block') {
        document.getElementById('loadingdiv').style.display = 'none';
    }
    else {
        document.getElementById('loadingdiv').style.display = 'block';
    }
    args.get_postBackElement().disabled = true;
}