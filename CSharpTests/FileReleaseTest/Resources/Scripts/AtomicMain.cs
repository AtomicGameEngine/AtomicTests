using System;
using System.IO;

using AtomicEngine;
using AtomicPlayer;

public class AtomicMain : AppDelegate
{
    float loadFileTime = 5;

    public override void Start()
    {
        AtomicNET.GetSubsystem<Player>().LoadScene("Scenes/Scene.scene");

        // set up the DebugHud to show metrics and update at 10hz
        var ui = GetSubsystem<UI>();
        ui.SetDebugHudProfileMode(DebugHudProfileMode.DEBUG_HUD_PROFILE_METRICS);
        ui.ShowDebugHud(true);
        ui.DebugHudRefreshInterval = 0.1f;

        SubscribeToEvent<UpdateEvent>(e =>
        {

            loadFileTime -= e.TimeStep;
            if (loadFileTime <= 0.0f)
            {
                loadFileTime = 10.0f;

                LoadFile();
            }
        });
    }

    private static void LoadFile()
    {
        ResourceCache cache = AtomicNET.GetSubsystem<ResourceCache>();
        using (Stream stream = cache.GetFileStream("Test.txt"))
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                string str = reader.ReadToEnd();
                Log.Debug(str);
            }
        }
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}
