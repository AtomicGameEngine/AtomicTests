using System;
using AtomicEngine;
using AtomicPlayer;

public class Spinner : CSComponent
{

    [Inspector]
    float speed = 1.0f;

    float timer = 0.0f;

    uint checkFrames = 0;

    Drawable drawable;

    void Start()
    {
        // grab drawable off node
        drawable = GetComponent<StaticModel>();

        if (drawable == null)
        {
            throw new Exception("Need a static model");
        }
    }

    void Update(float timeStep)
    {
        // get the player viewport (this can be any viewport)
        var viewport = GetSubsystem<Player>().Viewport;

        var camera = viewport.Camera;

        var cameraSpeed = 10.0f;

        var intersect = camera.Frustum.IsInside(drawable.WorldBoundingBox);

        if (intersect == Intersection.OUTSIDE)
            cameraSpeed *= 4;

        Node.Yaw(speed * timeStep * speed * 75.0f);

        camera.Node.Yaw(-cameraSpeed * timeStep * cameraSpeed);

        timer += timeStep;

        // check that defining Frustum has same result (minus a little floating point drift)

        var checkFrustum = new Frustum();

        checkFrustum.Define(camera.Fov, camera.AspectRatio, camera.Zoom, camera.NearClip, camera.FarClip, camera.Node.WorldPosition, camera.Node.WorldRotation);

        var checkIntersect = checkFrustum.IsInside(drawable.WorldBoundingBox);

        if (checkIntersect != intersect)
        {
            checkFrames++;
        }
        else
        {
            if (checkFrames > 3)
            {
                throw new Exception("Camera frustum and calculated disagreed for more than 3 frames");
            }

            checkFrames = 0;
        }

        if (timer > 0.15f)
        {
            Log.Info(intersect.ToString());
            timer = 0.0f;
        }

    }

}
