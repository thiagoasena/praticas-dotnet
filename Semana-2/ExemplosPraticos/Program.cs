// Escreva um programa em c# que imprime todos os números que são divisiveis por 3 ou 4 entre 
// 0 e 30

#region exemplo 1
for (int i = 0; i <= 30; i++)
{
    if (i % 3 == 0 || i % 4 == 0)
{
    Console.WriteLine(i);
}
}
#endregion

// Faça um programa em c# que imprima os primeiros números da série de finonacci até passar 
// de 100

#region exemplo 2
int a = 0, b = 1, c = 0;

while (c <= 100)
{
    Console.WriteLine(c);
    a = b;
    b = c;
    c = a + b;
}
#endregion

// Faça um programa que imprima a seguinte tabela até o nível 8

#region exemplo 3 
// int linhas = 4;

// for (int i = 4; i >= linhas; i--)
// {
//     for (int j = 1; j >= 8; j++)
//     {
//         Console.WriteLine($"[i * j]\t");
//     }
//     Console.WriteLine();
// }
#endregion

#region 
Console.WriteLine("Informe uma string");
string? str = Console.ReadLine();
Console.WriteLine($"A string foi:  {str}");


string [] strSplitted = str.Split(' ');

foreach(string s in strSplitted)
{
    Console.WriteLine($"A string foi: {strSplitted}");
}
#endregion
