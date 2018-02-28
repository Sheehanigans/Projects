$.ajax({
    type: "GET",
    url: "/Home/AllPeople",
    success: function (data) {

        $("#handle").text(JSON.stringify(data));
    },
    error: function (xhr, status, err) {
        
    }

})