class Clients
{
    Http = null;
    Clients = [];

    constructor($http)
    {
        this.Http = $http;
        this.GetAll();
    }

    AddClient()
    {
        this.Clients.push({"email":"lolo@g.com"});
    }

    GetAll()
    {
        this.Http(
        {
            method: 'GET',            
            url: 'api/clients'            
        })
        .then((response) => this.LoadClients(response.data), 
        function error(e) 
        {
            alert(e.statusText);
        });
    }

    LoadClients(clients)
    {
        this.Clients = clients;
    }
}

LibraryApp.
  component('clients', {   
    templateUrl: 'scripts/views/clients/clients.html',
    controller: Clients,
    controllerAs: "vm"
  });