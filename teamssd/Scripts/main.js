//³í³ö³àë³çàö³ÿ matirial design
$.material.init();


function actionInterest(id) {
    $.ajax({
        url: "/News/MarkInterest",
        data: { id: id },
        type: 'post',
        async: true,
        success: function (data) {
            $("#newsInterest_" + id).attr("disabled", "disabled");
            console.log("actionInterest id" + id);
        }
    });
}
function actionRelevant(id) {
    $.ajax({
        url: "/News/MarkRelevant",
        data: { id: id },
        type: 'post',
        async: true,
        success: function (data) {
            $("#newsRelevant_" + id).attr("disabled", "disabled");
            console.log("actionRelevant id" + id);
        }
    });


}
function actionUseful(id) {
    $.ajax({
        url: "/News/MarkUseful",
        data: { id: id },
        type: 'post',
        async: true,
        success: function (data) {
            $("#newsUseful_" + id).attr("disabled", "disabled");
            console.log("actionUseful id" + id);
        }
    });
}