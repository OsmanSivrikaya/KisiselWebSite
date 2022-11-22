//#region DataTable
var EducationDataT;
$(document).ready(function () {
    EducationDataT = $("#educationTable").DataTable({
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
            url: "/Education/EducationGetAll",
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
            { data: "educationDate" },          //3
            { data: "educationTitle" },         //5
            { data: "educationText" },          //6
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
    $("#educationTable tbody").on("click", ".duzenle", function () {
        var data = EducationDataT.row($(this).parents("tr")).data();
        EducationVue.DuzenleVeriGetir(data)
    });
    $("#educationTable tbody").on("click", ".sil", function () {
        var data = EducationDataT.row($(this).parents("tr")).data();
        EducationVue.EducationSil(data.id)
    });
});
//#endregion

//#region Education Vue
var EducationVue = new Vue({
    el: "#educationApp",
    data: {
        id: "",
        educationDate: "",
        mainPageVisibility: false,
        educationTitle: "",
        educationText: "",
    },
    methods: {
        Sifirla() {
            this.id = "";
            this.educationDate = "";
            this.mainPageVisibility = false;
            this.educationTitle = "";
            this.educationText = "";
        },
        async EducationEkle() {
            let formData = new FormData()
            formData.append('EducationDate', this.educationDate);
            formData.append('Id', this.id);
            formData.append('MainPageVisibility', this.mainPageVisibility);
            formData.append('EducationTitle', this.educationTitle);
            formData.append('EducationText', this.educationText);
            var Id = this.id;
            if (Id != null) {
                await $.ajax({
                    url: "/Education/EducationGuncelle",
                    data: formData,
                    type: 'POST',
                    processData: false,
                    contentType: false,
                    cache: false,
                    success: function (e) {
                        EducationDataT.ajax.reload(null, null);
                    },
                    error: function (message) {
                        console.log(message)
                    }
                });
            }
            if (Id == null || Id == "") {
                await $.ajax({
                    url: "/Education/EducationEkle",
                    data: formData,
                    type: 'POST',
                    processData: false,
                    contentType: false,
                    cache: false,
                    success: function (e) {
                        EducationDataT.ajax.reload(null, null);
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
            this.educationDate = data.educationDate;
            this.mainPageVisibility = data.mainPageVisibility;
            this.educationTitle = data.educationTitle;
            this.educationText = data.educationText;
        },
        async EducationSil(data) {
            let formData = new FormData()
            formData.append('Id', data);

            await $.ajax({
                url: "/Education/EducationSil",
                data: formData,
                type: 'POST',
                enctype: 'multipart/form-data',
                processData: false,
                contentType: false,
                cache: false,
                success: function (e) {
                    EducationDataT.ajax.reload(null, null);
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