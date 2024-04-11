$(document).ready(function() {
    $(".openModalBtn").click(function() {
        $(".modal").show();
        $(".overlay").show();
        $(".mainForm :input").prop("disabled", true);
    });

    $(".addValuesBtn").click(function() {
        var modalInputs = [];
        $(".modal :input").each(function() {
            modalInputs.push($(this).val());
        });
        var concatenatedValues = modalInputs.join("");
        $(".mainForm :input").prop("disabled", false);
        $(".overlay").hide();
        $(".modal").hide();
        
        var currentValues = $(".input1").val();
        if (currentValues !== "") {
            concatenatedValues = currentValues + "" + concatenatedValues;
        }
        $(".input1").val(concatenatedValues);
    });
});
