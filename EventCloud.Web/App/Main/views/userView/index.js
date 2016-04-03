(function () {
    var controllerId = 'app.views.userView.index';
    angular.module('app').controller(controllerId, [
        '$scope', '$modal', 'abp.services.app.creative', 'abp.services.app.session',
        function ($scope, $modal, creativesService, sessionService) {
            var vm = this;
            vm.creatives;

            vm.filters = {
                includeCanceledEvents: false
            };
            function loadCreatives() {
                sessionService.getCurrentLoginInformations().success(function (result) {
                    var sessionInformation = result;
                    creativesService.getList(sessionInformation.user.id).success(function (result) {
                        vm.creatives = jQuery.parseJSON(result).Items;
                        console.log(vm.creatives);
                    });
                });
            };

            vm.openNewCreativeDialog = function () {
                console.log("openNewCreativeDialog");
                var modalInstance = $modal.open({
                    templateUrl: abp.appPath + 'App/Main/views/creatives/createDialog.cshtml',
                    controller: 'app.views.creatives.createDialog as vm',
                    size: 'md'
                });

                modalInstance.result.then(function () {
                    loadCreatives();
                });
            };

            $scope.$watch('vm.filters.includeCanceledEvents', function (newValue, oldValue) {
                if (newValue != oldValue) {
                    loadCreatives();
                }
            });
            loadCreatives();
            console.log(vm.creatives);
        }
    ]);
})();