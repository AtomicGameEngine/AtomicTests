using System;
using AtomicEngine;

public class Spinner : CSComponent
{

    [Inspector]
    float speed = 1.0f;

    void Start()
    {
    }

    void Update(float timeStep)
    {
        Node.Yaw(speed * timeStep * 75.0f);
    }

}
