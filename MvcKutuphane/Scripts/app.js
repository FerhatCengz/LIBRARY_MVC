import "./dropzone.js?v=2.08";
import { App } from "./dropJsApp.js?v=2.08";

let sayfaKontrol = () => {
  for (let i = 0; i < localStorage.length; i++) {
    const localKey = localStorage.key(i);
    let contentDocument = $(
      ".data-table-id_" + localStorage.getItem(localKey)
    ).length;
    if (contentDocument >= 1) {
      $(".data-table-id_" + localStorage.getItem(localKey)).remove();
    }
  }
};
let pathName = window.location.pathname;

if (pathName == "/Panelim/Index" || pathName == "/Panelim") {
    App("/Panelim/ResimGuncelle",);
}

if (pathName == "/Uyeler/YeniUye") {
  App("/Uyeler/YeniUye", Number($("#dataLength").val()));
  $(".text-primary").click((e) => {
    $("#mydropzone").hide(750);
    $("#btnDropzonePost").hide();
    $("#btn_None_Photo").attr("type", "submit");
    $("#none-photo").text("Fotoğraflı Devam Etmek İstiyorum");
    $("#none-photo").removeClass("text-primary");
    $("#none-photo").remove();
  });
}

if (pathName == "/Uyeler/UyeListesi") {
  sayfaKontrol();

  const Toast = Swal.mixin({
    toast: true,
    position: "top-right",
    iconColor: "white",
    customClass: {
      popup: "colored-toast",
    },
    showConfirmButton: false,
    timer: 1500,
    timerProgressBar: true,
  });
  $(document).ready(function () {
    $(".btnDelete").click(function (e) {
      const data_id = Number(e.target.getAttribute("data-id"));
      $.ajax({
        url: "/Uyeler/UyeListesi",
        type: "GET",
        data: { islem: "sil", id: data_id },
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
          $.ajax({
            type: "GET",
            url: pathName + "?sayfa=" + sayfaNo,
            data: "id = dataTable",
            success: function (data) {
              const bulunanDeger = document.querySelector(
                ".data-table-id_" + data_id
              );
              $(".btnDelete").hide(0);
              Toast.fire({
                icon: "success",
                title: "Üye Başarıyle Silindi",
              });

              $(bulunanDeger).remove();
              localStorage.setItem("removeHTML" + data_id, data_id);
              setTimeout(() => {
                $(".btnDelete").show(750);
                if (document.querySelectorAll(".btnDelete").length == 0) {
                  let getPageNoParams = Number($("#sayfaNo").val()) - 1;
                  window.location =
                    "/Uyeler/UyeListesi?sayfa=" + getPageNoParams;
                }
              }, 1500);
            },
            error: function (data) {
              alert("Olmadı !");
            },
          });
        },
        error: function (data) {
          alert(data + "BAŞARIRISISIIZIZZZ !!");
        },
      });
    });
  });
}
