$(document).ready(function () {

    $("#wizard").steps();

    $("#form").steps({
        labels: {
            current: "current step:",
            pagination: "Pagination",
            finish: "Kaydet",
            next: "İleri",
            previous: "Geri",
            loading: "Yükleniyor.."
        },
        bodyTag: "fieldset",
        transitionEffect: "slideLeft",
        stepsOrientation: "vertical",
        onStepChanging: function (event, currentIndex, newIndex) {
            // Always allow going backward even if the current step contains invalid fields!


            if (currentIndex > newIndex) {
                return true;



            }

            // Forbid suppressing "Warning" step if the user is to young

            if (newIndex === 1) {
                var check = true;

                if ($("#KategoriSelect").val() == "") {
                    bilgilendirme_toast("<div >Lütfen Kategori Seciniz</div>");
                    check = false;
                }

                if ($("#DersAdi").val() == "") {
                    bilgilendirme_toast("<div >Lütfen Ders Adi Giriniz</div>");
                    check = false;
                }

                if ($("#DersKoduInput").val() == "") {
                    bilgilendirme_toast("<div >Ders Kodu Boş Bırakılamaz</div>");
                    check = false;
                }

                if ($("#Acıklama").val() == "") {
                    bilgilendirme_toast("<div >Lütfen Açıklama Yazınız</div>");
                    check = false;
                }

                if ($("#EgitimTuru").val() == "") {
                    bilgilendirme_toast("<div >Lütfen Eğitim Türünü Seçiniz</div>");
                    check = false;
                }


            }
            if (newIndex === 2) {
                var check = true;

                if ($("#EgitimSorumlusu").val() == "") {
                    bilgilendirme_toast("<div >Lütfen Eğitim Sorumlusunu Yazınız</div>");
                    check = false;
                }
                if ($("#HedefKitle").val() == "") {
                    bilgilendirme_toast("<div >Lütfen Hedef Kitleyi Yazınız</div>");
                    check = false;
                }
                if ($("#Seans").val() == "") {
                    bilgilendirme_toast("<div >Lütfen Seans Giriniz</div>");
                    check = false;
                }
                if ($("#SeansPeriyod").val() == "") {
                    bilgilendirme_toast("<div >Lütfen Seans Periyodunu Belirtiniz</div>");
                    check = false;

                }
                if ($("#Egitmen").val() == "") {
                    bilgilendirme_toast("<div >Lütfen Eğitimeni Yazınız</div>");
                    check = false;
                }

                if ($("#OgrenimHedefleri").val() == "") {
                    bilgilendirme_toast("<div >Lütfen Ogrenim Hedeflerini Belirtiniz</div>");
                    check = false;
                }

                if ($("#Sure").val() == "") {
                    bilgilendirme_toast("<div >Lütfen Sure Yazınız</div>");
                    check = false;
                }
                if ($("#OrtamGereklilikleri").val() == "") {
                    bilgilendirme_toast("<div >Lütfen Ortam Gereklilikleri Yazınız</div>");
                    check = false;
                }
                if ($("#Medya").val() == "") {
                    bilgilendirme_toast("<div >Lütfen Medya Belirtiniz</div>");
                    check = false;
                }
                if ($("#BasarımOlcuteri").val() == "") {
                    bilgilendirme_toast("<div>Lütfen Basarım Olcutleri Yazınız</div>");
                    check = false;
                }
            }
            if (newIndex === 3) {
                var check = true;

                if ($("#Egitmen").val() == "") {
                    bilgilendirme_toast("<div >Lütfen Eğitmen Giriniz</div>");
                    check = false;
                    return check;
                }

                if ($("#Medya").val() == "") {
                    bilgilendirme_toast("<div >Lütfen Medya Giriniz</div>");
                    check = false;
                    return check;
                }
            }

            var form = $(this);

            // Clean up if user went backward before
            if (currentIndex < newIndex) {
                // To remove error styles
                $(".body:eq(" + newIndex + ") label.error", form).remove();
                $(".body:eq(" + newIndex + ") .error", form).removeClass("error");
            }

            // Disable validation on fields that are disabled or hidden.
            form.validate().settings.ignore = ":disabled,:hidden";

            // Start validation; Prevent going forward if false
            return form.valid();
        },
        onStepChanged: function (event, currentIndex, priorIndex) {


            if (currentIndex == 2) {

                var egitimturu = $("#EgitimTuru").val();

                if ($("#Seans").val() == "tek") {
                    var seanssayi = 1;
                } else {
                    var seanssayi = $("#SeansSayisiInput").val();
                }

                $("#accordion").empty();
                for (var i = 1; i <= seanssayi; i++) {
                    var collapse = "";
                    var arti = "fa fa-plus";
                    if (i == 1) {
                        collapse = "in";
                        arti = "fa fa-minus";
                    }

                    if (egitimturu == "Online") {
                        $("#accordion").append(` <div class="panel panel-default">
      <div class="panel-heading" style="background-color:#ddeedd;">
        <h4 class="panel-title">
          <a class="buton ${arti}" data-toggle="collapse" href="#collapse${i}"  > </a>
          <a >Seans ${i}</a>
          <a style="margin-left:810px;background-color:#f8ac59" class="kapat btn btn btn-danger btn-xs fa fa-trash" data-veri-varmi="0" data-grup-value="collapse${i}"  ></a>
         </h4>
      </div>
      <div id="collapse${i}" class="panel-collapse collapse ${collapse}">
        <div class="panel-body"><div class="form-group row" >
                                    <label class="col-md-2 control-label">
                                        <span>Eğitmen</span>
                                       
                                    </label>
                                    <div class="col-md-4">
                                        <input class="form-control" name="Egitmen" id="Egitmen" type="text"  />
                                    </div>
                                                              
                                    <label class="col-md-2 control-label">
                                        <span>Öğrenim Hedefleri</span>
                                      
                                    </label>
                                    <div class="col-md-4">
                                        <input class="form-control" name="OgrenimHedef" id="OgrenimHedef" type="text"  />
                                    </div>
                                   </div>
                                <div class="form-group row">
                                    <label class="col-md-2 control-label">
                                        <span>Süre</span>
                                      
                                    </label>
                                    <div class="col-md-4">
                                        <input class="form-control" name="Sure" id="Sure" type="time"  />
                                    </div>
                                 
                               

                                
                                    <label class="col-md-2 control-label">
                                        <span>Ortam Gereklilikleri</span>
                                      
                                    </label>
                                    <div class="col-md-4">
                                     <input class="form-control" name="OrtamGereklilik" id="OrtamGereklilik" type="text"  />
                                    </div>

                                 </div>

                              <div class="form-group row">
                                    <label class="col-md-2 control-label">
                                        <span>Medya</span>
                                     
                                    </label>
                                    <div class="col-md-4">
                                     <input class="form-control" name="Medya" id="Medya" type="file"  />
                                    </div>
                                 
                      <div class="col-md-2">
                               
                        </div>

                    

                                
                                  
                                </div>
             
                                </div>
      </div>
    </div> `);
                    }
                    else {
                        $("#accordion").append(`<div class="panel panel-default">
      <div class="panel-heading" style="background-color:#ddeedd;">
        <h4 class="panel-title">
          <a class="buton ${arti}" data-toggle="collapse" href="#collapse${i}"  > </a>
          <a >Seans ${i}</a>
          <a style="margin-left:810px;background-color:#f8ac59" class="kapat btn btn btn-danger btn-xs fa fa-trash" data-veri-varmi="0" data-grup-value="collapse${i}"  ></a>
         </h4>
      </div>
      <div id="collapse${i}" class="panel-collapse collapse ${collapse}">
        <div class="panel-body"><div class="form-group row" >
                                   <label class="col-md-2 control-label">
                                        <span>Öğrenim Hedefleri</span>
                                      
                                    </label>
                                    <div class="col-md-4">
                                        <input class="form-control" name="OgrenimHedefleri" id="OgrenimHedef" type="text"  />
                                    </div>
                                    <label class="col-md-2 control-label">
                                        <span>Eğitmen</span>
                                       
                                    </label>
                                    <div class="col-md-4">
                                        <input class="form-control" name="Egitmen" id="Egitmen" type="text"  />
                                    </div>
                                                              
                                    
                                   </div>
                                <div class="form-group row">
                                    <label class="col-md-2 control-label">
                                        <span>Süre</span>
                                      
                                    </label>
                                    <div class="col-md-4">
                                        <input class="form-control" name="Sure" id="Sure" type="time"  />
                                    </div>
                                 
                               

                                
                                    <label class="col-md-2 control-label">
                                        <span>Ortam Gereklilikleri</span>
                                      
                                    </label>
                                    <div class="col-md-4">
                                     <input class="form-control" name="OrtamGereklilikleri" id="OrtamGereklilik" type="text"  />
                                    </div>

                                 </div>

                              <div class="form-group row">
                                    <label class="col-md-2 control-label">
                                        <span>Araçlar</span>
                                     
                                    </label>
                                    <div class="col-md-4">
                                     <input class="form-control" name="Araclar" id="Araclar" type="text"  />
                                    </div>

                                <label class="col-md-2 control-label">
                                        <span>Egitim Medya</span>
                                     
                                    </label>
                                    <div class="col-md-4">
                                     <input class="form-control" name="EgitmenMedya" id="EgitmenMedya" type="file"  />
                                    </div>
                       </div>
                      <div class="form-group row">
                                    <label class="col-md-2 control-label">
                                        <span>Egitmen Yetkinlikleri</span>
                                     
                                    </label>
                                    <div class="col-md-4">
                                     <input class="form-control" name="EgitmenYetkinlikleri" id="EgitmenYetkinlikleri" type="text"  />
                                    </div>

                                
                       </div>
                     

                      <div class="col-md-2">
                               
                        </div>

                    

                                
                                  
                                </div>
             
                                </div>
      </div>
    </div> `);
                    }
                }

                if ($("#Seans").val() == "tek") {

                    $("#seansekle").hide();
                    $(".kapat").hide();
                }
                else {
                    $("#seansekle").show();
                    $(".kapat").show();
                }




            }



        },
        onFinishing: function (event, currentIndex) {
            var form = $(this);

            var check = true;

            return check;
        },
        onFinished: function (event, currentIndex) {
            var form = $(this);
            form.submit();
        }
    }).validate({
        errorPlacement: function (error, element) {
            element.before(error);
        },
        rules: {
            confirm: {
                equalTo: "#passw"
            }
        }
    });





    $("#Seans").on("change", function () {
        if ($("#Seans").val() == "cok") {
            $("#SeansSayisi").append(`<label class="col-md-4 control-label">
                                        <span>Seans Sayısı</span>
                                        <span class="zorunlu">*</span>:
                                    </label>
                                    <div class="col-md-8">
                                        <input class="form-control" name="SeansSayisiInput" id="SeansSayisiInput" type="number" required />
                                    </div>`);
        }
        if ($("#Seans").val() == "tek") {
            $("#SeansSayisi").empty();

        }

    });

    $('a[href="#finish"]').addClass("buttonToAction");
    $('.chosen-select').chosen({ width: "100%" });




});

