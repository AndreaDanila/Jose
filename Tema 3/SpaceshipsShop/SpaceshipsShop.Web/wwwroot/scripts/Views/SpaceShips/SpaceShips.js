class SpaceShips
{
    //Model Fields
    Brand = "Titan";
    Password = "titan1234"
    FTLFactor = 4;
    Color = "Black";
    PassengersCapacity = 400;

    Http = null;

    Items = [];

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
        var getReq = 
        {
            method: 'GET',            
            url: 'api/spaceships'            
        };

        this.Http(getReq).then(
            (response) => this.LoadShips(response.data.$values), // on success
            (error) => alert(error.statusText));                   // on error
    }

    LoadShips(ships)
    {
        this.GridOptions.data.length = 0;   // clear array

        for (let i in ships)
            this.GridOptions.data.push(ships[i]);
    }

    Add()
    {
        var spaceShip = new SpaceShip();
        
        spaceShip.Brand = this.Brand;
        spaceShip.Password = this.Password;
        spaceShip.FTLFactor = this.FTLFactor;
        spaceShip.Color = this.Color;
        spaceShip.PassengersCapacity = this.PassengersCapacity;

        var postRequest = {
            method: 'POST',
            url: 'api/spaceships',
            headers: { 'Content-Type': 'application/json' },
            data: spaceShip
           };

        this.Http(postRequest).then(
               (response) => this.#OnAddSuccess(response.data), //on success                
               (error) => alert("server error: " + error.statusText));       // on error
    }

    #OnAddSuccess(result)
    {        
        if (result == true)
        {
            alert("se ha añadido correctamente la nave");
        }
        else
        {
            alert("no ha añadido correctamente la nave");
        }

        this.GetAll();        
    }
}

App.
  component('spaceships', {   
    templateUrl: 'scripts/views/spaceships/spaceships.html',
    controller: SpaceShips,
    controllerAs: "vm"
  });