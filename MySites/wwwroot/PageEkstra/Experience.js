//#region DataTable
var ExperienceDataT;
$(document).ready(function () {
    ExperienceDataT = $("#experienceTable").DataTable({
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
            url: "/Experience/ExperienceGetAll",
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
            { data: "experienceDate" },          //3
            { data: "experienceTitle" },         //5
            { data: "experienceText" },          //6
            {
                data: "mainPageVisibility", render: function (data) {
                    if (data == true) {
                        return "✔"
                    }
                    else {
                        return "❌"
                    }
                }
            },                                   //7
        ],
        columnDefs: [
            {
                targets: [2],
                visible: false,
                searchable: false,
            },
            { width: "1%", targets: [0, 1, 2] }
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
    $("#experienceTable tbody").on("click", ".duzenle", function () {
        var data = ExperienceDataT.row($(this).parents("tr")).data();
        experienceVue.DuzenleVeriGetir(data)
    });
    $("#experienceTable tbody").on("click", ".sil", function () {
        var data = ExperienceDataT.row($(this).parents("tr")).data();
        experienceVue.ExperienceSil(data.id)
    });
});
//#endregion

//#region Experience Vue
var experienceVue = new Vue({
    el: "#experienceApp",
    data: {
        id: "",
        experienceDate: "",
        mainPageVisibility: false,
        experienceTitle: "",
        experienceText: "",
    },
    methods: {
        Sifirla() {
            this.id = "";
            this.experienceDate = "";
            this.mainPageVisibility = false;
            this.experienceTitle = "";
            this.experienceText = "";
        },
        async ExperienceEkle() {
            let formData = new FormData()
            formData.append('ExperienceDate', this.experienceDate);
            formData.append('Id', this.id);
            formData.append('MainPageVisibility', this.mainPageVisibility);
            formData.append('ExperienceTitle', this.experienceTitle);
            formData.append('ExperienceText', this.experienceText);
            var Id = this.id;
            if (Id != null) {
                await $.ajax({
                    url: "/Experience/ExperienceGuncelle",
                    data: formData,
                    type: 'POST',
                    processData: false,
                    contentType: false,
                    cache: false,
                    success: function (e) {
                        ExperienceDataT.ajax.reload(null, null);
                    },
                    error: function (message) {
                        console.log(message)
                    }
                });
            }
            if (Id == null || Id == "") {
                await $.ajax({
                    url: "/Experience/ExperienceEkle",
                    data: formData,
                    type: 'POST',
                    processData: false,
                    contentType: false,
                    cache: false,
                    success: function (e) {
                        ExperienceDataT.ajax.reload(null, null);
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
            this.experienceDate = data.experienceDate;
            this.mainPageVisibility = data.mainPageVisibility;
            this.experienceTitle = data.experienceTitle;
            this.experienceText = data.experienceText;
        },
        async ExperienceSil(data) {
            let formData = new FormData()
            formData.append('Id', data);

            await $.ajax({
                url: "/Experience/ExperienceSil",
                data: formData,
                type: 'POST',
                enctype: 'multipart/form-data',
                processData: false,
                contentType: false,
                cache: false,
                success: function (e) {
                    ExperienceDataT.ajax.reload(null, null);
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