$(document).on("click", ".buton", function () {
    if ($(this).attr('class') == "buton fa fa-plus") {
        $(this).removeClass();
        $(this).addClass("buton fa fa-minus");
    }

    else {
        $(this).removeClass();
        $(this).addClass("buton fa fa-plus");
    }
});





$(document).on("click", ".kapat", function () {
    var silinecek = this.parentElement.parentElement.parentElement;

    var seanssayisi = $("#SeansSayisiInput").val();
    $("#SeansSayisiInput").val(seanssayisi - 1);
    silinecek.remove();

});


$(document).on('click', "#seansekle", function () {

    var sonseanssayi = Number($("#SeansSayisiInput").val());
    var eklenenseanssayi = sonseanssayi + 1;
    $("#SeansSayisiInput").val(sonseanssayi + 1);

    var collapses = "";
    var artii = "fa fa-plus";
    if (eklenenseanssayi == 1) {
        collapses = "in";
        artii = "fa fa-minus";
    }
    var egitimturuekle = $("#EgitimTuru").val();

    if (egitimturuekle == "Online") {
        $("#accordion").append(` <div class="panel panel-default">
      <div class="panel-heading" style="background-color:#ddeedd;">
        <h4 class="panel-title">
          <a class="buton ${artii}" data-toggle="collapse" href="#collapse${eklenenseanssayi}"  > </a>
          <a >Seans ${eklenenseanssayi}</a>
          <a style="margin-left:810px;background-color:#f8ac59" class="kapat btn btn btn-danger btn-xs fa fa-trash" data-veri-varmi="0" data-grup-value="collapse${eklenenseanssayi}"  ></a>
         </h4>
      </div>
      <div id="collapse${eklenenseanssayi}" class="panel-collapse collapse ${collapses}">
        <div class="panel-body"><div class="form-group row" >
                                    <label class="col-md-2 control-label">
                                        <span>Eğitmen</span>
                                       
                                    </label>
                                    <div class="col-md-4">
                                        <input class="form-control" name="Egitmen" id="Egitmen" type="text"  />
                                    </div>
                                                              
                                    <label class="col-md-2 control-label">
                                        <span>Öğrenim Hedefleri</span>
                                      
                                    </label>
                                    <div class="col-md-4">
                                        <input class="form-control" name="OgrenimHedef" id="OgrenimHedef" type="text"  />
                                    </div>
                                   </div>
                                <div class="form-group row">
                                    <label class="col-md-2 control-label">
                                        <span>Süre</span>
                                      
                                    </label>
                                    <div class="col-md-4">
                                        <input class="form-control" name="Sure" id="Sure" type="time"  />
                                    </div>
                                 
                               

                                
                                    <label class="col-md-2 control-label">
                                        <span>Ortam Gereklilikleri</span>
                                      
                                    </label>
                                    <div class="col-md-4">
                                     <input class="form-control" name="OrtamGereklilik" id="OrtamGereklilik" type="text"  />
                                    </div>

                                 </div>

                              <div class="form-group row">
                                    <label class="col-md-2 control-label">
                                        <span>Medya</span>
                                     
                                    </label>
                                    <div class="col-md-4">
                                     <input class="form-control" name="Medya" id="Medya" type="file"  />
                                    </div>
                                 
                      <div class="col-md-2">
                               
                        </div>

                    

                                
                                  
                                </div>
             
                                </div>
      </div>
    </div> `);
    }
    else {

        $("#accordion").append(`<div class="panel panel-default">
      <div class="panel-heading" style="background-color:#ddeedd;">
        <h4 class="panel-title">
          <a class="buton ${artii}" data-toggle="collapse" href="#collapse${eklenenseanssayi}"  > </a>
          <a >Seans ${eklenenseanssayi}</a>
          <a style="margin-left:810px;background-color:#f8ac59" class="kapat btn btn btn-danger btn-xs fa fa-trash" data-veri-varmi="0" data-grup-value="collapse${eklenenseanssayi}"  ></a>
         </h4>
      </div>
      <div id="collapse${eklenenseanssayi}" class="panel-collapse collapse ${collapses}">
        <div class="panel-body"><div class="form-group row" >
                                   <label class="col-md-2 control-label">
                                        <span>Öğrenim Hedefleri</span>
                                      
                                    </label>
                                    <div class="col-md-4">
                                        <input class="form-control" name="OgrenimHedefleri" id="OgrenimHedef" type="text"  />
                                    </div>
                                    <label class="col-md-2 control-label">
                                        <span>Eğitmen</span>
                                       
                                    </label>
                                    <div class="col-md-4">
                                        <input class="form-control" name="Egitmen" id="Egitmen" type="text"  />
                                    </div>
                                                              
                                    
                                   </div>
                                <div class="form-group row">
                                    <label class="col-md-2 control-label">
                                        <span>Süre</span>
                                      
                                    </label>
                                    <div class="col-md-4">
                                        <input class="form-control" name="Sure" id="Sure" type="time"  />
                                    </div>
                                 
                               

                                
                                    <label class="col-md-2 control-label">
                                        <span>Ortam Gereklilikleri</span>
                                      
                                    </label>
                                    <div class="col-md-4">
                                     <input class="form-control" name="OrtamGereklilikleri" id="OrtamGereklilik" type="text"  />
                                    </div>

                                 </div>

                              <div class="form-group row">
                                    <label class="col-md-2 control-label">
                                        <span>Araçlar</span>
                                     
                                    </label>
                                    <div class="col-md-4">
                                     <input class="form-control" name="Araclar" id="Araclar" type="text"  />
                                    </div>

                                <label class="col-md-2 control-label">
                                        <span>Egitim Medya</span>
                                     
                                    </label>
                                    <div class="col-md-4">
                                     <input class="form-control" name="EgitmenMedya" id="EgitmenMedya" type="file"  />
                                    </div>
                       </div>
                      <div class="form-group row">
                                    <label class="col-md-2 control-label">
                                        <span>Egitmen Yetkinlikleri</span>
                                     
                                    </label>
                                    <div class="col-md-4">
                                     <input class="form-control" name="EgitmenYetkinlikleri" id="EgitmenYetkinlikleri" type="text"  />
                                    </div>

                                
                       </div>
                     

                      <div class="col-md-2">
                               
                        </div>

                    

                                
                                  
                                </div>
             
                                </div>
      </div>
    </div> `);

    }
});


