function Add()
{
    Calculate('+');
}

function Sub()
{
    Calculate('-')
}

function Mult()
{
    Calculate('*')
}

function Div()
{
    Calculate('/')
}

function Calculate(operador)
{
    var num1 = TbNum1.value * 1;
    var num2 = TbNum2.value * 1;
    var msg = "";

    if (operador === "+")
    {        
        var resultado = num1 + num2;
        msg = "the sumatory is " + resultado;
    }
    else if(operador === "-")
    {
        var resultado = num1 - num2;
        msg = "the substraction is " + resultado;
    }
    else if(operador === "*")
    {
        var resultado = num1 * num2;
        msg = "the multiplication is " + resultado;
    }
    else if(operador === "/")
    {
        var resultado = num1 / num2;
        msg = "the division is " + resultado;
    }

    LbOutput.innerHTML = msg;
}
