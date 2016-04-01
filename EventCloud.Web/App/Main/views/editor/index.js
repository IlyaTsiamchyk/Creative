(function () {
    var controllerId = 'app.views.editor.indexx';
    angular.module('app').controller(controllerId, [
        '$scope', '$modal', '$stateParams', 'abp.services.app.creative', 'abp.services.app.session',
        function ($scope, $modal, $stateParams, creativesService, sessionService) {
            var vm = this;

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
                            throw {
                                message: "No eccess!"
                            }
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
                if (vm.creative.Title === '')
                    throw {
                        message: "Empty creative title"
                    }
                vm.creative.Chapters.forEach(function (chapter, i, chapters) {
                    chapter.Number = i;
                    if (chapter.Name === '') throw {
                        message: "Empty chapter name"
                    }
                });
                
            };

            vm.removeCreative = function () {
                
            }

            vm.newChapter = function () {
                vm.creative.Chapters.push({
                    Name: "New Chapter",
                    Content: ''
                });
                setDrag();
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
            function handleDragStart(e) {
                console.log("1");
                this.style.opacity = '0.4';  // this / e.target is the source node.
            }

            function handleDragOver(e) {
                if (e.preventDefault) {
                    e.preventDefault(); // Necessary. Allows us to drop.
                }

                e.dataTransfer.dropEffect = 'move';  // See the section on the DataTransfer object.

                return false;
            }

            function handleDragEnter(e) {
                // this / e.target is the current hover target.
                console.log("3");
                this.classList.add('over');
            }

            function handleDragLeave(e) {
                console.log("4");
                this.classList.remove('over');  // this / e.target is previous target element.
            }

            function handleDrop(e) {
                // this / e.target is current target element.

                if (e.stopPropagation) {
                    e.stopPropagation(); // stops the browser from redirecting.
                }

                // See the section on the DataTransfer object.

                return false;
            }

            function handleDragEnd(e) {
                // this/e.target is the source node.

                [].forEach.call(cols, function (col) {
                    col.classList.remove('over');
                });
            }

            function setDrag() {
                var cols = document.querySelectorAll('#chapters .dropdown');
                [].forEach.call(cols, function (col) {
                    col.addEventListener('dragstart', handleDragStart, false);
                    col.addEventListener('dragenter', handleDragEnter, false)
                    col.addEventListener('dragover', handleDragOver, false);
                    col.addEventListener('dragleave', handleDragLeave, false);
                    col.addEventListener('drop', handleDrop, false);
                    col.addEventListener('dragend', handleDragEnd, false);
                });
            }
        }
    ]);
})();