function bilgilendirme_toast(mesaj) {
    Command: toastr["warning"](
        mesaj);

    toastr.options = {
        "closeButton": true,
        "debug": false,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "onclick": null,
        "showDuration": "400",
        "hideDuration": "1000",
        "timeOut": "7000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
}



$("#fotograf_sil").on('click',
    function () {

        $('#FirmaImage').val("");
        $('#foto_varmi_kontrol').val(1);
        $("#fotograf").attr('src', firmaImagePath);
        const lightBoxGallery_href = document.getElementById("lightBoxGallery_href");
        lightBoxGallery_href.href = firmaImagePath;

    });

model_gelen_foto_ayarla();

function
    model_gelen_foto_ayarla() { // modelden gelen fotografi fotogral alani icerisinde boyutuna gore ayarlar
    const img = document.getElementById('fotograf');

    const width = img.clientWidth;
    const height = img.clientHeight;

    if (height > width) {


        img.style.width = 'auto';
        img.style.height = '100%';
    } else {
        img.style.width = '100%';
        img.style.height = 'auto';
    }

}

var _URL = window.URL || window.webkitURL;

$("#FirmaImage").change(function (e) {


    var file, img;

    $('#foto_varmi_kontrol').val(1);
    if ((file = this.files[0])) {
        img = new Image();
        img.onload = function () {
            //alert(this.width + " " + this.height);


            $('#fotograf').attr('src', this.src);
            $('#fotograf').hide();
            $('#fotograf').fadeIn(650);


            var foto_heigth, foto_width;
            foto_heigth = this.height;
            foto_width = this.width;
            const yourImg = document.getElementById('fotograf');

            if ((foto_heigth > foto_width)) {
                yourImg.style.width = '80%';
                yourImg.style.height = '100%';
            } else {
                yourImg.style.width = '100%';
                yourImg.style.height = '80%';
            }

        };
        img.onerror = function () {
            alert(`not a valid file: ${file.type}`);
        };
        img.src = _URL.createObjectURL(file);

        const lightBoxGallery_href = document.getElementById("lightBoxGallery_href");
        lightBoxGallery_href.href = _URL.createObjectURL(file);
    }

});



