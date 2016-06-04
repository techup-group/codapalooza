(function() {
    'use strict';

    angular
        .module('app.core')
        .value('config', config())
        .config(toastrConfig)
        .config(configure);

    function config() {
        return {
            appErrorPrefix: '[NG Error] ',
            appTitle: 'Homeless Resources',
            version: '1.0.0'
        };
    }

    function toastrConfig(toastr) {
          toastr.options.timeOut = 4000;
        toastr.options.positionClass = 'toast-bottom-right';
    }

    function configure ($logProvider, $routeProvider,
        routehelperConfigProvider, exceptionHandlerProvider) {
        if ($logProvider.debugEnabled) {
            $logProvider.debugEnabled(true);
        }

        routehelperConfigProvider.config.$routeProvider = $routeProvider;
        routehelperConfigProvider.config.docTitle = 'Homeless Resources';
        var resolveAlways = {
            dataservice: function(dataservice) {
                return dataservice.ready();
            }
        };
        routehelperConfigProvider.config.resolveAlways = resolveAlways;

        // Configure the common exception handler
        exceptionHandlerProvider.configure(config.appErrorPrefix);
    }
})();
