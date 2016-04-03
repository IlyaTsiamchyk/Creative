(function () {
    var controllerId = 'app.views.editor.indexx';
    angular.module('app').controller(controllerId, [
        '$scope', '$modal', '$stateParams', 'abp.services.app.creative', 'abp.services.app.session',
        function ($scope, $modal, $stateParams, creativesService, sessionService) {
            var vm = this;
            vm.tags;
            vm.isEccess = true;
            vm.creative;
            creativesService.details($stateParams.id).success(function (result) {
                try{
                    var creative = jQuery.parseJSON(result);
                    console.log(creative);
                    if (creative !== null) {
                        sessionService.getCurrentLoginInformations().success(function (result) {
                            var sessionInformation = result;
                            console.log(sessionInformation);
                            if (sessionInformation.user.id === creative.UserId) {
                                vm.creative = creative;
                                vm.tags = creative.Tags;
                                vm.creative.Chapters.sort(function (a, b) {
                                    return a.NumberOfChapter - b.NumberOfChapter;
                                })
                            }
                            else throw{
                                message: "No eccess!"
                            }
                        });
                    }
                    else
                        throw {
                            message: "Not found!"
                        }
                } catch (exp) {
                    abp.message.error("Error!", exp.message);
                    vm.isEccess = false;
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
                        chapter.NumberOfChapter = i + 1;
                        chapter.CreativeId = vm.creative.Id
                        if (chapter.Name === '')
                            throw {
                                message: "Empty chapter name"
                            }
                    });
                    creativesService.edit(vm.creative);
                    abp.notify.success('Saved successfully!','');
                    console.log(vm.creative);
                } catch (exp) {
                    abp.message.error("", exp.message);
                }
            };

            vm.removeCreative = function () {

            }

            vm.newChapter = function () {
                vm.creative.Chapters.push({
                    Name: "New Chapter",
                    Content: ''
                });
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

            var position = {};
            function changePosition() {
                var index1 = position.prev.indexOf(position.id);
                var index2 = position.next.indexOf(position.id);
                vm.creative.Chapters.splice(index2, 0, vm.creative.Chapters.splice(index1, 1)[0]);
            }

            $(function () {
                $("#sortable").sortable({
                    stop: function (event, ui) {
                        position.next = $('#sortable').sortable("toArray");
                        position.id = ui.item.context.id;
                        changePosition();
                    },
                    start: function(){
                        position.prev = $('#sortable').sortable("toArray");
                    }
                });
                $("#sortable").disableSelection();

            });
        }
    ]);
})();