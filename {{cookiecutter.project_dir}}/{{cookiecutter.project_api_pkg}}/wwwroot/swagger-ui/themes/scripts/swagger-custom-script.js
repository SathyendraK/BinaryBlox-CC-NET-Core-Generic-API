(function () {
    window.addEventListener("load", function () {
        setTimeout(function () {
            var logo = document.getElementsByClassName('link');
            logo[0].href = "https://kp.org/";
            logo[0].target = "_blank";

            logo[0].children[0].alt = "{{cookiecutter.project_name}}: Open API Documentation";
            ogo[0].children[0].src = "/swagger-ui/themes/images/kp-logo-white.png";
        });
    });
})();

