(function () {
    var controllerId = 'app.views.editor.indexx';
    angular.module('app').controller(controllerId, [
        '$scope', '$modal', '$stateParams', 'abp.services.app.creative', 'abp.services.app.session',
        function ($scope, $modal, $stateParams, creativesService, sessionService) {
            var vm = this;
            vm.creative;
            vm.isAccess = false;
            creativesService.details($stateParams.id).success(function (result) {
                try{
                    var creative = jQuery.parseJSON(result);
                    if (creative !== null) {
                        sessionService.getCurrentLoginInformations().success(function (result) {
                            vm.sessionInformation = result;
                            console.log(vm.sessionInformation);
                            if (vm.sessionInformation.user.id === creative.UserId) {
                                vm.isAccess = true;
                                vm.creative = creative;
                                vm.creative.Capters.sort(function (a, b) {
                                    return a.NumberOfChapter - b.NumberOfChapter;
                                })
                                console.log(vm.creative);
                                console.log(vm.creative.Capters);
                            }
                            else
                                abp.message.error("Error!", "You haven't eccess");
                        });
                    }
                    else
                        abp.message.error("Error!", "Page not found");
                } catch (exp) {
                    
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
                    vm.creative.Capters.forEach(function (chapter, i, chapters) {
                        chapter.NumberOfChapter = i + 1;
                        chapter.CreativeId = vm.creative.Id
                        if (chapter.Name === '')
                            throw {
                                message: "Empty chapter name"
                            }
                    });
                    vm.creative.Chapters = vm.creative.Capters;
                    console.log(vm.creative);
                    creativesService.edit(vm.creative);
                    abp.notify.success('Saved successfully!','');
                } catch (exp) {
                    abp.message.error("", exp.message);
                }
            };

            vm.removeCreative = function () {
            }

            vm.newChapter = function () {
                vm.creative.Capters.push({
                    Name: "New Chapter",
                    Content: ''
                });
            }

            vm.removeChapter = function () {
                var index = 0;
                if (vm.creative.Capters !== null) {
                    while (vm.creative.Capters[index].Id === vm.globalIndex) {
                        index++;
                    }
                    vm.creative.Capters.splice(index, 1);
                    vm.globalIndex = 0;
                }
            }

            var position = {};
            function changePosition() {
                var index1 = position.prev.indexOf(position.id);
                var index2 = position.next.indexOf(position.id);
                vm.creative.Capters.splice(index2, 0, vm.creative.Capters.splice(index1, 1)[0]);
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