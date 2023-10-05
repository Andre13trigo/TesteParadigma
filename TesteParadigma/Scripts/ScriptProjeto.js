$(document).ready(function() {
    $('.button').click(function() {
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
                html += '<li class="p1"></li>';
                html += '    <li class="p2"></li>';
                html += '   <li class="p3"></li>';
                html += '</ol>';
                $(html).appendTo('.answer');
                $('.answer .p1').text("Lista Original: [" + response.parametro + "]");
                $('.answer .p2').text("Nova Lista: [" + response.aux + "]");
                $('.answer .p3').text("Soma: " + response.soma);

            },
            error: function (xhr, status, error) {

                console.error(error);
            }
        });
    } else {
        console.log('Vetor não encontrado no texto.');
    }
}