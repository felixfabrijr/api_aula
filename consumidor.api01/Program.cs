// See https://aka.ms/new-console-template for more information
using consumidor.api01;

using Flurl;
using Flurl.Http;

Console.WriteLine("Hello, World!");

string url = "https://localhost:7207/";

item tarefa1 = new item();
tarefa1.Id = 1;
tarefa1.Nome = "Pagar conta";
tarefa1.Finalizado = true;

item tarefa2 = new item();
tarefa2.Id = 1;
tarefa2.Nome = "Receber conta xx";
tarefa2.Finalizado = false;

//gerar uma tarefa
string endpoint = url + "api/TarefasItems";

//retardar chamada e esperar api estar no ar
Thread.Sleep(new TimeSpan(0, 0, 5));
//flurl
endpoint.PostJsonAsync(tarefa1);
endpoint.PostJsonAsync(tarefa2);

//ler a lista

//alterar

//ler a lista

//deletar item lista

//ler a lista

Console.WriteLine("Aperte qualquer teclar Finalizar Aplicacao");
Console.Read();

