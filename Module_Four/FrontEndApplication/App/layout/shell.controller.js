(function () {
    'use strict';

    angular
        .module('app.layout')
        .controller('Shell', shell);

    /* @ngInject */
    function shell(config, logger, $location, $scope) {
    //    alert("hello shell");
      //  $location.path('/HP');
        $scope.Redirect = function () {
            $location.path('/HP');
        }
        $location.path('/HP');
    }
})();
