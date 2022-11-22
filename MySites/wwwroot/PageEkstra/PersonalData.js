//#region Gider Vue
var PersonalDataVue = new Vue({
    el: "#app",
    data: {
        birthDate: "",
        email: "",
        phone: "",
        address: "",
        facebook: "",
        twitter: "",
        instagram: "",
        github: "",
        introduceYourselfData: [],
        experties: [],
        experiences: [],
        educations: [],
        skills: [],
        languages: [],
        calisilanZaman:"",
    },
    methods: {
        async PersonalDataGetir() {
            await $.ajax({
                url: '/Home/PersonalDataGetAll'
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
        },
        async IntroduceYourselfDataGetir() {
            await $.ajax({
                url: '/Home/IntroduceYourselfDataGetAll'
            }).done(data => {
                this.introduceYourselfData = data;
            });
        },
        async ExpertiesDataGetir() {
            await $.ajax({
                url: '/Home/ExpertiesDataGetAll'
            }).done(data => {
                this.experties = data;
            });
        },
        async ExperiencesDataGetir() {
            await $.ajax({
                url: '/Home/ExperiencesDataGetAll'
            }).done(data => {
                this.experiences = data;
            });
        },
        async EducationsDataGetir() {
            await $.ajax({
                url: '/Home/EducationsDataGetAll'
            }).done(data => {
                this.educations = data;
            });
        },
        async SkillsDataGetir() {
            await $.ajax({
                url: '/Home/SkillsDataGetAll'
            }).done(data => {
                this.skills = data;
            });
        },
        async LanguagesDataGetir() {
            await $.ajax({
                url: '/Home/LanguagesDataGetAll'
            }).done(data => {
                this.languages = data;
            });
        },
        async CalisilanZamanHesapla() {
            var days = ['N', 'Y', 'Y', 'Y', 'Y', 'Y', 'N'];
            var tarih1 = new Date("2022-06-16");
            const timeElapsed = Date.now();
            var tarih2 = new Date(timeElapsed);

            var isGunu = 0;

            while (true) {

                if (tarih1 > tarih2) {
                    break;
                }

                var dayName = days[tarih1.getDay()];

                if (dayName != "N") {
                    isGunu++;
                }

                tarih1.setDate(tarih1.getDate() + 1);
            }
            this.calisilanZaman = isGunu * 9;
        }
    },
    created() {
        this.PersonalDataGetir();
        this.IntroduceYourselfDataGetir();
        this.ExpertiesDataGetir();
        this.ExperiencesDataGetir();
        this.EducationsDataGetir();
        this.SkillsDataGetir();
        this.LanguagesDataGetir();
        this.CalisilanZamanHesapla();
    },
    befourupdate() {
        this.PersonalDataGetir();
        this.IntroduceYourselfDataGetir();
        this.ExpertiesDataGetir();
        this.ExperiencesDataGetir();
        this.EducationsDataGetir();
        this.SkillsDataGetir();
        this.LanguagesDataGetir();
        this.CalisilanZamanHesapla();
    }
});

//#endregion