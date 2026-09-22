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
    
}

public class Matricula
{
    //talvez eu seja burro senhor
}*/

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
    //favor ver depois, nao vai dar de fazer essa parte ainda
}
