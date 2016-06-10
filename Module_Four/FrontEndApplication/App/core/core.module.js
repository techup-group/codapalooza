angular
    .module('app.core', [ 'ngRoute', 'ngSanitize', 'blocks.exception', 'blocks.logger', 'blocks.router'])
    .constant('moment', moment);
