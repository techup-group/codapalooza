(function () {
    'use strict';

    angular
        .module('app.hp')
        .controller('HomelessPeople', HomelessPeople);

    function HomelessPeople(dataservice, logger, $scope, $location) {
        var vm = this;
        vm.title = 'Homeless People';

     //   alert("hello");
        $scope.test = "Testing";

      //  getDataFromAPI();
        navigator.geolocation.getCurrentPosition(success, error);

        function getDataFromAPI()  {
            return dataservice.getEarnings().then(function (response) {
                $scope.myData = response;

            }).catch(function (err) {
                logger.error('Call to API failed' + err);
            });
        }

        $scope.update = function (user) {
            return dataservice.getProviders().then(function (response) {
                $scope.myData = response;

            }).catch(function (err) {
                logger.error('Call to API failed' + err);
            });
        };

        function success(position) {
            var latitude = position.coords.latitude;
            var longitude = position.coords.longitude;

            var location = latitude + "," + longitude;
        };

        function error(position) {
            var latitude = '28.053397';
            var longitude = '-82.4473383';

            var location = latitude + "," + longitude;
        };
    }
})();




