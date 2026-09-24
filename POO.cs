using System;

public class Aluno
{
    private string nome {get; private set;}
    private string cpf {get; private set;}
    private decimal peso {get; private set;}

    public Aluno(string Nome, string CPF, decimal Peso)
    {
        nome = Nome;
        cpf = CPF;
        peso = Peso;
    }

}

/*public class PersonalTrainer
{
    
}*/

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
    private decimal mensal {get; private set;}
    private decimal trimensal {get; private set;}
    private decimal anual {get; private set;}

    public Plano(decimal mensal, decimal trimensal, decimal anual)
    {
        this.mensal = mensal;
        this.trimensal = trimensal;
        this.anual = anual;
    }
    
}
