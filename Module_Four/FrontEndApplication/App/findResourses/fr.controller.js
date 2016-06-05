(function () {
    'use strict';

    angular
        .module('app.fr')
        .controller('FindResource', FindResource);

    function FindResource(dataservice, logger, $scope, $location) {
        $scope.myValue = true;

      //  getDataFromAPI();
      
        function getDataFromAPI()  {
            return dataservice.getEarnings().then(function (response) {
                $scope.Data = response;
            }).catch(function (err) {
                logger.error('Call to API failed' + err);
            });
        }

        $scope.Update = function () {
            $scope.myValue = false;
            navigator.geolocation.getCurrentPosition(success, error);

            var userSelection = ["CLOTHING", "FOOD"];


            var requestObj = new Object();
            requestObj.filters = userSelection;
            requestObj.query = '28.053397' + ',' + '-82.4473383';
            requestObj.range = 25;
            requestObj.limit = 20;
            return dataservice.getProviders(requestObj).then(function (response) {
                $scope.myData = response;

            }).catch(function (err) {
                logger.error('Call to API failed' + err);
            });
        };

        function success(position) {
            var latitude = position.coords.latitude;
            var longitude = position.coords.longitude;

            var locat = latitude + "," + longitude;
        };

        function error(position) {
            var latitude = '28.053397';
            var longitude = '-82.4473383';

            var locat = latitude + "," + longitude;
        };
    }
})();




