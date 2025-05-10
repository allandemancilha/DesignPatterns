using System.Text.Json;

public class Address
{
    public string? City { get; set; }
}

public class Costumer
{
    public string? Name { get; set; }
    public Address Address { get; set; }
}


public class CostumerPrototype : Costumer, ICloneable
{
    public object Clone()
    {
        // O MÉTODO MemberwiseClone() FUNCIONA APENAS PARA TIPOS PRIMITIVOS
        return MemberwiseClone();
    }

    public object Clone(CostumerPrototype costumerPrototype)
    {
        costumerPrototype.Name = this.Name;
        costumerPrototype.Address = new Address
        {
            City = this.Address?.City
        };  

        return costumerPrototype;
    }

    public object CloneSerializeJson()
    {
          var costumerPrototypeJson = JsonSerializer.Serialize(this);
          return JsonSerializer.Deserialize<CostumerPrototype>(costumerPrototypeJson) ?? new CostumerPrototype();
    }
   
}

public class Program
{
    public static void Main(string[] args)
    {
        Costumer Costumer1 = new Costumer { Name = "C1" };
        Costumer Costumer2 = Costumer1;
        Costumer2.Name = "C2";

        Console.WriteLine($"Costumer 1 (Original):    {Costumer1.Name}"); // SAÍDA:  C2
        Console.WriteLine($"Costumer 2 (ShallowCopy): {Costumer2.Name}"); // SAÍDA:  C2

        CostumerPrototype CostumerPrototype1 = new CostumerPrototype 
        { 
            Name = "CP1", 
            Address = new Address { City = "City CP1" }    
        };
        CostumerPrototype CostumerPrototype2 = (CostumerPrototype)CostumerPrototype1.Clone();   
        CostumerPrototype2.Name = "CP2";   
        CostumerPrototype2.Address.City = "City CP2";   

        CostumerPrototype CostumerPrototype3 = (CostumerPrototype)CostumerPrototype1.Clone(new CostumerPrototype());
        CostumerPrototype3.Name = "CP3";
        CostumerPrototype3.Address.City = "City CP3";

        CostumerPrototype CostumerPrototype4 = (CostumerPrototype)CostumerPrototype1.CloneSerializeJson();
        CostumerPrototype4.Name = "CP4";
        CostumerPrototype4.Address.City = "City CP4";


        Console.WriteLine($"Costumer Prototype 1 (Original):        {CostumerPrototype1.Name}, {CostumerPrototype1.Address.City}"); // SAÍDA:  CP1, City CP2
        Console.WriteLine($"Costumer Prototype 2 (MemberwiseClone): {CostumerPrototype2.Name}, {CostumerPrototype2.Address.City}"); // SAÍDA:  CP2, City CP2
        Console.WriteLine($"Costumer Prototype 3 (Overloading):     {CostumerPrototype3.Name}, {CostumerPrototype3.Address.City}"); // SAÍDA:  CP3, City CP3
        Console.WriteLine($"Costumer Prototype 4 (SerializeJson):   {CostumerPrototype4.Name}, {CostumerPrototype4.Address.City}"); // SAÍDA:  CP4, City CP4
    }
}