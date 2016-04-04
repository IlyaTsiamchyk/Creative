(function () {
    var controllerId = 'app.views.layout';
    angular.module('app').controller(controllerId, [
        '$scope', function ($scope) {
            var vm = this;
            //Layout logic...
            function initStyle() {
                var flag = localStorage.getItem("style");
                if (flag === "1") {
                    var elements = document.getElementsByClassName("abody");
                    for (var i = 0; i < elements.length; i++)
                        elements[i].className = elements[i].className.replace('abody', 'bbody');
                }
            }
            initStyle();
        }]);
})();