using System;
using AtomicEngine;
using AtomicPlayer;

public class AtomicMain : AppDelegate
{
    // scene switch time in seconds
    float switchTime = 2.0f;

    int currentScene = 0;
    string[] scenes = { "Scene", "Scene2", "EmptyScene" };

    public override void Start()
    {
        var ui = GetSubsystem<UI>();

        // set up the DebugHud to show metrics and update at 10hz
        ui.SetDebugHudProfileMode(DebugHudProfileMode.DEBUG_HUD_PROFILE_METRICS);
        ui.ShowDebugHud(true);
        ui.DebugHudRefreshInterval = 0.1f;

        switchScene();

        SubscribeToEvent<UpdateEvent>(e =>
        {

            switchTime -= e.TimeStep;

            if (switchTime <= 0.0f)
            {
                switchTime = 5.0f;

                switchScene();
            }

        });
    }

    void switchScene()
    {
        var player = GetSubsystem<Player>();

        player.UnloadAllScenes();

        // unload resources from cache
        GetSubsystem<ResourceCache>().ReleaseAllResources(false);

        player.LoadScene("Scenes/" + scenes[currentScene++] + ".scene");

        currentScene %= scenes.Length;

    }

}
