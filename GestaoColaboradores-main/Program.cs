using ColabEFinanceiro;
using System;

class Program
{
    //retorna o input do usuário em formato inteiro

    private static int retInput(string inputUser)
    {
        int outputInt;

        if(int.TryParse(inputUser, out outputInt))
        {
            return
            outputInt;
        }
        else
        { 
            return 999; 
        }
    }

    public static int pMenu()
    {
        //Menu de Secções

        Console.WriteLine( "Escolha a sua seccção:" );
        Console.WriteLine( "1 - Colaborador" );
        Console.WriteLine( "2 - Consulta ordenados e subsídios" );
        Console.WriteLine( "3 - Pagamentos e carregamentos" );
        Console.WriteLine( "4 - Métricas relevantes" );
        Console.WriteLine( "5 - Outras operações" );
        Console.WriteLine( "0 - Fechar a aplicação" );
        Console.Write( "Escolha uma opção: " );

        //Retorna a opção escolhida pelo utilizador
        return retInput(Console.ReadLine());
    }

    public static int colabMenu()
    {

        //Menu do Colaborador (1)

        Console.WriteLine( "Escolha a sua seccção:" );
        Console.WriteLine( "1 - Inserir colaborador" );
        Console.WriteLine( "2 - Listagem de registos de Colaboradores" );
        Console.WriteLine( "3 - Consultar o registo de um Colaborador" );
        Console.WriteLine( "0 - Voltar ao menu de secções" );
        Console.Write("Escolha uma opção: " );

        //Retorna a opção escolhida pelo utilizador
        return retInput(Console.ReadLine());
    }

    public static int consMenu()
    {
        // Menu de Consulta (2)

        Console.WriteLine( "Escolha a sua seção:" );
        Console.WriteLine( "1 - Consulta ordenado de um colaborador" );
        Console.WriteLine( "2 - Consulta subsídio de alimentação" );
        Console.WriteLine( "0 - Voltar ao menu de secções" );
        Console.Write( "Escolha uma opção: " );

        // Retorna a opção escolhida pelo utilizador
        return retInput(Console.ReadLine());
    }

    public static int pagMenu()
    {
        // Menu de Pagamentos (3)

        Console.WriteLine( "Escolha a sua seção:" );
        Console.WriteLine( "1 - Carregar o Plafond do subsídio Alimentação de um Colaborador" );
        Console.WriteLine( "2 - Carregar o Plafond do subsídio Alimentação de todos os Colaboradores" );
        Console.WriteLine( "0 - Voltar ao menu de secções" );
        Console.Write( "Escolha uma opção: " );

        // Retorna a opção escolhida pelo utilizador
        return retInput(Console.ReadLine());
    }

    public static int metricasMenu()
    {
        // Menu de Métricas Relevantes (4)

        Console.WriteLine( "Escolha a sua opção:" );
        Console.WriteLine( "1 - Calcular a média dos vencimentos dos colaboradores" );
        Console.WriteLine( "2 - Consulta nome d@ colaborador@ com melhor vencimento" );
        Console.WriteLine( "3 - Consulta nome d@ colaborador@ com menor vencimento" );
        Console.WriteLine( "0 - Voltar ao menu de secções" );
        Console.Write( "Escolha uma opção: " );

        // Retorna a opção escolhida pelo utilizador
        return retInput(Console.ReadLine());
    }

    public static int etcMenu ()
    {
        // Menu de Outras Operações (5)

        Console.WriteLine( "Escolha a sua seção:" );
        Console.WriteLine( "1 - Listagem dos colaboradores inscritos no seguro de saúde" );
        Console.WriteLine( "2 - Usar o cartão para as refeições" );
        Console.WriteLine( "0 - Voltar ao menu de secções" );
        Console.Write( "Escolha uma opção: " );

        // Retorna a opção escolhida pelo utilizador
        return retInput(Console.ReadLine());
    }

