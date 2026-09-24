using System;
using System.Collections.Generic;

public class Aluno
{
    public string Nome { get; private set; }
    public string Cpf { get; private set; }
    public decimal Peso { get; private set; }

    private List<Matricula> matriculas;

    public Aluno(string nome, string cpf, decimal peso)
    {
        Nome = nome;
        Cpf = cpf;

        if (peso <= 0)
        {
            throw new ArgumentException("PESO DEVE SER MAIOR QUE 0.");
        }

        Peso = peso;
        matriculas = new List<Matricula>();
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
    public string Nome { get; private set; }
    public string Cpf { get; private set; }

    public PersonalTrainer(string nome, string cpf)
    {
        Nome = nome;
        Cpf = cpf;
    }
}

public class Matricula
{
    public Aluno Aluno { get; private set; }
    public Plano Plano { get; private set; }
    public DateTime DataInicio { get; private set; }

    public Matricula(Aluno aluno, Plano plano, DateTime dataInicio)
    {
        if (aluno == null)
        {
            throw new ArgumentNullException(nameof(aluno));
        }

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
    public decimal ValorMensalidade { get; private set; }
    public string Nome { get; private set; }

    public Plano(string nome, decimal valorMensalidade)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("O nome do plano é obrigatório.");
        }

        if (valorMensalidade <= 0)
        {
            throw new ArgumentException("O valor da mensalidade deve ser maior que 0.");
        }

        Nome = nome;
        ValorMensalidade = valorMensalidade;
    }
}

public class Academia
{
    private List<Aluno> alunos;
    private List<Plano> planos;
    private List<PersonalTrainer> personalTrainers;
    private List<Matricula> matriculas;

    public Academia()
    {
        alunos = new List<Aluno>();
        planos = new List<Plano>();
        personalTrainers = new List<PersonalTrainer>();
        matriculas = new List<Matricula>();
    }

    public void CadastrarAluno(Aluno aluno)
    {
        if (aluno == null)
        {
            throw new ArgumentNullException(nameof(aluno));
        }

        alunos.Add(aluno);
    }

    public void CadastrarPersonalTrainer(PersonalTrainer personalTrainer)
    {
        if (personalTrainer == null)
        {
            throw new ArgumentNullException(nameof(personalTrainer));
        }

        personalTrainers.Add(personalTrainer);
    }

    public void CadastrarPlano(Plano plano)
    {
        if (plano == null)
        {
            throw new ArgumentNullException(nameof(plano));
        }

        planos.Add(plano);
    }

    public Matricula MatricularAluno(Aluno aluno, Plano plano, DateTime dataInicio)
    {
        if (!alunos.Contains(aluno))
        {
            throw new Exception("ALUNO NAO CADASTRADO.");
        }

        if (!planos.Contains(plano))
        {
            throw new Exception("PLANO NAO ATIVO.");
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

    public List<Plano> ListarPlanos()
    {
        return new List<Plano>(planos);
    }

    public List<PersonalTrainer> ListarPersonalTrainers()
    {
        return new List<PersonalTrainer>(personalTrainers);
    }

    public List<Matricula> ListarMatriculas()
    {
        return new List<Matricula>(matriculas);
    }
}

public class Program
{
    public static void Main()
    {
        Academia academia = new Academia();

        Aluno aluno1 = new Aluno("Ryan", "123.169.426-48", 40.5m);

        Aluno aluno2 = new Aluno("Lukas", "123.168.423-48", 50.5m);

        Plano planoMensal = new Plano("Mensal", 100.00m);

        Plano planoAnual = new Plano("Anual", 900.00m);

        academia.CadastrarAluno(aluno1);
        academia.CadastrarAluno(aluno2);

        academia.CadastrarPlano(planoMensal);
        academia.CadastrarPlano(planoAnual);

        Matricula matricula1 = academia.MatricularAluno(aluno1, planoMensal, DateTime.Now);

        Matricula matricula2 = academia.MatricularAluno( aluno2, planoAnual, DateTime.Now);

        PersonalTrainer personalTrainer =new PersonalTrainer( "Rogerio", "123.169.429-48");

        academia.CadastrarPersonalTrainer(personalTrainer);

        Console.WriteLine("--- ALUNOS CADASTRADOS ---");

        List<Aluno> alunos = academia.ListarAlunos();

        foreach (Aluno aluno in alunos)
        {
            Console.WriteLine("Nome: " + aluno.Nome + " - CPF: " + aluno.Cpf + " - Peso: " + aluno.Peso + " kg");
        }

        Console.WriteLine();
        Console.WriteLine("--- MATRÍCULAS ---");

        List<Matricula> matriculas =
            academia.ListarMatriculas();

        foreach (Matricula matricula in matriculas)
        {
            Console.WriteLine("Aluno: " + matricula.Aluno.Nome + " - Plano: " + matricula.Plano.Nome);
        }
    }
}
