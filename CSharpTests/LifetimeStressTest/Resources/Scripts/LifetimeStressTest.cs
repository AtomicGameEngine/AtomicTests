
using System;
using System.Collections.Generic;
using AtomicEngine;
using AtomicPlayer;


class LifetimeStressTest : NETScriptObject
{
    public LifetimeStressTest(bool testTearDown = false)
    {
        teardown = testTearDown;

        SubscribeToEvent<UpdateEvent>(this.Update);

        switchScene();

#if DEBUG
        Log.Warn("This stress test instantiates many objects, and tests lifetime issues, running in Release build for managed and native is recommended");
#endif                
    }

    float cycleDelta = 0.0f;

    // 2 second cycle time
    static readonly float CYCLE_TIME = 0.5f;
    static readonly Random random = new Random();

    static bool teardown = false;

    void Update(UpdateEvent ev)
    {
        cycleDelta -= ev.TimeStep;

        if (cycleDelta <= 0.0f)
        {
            cycleDelta = CYCLE_TIME;

            if (!teardown)
                RunCycle();
        }

        switchTime -= ev.TimeStep;

        if (switchTime <= 0.0f)
        {
            switchTime = 10.0f;

            switchScene();
        }
    }

    List<Scene> scenes = new List<Scene>();

    static bool unloadAllScenesOnCycle = false;

    void RunCycle()
    {
        Log.Info("LifetimeStressTest: Running Cycle");

        var scene = new Scene();
        scenes.Add(scene);

        scene.CreateComponent<Octree>();

        List<Node> nodes = new List<Node>();

        var rootNode = scene.CreateChild("RootNode");

        nodes.Add(rootNode);
        
        // 2k nodes with prefabs loaded
        for (int i = 0; i < 2048; i++)
        {
            var parent = nodes[random.Next(nodes.Count)];

            var node = parent.CreateChild("Node " + i);

            var prefabLoader = node.CreateComponent<PrefabLoader>();

            prefabLoader.prefabPath = random.Next(2) > 0 ? "Prefabs/Crate.prefab" : "Prefabs/Chest.prefab";
        }

        // 16k empty nodes
        for (int i = 0; i < 16384; i++)
        {
            var parent = nodes[random.Next(nodes.Count)];

            var node = parent.CreateChild("Node " + i);
        }

        if (scenes.Count >= 10)
        {
            var metrics = GetSubsystem<Metrics>();

            // remove up to 10 scenes
            var numScenes = random.Next(10) + 1;

            if (unloadAllScenesOnCycle)
                numScenes = scenes.Count;

            var msg = "LifetimeStressTest: Removing " + numScenes + " scenes";

            if (metrics.Enabled)
                msg += ", and waiting for Metrics to catch up, consider disabling for stress test";

            Log.Info(msg);

            for (int i = 0; i < numScenes; i++)
            {
                scene = scenes[random.Next(scenes.Count)];

                // Randomly destroy some children
                var children = new Vector<Node>();
                scene.GetChildren(children, true);

                for (int j = 0; j < 200; j++)
                {
                    var child = children[random.Next(children.Count)];
                    child.Destroy();

                }

                children.Clear();
                scenes.Remove(scene);
                scene.Destroy();
            }

            // unload resources from cache
            GetSubsystem<ResourceCache>().ReleaseAllResources(false);


            Log.Info(numScenes + "Scenes Destroyed");
        

        }        
    }

    void switchScene()
    {
        var player = GetSubsystem<Player>();

        player.UnloadAllScenes();
        scene = null;

        // unload resources from cache
        GetSubsystem<ResourceCache>().ReleaseAllResources(false);

        string sceneName = loadScenes[currentScene++];

        if (!string.IsNullOrEmpty(sceneName))
        {
            scene = player.LoadScene("Scenes/" + sceneName + ".scene");
        }

        currentScene %= loadScenes.Length;

    }

    // scene switch time in seconds
    float switchTime = 5.0f;

    int currentScene = 0;
    string[] loadScenes = { "", "Scene", "", "Scene2" };
    Scene scene;


}