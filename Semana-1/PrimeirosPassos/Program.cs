Console.WriteLine("Hello, World!");

#region Tipos de dados 

int tipoInteiro;
double tipoDouble;
float tipoFloat;
long tipoLong;
string tipoString;

#endregion

tipoInteiro = int.MaxValue;
tipoLong = long.MaxValue;

tipoString = "100";
tipoInteiro = int.Parse(tipoString);

Console.WriteLine("O maior número inteiro é: " + tipoInteiro);
Console.WriteLine("O maior número long é: " + tipoLong);

#region Operadores
tipoDouble = tipoInteiro + tipoLong;

#endregion
