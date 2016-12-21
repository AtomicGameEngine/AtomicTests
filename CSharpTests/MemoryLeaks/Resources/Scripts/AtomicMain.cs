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

        CreateSceneLoadButton("Empty");
        CreateSceneLoadButton("Scene");

        //AtomicNET.GetSubsystem<Player>().LoadScene("Scenes/Scene.scene");
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
                //view.Remove();
                if (currentScene != null)
                {
                    currentScene.RemoveAllChildren();
                }
                currentScene = null;
                GetSubsystem<ResourceCache>().ReleaseAllResources(true);
                System.GC.Collect();

                currentScene = AtomicNET.GetSubsystem<Player>().LoadScene("Scenes/"+ sceneName + ".scene");
            }
        });

        layout.AddChild(emptyButton);
    }
}
