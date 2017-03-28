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
                // NOTE: enums should be renamed, for example UI_LAYOUT_POSITION.RIGHT_BUTTON 

                // See for a layout cheatsheet: https://github.com/AtomicGameEngine/AtomicGameEngine/wiki/Turbobadger-Layout-Cheat-Sheet

                // Specifies which y position widgets in a AXIS_X layout should have, or which x position widgets in a AXIS_Y layout should have.
                LayoutPosition = UI_LAYOUT_POSITION.UI_LAYOUT_POSITION_RIGHT_BOTTOM,

                // Specifies how widgets should be moved horizontally in a AXIS_X layout(or vertically in a AXIS_Y layout) if there is extra space available.
                LayoutDistributionPosition = UI_LAYOUT_DISTRIBUTION_POSITION.UI_LAYOUT_DISTRIBUTION_POSITION_RIGHT_BOTTOM,
            
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
