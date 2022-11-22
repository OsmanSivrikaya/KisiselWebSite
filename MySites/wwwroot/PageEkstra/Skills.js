//#region Gider DataTable
var SkillsDataT;
$(document).ready(function () {
    SkillsDataT = $("#skillsTable").DataTable({
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
            url: "/Skills/SkillsGetAll",
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
            { data: "skillName" },              //3
            { data: "skillPoints" },            //4
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
    $("#skillsTable tbody").on("click", ".duzenle", function () {
        var data = SkillsDataT.row($(this).parents("tr")).data();
        SkillsVue.DuzenleVeriGetir(data)
    });
    $("#skillsTable tbody").on("click", ".sil", function () {
        var data = SkillsDataT.row($(this).parents("tr")).data();
        SkillsVue.SkillsSil(data.id)
    });
});
//#endregion

//#region SkillsVue Vue
var SkillsVue = new Vue({
    el: "#skillsApp",
    data: {
        id: "",
        skillsName: "",
        mainPageVisibility: false,
        skillPoints: 50,
    },
    methods: {
        Sifirla() {
            this.id = "";
            this.skillsName = "";
            this.mainPageVisibility = false;
            this.skillPoints = 50;
        },
        async SkillsEkle() {
            let formData = new FormData()
            formData.append('MainPageVisibility', this.mainPageVisibility);
            formData.append('Id', this.id);
            formData.append('SkillPoints', this.skillPoints);
            formData.append('SkillName', this.skillsName);
            var Id = this.id;
            console.log(Id)
            if (Id != null) {
                await $.ajax({
                    url: "/Skills/SkillsGuncelle",
                    data: formData,
                    type: 'POST',
                    processData: false,
                    contentType: false,
                    cache: false,
                    success: function (e) {
                        SkillsDataT.ajax.reload(null, null);
                    },
                    error: function (message) {
                        console.log(message)
                    }
                });
            }
            if(Id == null || Id == "")
            {
                await $.ajax({
                    url: "/Skills/SkillsEkle",
                    data: formData,
                    type: 'POST',
                    processData: false,
                    contentType: false,
                    cache: false,
                    success: function (e) {
                        SkillsDataT.ajax.reload(null, null);
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
            this.skillsName = data.skillName;
            this.mainPageVisibility = data.mainPageVisibility;
            this.skillPoints = data.skillPoints;
        },
        async SkillsSil(data) {
            let formData = new FormData()
            formData.append('Id', data);

            await $.ajax({
                url: "/Skills/SkillsSil",
                data: formData,
                type: 'POST',
                enctype: 'multipart/form-data',
                processData: false,
                contentType: false,
                cache: false,
                success: function (e) {
                    SkillsDataT.ajax.reload(null, null);
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