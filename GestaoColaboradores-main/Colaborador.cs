
using System;
using System.ComponentModel.Design;

namespace ColabEFinanceiro
{
    public class Colaborador
    {

        private int codColab;
        private string nomColab;
        private bool segSaudeColab;
        public Financeiro financeiro;
        public Colaborador[] colabArray = new Colaborador[0];
        private int lastIndex = -1;


        //método construtor ca classe com o mesmo nome
        public Colaborador(int newCodColab, string newNomColab, bool temSegSaude, double newVencColab, double newPlafAlimColab)
        {
            setCod(newCodColab);
            setNome(newNomColab);
            setSegSaudeColab(temSegSaude);
            financeiro = new Financeiro(newVencColab, newPlafAlimColab);
        }
        public Colaborador() 
        { 
        
        }
        
        //métodos acessores Get e Set
        public string getNome()
        {
            return nomColab;
        }
        public int getCod()
        {
            return codColab;
        }
        public bool getSegSaudeColab()
        {
            return segSaudeColab;
        }
            



        public void setNome(string newNome)
        {
            nomColab = newNome;
        }
        public void setCod(int newCod)
        {
            codColab = newCod;
        }
        public void setSegSaudeColab(bool newSegSaude)
        {
            segSaudeColab = newSegSaude;
        }



        //funções da classe Colaborador

        // essa função vai receber um valor n e criar um número de colaboradores de acordo com esse valor 
        public void addColab(int nColabs)
        {

            Array.Resize(ref colabArray, colabArray.Length + nColabs);

            //instancia um novo colaborador em uma posição determinada do array
            for (int i = 0; i < nColabs; i++)
            {
                lastIndex++;

                colabArray[lastIndex] = new Colaborador();
                
                Console.WriteLine($"Insira o código do colaborador {lastIndex + 1}:");
                int newCodColab = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine($"Insira o nome do colaborador {lastIndex + 1}:");
                string newNome = Console.ReadLine();
                
                Console.WriteLine($"O colaorador {lastIndex + 1} tem seguro de saúde? (sim/não)");
                bool newSegSaude = convertBooleano(Console.ReadLine());

                Console.WriteLine($"Insira o ordenado anual do colaborador {lastIndex + 1}:");
                double newVencColab = Double.Parse(Console.ReadLine());

                Console.WriteLine($"Insira o valor do subsídio mensal de alimentação do colaborador {lastIndex + 1}:");
                double newPlafAlimColab = Double.Parse(Console.ReadLine());
                    
                colabArray[lastIndex] = new Colaborador(newCodColab, newNome, newSegSaude, newVencColab, newPlafAlimColab);
         
            }
            Console.WriteLine("Colaborador(es) cadastrado(s) com sucesso!!");
            Thread.Sleep(500);
            Console.WriteLine("aguarde 2 segundo(s)");
            Thread.Sleep(1200);
            Console.WriteLine("aguarde 1 segundo(s)");
            Thread.Sleep(1200);
            Console.Clear();
        }



        //essa função vai percorrer o colabArray a fim de listar todos os colaboradores
        public void consultColabs()
        {
            if (colabArray != null && colabArray.Length != 0) 
            {
                for (int i = 0; i < colabArray.Length; i++)
                {
                    Console.WriteLine($"Colaborador {i + 1}:");
                    Console.WriteLine($"Nome: {colabArray[i].nomColab}");
                    Console.WriteLine($"Código: {colabArray[i].codColab}");
                    Console.WriteLine();
                }
            }
            
            else
            {
                Console.WriteLine("Crie algum(s) colaborador(es) antes de fazer a consulta!!");
                Console.WriteLine();
            }
        }



