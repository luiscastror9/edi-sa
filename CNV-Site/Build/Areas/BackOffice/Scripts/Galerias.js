$(function () {

    'use strict';



    $('#GaleriaData').DataTable({
        "paging": true,
        "dataType": "json",
        "lengthChange": false,
        "searching": false,
        "ordering": true,
        "info": true,
        "autoWidth": false,
        "bServerSide": true,
        "sAjaxSource": "http://" + window.location.host + "/BackOffice/Prensa/GaleriasDataSurvey",
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

            { "mData": "IdSliderNotes", "title": "Id", "sDefaultContent": "" },
            { "mData": "titleSliderNotes", "title": "Descripcion", "sDefaultContent": "" },
            {
                data: null,
                title: "Ver Imagenes",
                //"mRender": function (row) { return '<i class="fa fa-pencil edit-user-data data=' + row[0]+'" style="font- size: 22px;" data-original-title="Editar"></i>'; }
                "mRender": function (row) {
                    return '<i class="fa fa-pencil ver-Galeria-data" data-row-id=' + row['IdSliderNotes'] + ' style="font- size: 22px;cursor: pointer;" data-original-title="Editar"></i>';
                }


            },
             {
                data: null,
                title: "Editar",
                //"mRender": function (row) { return '<i class="fa fa-pencil edit-user-data data=' + row[0]+'" style="font- size: 22px;" data-original-title="Editar"></i>'; }
                "mRender": function (row) {
                    return '<i class="fa fa-pencil edit-Galeria-data" data-row-id=' + row['IdSliderNotes'] + ' style="font- size: 22px;cursor: pointer;" data-original-title="Editar"></i>';
                }

               
            },
            {
                data: null,
                title: "Eliminar",
                "mRender": function (row) {
                    return '<i class="fa fa-trash-o delete-Galeria-data" data-row-id=' + row['IdSliderNotes'] + ' style="font-size: 22px;cursor: pointer;" data-original-title="Borrar"></i>'
                }
            },
       ]
    });

    $('#GaleriaData tbody').on('click', '.edit-Galeria-data', function () {
        var table = $('#GaleriaData').DataTable();


        table.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
        var id = table.$(this).attr("data-row-id");
        location.href = "http://" + window.location.host + "/BackOffice/Prensa/EditGaleria/" + id;


    });
    $('#GaleriaData tbody').on('click', '.ver-Galeria-data', function () {
        var table = $('#GaleriaData').DataTable();


        table.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
        var id = table.$(this).attr("data-row-id");
        location.href = "http://" + window.location.host + "/BackOffice/Prensa/ImagenesGaleria/" + id;


    });

    $('#GaleriaData tbody').on('click', '.delete-Galeria-data', function () {
        var table = $('#GaleriaData').DataTable();


        table.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
        var id = table.$(this).attr("data-row-id");
        var r = confirm("Esta seguro que desea Borrar este Registro?");
        if (r == true) {
            $.ajax({
                url: "http://" + window.location.host + "/BackOffice/Prensa/DeleteGaleria/" + id,
                type: "POST",
                dataType: 'HTML',
                success: function (data) {
                    window.location.href = data;
                }

            });
        } else {

        }
    });


  

    $(document).on('click', '#btnNewGaleria', function () {

        location.href = "http://" + window.location.host + "/BackOffice/Prensa/CreateGalerias"

    });

  
}) ;