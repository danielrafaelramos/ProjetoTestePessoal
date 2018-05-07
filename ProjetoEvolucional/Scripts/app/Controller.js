app.controller("crudCtrl", function ($scope, crudService) {

    listaAlunos();

    function listaAlunos() {
        var alunosData = crudService.listaAlunos();
        alunosData.then(function (alunos) {
            $scope.alunos = alunos.data;
        }, function () {
            toastr["error"]("Erro ao obter os alunos", "Projeto Evolucional - Gerador de Notas");
        });

    }

    $scope.incluirAlunoDiv = function () {
        var processado = crudService.AdicionarAlunos();
        processado.then(function (data) {
            if (data.status == 200) {
                toastr["success"]("Notas processadas com sucesso!", "Projeto Evolucional - Gerador de Notas");
                listaAlunos();
            }
        }, function () {
            toastr["error"]("Erro ao processar", "Projeto Evolucional - Gerador de Notas");
        });
    }

    $scope.gerarRelatorio = function () {
        crudService.Relatorio();
    }
});
