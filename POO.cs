using System;
using System.Collections.Generic;

public class Aluno
{
    /*
    Representa um aluno cadastrado na academia.
    O aluno possui dados próprios e pode ter zero ou várias matrículas ao longo do tempo. Isso permite que ele continue cadastrado mesmo quando não possui uma matrícula ativa.
    */

    // As propriedades possuem set privado para impedir alterações externas diretas.
    public string Nome { get; private set; }
    public string Cpf { get; private set; }
    public decimal Peso { get; private set; }

    /*
    A lista de matrículas é private para aplicar encapsulamento.
    O acesso à lista ocorre através dos métodos da própria classe, evitando que outras classes alterem a lista diretamente.
    */
    private List<Matricula> matriculas;

    // Construtor responsável por inicializar os dados obrigatórios do aluno.
    public Aluno(string nome, string cpf, decimal peso)
    {
        Nome = nome;
        Cpf = cpf;

        // O peso deve ser sempre maior que zero.
        if (peso <= 0)
        {
            throw new ArgumentException("PESO DEVE SER MAIOR QUE 0.");
        }

        Peso = peso;

        /*
        A lista de matrículas é criada junto com o aluno e fica sob seu controle.
        */
        matriculas = new List<Matricula>();
    }

    /*
    Adiciona uma matrícula à lista do aluno.

    O método é public para que outras classes possam solicitar a inclusão, mas a lista continua private. Assim, o encapsulamento é maintdo.
    */
    public void AddMatricula(Matricula matricula)
    {
        if (matricula == null)
        {
            throw new ArgumentNullException(nameof(matricula));
        }

        matriculas.Add(matricula);
    }

    public void AtualizarPeso(decimal novoPeso)
    {
        if (novoPeso <= 0)
        {
            throw new ArgumentException("PESO DEVE SER MAIOR QUE 0.");
        }

        Peso = novoPeso;
    }
}

public class PersonalTrainer
{
    /*
    Representa um Personal Trainer cadastrado na academia.

    O Personal Trainer existe de forma independente dos alunos.
    */

    // O set privado impede alterações diretas dos dados por outras classes.
    public string Nome { get; private set; }
    public string Cpf { get; private set; }

    // Construtor responsável por inicializar os dados do Personal Trainer.
    public PersonalTrainer(string nome, string cpf)
    {
        Nome = nome;
        Cpf = cpf;
    }
}

public class Matricula
{
    /*
    Representa a matrícula de um aluno em um plano.
    A matrícula depende da existência de um Aluno e de um Plano previamente cadastrados. Por isso, o construtor recebe esses dois objetos.
    */

    /*
    As propriedades possuem set privado para impedir que uma matrícula já criada seja associada externamente a outro aluno ou plano.
    */
    public Aluno Aluno { get; private set; }
    public Plano Plano { get; private set; }
    public DateTime DataInicio { get; private set; }

    // Construtor responsável por criar uma matrícula válida.
    public Matricula(Aluno aluno, Plano plano, DateTime dataInicio)
    {
        /*
        Uma matrícula só faz sentido quando existe um aluno associado.
        */
        if (aluno == null)
        {
            throw new ArgumentNullException(nameof(aluno));
        }

        /*
        Uma matrícula também precisa estar relacionada a um plano existente.
        */
        if (plano == null)
        {
            throw new ArgumentNullException(nameof(plano));
        }

        Aluno = aluno;
        Plano = plano;
        DataInicio = dataInicio;
    }
}

public class Plano
{
    /*
    Representa um plano oferecido pela academia, como Mensal ou Anual.
    O plano possui seus próprios dados e pode existir independentemente de uma matrícula.
    */

    // O set privado protege o valor da mensalidade contra alterações externas.
    public decimal ValorMensalidade { get; private set; }
    public string Nome { get; private set; }

    // Construtor responsável por criar um plano com dados válidos.
    public Plano(string nome, decimal valorMensalidade)
    {
        // O nome do plano é obrigatório.
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("O nome do plano é obrigatório.");
        }

        // O valor da mensalidade deve ser maior que zero.
        if (valorMensalidade <= 0)
        {
            throw new ArgumentException(
                "O valor da mensalidade deve ser maior que 0."
            );
        }

        Nome = nome;
        ValorMensalidade = valorMensalidade;
    }
}

public class Academia
{
    /*
    Academia centraliza o cadastro de alunos, planos, Personal Trainers e matrículas.
    As coleções são private para impedir wue outras classes alterem os objetos diretamente.
    */
    private List<Aluno> alunos;
    private List<Plano> planos;
    private List<PersonalTrainer> personalTrainers;
    private List<Matricula> matriculas;

    // Construtor responsável por inicializar as coleções da academia.
    public Academia(){
        alunos = new List<Aluno>();
        planos = new List<Plano>();
        personalTrainers = new List<PersonalTrainer>();
        matriculas = new List<Matricula>();
    }

    /*
    Cadastra um aluno na academia.
    */
    public void CadastrarAluno(Aluno aluno){
        if (aluno == null)
        {
            throw new ArgumentNullException(nameof(aluno));
        }

        alunos.Add(aluno);
    }

    /*
    Cadastra um Personal Trainer.
    O Personal Trainer pode existir independentemente da Academia e dos alunos.
    */
    public void CadastrarPersonalTrainer(PersonalTrainer personalTrainer){
        if (personalTrainer == null)
        {
            throw new ArgumentNullException(nameof(personalTrainer));
        }

        personalTrainers.Add(personalTrainer);
    }

