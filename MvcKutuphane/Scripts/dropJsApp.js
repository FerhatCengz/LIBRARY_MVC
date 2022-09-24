Dropzone.autoDiscover = false;
export const App = async (actionName, dataLength = 0) => {
    $("#mydropzone").dropzone({
        url: actionName,
        autoProcessQueue: false,
        paramName: "file",
        dictDefaultMessage: "Fotoğrafınızı Sürükle / Bırak Yaparak Seçebilirsiniz",
        maxFiles: 1,
        dictMaxFilesExceeded: "En fazla 1 Dosya Gönderebilirsiniz",
        maxFilesize: 5,
        dictFileTooBig: "Dosya boyutu fazla - Max:5Mb",
        acceptedFiles: "image/jpeg,image/png,image/gif",
        dictInvalidFileType: "Geçersiz dosya tipi (.png) olmalı !",
        addRemoveLinks: true,
        dictRemoveFile: "Dosyayı Kaldır",
        init: function () {
            const dz = this;

            this.on("sending", function (image, xhr, formData) {
                if (actionName == "/Panelim/ResimGuncelle") {
                    formData.append("updatePhotoName", image.name)
                }

                if (actionName == "/Uyeler/YeniUye") {
                    formData.append("AD", $("#AD").val());
                    formData.append("SOYAD", $("#SOYAD").val());
                    formData.append("MAIL", $("#MAIL").val());
                    formData.append("KAD", $("#KAD").val());
                    formData.append("PASS", $("#PASS").val());
                    formData.append("USERPHOTO", image.name);
                    formData.append("PHONENO", $("#PHONENO").val());
                    formData.append("OKUL", $("#OKUL").val());
                }

            });

            $(document).on("click", "#btnDropzonePost", function (e) {
                dz.processQueue();
            });

            dz.on("error", function (file) {
                alert("Bir Sorun İle Karşılaştık Lütfen Tekrar Deneyiniz");
            });

            dz.on("success", function (file, respone) {
                if (actionName == "/Uyeler/YeniUye") {
                    window.location = `/Uyeler/UyeListesi?sayfa=${dataLength}`;
                }
                if (actionName == "/Panelim/ResimGuncelle") {
                    window.location.reload();
                }
            });
        },
    });
};
