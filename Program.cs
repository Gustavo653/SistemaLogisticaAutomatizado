using System;
using System.Collections.Generic;

namespace Trabalho___Gustavo_Henrique_da_Silva
{
    class Program
    {
        static void Main(string[] args)
        {
            // Escreva seus códigos Aqui ;)
            // Nome : Gustavo Henrique da Silva

            //01 - Recebe carga e organiza no estoque
            int x = 6, y = 6; 
            int[,] Prod1 = new int[x, y];
            int[,] Prod2 = new int[x, y];
            int[,] Prod3 = new int[x, y];
            int[,] Prod4 = new int[x, y];
            PopularEstoque(Prod1, x, y, 1); //Cria e popula os estoques
            PopularEstoque(Prod2, x, y, 2);
            PopularEstoque(Prod3, x, y, 3);
            PopularEstoque(Prod4, x, y, 4);

            Console.WriteLine("Para utlizar este programa, pressione qualquer tecla para passar a próxima tela.");
            Console.ReadKey();
            Console.Clear();

            for (int Dia = 0; Dia < 6; Dia++)
            {
                Console.WriteLine("Dia " + (Dia + 1));
                Console.WriteLine();
                List<string> EntradaPedido = new List<string>();
                int QuantidadeCargas = Geradores.Qtd();
                int ContID1 = 0;
                int ContID2 = 0;
                int ContID3 = 0;
                int ContID4 = 0;
                Console.WriteLine("Carga recebida!");
                for (int i = 1; i <= QuantidadeCargas; i++)
                {
                    EntradaPedido = Geradores.GeraEntrada();
                    Console.WriteLine("Carga: Nº" + i);
                    Console.Write("-> ");
                    foreach (var item in EntradaPedido) //Separa, organiza e mostra os pedidos
                    {
                        if (item == "1")
                        {
                            ContID1++;
                        }
                        else if (item == "2")
                        {
                            ContID2++;
                        }
                        else if (item == "3")
                        {
                            ContID3++;
                        }
                        else
                        {
                            ContID4++;
                        }
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }

                EstatisticasCarga(QuantidadeCargas, ContID1, ContID2, ContID3, ContID4);

                Prod1 = AdicionarProduto(Prod1, x, y, ContID1, 1);
                Prod2 = AdicionarProduto(Prod2, x, y, ContID2, 2);
                Prod3 = AdicionarProduto(Prod3, x, y, ContID3, 3);
                Prod4 = AdicionarProduto(Prod4, x, y, ContID4, 4);

                Console.WriteLine("Carga organizada!");
                Console.ReadKey();
                Console.Clear();

                //02 - Mostra o estoque
                MostrarEstoque(Prod1, Prod2, Prod3, Prod4, x, y);
                Console.ReadKey();
                Console.Clear();

                //03 - Enviar carga
                QuantidadeCargas = Geradores.Qtd();

                ContID1 = 0;
                ContID2 = 0;
                ContID3 = 0;
                ContID4 = 0;
                Console.WriteLine("Ordem de serviço recebida!");

                for (int i = 1; i <= QuantidadeCargas; i++)
                {
                    string OrdemServicoRecebida = Geradores.OrdemDeServico();
                    int[] Pedidos = ConverterStringInt(OrdemServicoRecebida);
                    Console.WriteLine("Carga solicitada pelo cliente: Nº" + i);

                    Console.Write("-> ");
                    foreach (var item in Pedidos) //Verifica quantos itens devem ser retirados
                    {
                        if (item == 1)
                        {
                            ContID1++;
                        }
                        else if (item == 2)
                        {
                            ContID2++;
                        }
                        else if (item == 3)
                        {
                            ContID3++;
                        }
                        else
                        {
                            ContID4++;
                        }
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }

                EstatisticasCarga(QuantidadeCargas, ContID1, ContID2, ContID3, ContID4);

                int[] OrdemServicoEnviada = GerarOrdemServico(x, y, Prod1, Prod2, Prod3, Prod4, ContID1, ContID2, ContID3, ContID4);
                Console.WriteLine("Carga que será enviada ao cliente:");
                Console.Write("-> ");
                for (int i = 0; i < OrdemServicoEnviada.Length; i++)
                {
                    Console.Write(OrdemServicoEnviada[i] + " ");
                }

                Prod1 = RemoverProduto(Prod1, x, y, ContID1, 1);
                Prod2 = RemoverProduto(Prod2, x, y, ContID2, 2);
                Prod3 = RemoverProduto(Prod3, x, y, ContID3, 3);
                Prod4 = RemoverProduto(Prod4, x, y, ContID4, 4);

                Console.ReadKey();
                Console.Clear();

                //04 - Mostra o estoque
                MostrarEstoque(Prod1, Prod2, Prod3, Prod4, x, y);
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine("Encerrando programa!");
            Console.WriteLine("Obrigado por utiliza-lo");
            Console.ReadKey();
        }
        public static void MostrarEstoque(int[,] Prod1, int[,] Prod2, int[,] Prod3, int[,] Prod4, int x, int y)
        {
            Console.WriteLine("Mostrando o estoque");
            Console.WriteLine("--/--");
            Console.WriteLine("Estoque 1");
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write(Prod1[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("--/--");
            Console.WriteLine("Estoque 2");
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write(Prod2[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("--/--");
            Console.WriteLine("Estoque 3");
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write(Prod3[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("--/--");
            Console.WriteLine("Estoque 4");
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write(Prod4[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static int[,] PopularEstoque(int[,] Prod, int x, int y, int ID)
        {
            for (int i = 0; i < x; i++) //Enche o estoque até a metade (18 itens)
            {
                for (int j = 0; j < y; j++)
                {
                    if (i == 3)
                    {
                        i = 7;
                        break;
                    }
                    else
                    {
                        Prod[i, j] = ID;
                    }
                }
            }
            return Prod;
        }
        public static void EstatisticasCarga(int QuantidadeCargas, int ContID1, int ContID2, int ContID3, int ContID4)
        {
            Console.WriteLine("--/--");
            Console.WriteLine("Estatísticas");
            Console.WriteLine("Quantidade de cargas: " + QuantidadeCargas);
            Console.WriteLine("Quantidade de itens categoria 1: " + ContID1);
            Console.WriteLine("Quantidade de itens categoria 2: " + ContID2);
            Console.WriteLine("Quantidade de itens categoria 3: " + ContID3);
            Console.WriteLine("Quantidade de itens categoria 4: " + ContID4);
            Console.WriteLine("--/--");
        }
        public static int[,] AdicionarProduto(int[,] Prod, int x, int y, int ContID, int ID)
        {
            int AuxContId = 0;
            for (int k = 0; k < x; k++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (Prod[k, j] == 0 && AuxContId < ContID) //Verifica se há espaço vazio e se há itens restantes para adicionar
                    {
                        Prod[k, j] = ID;
                        AuxContId++;
                    }
                }
            }
            return Prod;
        }
        public static int[,] RemoverProduto(int[,] Prod, int x, int y, int ContID, int ID)
        {
            int AuxContId = 0;
            for (int k = (x - 1); k >= 0; k--) //Percorre a matriz de traz para frente
            {
                for (int j = (y - 1); j >= 0; j--)
                {
                    if (Prod[k, j] == ID && AuxContId < ContID) //Verifica se a matriz está ocupada e se há itens restantes para remover
                    {
                        Prod[k, j] = 0;
                        ContID--;
                    }
                }
            }
            return Prod;
        }
        public static int[] ConverterStringInt(string OrdemServico)
        {
            int[] Pedidos = new int[OrdemServico.Length];
            for (int j = 0; j < Pedidos.Length; j++)
            {
                Pedidos[j] = (int)char.GetNumericValue(OrdemServico[j]); //Converte de char para int e atribui o valor
            }
            return Pedidos;
        }
        public static int[] GerarOrdemServico(int x, int y, int[,] Prod1, int[,] Prod2, int[,] Prod3, int[,] Prod4, int ContID1, int ContID2, int ContID3, int ContID4)
        {
            int AuxContID1 = 0; //Contador auxiliar para receber a quantidade de itens pedidos na ordem de serviço
            int AuxContID2 = 0; //Também verifica se há itens suficientes
            int AuxContID3 = 0;
            int AuxContID4 = 0;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (Prod1[i, j] != 0 && AuxContID1 < ContID1)
                    {
                        AuxContID1++;
                    }
                }
            }
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (Prod2[i, j] != 0 && AuxContID2 < ContID2)
                    {
                        AuxContID2++;
                    }
                }
            }
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (Prod3[i, j] != 0 && AuxContID3 < ContID3)
                    {
                        AuxContID3++;
                    }
                }
            }
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (Prod4[i, j] != 0 && AuxContID4 < ContID4)
                    {
                        AuxContID4++;
                    }
                }
            }
            int TamanhoVetor = (AuxContID1 + AuxContID2 + AuxContID3 + AuxContID4); 
            int[] OrdemServico = new int[TamanhoVetor]; //Cria um vetor do tamanho correto do pedido
            for (int i = 0; i < OrdemServico.Length; i++) //Preenche o vetor em ordem crescente
            {
                if (AuxContID1 > 0)
                {
                    OrdemServico[i] = 1;
                    AuxContID1--;
                }
                else if (AuxContID2 > 0)
                {
                    OrdemServico[i] = 2;
                    AuxContID2--;
                }
                else if (AuxContID3 > 0)
                {
                    OrdemServico[i] = 3;
                    AuxContID3--;
                }
                else if (AuxContID4 > 0)
                {
                    OrdemServico[i] = 4;
                    AuxContID4--;
                }
            }
            return OrdemServico;
        }
    }
}
