(function() {
    var controllerId = 'app.views.creatives.index';
    angular.module('app').controller(controllerId, [
        '$scope', '$modal', 'abp.services.app.creative',
        function ($scope, $modal, creativesService) {
            var vm = this;
            vm.creatives = [];
            vm.filters = {
                includeCanceledEvents: false
            };

            function loadCreatives() {
                creativesService.GetList(vm.filters).success(function (result) {
                    vm.creatives = result.items;
                });
            };

            vm.openNewEventDialog = function() {
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
        }
    ]);
})();