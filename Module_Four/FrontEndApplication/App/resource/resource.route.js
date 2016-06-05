(function () {
    'use strict';

    angular
        .module('app.resources')
        .run(appRun);

    function appRun(routehelper) {
        routehelper.configureRoutes(getRoutes());
    }

    function getRoutes() {
        return [
            {
                url: '/resource',
                config: {
                    templateUrl: 'App/resource/resource.html',
                    controller: 'resource'
                }
            }
        ];
    }
})();
