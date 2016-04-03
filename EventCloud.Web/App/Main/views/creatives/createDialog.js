(function () {
    angular.module('app').controller('app.views.creatives.createDialog', [
        'abp.services.app.creative', 'abp.services.app.session', '$modalInstance', 'abp.services.app.category',
        function (creativeService, sessionService, $modalInstance, categoryService) {
            var vm = this;
            var information = {};
            vm.creative = {
                Title: '',
                CreationTime: moment().format('MMMM Do YYYY, h:mm:ss a'),
                UserId: 0 ,
                CategoryId: 0
            }

            vm.save = function() {
                console.log(information);
               /* creativeService
                    .create(vm.creative)
                    .success(function () {
                        abp.notify.success("Successfully saved.");
                        $modalInstance.close();*/
                    //});
            };

            vm.cancel = function () {
                $modalInstance.dismiss('cancel');
            };
            
            function getInformation() {
               
            }
            getInformation();
        }
    ]);
})();