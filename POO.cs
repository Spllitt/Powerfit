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
    
    public Plano(decimal mensal, decimal trimensal, decimal anual)
    {
        this.mensal = mensal;
        this.trimensal = trimensal;
        this.anual = anual;
    }
    
}