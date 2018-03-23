//Autocomplete
$("#cliente_nome").autocomplete({
    source: function (request, response) {
        urlpronta = "/Clientes/GetClientes?texto=" + document.getElementById("cliente_nome").value;
        $.getJSON(urlpronta, function (data) {
            //console.log(data);
            response($.map(data, function (value, key) {
                return {
                    label: value.Nome,
                    value: value.ClienteId
                };
            }));
        });
    },
    minLength: 3,
    delay: 200,
    select: function (event, ui) {
        event.preventDefault();
        //selecionado = ui.item.value;
        $("#cliente_nome").val(ui.item.label);
        $("#ClienteId").val(ui.item.value);
        //pesquisarclique();
        //selecionado = undefined;
    }
});

$("#pedido").autocomplete({
    source: function (request, response) {
        urlpronta = "/Vendas/GetVendas?texto=" + document.getElementById("pedido").value + "&pago=0";
        $.getJSON(urlpronta, function (data) {
            //console.log(data);
            response($.map(data, function (value, key) {
                return {
                    label: value.Apelido,
                    value: value.PedidoId
                };
            }));
        });
    },
    minLength: 3,
    delay: 200,
    select: function (event, ui) {
        event.preventDefault();
        //selecionado = ui.item.value;
        $("#pedido").val(ui.item.label);
        $("#PedidoId").val(ui.item.value);
        //pesquisarclique();
        //selecionado = undefined;
        $("#Valor").val("");
        RecuperaSaldo();
    }
});

//Datatables
$(document).ready(function () {
    $('#tabela').DataTable({
        "language": {
            lengthMenu: "Mostrar _MENU_ pregistros por página",
            zeroRecords: "Nenhum resultado encontrado",
            info: "Mostrando página _PAGE_ de _PAGES_",
            infoEmpty: "Não há resultados",
            infoFiltered: "(Econtrado(s) _MAX_ resultados)",
            search: "Procurar:",
            paginate: {
                first: "Primeira página",
                previous: "Página anterior",
                next: "Próxima página",
                last: "Última página"
            },
            aria: {
                sortAscending: ": classificado ascendente",
                sortDescending: ": classificado descendente"
            }
        }
    });
});

function RecuperaSaldo() {
    var pedido = document.getElementById("PedidoId").value;
    $.ajax({
        url: "/Recebimentos/RecuperaSaldo?PedidoId=" + pedido,
        data: { pedido: pedido }
    }).done(function (data) {
        $("#Valor").val(data);
    });
};