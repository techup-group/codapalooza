(function() {
    'use strict';

    angular
        .module('blocks.exception')
        .service('exception', exception);

    /* @ngInject */
    function exception(logger) {
        this.catcher = catcher;

        function catcher(message) {
            return function(reason) {
                logger.error(message, reason);
            };
        }
    }
})();
