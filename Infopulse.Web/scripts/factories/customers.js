mainmodule.factory('customersFctr', function ($http, apiUrl) {

    return $http.get(apiUrl + '/api/customers/getcustomers/');
  
});
