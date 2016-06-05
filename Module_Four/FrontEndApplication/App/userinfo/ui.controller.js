(function () {
    'use strict';

    angular
        .module('app.ui')
        .controller('UserInfo', UserInfo);

    function UserInfo(dataservice, logger, $scope, $location) {
        var vm = this;
        vm.title = 'Sign-In';
        $scope.isThankYou = false;

        $scope.submit = function () {

            var userRegistration = new UserRegistration();
            userRegistration.firstName = $scope.firstName;
            userRegistration.lastName = $scope.lastName;
            userRegistration.email = $scope.email;
            userRegistration.phone = $scope.phone;
            userRegistration.gender = $scope.gender;
            userRegistration.marriageStatus = $scope.marriableStatus;
            userRegistration.familyCount = $scope.childrenCount;

            return dataservice.submitUserForm(userRegistration).then(
                function () {
                    $scope.isThankYou = true;
                }).catch(function (err) {
                logger.error('Call to API failed' + err);
            });
        }
        $scope.done = function() {
            $location.path("/HP");
        }
    }

})();


function UserRegistration() {
    var firstName;
    var lastName;
    var email;
    var phone;
    var gender;
    var marriageStatus;
    var familyCount;
}

