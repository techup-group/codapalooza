/* Help configure the ngRoute router */
(function() {
    'use strict';

    angular
        .module('blocks.router')
        .provider('routehelperConfig', routehelperConfig)
        .factory('routehelper', routehelper);

    function routehelperConfig() {
        this.config = {
            listenForRouteChange: false // set true for debugging
        };

        this.$get = function() {
            return {
                config: this.config
            };
        };
    }

    function routehelper($location, $rootScope, $route, logger, routehelperConfig) {
        var handlingRouteChangeError = false;
        var routeCounts = {
            errors: 0,
            changes: 0
        };
        var routes = [];
        var $routeProvider = routehelperConfig.config.$routeProvider;

        var service = {
            configureRoutes: configureRoutes,
            getRoutes: getRoutes,
            routeCounts: routeCounts
        };

        init();

        return service;

        function configureRoutes(routes) {
            routes.forEach(function(route) {
                route.config.resolve =
                    angular.extend(route.config.resolve || {},
                        routehelperConfig.config.resolveAlways);
                $routeProvider.when(route.url, route.config);
            });
            $routeProvider.otherwise({redirectTo: '/'});
        }

        function getRoutes() {
            for (var prop in $route.routes) {
                if ($route.routes.hasOwnProperty(prop)) {
                    var route = $route.routes[prop];
                    var isRoute = !!route.title;
                    if (isRoute) {
                        routes.push(route);
                    }
                }
            }
            return routes;
        }

        function handleRoutingErrors() {
            $rootScope.$on('$routeChangeError',
                function(event, current, previous, rejection) {
                    if (handlingRouteChangeError) {
                        return;
                    }
                    routeCounts.errors++;
                    handlingRouteChangeError = true;
                    var destination = (current && (current.title ||
                        current.name || current.loadedTemplateUrl)) ||
                        'unknown target';
                    var msg = 'Error routing to ' + destination + '. ' + (rejection.msg || '');
                    logger.warning(msg, [current]);
                    $location.path('/');
                }
            );
        }

        function init() {
            listenForRouteChange();
            handleRoutingErrors();
            updateDocTitle();
        }

        function listenForRouteChange() {
            if (!routehelperConfig.config.listenForRouteChange) {
                return; // never listen
            }
            $rootScope.$on('$routeChangeStart',
                function(event, current, previous) {
                    if (!routehelperConfig.config.listenForRouteChange) {
                        return;
                    }
                    var dest;
                    if (current) {
                        dest = current.title || current.name || 'unnamed';
                        dest += ' (controller: ' + current.controller;
                        dest += ' templateUrl: ' + current.templateUrl + ')';
                    }
                    if (!dest) {
                        dest = 'unknown target';
                    }
                    var msg = 'Starting route change to ' + dest;
                    logger.info(msg, [current]);
                }
            );
        }

        function updateDocTitle() {
            $rootScope.$on('$routeChangeSuccess',
                function(event, current, previous) {
                    routeCounts.changes++;
                    handlingRouteChangeError = false;
                    var title = routehelperConfig.config.docTitle + ' ' + (current.title || '');
                    $rootScope.title = title; // data bind to <title>
                }
            );
        }
    }
})();
