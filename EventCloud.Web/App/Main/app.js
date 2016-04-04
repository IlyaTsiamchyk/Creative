(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',
        'oi.select',
        'abp',
        'angular-input-stars',
        'angularUtils.directives.dirDisqus',
        'textAngular'   
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider',
        function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/creatives');
            $stateProvider
                .state('creativeContent', {
                    url: '/creatives/:id',
                    templateUrl: '/App/Main/views/reader/index.cshtml',
                    menu: 'Creatives' 
                })
                .state('creatives', {
                    url: '/creatives',
                    templateUrl: '/App/Main/views/creatives/index.cshtml',
                    menu: 'Creatives'
                })
            .state('editor', {
                url: '/editor/:id',
                templateUrl: '/App/Main/views/editor/index.cshtml',
                menu: 'Editor'
            })
            .state('user', {
                url: '/user/:id',
                templateUrl: '/App/Main/views/userView/index.cshtml',
                menu: 'User' //Matches to name of 'About' menu in EventCloudNavigationProvider
            });
        }
    ]);
})();