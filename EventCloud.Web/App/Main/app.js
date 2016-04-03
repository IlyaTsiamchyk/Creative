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
            $urlRouterProvider.otherwise('/events');
            $stateProvider
                .state('events', {
                    url: '/events',
                    templateUrl: '/App/Main/views/events/index.cshtml',
                    menu: 'Events' //Matches to name of 'Events' menu in EventCloudNavigationProvider
                })
                .state('eventDetail', {
                    url: '/events/:id',
                    templateUrl: '/App/Main/views/events/detail.cshtml',
                    menu: 'Events' //Matches to name of 'Events' menu in EventCloudNavigationProvider
                })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml',
                    menu: 'About' //Matches to name of 'About' menu in EventCloudNavigationProvider
                })
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