class Persona
{
    Name = "";
    BirthDate = null;

    constructor(name, birthDate)
    {
        this.Name = name;
        this.BirthDate = birthDate;
    }

    SayHello(otraPersona)
    {
        var b = this.AmIOlder(otraPersona);

        var msg = "Hola " 
                    + otraPersona.Name 
                    + ", soy " 
                    + this.Name + " "
                    + (b ? "Soy mayor que tú" : "Eres un viejales");
        alert(msg);
    }

    AmIOlder(otraPersona)
    {
        return this.BirthDate > otraPersona.BirthDate;
    }
}