#region Configuração do Ambiente

// Verificar a versão do .NET SDK instalado:
// dotnet --version

// Verificar as versões SDK instaladas:
// dotnet --list-sdks

// Atualizar para a última versão:
// dotnet --version
// dotnet --install-dir "/usr/local/share/dotnet" --version "latest"

// Atualizar para uma versão específica:
// dotnet --version
// dotnet --install-dir "/usr/local/share/dotnet" --version "x.x.x"

// Remover uma versão específica:
// dotnet --version
// dotnet --uninstall-pkgs-dir "/usr/local/share/dotnet" --version "x.x.x"

// Remover todas as versões:
// dotnet --version
// dotnet --uninstall-pkgs-dir "/usr/local/share/dotnet" --all 

#endregion

#region Tipos de dados
//sbyte:
//Intervalo: -128 a 127
//Exemplo: sbyte mySByte = 42;

//byte:
//Intervalo: 0 a 255
//Exemplo: byte myByte = 255;

//short:
//Intervalo: -32,768 a 32,767
//Exemplo: short myShort = 12345;

//ushort:
//Intervalo: 0 a 65,535
//Exemplo: ushort myUShort = 56789;

//int:
//Intervalo: -2.147.483.648 a 2.147.483.647
//Exemplo: int myInt = 123456789;

//uint:
//Intervalo: 0 a 4.294.967.295
//Exemplo: uint myUInt = 4000000000;

//long:
//Intervalo: -9.223.372.036.854.775.808 a 9.223.372.036.854.775.807
//Exemplo: long myLong = 9876543210L;


//ulong:
//Intervalo: 0 a 18.446.744.073.709.551.615
// Exemplo: ulong myULong = 18446744073709551615UL;
#endregion

#region Conversão de Tipos de Dados:
double numeroDouble = 10.75;

// Usando Convert.ToInt32
int numeroInt1 = Convert.ToInt32(numeroDouble);
Console.WriteLine($"Usando Convert.ToInt32: {numeroInt1}");

// Usando coerção (casting)
int numeroInt2 = (int)numeroDouble;
Console.WriteLine($"Usando coerção (casting): {numeroInt2}");

// Se a parte fracionária não puder ser representada como um número inteiro válido
double numeroComParteFracionaria = 10.99;

// Usando Convert.ToInt32
// Isso resultará em perda de dados, a parte fracionária é truncada
int numeroInt3 = Convert.ToInt32(numeroComParteFracionaria);
Console.WriteLine($"Usando Convert.ToInt32 com parte fracionária: {numeroInt3}");

// Usando coerção (casting)
// Isso também resultará em perda de dados
int numeroInt4 = (int)numeroComParteFracionaria;
Console.WriteLine($"Usando coerção (casting) com parte fracionária: {numeroInt4}");
#endregion

#region Operadores Aritméticos:
int x = 10;
int y = 3;

// Adição
int soma = x + y;
Console.WriteLine($"Adição: {soma}");

// Subtração
int subtracao = x - y;
Console.WriteLine($"Subtração: {subtracao}");

// Multiplicação
int multiplicacao = x * y;
Console.WriteLine($"Multiplicação: {multiplicacao}");

// Divisão
double divisao = (double)x / y;
Console.WriteLine($"Divisão: {divisao}");
#endregion

#region Operadores de Comparação:
int a = 5;
int b = 8;

if (a > b)
{
    Console.WriteLine("a é maior que b.");
}
else
{
    Console.WriteLine("a não é maior que b.");
}
#endregion

#region Operadores de Igualdade:
string str1 = "Hello";
string str2 = "World";

if (str1 == str2)
{
    Console.WriteLine("As strings são iguais.");
}
else
{
    Console.WriteLine("As strings não são iguais.");
}
#endregion

#region Operadores Lógicos:
bool condicao1 = true;
bool condicao2 = false;

if (condicao1 && condicao2)
{
    Console.WriteLine("Ambas as condições são verdadeiras.");
}
else
{
    Console.WriteLine("Pelo menos uma das condições não é verdadeira.");
}
#endregion

#region Desafio de Mistura de Operadores:
int num1 = 7;
int num2 = 3;
int num3 = 10;

// Verificar se num1 é maior que num2
if (num1 > num2)
{
    Console.WriteLine("num1 é maior que num2.");

    // Verificar se num3 é igual a num1 + num2
    if (num3 == num1 + num2)
    {
        Console.WriteLine("num3 é igual a num1 + num2.");
    }
    else
    {
        Console.WriteLine("num3 não é igual a num1 + num2.");
    }
}
else
{
    Console.WriteLine("num1 não é maior que num2.");
}
#endregion