        public void searchColab(string termoPesquisa)
        {

            //tenta converter o termoPesquisa em um número
            if (int.TryParse(termoPesquisa, out int codPesquisa))
            {
                for (int i = 0; i < colabArray.Length; i++)
                {
                    if (colabArray[i].getCod() == codPesquisa)
                    {
                        Console.WriteLine($"O colaborador encontrado se chama {colabArray[i].getNome()}, possui o código {colabArray[i].getCod()} e");
                        Console.WriteLine($"possui um vencimento anual no valor de {colabArray[i].financeiro.getVencAnual()}€ além de um subsídio mensal de alimentação no valor de {colabArray[i].financeiro.getSubsAlim()}€");
                        Console.WriteLine();
                        break;
                    }
                }
                Console.WriteLine("Não foi possível encontrar um colaborador com esse código.");

            }

            else if (termoPesquisa.GetType() == typeof(string))
            {
                for (int i = 0; i < colabArray.Length; i++)
                {
                    if (colabArray[i].getNome() == termoPesquisa)
                    {
                        Console.WriteLine($"O colaborador encontrado se chama {colabArray[i].getNome()} e possui o código {colabArray[i].getCod()}");
                        Console.WriteLine($"possui um vencimento anual no valor de {colabArray[i].financeiro.getVencAnual()}¢ além de um subsídio mensal de alimentação no valor de {colabArray[i].financeiro.getSubsAlim()}¢");
                        Console.WriteLine();
                        break;
                    }
                }
                Console.WriteLine("Não foi possível encontrar um colaborador com esse nome.");
            }

            else
            {
                Console.WriteLine("Não foi possível encontrar esse colaborador, verifique se o código/nome está correto.");
            }
        }



        //mostra o ordenado de um colaborador e o ID da conta
        public void buscaOrdColab(string termoPesquisa)
        {
            if (int.TryParse(termoPesquisa, out int codPesquisa))
            {

                for (int i = 0; i < colabArray.Length; i++)
                {

                    if (colabArray[i].getCod() == codPesquisa)
                    {
                        Console.WriteLine($"O colaborador se chama {colabArray[i].getNome()}, possui um ordenado anual no valor de {colabArray[i].financeiro.getVencAnual()}¢ transferido para a conta Nº{colabArray[i].financeiro.getContaID()}");
                        break;
                    }

                }

            }

            else
            {
                Console.WriteLine("Por favor digite um código válido.");
            }

        }


        //Mostra o saldo do subsídio Alimentação de um Colaborador
        public void buscaSubsAlmColab(string termoPesquisa)
        {

            if (int.TryParse(termoPesquisa, out int codPesquisa))
            {
                for (int i = 0; i < colabArray.Length; i++)
                {

                    if (colabArray[i].getCod() == codPesquisa)
                    {
                        Console.WriteLine($"O colaborador se chama {colabArray[i].getNome()} e possui um saldo de alimentação no valor de {colabArray[i].financeiro.getSubsAlim()}¢");
                        break;
                    }

                }

              
            }
            else 
            {
                Console.WriteLine("Por favor digite um código válido.");
            }
        }



        //Função de carregamento de Plafond para um colaborador
        public void carregaPlafond()
        {
            Console.WriteLine("Para qual código de colaborador deseja carregar?");
            int codColab = int.Parse(Console.ReadLine());

            for (int i = 0; i < colabArray.Length; i++)
            {
                if (colabArray[i].getCod() == codColab)
                {
                    Console.WriteLine("Digite o valor a ser carregado:");
                    double valorPlafond = double.Parse(Console.ReadLine());

                    colabArray[i].financeiro.setPlafondAlim(colabArray[i].financeiro.getSubsAlim() + valorPlafond);
                    Console.WriteLine($"O novo valor do Plafond do subsídio Alimentação do/a {colabArray[i].getNome()} é: {colabArray[i].financeiro.getSubsAlim()}¢ ");
                    Console.WriteLine();
                    break;
                }
               

            }


        }



        //Função de carregamento de Plafond para todos os colaboradores
        public void carregaPlafondTodos()
        {
            Console.WriteLine("Carregar no valor padrão de 140¢?? (sim/não)");
            bool carrPadrao = convertBooleano(Console.ReadLine());

            //Loop para percorrer todos os colaboradores e carregar o valor no Plafond do subsídio Alimentação

            if (carrPadrao == true)
            {
                for (int i = 0; i < colabArray.Length; i++)
                {
                    colabArray[i].financeiro.setPlafondAlim(colabArray[i].financeiro.getSubsAlim() + 140);  
                }
                Console.WriteLine("Todos os colaboradores tiveram o plafond carregado de acordo com o valor padrão");
                Console.WriteLine();
            }
            else if (carrPadrao == false)
            {
                for (int i = 0; i < colabArray.Length; i++)
                {
                    Console.WriteLine($"Qual valor deve ser carregado para o colaborador {i + 1} (nome: {colabArray[i].getNome()})? ");
                    double valorCarr = double.Parse(Console.ReadLine());
                    colabArray[i].financeiro.setPlafondAlim(colabArray[i].financeiro.getSubsAlim() + valorCarr);
                    Console.WriteLine($"O novo valor do Plafond do subsídio Alimentação do colaborador {i + 1} é: {colabArray[i].financeiro.getSubsAlim()}");
                    Console.WriteLine();
                }

            }
            
        }



