// ejemplo estructurado
var name1 = "Pepe";
var birthDate1 = new Date("15/12/1978");

var name2 = "Lolo";
var birthDate2 = new Date("15/12/1980");

function AmIOlder(birthDate1, birthDate2)
{
    return birthDate1 > birthDate2;
}

function SayHello(personName, theOtherOneName, birthDate1, birthDate2)
{
    var b = AmIOlder(birthDate1, birthDate2);

    var msg = "Hola " 
                + theOtherOneName 
                + ", soy " 
                + personName + " "
                + (b ? "Soy mayor que tú" : "Eres un viejales");
    alert(msg);
}

//SayHello(name1, name2, birthDate1, birthDate2);

// Ejemplo OOP
var persona1 = new Persona("Pepe", new Date(1978, 11, 15));
var persona2 = new Persona("Lolo", new Date(1980, 11, 15));

persona1.SayHello(persona2);