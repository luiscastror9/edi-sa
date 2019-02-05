$(function () {

    'use strict';

    $('#CategoriasData').DataTable({
        "paging": true,
        "dataType": "json",
        "lengthChange": false,
        "searching": false,
        "ordering": true,
        "info": true,
        "autoWidth": false,
        "bServerSide": true,
        "sAjaxSource": "http://" + window.location.host + window.location.pathname.substring(0, window.location.pathname.lastIndexOf("/") + 1) + "/BackOffice/Prensa/CategoriasDataSurvey",
        "bProcessing": true,
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        },
        "aoColumns": [

            { "mData": "IdCategoriasNotes", "title": "Id", "sDefaultContent": "" },
            { "mData": "descCategoriasNotes", "title": "Nombre", "sDefaultContent": "" },
            {
                data: null,
                title: "Editar",
                //"mRender": function (row) { return '<i class="fa fa-pencil edit-user-data data=' + row[0]+'" style="font- size: 22px;" data-original-title="Editar"></i>'; }
                "mRender": function (row) {
                    return '<i class="fa fa-pencil edit-Categorias-data" data-row-id=' + row['IdCategoriasNotes'] + ' style="font- size: 22px;cursor: pointer;" data-original-title="Editar"></i>';
                }


            },
            {
                data: null,
                title: "Eliminar",
                "mRender": function (row) {
                    return '<i class="fa fa-trash-o delete-Categorias-data" data-row-id=' + row['IdCategoriasNotes'] + ' style="font-size: 22px;cursor: pointer;" data-original-title="Borrar"></i>'
                }
            },
           
       
       ]
    });

    $('#CategoriasData tbody').on('click', '.edit-Categorias-data', function () {
        var table = $('#CategoriasData').DataTable();


        table.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
        var id = table.$(this).attr("data-row-id");
        location.href = "http://" + window.location.host + window.location.pathname.substring(0, window.location.pathname.lastIndexOf("/") + 1) + "/BackOffice/Prensa/EditCategorias/" + id;


    });

    $(document).on('click', '#btnNewCategorias', function () {

        location.href = "http://" + window.location.host + window.location.pathname.substring(0, window.location.pathname.lastIndexOf("/") + 1) + "/BackOffice/Prensa/CreateCategorias"

    });

    $('#CategoriasData tbody').on('click', '.delete-Categorias-data', function () {
        var table = $('#CategoriasData').DataTable();


        table.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
        var id = table.$(this).attr("data-row-id");
        var r = confirm("Esta seguro que desea Borrar este Registro?");
        if (r == true) {
            $.ajax({
                url: "http://" + window.location.host + window.location.pathname.substring(0, window.location.pathname.lastIndexOf("/") + 1) + "/BackOffice/Prensa/DeleteCategorias/" + id,
                type: "POST",
                dataType: 'HTML',
                success: function (data) {
                    window.location.href = data;
                }

            });
        } else {

        }
    });

}) ;