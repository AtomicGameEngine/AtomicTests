using System.Diagnostics;

using AtomicEngine;
using AtomicPlayer;

using ExternalDll;

public class AtomicMain : AppDelegate
{
    public override void Start()
    {
        var assembly = AtomicNET.GetSubsystem<ResourceCache>().GetResource<CSComponentAssembly>("ExternalDll.dll");
        Assert(assembly != null, "Could not load External.dll");

        Scene scene = AtomicNET.GetSubsystem<Player>().LoadScene("Scenes/Scene.scene");

        // Test the ability to get instances of components from default and external dlls
        // using various Node methods
        var defaultDllComponent = scene.GetCSComponent<DefaultDllComponent>(true);
        Assert(defaultDllComponent != null, "Could not get DefaultDllComponent with GetCSComponent");
        var defaultDllDerivedComponent = scene.GetCSComponent<DefaultDllDerivedComponent>(true);
        Assert(defaultDllComponent != null, "Could not get DefaultDllDerivedComponent with GetCSComponent");
        var defaultDllComponents = new Vector<DefaultDllComponent>();
        scene.GetDerivedCSComponents(defaultDllComponents, true);
        Assert(defaultDllComponents.Count >= 2, "Could not get all DefaultDllComponents with GetDerivedCSComponents");

        var externalDllComponent = scene.GetCSComponent<ExternalDllComponent>(true);
        Assert(externalDllComponent != null, "Could not get ExternalDllComponent with GetCSComponent");
        var externalDllDerivedComponent = scene.GetCSComponent<ExternalDllDerivedComponent>(true);
        Assert(externalDllDerivedComponent != null, "Could not get ExternalDllDerivedComponent with GetCSComponent");
        var externalDllComponents = new Vector<ExternalDllComponent>();
        scene.GetDerivedCSComponents(externalDllComponents, true);
        Assert(externalDllComponents.Count >= 2, "Could not get all ExternalDllComponents with GetDerivedCSComponents");
    }

    private static void Assert(bool test, string message)
    {
        if (!test)
        {
            Log.Write(Constants.LOG_ERROR, message);
            Debug.Assert(test, message); // for debug break
        }
    }

}
