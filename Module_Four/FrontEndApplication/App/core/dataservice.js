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

      function shapeResourceData(data) {
            var shapedData = [{ resourceName: 'Clothing', details: [] },
                              { resourceName: 'Food', details: [] },
                              { resourceName: 'Shelter', details: [] }, 
                              { resourceName: 'Domestic Violence', details: [] },
                              { resourceName: 'Hygiene Products', details: [] },
                              { resourceName: 'Medical', details: [] }];

           function getIndex(resource) {
               for (var idx = 0; idx < shapedData.length; idx++) {
                   if (shapedData[idx].resourceName === resource.name) {
                        return idx;
                   }
               }
               return -1;
           }
  
           function getPhysical(addrDtl) {
               for (var idx = 0; idx < addrDtl.providers.addresses.length; idx++) {
                   if (addrDtl.providers.addresses[idx].addressType === 'Physical') {
                       return {
                           streetAddress: addrDtl.providers.addresses[idx].streetAddress, city: addrDtl.providers.addresses[idx].city, state: addrDtl.providers.addresses[idx].state,
                           zipCode: addrDtl.providers.addresses[idx].zipCode, country: addrDtl.providers.addresses[idx].country, landmarks: addrDtl.providers.addresses[idx].landmarks,
                           latitude: addrDtl.providers.addresses[idx].latitude, longitude: addrDtl.providers.addresses[idx].longitude
                       };
                   }
               }

               return {};
           }

           function getPhone(phoneDtl) {
               for (var idx = 0; idx < phoneDtl.providers.contactInformations.length; idx++) {
                   if (phoneDtl.providers.contactInformations[idx].name.substring(0, 4) === 'Main') {
                       return phoneDtl.providers.contactInformations[idx].number;
                   };
                }

               return null;
           }


            for (var providerIdx = 0; providerIdx < data.length; providerIdx++) {
                var dt = data[providerIdx];

                for (var resourceIdx = 0; resourceIdx < dt.providers.providedServices.length; resourceIdx++) {
                    var idxShape = getIndex(dt.providers.providedServices[resourceIdx]);
                    if (idxShape<0)
                        continue;;

                    var addr = getPhysical(dt);
                    shapedData[idxShape].details.push({
                        distance: dt.distance,
                        providerName: dt.providers.name,
                        streetAddress: addr.streetAddress,
                        city: addr.city,
                        state: addr.state,
                        zipCode: addr.zipCode,
                        country: addr.country,
                        landmarks: addr.landmarks,
                        latitude: addr.latitude,
                        longitude: addr.longitude,
                        operationHours: dt.providers.operationHours,
                        totalUnits: dt.providers.totalUnits,
                        phoneNumber: getPhone(dt)
                    });
                }

            }

            return shapedData;
        }


        function getProviders(requestObj) {
            return $http.post(appUrl, 
                requestObj
            ).then(function (response) {
             //   alert("getProviders");
                return shapeResourceData(response.data);
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
