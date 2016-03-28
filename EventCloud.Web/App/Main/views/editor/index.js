(function () {
    var controllerId = 'app.views.editor.indexx';
    angular.module('app').controller(controllerId, [
        '$scope', '$modal', 'abp.services.app.creative', 'abp.services.app.session',
        function ($scope, $modal, creativesService, sessionService) {
            var vm = this;
            vm.globalId = 0;
            vm.chaptersList = [
                {
                    Name: "firts chap",
                    Content: 'asakjhdshdskjadsfkjdsfjdsfjads',
                    Number: 1,
                    Id: 1
                },
                {
                    Name: "sec chap",
                    Content: 'asdasddfsczxczxcjads',
                    Number: 3,
                    Id: 2
                },
                {
                    Name: "thre chap",
                    Content: 'asadzxczxfjdsfjads',
                    Number: 5,
                    Id: 3
                },
                {
                    Name: "fouth chap",
                    Content: 'asakzxcaddqwadasdasdfkjdsfjdsfjads',
                    Number: 6,
                    Id: 4
                }
            ]
            vm.editorContent = 'qwertyuiop';
            vm.creativeTitle = 'Kokoko';
            vm.getChapterContent = function (Id) {
                Id--;
                vm.chaptersList[vm.globalId].Content = vm.editorContent;
                vm.editorContent = vm.chaptersList[Id].Content;
                vm.globalId = Id;
            };
            vm.saveCreative = function () {
                
            };
            
            vm.removeCreative = function () {
                
            }
            vm.newChapter = function () {
                vm.chaptersList.push({
                    Name: "New Chapter",
                    Content: '',
                    Number: vm.chaptersList.length + 1,
                    Id: vm.chaptersList.length + 1
                });
            }
            vm.removeChapter = function () {
                
            }
        }
    ]);
})();