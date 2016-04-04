(function () {
    var controllerId = 'app.views.reader.index';
    angular.module('app').controller(controllerId, [
        '$scope', '$modal', '$stateParams', 'abp.services.app.creative', 'abp.services.app.session',
        function ($scope, $modal, $stateParams, creativesService, sessionService) {
            var vm = this;
            var styles = [{ "font-size": "12px!important" },
                          { "font-size": "18px!important" },
                          { "font-size": "22px!important" }];
            vm.styleId = 1;
            vm.success = false;
            vm.chaptersIsEmpty = true;
            vm.creativeReader = styles[vm.styleId];

            vm.setStyleId = function (Id) {
                vm.creativeReader = styles[Id];
            };

            $scope.disqusConfig = {};

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
                    $scope.disqusConfig = {
                        disqus_shortname: 'CreativeBlog',
                        disqus_identifier: 'http://localhost:6334/#/' + vm.creative.Id,
                        disqus_url: 'http://localhost:6334/#/creatives/' + vm.creative.Id
                    };
                    //vm.Rating = vm.creative.Rates;
                }
            });

            var sessionInformation;
            sessionService.getCurrentLoginInformations().success(function (result) {
                sessionInformation = result;
            });

            vm.setRating = function () {
                creativesService.addRate({
                    Value: vm.creative.creativeRate,
                    UserBy: sessionInformation.user.id,
                    CreativeId: vm.creative.Id
                }).success(function () {
                    abp.notify.success("Successfully saved.");
                });
            }

            vm.isAccess = function (userId) {
                return vm.sessionInformation.user.id === userId ? true : false;
            };
        }
    ]);
})();