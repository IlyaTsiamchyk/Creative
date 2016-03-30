(function () {
    var controllerId = 'app.views.reader.index';
    angular.module('app').controller(controllerId, [
        '$scope', '$modal', 'abp.services.app.creative',
        function ($scope, $modal, creativesService) {
            var vm = this;
            var styles = [{ "font-size": "20px" },
                          { "font-size": "40px" },
                          { "font-size": "60px" }];
            vm.styleId = 1;
            vm.creativeReader = styles[vm.styleId];
            vm.setStyleId = function (Id) {
                console.log(Id);
                vm.creativeReader = styles[vm.styleId];
            };
        }
    ]);
})();