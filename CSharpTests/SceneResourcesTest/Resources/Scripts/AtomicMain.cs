using System;
using AtomicEngine;
using AtomicPlayer;

public class AtomicMain : AppDelegate
{
    // scene switch time in seconds
    float switchTime = 2.0f;

    int currentScene = 0;
    string[] scenes = { "Scene", "Scene2", "EmptyScene", "" };
    Scene scene;

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
                switchTime = 10.0f;

                switchScene();
            }

        });
    }

    void switchScene()
    {
        var player = GetSubsystem<Player>();

        //scene = null; // uncomment for no leaks
        player.UnloadAllScenes();
        scene = null;

        // unload resources from cache
        GetSubsystem<ResourceCache>().ReleaseAllResources(false);

        string sceneName = scenes[currentScene++];

        if (!string.IsNullOrEmpty(sceneName))
            scene = player.LoadScene("Scenes/" + sceneName + ".scene");

        currentScene %= scenes.Length;

    }

}
