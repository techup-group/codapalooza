(function () {
    'use strict';

    angular
        .module('app.hp')
        .controller('HomelessPeople', HomelessPeople);

    function HomelessPeople(dataservice, logger, $scope, $location) {
        var vm = this;
        vm.title = 'Homeless People';
        var locat;
     //   alert("hello");
        $scope.test = "Testing";

      //  getDataFromAPI();
      
        function getDataFromAPI()  {
            return dataservice.getEarnings().then(function (response) {
                $scope.Data = response;
            }).catch(function (err) {
                logger.error('Call to API failed' + err);
            });
        }

        $scope.Update = function () {
            navigator.geolocation.getCurrentPosition(success, error);
            var requestObj = new Object();
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




