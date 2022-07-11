namespace LabManager.Models;

class Lab{
    public int Id {get; set;}
    public string Number { get; set; }
    public string Name { get; set; }
    public string Block { get; set; }

    public Lab()
    {
        
    }
    public Lab(int id, string number, string name, String block)
    {
        Id = id;
        Number = number;
        Name = name;
        Block = block;
    }
}
