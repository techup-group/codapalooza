(function () {
    'use strict';

    angular
        .module('app.core')
        .service('dataservice', dataservice);

    function dataservice($http, $q, exception, logger) {
        var readyPromise;
        var ds = this;
        ds.ready = ready;
        ds.getEarnings = getEarnings;


        function getEarnings(data) {
            return $http.get('api/Request/GetDetails', {
                params: {
                    storeId: data.unitId
                }
            }).then(function(response) {
                return response.data;
            }).catch(function(message){
                exception.catcher('XHR Failed for GetDetails')(message.data.ExceptionMessage);
            })
        }

        function getReady() {
            if (!readyPromise) {

                readyPromise = $q.when(ds);
            }
            return readyPromise;
        }

        function ready(promisesArray) {
            return getReady()
                .then(function () {
                    return promisesArray ? $q.all(promisesArray) : readyPromise;
                })
                .catch(exception.catcher('"ready" function failed'));
        }
    }
})();
