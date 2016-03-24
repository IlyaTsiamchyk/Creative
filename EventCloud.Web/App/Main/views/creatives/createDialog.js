(function () {
    angular.module('app').controller('app.views.creatives.createDialog', [
        'abp.services.app.creative', '$modalInstance',
        function (creativService, $modalInstance) {
            var vm = this;

            vm.creativ = {
                Title: 'popopo',
                //description: '',
                date: moment().add('day', 1).format('YYYY-MM-DD'),
                maxRegistrationCount: 0
            }

            vm.save = function() {
                creativService
                    .Create(vm.creativ)
                    .success(function () {
                        abp.notify.success("Successfully saved.");
                        $modalInstance.close();
                    });
            };

            vm.cancel = function () {
                $modalInstance.dismiss('cancel');
            };
        }
    ]);
})();