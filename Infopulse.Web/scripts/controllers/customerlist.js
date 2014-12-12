mainmodule.controller('customerlistCtrl', function ($scope, $http, apiUrl, ngTableParams, $filter, customersFctr) {
    $scope.customers = [];


    customersFctr.then(function (response) {
        $scope.customers = response.data;

        $scope.tableParams = new ngTableParams({
            page: 1,
            count: 10,
            sorting: { name: 'asc' }
        },
     {
         total: $scope.customers.length,
         getData: function ($defer, params) {

             $scope.customers = params.sorting() ?
                      $filter('orderBy')($scope.customers, params.orderBy()) : $scope.customers;
             params.total($scope.customers.length);
             $defer.resolve($scope.customers.slice((params.page() - 1) * params.count(), params.page() * params.count()));
         }
     });
    });

    $scope.deleteCustomer = function () {
        var customersForDelete = $filter('filter')($scope.customers, { "$selected": true });

        if (customersForDelete) {
            _(customersForDelete).each(function (customer) {

                $http({
                    method: 'DELETE',
                    url: apiUrl + 'api/customers/delete/' + customer.Id,
                }).success(function () {
                    $scope.customers = _($scope.customers).without(customer);
                    $scope.tableParams.reload();
                    $scope.message = 'Customer Deleted successfully';
                    $scope.error = null;
                }).error(function (e) {
                    $scope.message = null;
                    $scope.error = (e.ExceptionMessage);
                });
            });
        };
    };
});