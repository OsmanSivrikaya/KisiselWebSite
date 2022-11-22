//#region Gider DataTable
var LanguagesDataT;
$(document).ready(function () {
    LanguagesDataT = $("#languagesTable").DataTable({
        paging: true,
        select: false,
        dom: "Blfrtip",
        lengthChange: false,
        searching: true,
        ordering: true,
        info: true,
        scrollX: false,
        autoWidth: true,
        destroy: true,
        responsive: true,
        order: [[1, "desc"]],
        lengthMenu: [[10, 25, 50, -1], ['10', '25', '50', 'Hepsini Göster']],
        ajax: {
            url: "/Languages/LanguagesGetAll",
            type: "GET",
            datatype: "json"
        },
        buttons: [
            {
                extend: 'pageLength',
                orientation: 'landscape',
                className: "btn btn-info",
            },
        ],
        columns: [
            {
                data: "id", render: function (data, type, row) {
                    return '<button class="btn btn-danger sil"><i class="fa-solid fa-trash"></i></button>'
                }
            },                                  //0 
            {
                data: "id", render: function (data, type, row) {
                    return '<button class="btn btn-success duzenle"><i class="fa-solid fa-pen-to-square"></i></button>'
                }
            },                                  //1
            { data: "id" },                     //2
            { data: "languagesName" },              //3
            { data: "languagesPoints" },            //4
            {
                data: "mainPageVisibility", render: function (data) {
                    if (data == true) {
                        return "✔"
                    }
                    else {
                        return "❌"
                    }
                }
            },     //5
        ],
        columnDefs: [
            {
                targets: [2],
                visible: false,
                searchable: false,
            },
            { width: "1%", targets: [0, 1, 2, 5] }
        ],
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.12.1/i18n/tr.json"
        },
        stateSave: true,
        stateSaveCallback: function (settings, data) {
            localStorage.setItem('DataTables_' + settings.sInstance, JSON.stringify(data))
        },
        stateLoadCallback: function (settings) {
            return JSON.parse(localStorage.getItem('DataTables_' + settings.sInstance))
        }
    });
    $("#languagesTable tbody").on("click", ".duzenle", function () {
        var data = LanguagesDataT.row($(this).parents("tr")).data();
        LanguagesVue.DuzenleVeriGetir(data)
    });
    $("#languagesTable tbody").on("click", ".sil", function () {
        var data = LanguagesDataT.row($(this).parents("tr")).data();
        LanguagesVue.LanguageSil(data.id)
    });
});
//#endregion

//#region Languages Vue
var LanguagesVue = new Vue({
    el: "#languagesApp",
    data: {
        id: "",
        languageName: "",
        mainPageVisibility: false,
        languagePoints: 50,
    },
    methods: {
        Sifirla() {
            this.id = "";
            this.languageName = "";
            this.mainPageVisibility = false;
            this.languagePoints = 50;
        },
        async LanguageEkle() {
            let formData = new FormData()
            formData.append('MainPageVisibility', this.mainPageVisibility);
            formData.append('Id', this.id);
            formData.append('LanguagesPoints', this.languagePoints);
            formData.append('LanguagesName', this.languageName);
            var Id = this.id;
            if (Id != null) {
                await $.ajax({
                    url: "/Languages/LanguagesGuncelle",
                    data: formData,
                    type: 'POST',
                    processData: false,
                    contentType: false,
                    cache: false,
                    success: function (e) {
                        LanguagesDataT.ajax.reload(null, null);
                    },
                    error: function (message) {
                        console.log(message)
                    }
                });
            }
            if (Id == null || Id == "") {
                await $.ajax({
                    url: "/Languages/LanguagesEkle",
                    data: formData,
                    type: 'POST',
                    processData: false,
                    contentType: false,
                    cache: false,
                    success: function (e) {
                        LanguagesDataT.ajax.reload(null, null);
                    },
                    error: function (message) {
                        console.log(message)
                    }
                });
            }
            this.Sifirla();
        },
        DuzenleVeriGetir(data) {
            this.id = data.id;
            this.languageName = data.languagesName;
            this.mainPageVisibility = data.mainPageVisibility;
            this.languagePoints = data.languagesPoints;
        },
        async LanguageSil(data) {
            let formData = new FormData()
            formData.append('Id', data);

            await $.ajax({
                url: "/Languages/LanguagesSil",
                data: formData,
                type: 'POST',
                enctype: 'multipart/form-data',
                processData: false,
                contentType: false,
                cache: false,
                success: function (e) {
                    LanguagesDataT.ajax.reload(null, null);
                },
                error: function (message) {
                    console.log(message)
                }
            });
            this.Sifirla();
        }
    },
    created() {
    },
    befourupdate() {
    }
});
//#endregion