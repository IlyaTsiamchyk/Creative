(function() {
    var controllerId = 'app.views.creatives.index';
    angular.module('app').controller(controllerId, [
        '$scope', '$modal', 'abp.services.app.creative', 'abp.services.app.session',
        function ($scope, $modal, creativesService, sessionService) {
            var vm = this;
            vm.creatives;
            vm.sessionInformation;
            function loadCreatives() {
                sessionService.getCurrentLoginInformations().success(function (result) {
                    vm.sessionInformation = result;
                    creativesService.getAll().success(function (result) {
                        vm.creatives = result;
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

            vm.setRating = function (creativeId, index) {
                creativesService.addRate({
                    Value: vm.creatives[index].creativeRate,
                    UserBy: vm.sessionInformation.user.id,
                    CreativeId: creativeId
                }).success(function () {
                    abp.notify.success("Successfully saved.");
                });
            }

            vm.isAccess = function (userId) {
                return vm.sessionInformation.user.id === userId ? true : false;
            };

            loadCreatives();

        }
    ]);
})();