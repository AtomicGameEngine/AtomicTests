
using System;
using System.Collections.Generic;
using AtomicEngine;


class LifetimeStressTest : NETScriptObject
{
    public LifetimeStressTest()
    {
        SubscribeToEvent<UpdateEvent>(this.Update);

#if DEBUG
        Log.Warn("This stress test instantiates many objects, and tests lifetime issues, running in Release build for managed and native is recommended");
#endif                
    }

    float cycleDelta = 0.0f;

    // 2 second cycle time
    static readonly float CYCLE_TIME = 0.5f;
    static readonly Random random = new Random();

    void Update(UpdateEvent ev)
    {
        cycleDelta -= ev.TimeStep;

        if (cycleDelta <= 0.0f)
        {
            cycleDelta = CYCLE_TIME;

            RunCycle();
        }
        
    }

    List<Scene> scenes = new List<Scene>();

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

            var msg = "LifetimeStressTest: Removing " + numScenes + " scenes";

            if (metrics.Enabled)
                msg += ", and waiting for Metrics to catch up, consider disabling for stress test";

            Log.Info(msg);

            for (int i = 0; i < numScenes; i++)
            {
                scene = scenes[random.Next(scenes.Count)];
                scenes.Remove(scene);
                scene.Dispose();
            }
        }        
    }
}