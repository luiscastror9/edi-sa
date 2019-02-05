$(function () {

    'use strict';

    $('#ConsultaData').DataTable({
        "paging": true,
        "dataType": "json",
        "lengthChange": false,
        "searching": false,
        "ordering": true,
        "info": true,
        "autoWidth": false,
        "bServerSide": true,
        "sAjaxSource": "http://" + window.location.host +  "/BackOffice/Default/ConsultaDataSurvey",
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

            { "mData": "IdConsulta", "title": "Id", "sDefaultContent": "" },
            { "mData": "NombreConsulta", "title": "Nombre", "sDefaultContent": "" },
            { "mData": "EmailConsulta", "title": "Email", "sDefaultContent": "" },

            {
                data: null,
                title: "Ver Consulta",
                //"mRender": function (row) { return '<i class="fa fa-pencil edit-user-data data=' + row[0]+'" style="font- size: 22px;" data-original-title="Editar"></i>'; }
                "mRender": function (row) {
                    return '<i class="fa fa-pencil edit-Consulta-data" data-row-id=' + row['IdConsulta'] + ' style="font- size: 22px;cursor: pointer;" data-original-title="Editar"></i>';
                }

               
            },
            {
                data: null,
                title: "Responder Consulta",
                //"mRender": function (row) { return '<i class="fa fa-pencil edit-user-data data=' + row[0]+'" style="font- size: 22px;" data-original-title="Editar"></i>'; }
                "mRender": function (row) {
                    return '<i class="fa fa-pencil edit-ResponderConsulta-data" data-row-id=' + row['IdConsulta'] + ' style="font- size: 22px;cursor: pointer;" data-original-title="Responder"></i>';
                }


            },
       
       ]
    });

    $('#ConsultaData tbody').on('click', '.edit-Consulta-data', function () {
        var table = $('#ConsultaData').DataTable();


        table.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
        var id = table.$(this).attr("data-row-id");
        location.href = "http://" + window.location.host +  "/BackOffice/Default/ViewConsulta/" + id;


    });
    $('#ConsultaData tbody').on('click', '.edit-ResponderConsulta-data', function () {
        var table = $('#ConsultaData').DataTable();

        table.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
        var id = table.$(this).attr("data-row-id");
        location.href = "http://" + window.location.host +  "/BackOffice/Default/ResponderConsulta/" + id;


    });

    $(document).on('click', '#btnNewRespuestaConsulta', function () {

        location.href = "http://" + window.location.host +  "/BackOffice/Default/ResponderConsulta"

    });
}) ;