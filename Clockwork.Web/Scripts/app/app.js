(function () {
    const myApp = angular.module('ClockworkApp', ['ngAnimate']);
    var app = myApp;

    app.controller("HomeController", ['$scope', 'clockworkServiceFactory', function ($scope, clockworkServiceFactory) {

        $scope.currentLog = {
            currentTimeQueryId: null,
            time: null,
            clientIp: null,
            utcTime: null
        };

        $scope.logList = [];

        $scope.userAction = function () {
            var service = clockworkServiceFactory.createClockworkService();

            service
                .getCurrentTime()
                .then(function (result) {
                    $scope.model = result.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
        }
    }]);

    app.factory("clockworkServiceFactory", ['$http', function ($http) {
        var factory = {};
        factory.createClockworkService = function () {
            var service = {
                getCurrentTime: function () {
                    return $http.get("http://localhost:5000/api/currenttime");
                }
            }
            return service;
        };
        return factory;
    }]);

})();


