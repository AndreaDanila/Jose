let MyApp = angular.module("MyApp", []);

MyApp.controller('GreetingController', ['$scope', function($scope) 
{
    $scope.Name = 'Hola!';

    $scope.Login = function()
    {
        alert($scope.Name);
    }
  
}]);