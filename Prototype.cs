public class Prototype
{
    public Prototype()
    {
        
    }

    public void Iniciar()
    {
        Costumer Costumer1 = new() { Name = "C1" };
        Costumer Costumer2 = Costumer1;
        Costumer2.Name = "C2";

        Console.WriteLine($"Costumer 1 (Original):    {Costumer1.Name}"); // SAÍDA:  C2
        Console.WriteLine($"Costumer 2 (ShallowCopy): {Costumer2.Name}"); // SAÍDA:  C2

        CostumerPrototype CostumerPrototype1 = new() 
        { 
            Name = "CP1", 
            Address = new Address { City = "City CP1" }    
        };
        CostumerPrototype CostumerPrototype2 = (CostumerPrototype)CostumerPrototype1.Clone();   
        CostumerPrototype2.Name = "CP2";   
        CostumerPrototype2.Address.City = "City CP2";   

        CostumerPrototype CostumerPrototype3 = CostumerPrototype1.DeepCloneClass();
        CostumerPrototype3.Name = "CP3";
        CostumerPrototype3.Address.City = "City CP3";

        CostumerPrototype CostumerPrototype4 = CostumerPrototype1.DeepCloneJson();
        CostumerPrototype4.Name = "CP4";
        CostumerPrototype4.Address.City = "City CP4";

        Console.WriteLine($"Costumer Prototype 1 (Original):         {CostumerPrototype1.Name}, {CostumerPrototype1.Address.City}"); // SAÍDA:  CP1, City CP2
        Console.WriteLine($"Costumer Prototype 2 (MemberwiseClone):  {CostumerPrototype2.Name}, {CostumerPrototype2.Address.City}"); // SAÍDA:  CP2, City CP2
        Console.WriteLine($"Costumer Prototype 3 (ClassInstance):    {CostumerPrototype3.Name}, {CostumerPrototype3.Address.City}"); // SAÍDA:  CP3, City CP3
        Console.WriteLine($"Costumer Prototype 4 (SerializeJson):    {CostumerPrototype4.Name}, {CostumerPrototype4.Address.City}"); // SAÍDA:  CP4, City CP4
    }
}
