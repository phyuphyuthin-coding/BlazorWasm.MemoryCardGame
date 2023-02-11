namespace BlazorWasmMemoryCardGame.Models;

public class MemoryCardGameModel
{
    public MemoryCardGameModel(){}
    public MemoryCardGameModel(string name, string image)
    {
        this.name = name;
        this.image = image;
    }
    public string name { get; set; }
    public string image { get; set; }
}