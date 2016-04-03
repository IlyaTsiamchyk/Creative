(function () {
    angular.module('app').controller('app.views.creatives.createDialog', [
        'abp.services.app.creative', 'abp.services.app.session', '$modalInstance', 'abp.services.app.category',
        function (creativeService, sessionService, $modalInstance, categoryService) {
            var vm = this;
            vm.categores;
            vm.creative = {
                Title: '',
                CreationTime: moment().format('MMMM Do YYYY, h:mm:ss a'),
                UserId: 0 ,
                CategoryId: 0
            }

            vm.save = function() {
                creativeService
                    .create(vm.creative)
                    .success(function () {
                        abp.notify.success("Successfully saved.");
                        $modalInstance.close();
                    });
            };

            vm.cancel = function () {
                $modalInstance.dismiss('cancel');
            };
            
            function getInformation() {
                sessionService.getCurrentLoginInformations().success(function (result) {
                    vm.creative.UserId = result.user.id;
                });
                categoryService.getList().success(function (result) {
                    vm.categores = result;
                    console.log(vm.categores);
                });
            }
            getInformation();
        }
    ]);
})();