    static void Main(string[] args)
    {

        //as classes Colaborador e Financeiro foram instanciadas como objetos
        Colaborador colaborador = new Colaborador();
        Financeiro financeiro = new Financeiro();

        int opt = 0;
        do
        {
            opt = pMenu();
            switch (opt)
            {
                case 1:
                    // Menu Colaborador
                    Console.Clear();
                    int optColab = 0;
                    do
                    {
                        optColab = colabMenu();
                        switch (optColab)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine( "Quantos colaboradores devem ser criados?" );
                                int nColabs = Convert.ToInt32(Console.ReadLine());
                                colaborador.addColab(nColabs);
                                break;

                            case 2:
                                //2 - Listagem de registos de Colaboradores
                                Console.Clear();
                                colaborador.consultColabs();
                                break;

                            case 3:
                                //3 - Consultar o registo de um Colaborador
                                Console.Clear();
                                Console.WriteLine( "Digite o código ou o nome de um colaborador para fazer a pesquisa:" );
                                colaborador.searchColab(Console.ReadLine());
                                break;

                            case 0:
                                Console.Clear();
                                break;

                            default:
                                Console.WriteLine();
                                Console.WriteLine( "Escolha somente uma das opções mostradas." );
                                Thread.Sleep(1200);
                                Console.Clear();
                                break;
                        }
                    }

                    while (optColab != 0 );
                    break;

                case 2:
                    //Menu consulta ordenados e subsídios
                    Console.Clear();
                    int optCons = 0;
                    do
                    {
                        optCons = consMenu();
                        switch (optCons)
                        {

                            case 1:
                                //Consultar ordenado atual de um colaborador
                                Console.Clear();
                                Console.WriteLine( "Digite o código do colaborador para fazer a consulta" );
                                colaborador.buscaOrdColab(Console.ReadLine());
                                break;

                            case 2:
                                //Consultar saldo do subsídio Alimentação de um Colaborador
                                Console.Clear();
                                Console.WriteLine( "Digite o código do colaborador para fazer a consulta" );
                                colaborador.buscaSubsAlmColab(Console.ReadLine());
                                break;

                            case 0:
                                Console.Clear();
                                break;

                            default:
                                Console.WriteLine();
                                Console.WriteLine( "Escolha somente uma das opções mostradas." );
                                Thread.Sleep( 1200 );
                                Console.Clear();
                                break;
                        }
                    }
                    while (optCons != 0 );
                    break;

                case 3:
                    //Pagamentos e carregamentos
                    Console.Clear();
                    int optPag = 0;
                    do
                    {
                        optPag = pagMenu();
                        switch(optPag)
                        {
                            case 1:
                                //Carregar o Plafond do subsídio Alimentação de um Colaborador                            
                                Console.Clear();
                                colaborador.carregaPlafond();
                                break;

                            case 2:
                                //Carregar o Plafond do subsídio Alimentação de todos os Colaboradores                            
                                Console.Clear();
                                colaborador.carregaPlafondTodos();
                                break;

                            case 0:
                                Console.WriteLine( "Retornando ao menu..." );
                                Console.Clear();
                                break;

                            default:
                                Console.WriteLine();
                                Console.WriteLine( "Escolha somente uma das opções mostradas." );
                                Thread.Sleep( 1200 );
                                Console.Clear();
                                break;
                        }
                    }
                    while (optPag!= 0);
                    break;

                case 4:
                    //4 - Métricas relevantes
                    Console.Clear();
                    int optMet = 0;
                    do
                    {
                        optMet = metricasMenu();
                        switch (optMet)
                        {

                            case 1:
                                // 
                                Console.Clear();
                                colaborador.MediaVencColabs();
                                break;

                            case 2:
                                //
                                Console.Clear();
                                colaborador.colabMaiorVenc();
                                break;

                            case 3:
                                //
                                Console.Clear();
                                colaborador.colabMenorVenc();
                                break;

                            case 0:
                                Console.Clear();
                                break;

                            default:
                                Console.WriteLine();
                                Console.WriteLine( "Escolha somente uma das opções mostradas." );
                                Thread.Sleep(1200);
                                Console.Clear();
                                break;
                        }
                    }
                    while (optMet != 0);
                    break;

                case 5:
                    //5 - Outras operações
                    Console.Clear();
                    int optEtc = 0;
                    do
                    {
                        optEtc = etcMenu();
                        switch (optEtc)
                        {

                            case 1:
                                //Listagem dos Inscritos no Seguro de Saúde
                                Console.Clear();
                                colaborador.listSegSau();
                                break;

                            case 2:
                                //2. Usar o cartão para as refeições
                                Console.Clear();
                                colaborador.FoodCardDisc();
                                break;

                            case 0:
                                Console.Clear();
                                break;

                            default:
                                Console.WriteLine();
                                Console.WriteLine( "Escolha somente uma das opções mostradas." );
                                Thread.Sleep( 1200 );
                                Console.Clear();
                                break;
                        }
                    }
                    while (optEtc != 0 );
                    break;

                case 0:
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine( "Escolha somente uma das opções mostradas." );
                    Thread.Sleep( 1200 );
                    Console.Clear();
                    break;
            }
        }// fim menu de secções
        
        while (opt != 0 );
    }
}
//criar um menu visual de Secções da seguinte forma:

// ***Escolha a sua seccção***
// 1 - Colaborador
// 2 - Consulta ordenados e subsídios
// 3 - pagamentos e carregamentos
// 4 - métricas relevantes
// 5 - outras operações
// 0 - fechar a aplicação

//(1) criação do menu Colaborador
//1. Inserir colaborador
//2. Listagem de registos de Colaboradores
//3. Consultar o registo de um Colaborador
//0. Voltar ao menu de seccções

//(2) criação do menu Consulta ordenados e subsídios
//1. Consultar ordenado atual de um colaborador
//2. Consultar saldo do subsídio Alimentação de um Colaborador
//0. Voltar ao menu de seccções

//(3) criação do menu pagamentos e carregamentos (JP)
//1. Carregar o Plafond do subsídio Alimentação de um Colaborador
//2. Carregar o Plafond do subsídio Alimentação de todos os Colaboradores
//0. Voltar ao menu de seccções

//(4) criação do menu métricas relevantes (Letícia)
//1. Calcular a média dos vencimentos dos colaboradores
//2. Consulta nome d@ colaborador@ com melhor vencimento
//3. Consulta nome d@ colaborador@ com menor vencimento
//0. Voltar ao menu de seccções

//(5) criação do menu outras operações (Dotô Ivan)
//1. Listagem dos Inscritos no Seguro de Saúde
//2. Usar o cartão para as refeições
//0. Voltar ao menu de seccções
