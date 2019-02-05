$(function () {

    'use strict';

    $('#BannerData').DataTable({
        "paging": true,
        "dataType": "json",
        "lengthChange": false,
        "searching": false,
        "ordering": true,
        "info": true,
        "autoWidth": false,
        "bServerSide": true,
        "sAjaxSource": "http://" + window.location.host + "/BackOffice/Default/BannerDataSurvey",
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

            { "mData": "IdSlideHome", "title": "Id", "sDefaultContent": "" },
            { "mData": "descSlideHome", "title": "Descripcion", "sDefaultContent": "" },
            {
                data: null,
                title: "Url ",
                //"mRender": function (row) { return '<i class="fa fa-pencil edit-user-data data=' + row[0]+'" style="font- size: 22px;" data-original-title="Editar"></i>'; }
                "mRender": function (row) {
                    return '<span  style="font- size: 22px;cursor: pointer;">' + row['urlSlideHome'] + '</span>';
                }

             
            }
            , {
                data: null,
                title: "Imagen ",
                //"mRender": function (row) { return '<i class="fa fa-pencil edit-user-data data=' + row[0]+'" style="font- size: 22px;" data-original-title="Editar"></i>'; }
                "mRender": function (row) {
                    return '<img width="50px" height="50px" style="font- size: 22px;cursor: pointer;" src="http://' + window.location.host + '/Content/Upload/' + row['urlImgSlideHome'] + '"/>';
                }


            }
            ,
            {
                data: null,
                title: "Editar",
                //"mRender": function (row) { return '<i class="fa fa-pencil edit-user-data data=' + row[0]+'" style="font- size: 22px;" data-original-title="Editar"></i>'; }
                "mRender": function (row) {
                    return '<i class="fa fa-pencil edit-banner-data" data-row-id=' + row['IdSlideHome'] + ' style="font- size: 22px;cursor: pointer;" data-original-title="Editar"></i>';
                }

               
            },
            {
                data: null,
                title: "Eliminar",
                "mRender": function (row) {
                    return '<i class="fa fa-trash-o delete-banner-data" data-row-id=' + row['IdSlideHome'] + ' style="font-size: 22px;cursor: pointer;" data-original-title="Borrar"></i>'
                }
            },
       ]
    });

    $('#BannerData tbody').on('click', '.edit-banner-data', function () {
        var table = $('#BannerData').DataTable();


        table.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
        var id = table.$(this).attr("data-row-id");
        location.href = "http://" + window.location.host + "/BackOffice/Default/EditBanner/" + id;


    });

    $('#BannerData tbody').on('click', '.delete-banner-data', function () {
        var table = $('#BannerData').DataTable();


        table.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
        var id = table.$(this).attr("data-row-id");
        var r = confirm("Esta seguro que desea Borrar este Registro?");
        if (r == true) {
            $.ajax({
                url: "http://" + window.location.host + "/BackOffice/Default/DeleteBanner/" + id,
                type: "POST",
                dataType: 'HTML',
                success: function (data) {
                    window.location.href = data;
                }

            });
        } else {

        }
    });


    $(document).on('click', '#btnNewBanner', function () {

        location.href = "http://" + window.location.host + "/BackOffice/Default/CreateBanner"

    });

    $('#activeSlideHome').change(function () {
        if ($('#h_activeSlideHome')[0].value == "true")
            $('#h_activeSlideHome')[0].value = "false";
        else
            $('#h_activeSlideHome')[0].value = "true";
    })

}) ;