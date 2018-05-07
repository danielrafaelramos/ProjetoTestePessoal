app.service("crudService", function ($http) {


    //Obter todos os alunos cadastrados
    this.listaAlunos = function () {

        return $http.get("/api/v1/public/alunos");
    }

    //Incluir Alunos
    this.AdicionarAlunos = function () {
        var response = $http({
            method: "post",
            url: "/api/v1/public/alunos"
        });

        return response;
    }

    this.Relatorio = function () {
        window.location = '/Home/GerarExcel';
        return;
    }
});