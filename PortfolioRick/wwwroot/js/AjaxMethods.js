$(document).ready(function () {

    retrieveContactform();

    //Retrieve partialview roles
    function retrieveContactform(data, status) {
        $.ajax({
            type: "GET",
            url: "/Mail/RetrieveContactForm",
            dataType: "html",
            success: successFunc,
            error: errorFunc
        });
    }

    //Basic success and error functions
    function successFunc(data, status) {
        $("#partialform").html(data);
        $("divLoader").hide();
    }

    //If something goes wrong use this method
    function errorFunc(jQXHR, textStatus, errorThrown) {
        alert("An error occurred while trying to contact the server: " + jQXHR.status + " " + textStatus + " " + errorThrown);
    }
});