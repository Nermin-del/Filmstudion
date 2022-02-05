var DataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    DataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Film/GetAllFilms",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {"data": "title", "width": "50%"},
            {"data": "description", "width": "20%"},
            { "data": "filmcopies", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a hreh="/Film/Upsert/${data}" class='btn btn-success text-white`
                                    
                }
            }
        ]
    })
}