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
         
    }
})();