    /*
    Cadastra um plano na academia.
    O plano é um objeto independente e pode existir antes de uma matrícula.
    */
    public void CadastrarPlano(Plano plano)
    {
        if (plano == null)
        {
            throw new ArgumentNullException(nameof(plano));
        }

        planos.Add(plano);
    }

    /*
    Cria uma matrícula para um aluno e um plano já cadastrados.
    A validação garante que uma matrícula só seja criada quando o aluno e o plano já fizerem parte dos cadastros da academia.
    */
    public Matricula MatricularAluno(Aluno aluno, Plano plano, DateTime dataInicio){
        if (!alunos.Contains(aluno))
        {
            throw new Exception("ALUNO NAO CADASTRADO.");
        }

        if (!planos.Contains(plano))
        {
            throw new Exception("PLANO NAO ATIVO.");
        }

        /*
        Criação da matrícula.
        A Academia cria o objeto Matricula e o registra em sua lista.
        */
        Matricula matricula = new Matricula(aluno, plano, dataInicio);

        matriculas.Add(matricula);

        /*
        Associação da matrícula ao aluno.

        Destinatário: aluno
        Seletor: AddMatricula
        Argumento: matricula

        A mensagem solicita ao objeto Aluno que registre a nova matrícula
        em sua própria lista.
        */
        aluno.AddMatricula(matricula);

        return matricula;
    }

    /*
    Retorna uma cópia da lista de alunos.

    Isso impede que a lista interna da Academia seja modificada diretamente por código externo, preservando o encapsulamento.
    */
    public List<Aluno> ListarAlunos()
    {
        return new List<Aluno>(alunos);
    }

    /*
    Retorna uma cópia da lista de planos para impedir alterações diretas na lista interna da Academia.
    */
    public List<Plano> ListarPlanos()
    {
        return new List<Plano>(planos);
    }

    /*
    Retorna uma cópia da lista de Personal Trainers.
    */
    public List<PersonalTrainer> ListarPersonalTrainers()
    {
        return new List<PersonalTrainer>(personalTrainers);
    }

    /*
    Retorna uma cópia da lista de matrículas.

    Dessa forma, o código externo pode consultar as matrículas sem receber acesso direto à lista interna.
    */
    public List<Matricula> ListarMatriculas()
    {
        return new List<Matricula>(matriculas);
    }
}

public class Program
{
    public static void Main()
    {
        /*
        Criação da Academia
        O objeto Academia será responsável por manter os cadastros e controlar a criação das matrículas.
        */
        Academia academia = new Academia();

        /*
        Criação de dois alunos.
        O aluno é criado antes de escolher qualquer plano, conforme a regra do sistema.
        */
        Aluno aluno1 = new Aluno("Gabriel", "133.256.723-21", 40.5m);

        Aluno aluno2 = new Aluno("Nathan", "176.149.659-18", 50.5m);

        // Criação dos planos disponíveis na academia.
        Plano planoMensal = new Plano("Mensal", 100.00m);

        Plano planoAnual = new Plano("Anual", 900.00m);

        /*
        Os alunos são cadastrados na Academia antes da criação das matrículas.
        */
        academia.CadastrarAluno(aluno1);
        academia.CadastrarAluno(aluno2);

        // Os planos também precisam estar cadastrados antes da matrícula.
        academia.CadastrarPlano(planoMensal);
        academia.CadastrarPlano(planoAnual);

        /*
        Criação da matrícula do aluno1.

        Destinatário: academia
        Seletor: MatricularAluno
        Argumentos: aluno1, planoMensal, DateTime.Now

        A Academia verifica se os objetos foram cadastrados, cria a matrícula
        e associa a matrícula ao aluno.
        */
        Matricula matricula1 = academia.MatricularAluno(aluno1, planoMensal, DateTime.Now);

        /*
        Criação da matrícula do aluno2.

        Destinatário: academia
        Seletor: MatricularAluno
        Argumentos: aluno2, planoAnual, DateTime.Now
        */
        Matricula matricula2 = academia.MatricularAluno(aluno2, planoAnual, DateTime.Now);

        /*
        Criação de um Personal Trainer.
        O Personal Trainer é independente dos alunos e pode ser cadastrado posteriormente na Academia.
        */
        PersonalTrainer personalTrainer = new PersonalTrainer("Dafne", "191.069.487-38");

        academia.CadastrarPersonalTrainer(personalTrainer);

        Console.WriteLine("///- ALUNOS CADASTRADOS -///");

        /*
        A Academia fornece uma cópia da lista de alunos.
        O foreach permite consultar os objetos sem modificar a lista interna.
        */
        List<Aluno> alunos = academia.ListarAlunos();

        foreach (Aluno aluno in alunos)
        {
            Console.WriteLine("NOME: " + aluno.Nome + " - CPF: " + aluno.Cpf + " - PESO: " + aluno.Peso + " KG");
        }

        Console.WriteLine();
        Console.WriteLine("///- MATRÍCULAS -///");

        List<Matricula> matriculas = academia.ListarMatriculas();

        foreach (Matricula matricula in matriculas)
        {
            Console.WriteLine("ALUNO: " + matricula.Aluno.Nome + " - PLANO: " + matricula.Plano.Nome);
        }
    }
}
