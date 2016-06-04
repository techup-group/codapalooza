(function () {
    'use strict';

    angular
        .module('app.hp')
        .run(appRun);

    function appRun(routehelper) {
        routehelper.configureRoutes(getRoutes());
    }

    function getRoutes() {
        return [
            {
                url: '/HP',
                config: {
                    templateUrl: 'App/hp/hp.html',
                    controller: 'HomelessPeople'
                }
            }
        ];
    }
})();
