using AtomicEngine;
using AtomicPlayer;

public class AtomicMain : AppDelegate
{
    public override void Start()
    {
        var scene = AtomicNET.GetSubsystem<Player>().LoadScene("Scenes/Scene.scene");
    }

}
