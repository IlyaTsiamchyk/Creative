(function () {
    var controllerId = 'app.views.userView.index';
    angular.module('app').controller(controllerId, [
        '$scope', '$modal', '$stateParams', 'abp.services.app.creative', 'abp.services.app.session', 'abp.services.app.user',
        function ($scope, $modal, $stateParams, creativesService, sessionService, userService) {
            var vm = this;
            vm.creatives;
            vm.user;
            vm.medals = [false, false, false, false];
            function loadCreatives() {
                sessionService.getCurrentLoginInformations().success(function (result) {
                    vm.sessionInformation = result;
                    var Id = $stateParams.id;
                    
                    if (Id === '') Id = vm.sessionInformation.user.id;
                    creativesService.getList(Id).success(function (result) {
                        vm.creatives = result;
                        console.log(vm.creatives);
                        if (vm.creatives[0].userId % 3 === 0) vm.medals[0] = true;
                        if (vm.creatives.length >= 1) vm.medals[1] = true;
                        if (vm.creatives.length >= 5) vm.medals[2] = true;
                        
                        userService.getUser(Id).success(function (result) {
                            vm.user = result;
                            console.log(result);
                        });
                    });
                });
            };

            function loadUserInformation() {
                
            }
            loadUserInformation();

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