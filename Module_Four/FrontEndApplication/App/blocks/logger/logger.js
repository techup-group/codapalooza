(function() {
    'use strict';

    angular
        .module('blocks.logger')
        .factory('logger', logger);

    function logger($log, toastr) {
        var service = {
            showToasts: true,

            error   : error,
            info    : info,
            success : success,
            warning : warning,

            log     : $log.log
        };

        return service;

        function error(message, data, title) {
            
            toastr.error(message, data, { timeOut: 0, closeButton: true, extendedTimeOut: 0 }); //, { timeout: 0, extendedTimeOut: 0,  "closeButton": true });
            $log.error('Error: ' + message, data);
        }

        function info(message, data, title) {
            toastr.info(message, data, { timeOut: 20000 });
            $log.info('Info: ' + message, data);
        }

        function success(message, data, title) {
            toastr.success(message, data);
            $log.info('Success: ' + message, data);
        }

        function warning(message, data, title) {
            toastr.warning(message, data);
            $log.warn('Warning: ' + message, data);
        }

        function setInfo(data) {
            return $http.post('api/Common/LoggerMessage', {
                params: {
                    category: data.category,
                    message: data.message,
                    type: "info"
                }
            }).then(function (response) {
            })
        }

        function setWarning(data) {
            return $http.post('api/Common/LoggerMessage', {
                params: {
                    category: data.category,
                    message: data.message,
                    type: "warning"
                }
            }).then(function(response) {
            })
        }


        function setError(data) {
            return $http.post('api/Common/LoggerMessage', {
                params: {
                    category: data.category,
                    message: data.message,
                    type: "error"
                }
            }).then(function (response) {
            })
        }

    }
}());
