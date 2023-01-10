$(document).ready(function () {
    $('.my-table').DataTable();
    $('.my-select').select2;
    $('#listCat').change(function () {
        let id = $("#listCat").val();
        /*alert("ID " = +id);*/
        console.log("ID =" + id);
        $("#result").load("/Product/LoadProduct/" + id);
    })
});
 