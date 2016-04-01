(function () {
    var controllerId = 'app.views.reader.index';
    angular.module('app').controller(controllerId, [
        '$scope', '$modal', '$stateParams', 'abp.services.app.creative',
        function ($scope, $modal, $stateParams, creativesService) {
            var vm = this;
            var styles = [{ "font-size": "20px" },
                          { "font-size": "30px" },
                          { "font-size": "40px" }];
            vm.styleId = 1;
            vm.success = false;
            vm.creativeReader = styles[vm.styleId];
            vm.setStyleId = function (Id) {
                console.log(Id);
                vm.creativeReader = styles[Id];
                console.log(vm.creativeReader);
            };
            
            var chapterNumber = 0;
            vm.choiseChapter = function (offset) {
                if (vm.creative.Chapters === null) {
                    vm.chaptersIsEmpty = true;
                    return;
                }
                else
                    vm.chaptersIsEmpty = false;
                chapterNumber = ((chapterNumber + offset) > 0 && offset < 0) || ((chapterNumber + offset) < vm.creative.Chapters.length && offset > 0)
                    ? chapterNumber + offset : chapterNumber;
                vm.chapterToShow = vm.creative.Chapters[chapterNumber];
            }

            creativesService.details($stateParams.id).success(function (result) {
                vm.creative = jQuery.parseJSON(result);
                console.log(vm.creative);
                if (vm.creative !== null) {
                    vm.choiseChapter(chapterNumber);
                    vm.success = true;
                }
            });
        }
    ]);
})();