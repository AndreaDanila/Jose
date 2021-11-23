class Spaceship
{
    Http = null;

    GridOptions = 
    {
        columnDefs : 
        [ 
            {name: 'Brand', field: 'brand'},
            {name: 'FTLFactor',  field: 'fTLFactor'},
            {name: 'Color',  field: 'color'},
            {name: 'PassengersCapacity',  field: 'passengersCapacity'},
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