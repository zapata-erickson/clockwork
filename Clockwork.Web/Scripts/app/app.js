(function () {
    const myApp = angular.module('ClockworkApp', ['ngAnimate','angularjsToast']);
    var app = myApp;

    app.controller("HomeController", ['$scope', 'toastServiceFactory', 'clockworkServiceFactory', function ($scope, toastServiceFactory, clockworkServiceFactory) {
        $scope.currentQuery = {
            currentTimeQueryId: null,
            time: null,
            clientIp: null,
            utcTime: null
        };

        $scope.queries = [];
              
        $scope.queryAndLogTime = function () {
            var service = clockworkServiceFactory.createClockworkService();
            var notificationService = toastServiceFactory.createToasterService();

            service
                .queryCurrentTime()
                .then(function (result) {
                    $scope.currentQuery = result.data;
                    notificationService.notifySuccess('Success! Logged Current time:&nbsp;' + $scope.currentQuery.time + '&nbsp;and&nbsp;Current IP:&nbsp;' + $scope.currentQuery.clientIp);
                })
                .catch(function (error) {
                    notificationService.notifyError(error);
                    console.log(error);
                })
        }

        $scope.getEntries = function () {
            var service = clockworkServiceFactory.createClockworkService();

            service
                .queryAllEntries()
                .then(function (result) {
                    $scope.queries = result.data;
                    $scope.getEntries();
                })
                .catch(function (error) {
                    notificationService.notifyError(error);
                    console.log(error);
                });
        }

        $scope.getEntries();

    }]);

    app.factory('clockworkServiceFactory', ['$http', function ($http) {
        var factory = {};

        factory.createClockworkService = function () {
            var service = {
                queryCurrentTime: function () {
                    return $http.get('http://localhost:5000/api/currenttime');
                },
                queryAllEntries: function () {
                    return $http.get('http://localhost:5000/api/currenttime/list');
                }
            }
            return service;
        };
        return factory;
    }]);

    app.factory('toastServiceFactory', ['toast', function (toast) {
        var factory = {};

        factory.createToasterService = function () {
            var service = {
                notifySuccess: function (message) {
                    toast({
                        duration: 10000,
                        message: message,
                        className: 'alert-success'
                    });               
                },
                notifyError: function (message) {
                    toast({
                        duration: 10000,
                        message: message,
                        className: 'alert-danger'
                    });
                }
            }
            return service;
        }
        return factory;
    }]);

})();


