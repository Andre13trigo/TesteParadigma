$(document).ready(function () {
    $('.button').click(function () {
        $(this).toggleClass('active');
    });
});

function resolveTaskOne() {
    $('.answer').empty();
    var textoElemento = $('.lead').text();
    var html = "";
    // Encontrando o vetor no texto usando uma expressão regular
    var vetorRegex = /\[([\d,\s]+)\]/;
    var vetorEncontrado = textoElemento.match(vetorRegex);

    if (vetorEncontrado) {
        var vetorString = vetorEncontrado[1];
        var vetor = vetorString.split(',').map(function (item) {
            return parseInt(item.trim(), 10);
        });

        $.ajax({
            url: '/Tarefas/ResolveTarefa1',
            type: 'POST',
            dataType: 'json',
            data: {
                parametro: vetor
            },
            success: function (response) {
                html += '<ol>';
                html += '    <li class="p1"></li>';
                html += '    <li class="p2"></li>';
                html += '    <li class="p3"></li>';
                html += '</ol>';
                $(html).appendTo('.answer');
                $('.answer .p1').text("Lista Original: [" + response.parametro + "]");
                $('.answer .p2').text("Nova Lista: [" + response.aux + "]");
                $('.answer .p3').text("Soma: " + response.soma);

            },
            error: function (xhr, status, error) {

                alert(error);
            }
        });
    } else {
        alert('Vetor não encontrado no texto.');
    }
}

function resolveTaskTwo() {
    $('.answer').empty();
    var html = "";
    $.ajax({
        url: '/Tarefas/ResolveTarefa2',
        type: 'POST',
        dataType: 'json',
        success: function (response) {
            html += '<ol>';
            html += '    <li class="p1"></li>';
            html += '    <li class="p2"></li>';
            html += '    <li class="p3"></li>';
            html += '    <li class="p4"></li>';
            html += '</ol>';
            $(html).appendTo('.answer');
            $('.answer .p1').text(response.text1);
            $('.answer .p2').text(response.text2);
            $('.answer .p3').text(response.text3);
            $('.answer .p4').text(response.resp);

        },
        error: function (xhr, status, error) {

            alert(error);
        }
    });
}

function resolveTaskThree() {
    $('.answer').empty();
    var inputElement = $('.dados').val();
    var html = "";
    if (validaNumero()) {
        var soma = parseInt($('.soma').val());
        var regex = /^\d+(,\d+)*$/;
        if (regex.test(inputElement)) {
            var Model = {
                array: inputElement,
                soma: soma
            };

            $.ajax({
                url: '/Tarefas/ResolveTarefa3',
                type: 'POST',
                data: {
                    Model: JSON.stringify(Model),
                },
                dataType: 'json',
                success: function (response) {
                    html += '<ol>';
                    html += '    <li class="p1"></li>';
                    html += '</ol>';
                    $(html).appendTo('.answer');
                    $('.answer .p1').text(response.resp);

                },
                error: function (xhr, status, error) {

                    alert(error);
                }
            });
        } else {
            alert('Entrada inválida. Insira números separados por vírgula e verifique se a soma é um número válido');
        }
    } else {
        alert('Entrada da Soma inválida. Insira apenas um número.');
    }
}

function validaNumero() {
    var num = parseInt($('.soma').val());
    if (!(!isNaN(parseFloat(num)) && isFinite(num))) {
        alert('Entrada da Soma inválida. Insira apenas um número.');
        return false;
    } else {
        return true;
    }
}