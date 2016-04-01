(function () {
    var controllerId = 'app.views.editor.indexx';
    angular.module('app').controller(controllerId, [
        '$scope', '$modal', '$stateParams', 'abp.services.app.creative', 'abp.services.app.session',
        function ($scope, $modal, $stateParams, creativesService, sessionService) {
            var vm = this;
            vm.creative;
            creativesService.details($stateParams.id).success(function (result) {
                var creative = jQuery.parseJSON(result);
                console.log(creative);
                if (creative !== null) {
                    sessionService.getCurrentLoginInformations().success(function (result) {
                        var sessionInformation = result;
                        console.log(sessionInformation);
                        if (sessionInformation.user.id === creative.UserId) {
                            vm.creative = creative;
                            vm.creative.Chapters.sort(function (a, b) {
                                return a.number - b.number;
                            })
                        }
                        else {
                            abp.message.error("No eccess!", 'saasdasdasd');

                        }
                    });
                }
                else
                    throw {
                        message: "Not found!"
                    }
            });

            vm.globalIndex = 0;

            vm.getChapterContent = function (Index) {
                vm.globalIndex = Index;
            };

            vm.saveCreative = function () {
                try {
                    if (vm.creative.Title === '')
                        throw {
                            message: "Empty creative title"
                        }
                    vm.creative.Chapters.forEach(function (chapter, i, chapters) {
                        chapter.Number = i;
                        if (chapter.Name === '')
                            throw {
                                message: "Empty chapter name"
                            }
                        creativesService.edit(vm.creative);
                        console.log(vm.creative);
                    });
                } catch (exp) {
                    abp.message.error("", "Empty chapter name");
                }
            };

            vm.removeCreative = function () {

            }

            vm.newChapter = function () {
                vm.creative.Chapters.push({
                    Name: "New Chapter",
                    CreativeId: vm.creative.Id,
                    Content: ''
                });
                //setDrag();
            }

            vm.removeChapter = function () {
                var index = 0;
                if (vm.creative.Chapters !== null) {
                    while (vm.creative.Chapters[index].Id === vm.globalIndex) {
                        index++;
                    }
                    vm.creative.Chapters.splice(index, 1);
                }
            }



            //////////////////////////////////////////////////////////
        }
    ]);
})();