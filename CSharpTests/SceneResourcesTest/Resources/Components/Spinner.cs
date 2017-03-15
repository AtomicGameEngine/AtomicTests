using System;
using AtomicEngine;

public class Spinner : CSComponent
{

    [Inspector]
    float speed = 1.0f;

    Node node;

    void Start()
    {
        // store a local reference to Node, otherwise C# wrapper around native instance created and GC'd
        // when running GC aggressively, this causes a bunch of ScriptVectors to be created for return values
        // in instance
        node = Node;
    }

    void Update(float timeStep)
    {
        node.Yaw(speed * timeStep * 75.0f);
    }

}
