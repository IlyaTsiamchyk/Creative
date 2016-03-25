(function () {
    angular.module('app').controller('app.views.creatives.createDialog', [
        'abp.services.app.creative', 'abp.services.app.session', '$modalInstance',
        function (creativeService, sessionService, $modalInstance) {
            var vm = this;

            vm.creative = {
                Title: '',
                CreationTime: moment().format('MMMM Do YYYY, h:mm:ss a'),
                UserId: getUserId,
                Category: 'novel'
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
            function getUserId() {
                return 2;
            }
        }
    ]);
})();