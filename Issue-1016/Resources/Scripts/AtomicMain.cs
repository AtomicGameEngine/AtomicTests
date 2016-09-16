using System;
using AtomicEngine;
using AtomicPlayer;

public class AtomicMain : AppDelegate
{
    public override void Start()
    {
        var scene = AtomicNET.GetSubsystem<Player>().LoadScene("Scenes/Scene.scene");

        var node = scene.GetChild("TestNode", true);

        Vector<MyComponent> destVector = new Vector<MyComponent>();
        node.GetCSComponents<MyComponent>(destVector, true);

        if (destVector.Count != 1)
        {
            throw new InvalidOperationException("Couldn't get MyComponent");
        }

        foreach (var c in destVector)
        {
                
            if (c.GetType().Name != "MyComponent" || c.TypeName != "MyComponent")
            {
                throw new InvalidOperationException("TypeName != MyComponent");
            }
            
        }

    }

}
