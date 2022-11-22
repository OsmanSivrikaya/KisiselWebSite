//#region Gider Vue
var _LayoutVue = new Vue({
    el: "#layoutApp",
    data: {
        birthDate: "",
        email: "",
        phone: "",
        address: "",
        facebook: "",
        twitter: "",
        instagram: "",
        github: "",
    },
    methods: {
        async VeriGetir() {
            await $.ajax({
                url: '/Layout/PersonalDataGetAll'
            }).done(data => {
                this.birthDate = data[0].birthdate;
                this.email = data[0].email;
                this.phone = data[0].number;
                this.address = data[0].address;
                this.facebook = data[0].facebook;
                this.twitter = data[0].twitter;
                this.instagram = data[0].instagram;
                this.github = data[0].github;
            });
        }
    },
    created() {
        this.VeriGetir();
    },
    befourupdate() {
        this.VeriGetir();
    }
});

var _LayoutFooterVue = new Vue({
    el: "#footerApp",
    data: {
        birthDate: "",
        email: "",
        phone: "",
        address: "",
        facebook: "",
        twitter: "",
        instagram: "",
        github: "",
    },
    methods: {
        async VeriGetir() {
            await $.ajax({
                url: '/Layout/PersonalDataGetAll'
            }).done(data => {
                this.birthDate = data[0].birthdate;
                this.email = data[0].email;
                this.phone = data[0].number;
                this.address = data[0].address;
                this.facebook = data[0].facebook;
                this.twitter = data[0].twitter;
                this.instagram = data[0].instagram;
                this.github = data[0].github;
            });
        }
    },
    created() {
        this.VeriGetir();
    },
    befourupdate() {
        this.VeriGetir();
    }
});
//#endregion