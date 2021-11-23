class Main
{
    Title = "Estamos en Main"
    constructor()
    {
        
    }
}

App.
  component('main', {   
    templateUrl: 'scripts/views/main/main.html',
    controller: Main,
    controllerAs: "vm"
  });

//vm = new Main();