(function ($) {
    "use strict";
    $(document).ready(function () {
        $(function () {

/* ========================================================================== */
/* =========> Toggle Menu Activate
/* ========================================================================== */
$( "#clickble" ).click(function(e) {
$( this).next().toggleClass( "active_bar" );
$( this).next().slideToggle( "slow" );
e.preventDefault();
});
$( ".menu_toggle" ).click(function(e) {
$( this).next().slideToggle( "slow" );
e.preventDefault();
});


      });
    });
})(jQuery);

