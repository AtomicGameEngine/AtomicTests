using System.IO;

using AtomicEngine;

public class AtomicMain : AppDelegate
{
    LifetimeStressTest stressTest;

    public override void Start()
    {

        AddExternalResourcesPathToCache();

        var ui = GetSubsystem<UI>();

        // Metrics are very expensive for this stress test, only enable for verifying objects are being released
        var metricsEnabled = false;

        if (metricsEnabled)
        {
            // set up the DebugHud to show metrics and update at 10hz
            ui.SetDebugHudProfileMode(DebugHudProfileMode.DEBUG_HUD_PROFILE_METRICS);
            ui.ShowDebugHud(true);
            // only update metrics every 30 seconds
            ui.DebugHudRefreshInterval = 30.0f;
            GetSubsystem<Metrics>().Enable();
        }

        // the stress test can be run in "tear down" mode by passing true to constuctor
        // tear down mode is a sequential scene/resource load/unload test, without the GC/lifetime churn test
        stressTest = new LifetimeStressTest(false);

    }

    void AddExternalResourcesPathToCache()
    {
        ResourceCache cache = GetSubsystem<ResourceCache>();

        string mainScriptPath = cache.GetResourceFileName("Scripts/AtomicMain.cs");
        string externalResourcesDir = Path.GetDirectoryName(mainScriptPath);
        externalResourcesDir = Path.Combine(externalResourcesDir, "../../ExternalResources");

        cache.AddResourceDir(externalResourcesDir);
    }



}
