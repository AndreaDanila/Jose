class Spaceship
{
    Http = null;

    GridOptions = 
    {
        columnDefs : 
        [ 
                { name: 'Brand', field: 'Brand'},
                { name: 'FTLFactor', field: 'FTLFactor'},
                { name: 'Color', field: 'Color'},
                { name: 'PassengersCapacity', field: 'PassengersCapacity'},
        ],
        data : []
      };

    
    constructor($http)
    {        
        this.Http = $http;
        this.GetAll();
    }

    GetAll()
    {
        this.Http(
        {
            method: 'GET',            
            url: 'api/spaceships'            
        })
        .then((response) => this.LoadShips(response.data), 
        function error(e) 
        {
            alert(e.statusText);
        });
    }

    LoadShips(ships)
    {
        for (let i in ships)
            this.GridOptions.data.push(ships[i]);
    }
}

App.
  component('spaceship', {   
    templateUrl: 'scripts/views/spaceship/spaceship.html',
    controller: Spaceship,
    controllerAs: "vm"
  });