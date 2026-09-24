using System;

public class Aluno
{
    public string nome {get; private set;}
    public string cpf {get; private set;}
    public decimal peso {get; private set;}

    public Aluno(string Nome, string CPF, decimal Peso)
    {
        nome = Nome;
        cpf = CPF;
        peso = Peso;
    }

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
    public string nome {get; private set;}
    public string cpf {get; private set;}
    public PersonalTrainer(string Nome, string CPF)
    {
        nome = Nome;
        cpf = CPF;
    }
}

public class Matricula
{
    Aluno aluno{get; private set;}
    Plano plano{get; private set;}
    DateTime dataInicio{get; private set;}

    public Matricula(Aluno aluno, Plano plano, DateTime dataInicio)
    {
        this.aluno = aluno;
        this.plano = plano;
        this.dataInicio = dataInicio;
    }
}

public class Plano
{
    public decimal ValorMensalidade {get; private set;}
    public string nomePlano {get; private set;}
}

public class Academia{
    
    private List <Aluno> alunos
    private List <Plano> planos
    private List <PersonalTrainer> personaltrainer

    public Academia(){
        
        alunos = new List <Aluno>();
        planos = new List <Plano>();
        personaltrainer = new List <PersonalTrainer>();

    }

    public void CadastroAluno(Aluno aluno){

        if (aluno == null)
        {
            throw new ArgumentNullException(nameof(aluno));
        }

        alunos.Add(alunos);
    }

    public void CadastroPersonalTrainer(PersonalTrainer personaltrainer){

        if (personaltrainer == null)
        {
            throw new ArgumentNullException(nameof(personaltrainer));
        }

        personaltrainer.Add(personaltrainer);
    }

    public void CadastroPlano(Plano plano){

        if (plano == null)
        {
            throw new ArgumentNullException(nameof(planos));
        }

        planos.Add(planos);
    }

    Matricula MatricularAluno(Aluno aluno, Plano plano, DateTime dataInicio){

        if(!alunos.Contains(aluno)){
            throw new Exception("ALUNO NAO MATRICULADO");
        }
        
        if(!planos.Contains(plano)){
            throw new Exception("PLANO NAO ATIVO");
        }

        Matricula matricula = new Matricula(aluno, plano, dataInicio);
        matriculas.Add(matricula);

        aluno.AddMatricula(matricula);
        return matricula;
    }

     public List<Aluno> ListarAlunos()
    {
        return new List<Aluno>(alunos);
    }
    // Retorna uma cópia da lista de planos
    public List<Plano> ListarPlanos()
    {
        return new List<Plano>(planos);
    }
    // Retorna uma cópia da lista de personal trainers
    public List<PersonalTrainer> ListarPersonalTrainers()
    {
        return new List<PersonalTrainer>(personalTrainer);
    }
    // Retorna uma cópia da lista de matrículas
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
        Criação da academia.
        Relação de composiçãp entre Academia e Matrícula
        */
        Academia academia = new Academia();
        /*
        Criação de dois alunos.
        Cada aluno possui estado obrigatório (nome, CPF e peso)
        */
        Aluno aluno1 = new Aluno("Ryan", "123.169.426-48", 40.5m);
        Aluno aluno2 = new Aluno("Lukas", "123.168.423-48", 50.5m);
        /*
        Criação dos planos.
        Plano também possui estado obrigatório(nome e valor)
        */
        Plano planoMensal = new Plano("Mensal", 100.00m);
        Plano planoAnual = new Plano("Anual", 900.00m);
        /*
        Associação entre a Academia e os alunos.
        O objeto Aluno existe independentemente da Academia
        */
        academia.CadastrarAluno(aluno1);
        academia.CadastrarAluno(aluno2);

        // Associação entre a Academia e os planos
        academia.CadastrarPlano(planoMensal);
        academia.CadastrarPlano(planoAnual);
        /*
        Matrícula do primeiro aluno no plano mensal.
        Destinatário: academia
        Seletor: MatricularAluno
        Argumentos: aluno1, planoMensal e a data atual.
        */
        Matricula matricula1 = academia.MatricularAluno(aluno1, planoMensal, DateTime.Now);

        // Matrícula do segundo aluno no plano anual.
        Matricula matricula2 = academia.MatricularAluno(aluno2, planoAnual, DateTime.Now);

        // Criação de um PersonalTrainer.
        PersonalTrainer personalTrainer = new PersonalTrainer("Rogerio", "123.169.429-48");

        // Associação entre Academia e PersonalTrainer.
        academia.CadastrarPersonalTrainer(personalTrainer);

        Console.WriteLine("---ALUNOS CADASTRADOS---");
        List<Aluno> alunos = academia.ListarAlunos();

        foreach (Aluno aluno in alunos)
        {
            Console.WriteLine("Nome: " + aluno.Nome + " - CPF: " + aluno.Cpf + " - Peso: " + aluno.Peso + " kg");
        }

        Console.WriteLine();
        Console.WriteLine("---MATRÍCULAS---");

        // Solicita à academia uma cópia da lista de matrículas.
        List<Matricula> matriculas = academia.ListarMatriculas();

        foreach (Matricula matricula in matriculas)
        {
            Console.WriteLine( "Aluno: " + matricula.Aluno.Nome + " - Plano: " + matricula.Plano.Nome);
        }
    }
}