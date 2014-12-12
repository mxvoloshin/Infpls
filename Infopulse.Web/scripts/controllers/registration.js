mainmodule.controller('registrationCtrl', function ($scope, $http, apiUrl, customersFctr) {
    $scope.customers = [];

    customersFctr.success(function (responsedata) {
        $scope.customers = responsedata;

        $scope.addCustomer = function (customer) {

            //add check if customer exist
            var isExist = false;
            _($scope.customers).each(function (c) {
                if (c.Name === customer.Name && c.Address === customer.Address) {
                    isExist = true;
                  $scope.error = 'Customer already exist';
                };
            });

            if (!isExist) {
                $http({
                    method: 'POST',
                    headers: { "Content-type": "application/x-www-form-urlencoded; charset=utf-8" },
                    url: apiUrl + '/api/customers/addcustomer/',
                    data: $.param(customer)
                }).success(function () {
                    $scope.customers.push(customer);
                    $scope.error = null;
                    $scope.message = 'Customer added successfully';
                    })
                .error(function (e) {
                    $scope.message = null;
                    $scope.error = (e.ExceptionMessage);
                });
            }
        };
    });
});