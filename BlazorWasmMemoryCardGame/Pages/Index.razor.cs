using BlazorWasmMemoryCardGame.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorWasmMemoryCardGame.Pages;

public partial class Index
{
    private bool startGame = false;

    private List<MemoryCardGameModel> lstMemoryCard = new List<MemoryCardGameModel>()
    {
        new MemoryCardGameModel(){},
        new MemoryCardGameModel() { name = "bee", image = "bee.png" },
        new MemoryCardGameModel() { name = "crocodile", image = "crocodile.png" },
        new MemoryCardGameModel() { name = "macaw", image = "macaw.png" },
        new MemoryCardGameModel() { name = "gorilla", image = "gorilla.png" },
        new MemoryCardGameModel() { name = "tiger", image = "tiger.png" },
        new MemoryCardGameModel() { name = "monkey", image = "monkey.png" },
        new MemoryCardGameModel() { name = "chameleon", image = "chameleon.png" },
        new MemoryCardGameModel() { name = "piranha", image = "piranha.png" },
        // new MemoryCardGameModel() { name = "anaconda", image = "anaconda.png" },
        // new MemoryCardGameModel() { name = "sloth", image = "sloth.png" },
        // new MemoryCardGameModel() { name = "cockatoo", image = "cockatoo.png" },
        // new MemoryCardGameModel() { name = "toucan", image = "toucan.png" },
        new MemoryCardGameModel() { name = "bee", image = "bee.png" },
        new MemoryCardGameModel() { name = "crocodile", image = "crocodile.png" },
        new MemoryCardGameModel() { name = "macaw", image = "macaw.png" },
        new MemoryCardGameModel() { name = "gorilla", image = "gorilla.png" },
        new MemoryCardGameModel() { name = "tiger", image = "tiger.png" },
        new MemoryCardGameModel() { name = "monkey", image = "monkey.png" },
        new MemoryCardGameModel() { name = "chameleon", image = "chameleon.png" },
        new MemoryCardGameModel() { name = "piranha", image = "piranha.png" }
        // new MemoryCardGameModel() { name = "anaconda", image = "anaconda.png" },
        // new MemoryCardGameModel() { name = "sloth", image = "sloth.png" },
        // new MemoryCardGameModel() { name = "cockatoo", image = "cockatoo.png" },
        // new MemoryCardGameModel() { name = "toucan", image = "toucan.png" }
        
    };

    private int[] intArr = new int[16];

    private ElementReference[] _elementReferences = new ElementReference[16+1];
    
    private DotNetObjectReference<Index>? objRef;

    protected override void OnInitialized()
    {
        objRef = DotNetObjectReference.Create(this);
    }

    [JSInvokable("stopGame")]
    public void StopGame()
    {
        startGame = false;
    } 

    void Start()
    {
        startGame = true;
        Random random = new Random();
        for (int i = 1; i <= 16; i++)
        {
            intArr[i - 1] = i;
        }
        intArr = intArr.OrderBy(x => random.Next()).ToArray();
    }

    async Task CardClick(int i, string name)
    {
        int cardCount = intArr.Length / 2;
        var element = _elementReferences[i];
        await _JsRuntime.InvokeVoidAsync("cardOnclick", element, name, cardCount, objRef);
    }
}