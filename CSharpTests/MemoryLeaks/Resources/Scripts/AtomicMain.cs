using AtomicEngine;
using AtomicPlayer;

public class AtomicMain : AppDelegate
{
    private UIView view;
    private UILayout layout;
    private UIFontDescription fontDescription;
    private Scene currentScene;

    public override void Start()
    {
        view = new UIView()
        {
            X = 0,
            Y = 0
        };

        fontDescription = new UIFontDescription()
        {
            Size = 22,
            Id = "Anonymous Pro"
        };

        layout = new UILayout()
        {
            Axis = UI_AXIS.UI_AXIS_Y,
            Rect = view.Rect,
            LayoutPosition = UI_LAYOUT_POSITION.UI_LAYOUT_POSITION_CENTER
        };

        view.AddChild(layout);

        CreateSceneLoadButton("Clear");
        CreateSceneLoadButton("Empty");
        CreateSceneLoadButton("Scene");

        // Setup debug hud to display metrics
        GetSubsystem<UI>().ShowDebugHud(true);
        GetSubsystem<UI>().SetDebugHudProfileMode(DebugHudProfileMode.DEBUG_HUD_PROFILE_METRICS);
    }

    private void CreateSceneLoadButton(string sceneName)
    {
        UIButton emptyButton = new UIButton()
        {
            Text = sceneName,
            FontDescription = fontDescription,
            Gravity = UI_GRAVITY.UI_GRAVITY_NONE
        };

        emptyButton.SubscribeToEvent<WidgetEvent>(emptyButton, (eventData) =>
        {
            if (eventData.Type == UI_EVENT_TYPE.UI_EVENT_TYPE_CLICK)
            {
                var player = AtomicNET.GetSubsystem<Player>();


                if (sceneName != "Clear")
                {
                    if (currentScene != null)
                    {
                        // This tests that CSComponents (and other components) and cleaned up when keeping scene, though removing all the nodes
                        currentScene.RemoveAllChildren();
                    }

                    currentScene = player.LoadScene("Scenes/" + sceneName + ".scene");
                    player.SetCurrentScene(currentScene);

                }
                else
                {
                    currentScene = null;
                    player.UnloadAllScenes();
                }

                GetSubsystem<ResourceCache>().ReleaseAllResources(true);

                System.GC.Collect();

            }
        });

        layout.AddChild(emptyButton);
    }
}
