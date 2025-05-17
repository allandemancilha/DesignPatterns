using System.Text.Json;
public class CostumerPrototype : Costumer, ICloneable
{
    public object Clone()
    {
        // O MÉTODO MemberwiseClone() FUNCIONA APENAS PARA TIPOS PRIMITIVOS
        return MemberwiseClone();
    }

    public CostumerPrototype DeepCloneClass()
    {
        var costumerPrototype = new CostumerPrototype
        {
            Name = this.Name,
            Address = new Address 
            {   
                City = this.Address?.City 
            }
        };

        return costumerPrototype;
    }

    public CostumerPrototype DeepCloneJson()
    {
        var costumerPrototypeJson = JsonSerializer.Serialize(this);
        return JsonSerializer.Deserialize<CostumerPrototype>(costumerPrototypeJson) ?? new CostumerPrototype();
    }
   
}