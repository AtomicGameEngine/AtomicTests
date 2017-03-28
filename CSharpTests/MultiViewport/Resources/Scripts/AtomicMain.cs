using AtomicEngine;
using AtomicPlayer;

public class AtomicMain : AppDelegate
{
    private UIView[] views;
    private UIFontDescription fontDescription = new UIFontDescription()
    {
        Size = 22,
        Id = "Anonymous Pro"
    };

    public override void Start()
    {
        Scene scene = AtomicNET.GetSubsystem<Player>().LoadScene("Scenes/Scene.scene");

        Vector<Camera> cameras = new Vector<Camera>();
        scene.GetComponents(cameras, true);

        Graphics graphics = GetSubsystem<Graphics>();
        Renderer renderer = GetSubsystem<Renderer>();
        int numCameras = cameras.Count;
        views = new UIView[numCameras];
        renderer.SetNumViewports((uint)numCameras);
        int viewportWidth = graphics.Width / numCameras;
        for (int i = 0; i < numCameras; ++i)
        {
            Viewport viewport = new Viewport(scene, cameras[i]);
            viewport.Rect = new IntRect(
                i * viewportWidth, 0,
                (i+1) * viewportWidth, graphics.Height);
            renderer.SetViewport((uint)i, viewport);

            UIView view = new UIView();
            UILayout layout = new UILayout()
            {
                LayoutPosition = UI_LAYOUT_POSITION.UI_LAYOUT_POSITION_RIGHT_BOTTOM,
                //LayoutPosition = UI_LAYOUT_POSITION.UI_LAYOUT_POSITION_GRAVITY,
                //Gravity = UI_GRAVITY.UI_GRAVITY_LEFT,
                Rect = viewport.Rect
            };
            layout.AddChild(new UITextField()
            {
                FontDescription = fontDescription,
                Text = cameras[i].Node.Name
            });
            view.AddChild(layout);
            views[i] = view;
        }
    }

}
