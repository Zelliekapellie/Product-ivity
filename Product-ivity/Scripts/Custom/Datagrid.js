let lastID = 0;
$(document).ready(function () {


    lastID = $('#products-data-table tr:last').find("td:eq(1)").attr("id");

    $('#products-data-table').DataTable();

    $('#products-data-table table tbody tr td input').change(function (e) {
        console.log("change");
        $(this).addClass("edited");
        $(this).addClass("bg-blue");
    });
});

function errorModal(message) {
    $('#myModal').on('shown.bs.modal', function () {
        $('#myInput').trigger('focus')
    })
}

function productsAdd(data) {
    
    let id = lastID + 1;
    let productName = $(data).find("#name").val();
    let productCategory = $(data).find("#clist").val();
    let price = $(data).find("#price").val();

    //if (productName == "undefined" || productName == "") {
    //    errorModal("Please enter a product name");
    //}

    $.ajax({
        type: "POST",
        url: "Product/Create",
        dataType: "json",
        data: { pname: productName, pcategory: productCategory, price: price },
        success: function (data, status) { alert(data); },
        error: function () {
            alert("error");
        }

    });
}

function productDelete(ctl) {
    $(ctl).parents("tr").remove();
}

function productUpdate() {
    console.log("edit");
    $("#Input").show();
    $('#Input').on('shown.bs.modal', function () {
        $('#Input').trigger('focus')
    });
    //if ($("#updateButton").text() == "Update") {
    //    productUpdateInTable();
    //}
    //else {
    //    productAddToTable();
    //}

    //// Clear form fields
    //formClear();

    //// Focus to product name field
    //$("#productname").focus();
}

function productUpdateInTable() {
    debugger;
    // Add changed product to table
    $(_row).after(productBuildTableRow());

    // Remove old product row
    $(_row).remove();

    // Clear form fields
    formClear();

    // Change Update Button Text
    $("#updateButton").text("Add");
}


