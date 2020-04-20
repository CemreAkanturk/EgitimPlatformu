$(document).ready(function () {


  

    $("#wizard").steps();

    $("#form").steps({
        labels: {
            current: "current step:",
            pagination: "Pagination",
            finish: "Save",
            next: "Next",
            previous: "Prev",
            loading: "Loading"
        },
        bodyTag: "fieldset",
        onStepChanging: function (event, currentIndex, newIndex) {
            // Always allow going backward even if the current step contains invalid fields!


            if (currentIndex > newIndex) {
                return true;



            }

            // Forbid suppressing "Warning" step if the user is to young

            if (newIndex === 1) {
                var check = true;

                if ($("#KategoriSelect").val() == "bos") {
                   
                    bilgilendirme_toast("<div>Lütfen Kategori Seciniz</div>");
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

                if ($("#Acıklama").val() == "") {
                    bilgilendirme_toast("<div >Lütfen Açıklama Yazınız</div>");
                    check = false;
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
          

         

        },
        onFinishing: function (event, currentIndex) {
            var form = $(this);
            var check = true;
            

            var SeansPeriyodSayisi = $("#SeansPeriyodInput").val();
            var SeansPeriyodTipi = $("#SeansPeriyodSelect").val();

            if (SeansPeriyodTipi == 0) {

                $("#SeansPeriyod").val(SeansPeriyodSayisi*1);
                
            } 
            else if (SeansPeriyodTipi == 1) {
                $("#SeansPeriyod").val(SeansPeriyodSayisi * 7);
            }
            else if (SeansPeriyodTipi == 2) {
                $("#SeansPeriyod").val(SeansPeriyodSayisi * 30);
            }
            else if (SeansPeriyodTipi == 3) {
                $("#SeansPeriyod").val(SeansPeriyodSayisi * 365);
            }

            alert($("#SeansPeriyod").val())
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


   
    $('.chosen-select').chosen({ width: "100%" });




    RegexValidation();

    function RegexValidation() {


        const maxLength_atama = document.querySelectorAll(".regex_validation");
        for (let i = 0; i < maxLength_atama.length; i++) {
            if (maxLength_atama[i].parentNode.getElementsByClassName("max")) {
                maxLength_atama[i].parentNode.getElementsByClassName("max")[0].innerHTML =
                    maxLength_atama[i].maxLength;
            }

        }

        $('.regex_validation').keyup(function () {
       
            var regex; //regex tanimi bknz: regexr.com

            if (this.getAttribute('data-type') === 'text') {
                regex = /[a-zA-Z0-9 ]+/g;


                var input_value = this.value; //input degerini alir
                var karakter_uzunlugu = input_value.length; //input strin uzunlugunu alir
                //$( this ).attr( "maxlength", maxlength); //input maxlength atrr na gelen degeri atar
                //var sayac = this.parentNode.getElementsByClassName( "current" )[0].innerHTML = maxlength - karakter_uzunlugu;

                this.parentNode.getElementsByClassName("current")[0].innerHTML =
                    karakter_uzunlugu; //girilen_karakter_sayisi

                //var girilebilcek_karakter_sayisi = this.parentNode.getElementsByClassName( "max" )[0].innerHTML = this.maxLength;
                //tiklanan input uzerinde bulunan ebeveyn dive ulasir ve bu ebeveyn div icindeki sayac icin tanimli olan dive gecer . Standart yapisi bu sekilde olmalidir
                var regex_sonuc = input_value.match(regex); //gelen input degerini regex e tabi tutar
                this.value = regex_sonuc; //input degerine regex sonucunu atar
            }



        });


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