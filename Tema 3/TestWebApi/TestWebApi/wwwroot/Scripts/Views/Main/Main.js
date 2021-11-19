class Main
{
  IsLoginViewActive = true;
  IsClientsViewActive = false;

  LoginNavClass = "nav-link active";
  ClientsNavClass = "nav-link";


  constructor()
  {

  }

  SelectLogin()
  {
    this.IsLoginViewActive = true;
    this.IsClientsViewActive = false;
  }

  SelectClients()
  {
    this.IsLoginViewActive = false;
    this.IsClientsViewActive = true;
    this.LoginNavClass = "nav-link";
    this.ClientsNavClass = "nav-link active";
  }
}

LibraryApp.
  component('main', {   
    templateUrl: 'scripts/views/main/main.html',
    controller: Main,
    controllerAs: "vm"
  });