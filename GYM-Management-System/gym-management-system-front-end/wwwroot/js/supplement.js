var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/Supplement/GetAll' },
        "columns": [
            { data: 'name', "width": "15%" },
            { data: 'price', "width": "15%" },
            { data: 'description', "width": "30%" },
            {
                data: 'supplementID',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/Supplement/Edit?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>               
                     <a href="/Supplement/Delete?id=${data}" class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
                    </div>`
                },
                "width": "25%"
            }
        ]
    });
}


