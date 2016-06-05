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
        ds.getProviders = getProviders;

        //var baseUrl = "http://localhost:51319/";

        var appUrl = 'http://tampainnovationwebservices.azurewebsites.net/providers';

        function getEarnings() {
            return $http.get(baseUrl + 'api/Values/Get', {
                params: {
                    id: 3
                }
            }).then(function(response) {
                return response.data;
            }).catch(function(message){
                exception.catcher('XHR Failed for GetDetails')(message.data.ExceptionMessage);
            })
        }

        //function getProviders(requestObj) {
        //    return $http.get(baseUrl + 'Providers', {
        //        params: {
        //            query: requestObj.query,
        //            range: requestObj.range,
        //            limit: requestObj.limit
        //        }
        //    }).then(function (response) {
        //        return response.data;
        //    }).catch(function (message) {
        //        exception.catcher('XHR Failed for GetDetails')(message.data.ExceptionMessage);
        //    })
        //}

        function getProviders(requestObj) {
            return $http.post(appUrl, {
                filters: JSON.stringify(requestObj.requirment),
                query: requestObj.query, range: requestObj.range, limit: requestObj.limit
            }).then(function (response) {
                alert("getProviders");
                return response.data;
            }).catch(function (message) {
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
