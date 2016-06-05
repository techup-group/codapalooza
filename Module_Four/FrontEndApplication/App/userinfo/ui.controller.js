(function () {
    'use strict';

    angular
        .module('app.ui')
        .controller('UserInfo', UserInfo);

    function UserInfo(dataservice, logger, $scope, $location) {
        var vm = this;
        vm.title = 'Homeless People';

      //  getDataFromAPI();
      
        function getDataFromAPI()  {
            return dataservice.getEarnings().then(function (response) {
                $scope.Data = response;
            }).catch(function (err) {
                logger.error('Call to API failed' + err);
            });
        }       
    }
})();




