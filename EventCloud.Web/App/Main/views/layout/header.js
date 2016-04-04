(function () {
    var controllerId = 'app.views.layout.header';
    angular.module('app').controller(controllerId, [
        '$rootScope', '$state', 'appSession',
        function ($rootScope, $state, appSession) {
            var vm = this;

            vm.languages = abp.localization.languages;
            vm.currentLanguage = abp.localization.currentLanguage;

            vm.menu = abp.nav.menus.MainMenu;
            vm.currentMenuName = $state.current.menu;

            $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
                vm.currentMenuName = toState.menu;
            });

            vm.setStyle = function () {
                var flag = true;
                var elements = document.getElementsByClassName("abody");
                if (elements.length === 0) {
                    elements = document.getElementsByClassName("bbody");
                    flag = false;
                }
                for (var i = 0; i < elements.length; i++) {
                    if (flag) {
                        elements[i].className = elements[i].className.replace('abody', 'bbody');
                        localStorage.setItem("style", 1);
                    }
                    else {
                        elements[i].className = elements[i].className.replace('bbody', 'abody');
                        localStorage.setItem("style", 2);
                    }
                }
                
            }

            vm.getShownUserName = function () {
                if (!abp.multiTenancy.isEnabled) {
                    return appSession.user.userName;
                } else {
                    if (appSession.tenant) {
                        return appSession.tenant.tenancyName + '\\' + appSession.user.userName;
                    } else {
                        return '.\\' + appSession.user.userName;
                    }
                }
            };
        }
    ]);
})();