        public void MediaVencColabs()
        {
            
            if (colabArray != null ) 
            {
                double totalVencColabs = 0;
                double medVencColabs = 0;

                for (int i = 0; i < colabArray.Length; i++)
                {
                    totalVencColabs += colabArray[i].financeiro.getVencAnual();
                    
                }

                medVencColabs = totalVencColabs / colabArray.Length;

                Console.WriteLine($"O valor da média dos vencimentos anuais dos colaboradores é {medVencColabs}");
                Console.WriteLine();

            }

            else
            {
                Console.WriteLine("Crie alguns colaboradores antes de executar esta operação !!");
            }
            
        }



        public void colabMaiorVenc()
        {
            if (colabArray != null && colabArray.Length != 1)
            {
                double maiorVenc = 0;
                string nomeColab = "";
                for (int i = 0; i < colabArray.Length; i++) 
                {
                    if (colabArray[i].financeiro.getVencAnual() > maiorVenc) 
                    {
                        nomeColab = colabArray[i].getNome();

                    }

                }

                Console.WriteLine($"@ colaborador@ com maior vencimento se chama {nomeColab}");
                Console.WriteLine();

            }

            else
            { 
                Console.WriteLine("Crie alguns colaboradores antes de utilizar esta função!!");
                Console.WriteLine();
            }

        }



        public void colabMenorVenc()
        {
            if (colabArray != null && colabArray.Length != 1)
            {
                double menorVenc = 999999;
                string nomeColab = "";

                for (int i = 0; i < colabArray.Length; i++)
                {
                    if (colabArray[i].financeiro.getVencAnual() < menorVenc)
                    {
                        nomeColab = colabArray[i].getNome();

                    }

                }

                Console.WriteLine($"@ colaborador@ com menor vencimento se chama {nomeColab}");
                Console.WriteLine();

            }

            else
            {
                Console.WriteLine("Crie alguns colaboradores antes de utilizar esta função!!");
                Console.WriteLine();
            }

        }



        // Listagem dos Inscritos no Seguro de Saúde
        public void listSegSau()
        {
            Console.WriteLine("Iniciando listagem de todos os colaboradores com e sem seguro saúde...");

            for (int i = 0; i < colabArray.Length; i++)
            {
                if (colabArray[i].getSegSaudeColab() == true)
                {
                    Console.WriteLine($"O colaborador {i + 1} com nome {colabArray[i].getNome()} está inscrito no seguro saúde");
                }
                if (colabArray[i].getSegSaudeColab() == false)
                {
                    Console.WriteLine($"O colaborador {i + 1} com nome {colabArray[i].getNome()} não está inscrito no seguro saúde");
                }
                Console.WriteLine();


            }

        }



        public void FoodCardDisc()
        {
            Console.WriteLine("Qual o código do colaborador a descontar?");
            int codColab = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < colabArray.Length; i++)
            {
                if (codColab == colabArray[i].getCod())
                {
                    Console.WriteLine("Qual o valor a ser descontado do " + colabArray[i].getNome());
                    int valorDisc = Convert.ToInt32(Console.ReadLine());
                    if (valorDisc <= colabArray[i].financeiro.getSubsAlim())
                    {
                        colabArray[i].financeiro.setPlafondAlim(colabArray[i].financeiro.getSubsAlim() - valorDisc);
                        Console.WriteLine("O saldo da sua conta atualizado é " + colabArray[i].financeiro.getSubsAlim());
                        Console.WriteLine();
                        break;
                    }
                    else if (valorDisc > colabArray[i].financeiro.getSubsAlim())
                    {
                        Console.WriteLine("O valor a ser descontado é maior que o saldo da conta!");
                        Console.WriteLine();
                        break;
                    }

                }
            }
        }



        public static bool convertBooleano(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            //coloca o input em letras minúsculas e remove espaços em branco
            input = input.Trim().ToLowerInvariant();

            if (input == "s" || input == "sim" || input == "y" || input == "yes")
            {
                return true;
            }
            else if (input == "n" || input == "não" || input == "nao" || input == "no")
            {
                return false;
            }
            else
            {
                bool result;
                if (bool.TryParse(input, out result))
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
        }





    }
}

