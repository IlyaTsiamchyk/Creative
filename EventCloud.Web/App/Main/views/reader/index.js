(function () {
    var controllerId = 'app.views.reader.index';
    angular.module('app').controller(controllerId, [
        '$scope', '$modal', '$stateParams', 'abp.services.app.creative',
        function ($scope, $modal, $stateParams, creativesService) {
            var vm = this;
            var styles = [{ "font-size": "12px!important" },
                          { "font-size": "18px!important" },
                          { "font-size": "22px!important" }];
            vm.Rating = 5;
            vm.styleId = 1;
            vm.success = false;
            vm.chaptersIsEmpty = true;
            vm.creativeReader = styles[vm.styleId];

            vm.setStyleId = function (Id) {
                vm.creativeReader = styles[Id];
            };
            
            var chapterNumber = 0;
            vm.choiseChapter = function (offset) {
                chapterNumber = ((chapterNumber + offset) >= 0 && offset < 0) || ((chapterNumber + offset) < vm.creative.Chapters.length && offset > 0)
                    ? chapterNumber + offset : chapterNumber;
                vm.chapterToShow = vm.creative.Chapters[chapterNumber];
            }

            creativesService.details($stateParams.id).success(function (result) {
                vm.creative = jQuery.parseJSON(result);
                console.log(vm.creative);
                if (vm.creative !== null) {
                    vm.success = true;
                    if (vm.creative.Chapters.length !== 0) {
                        vm.choiseChapter(chapterNumber);
                        vm.chaptersIsEmpty = false;
                    }
                    //vm.Rating = vm.creative.Rates;
                }
            });

            vm.setRating = function () {

            }
        }
    ]);
})();