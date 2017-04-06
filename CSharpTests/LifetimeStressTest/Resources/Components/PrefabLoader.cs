using System;

using AtomicEngine;

public class PrefabLoader : CSComponent
{

    [Inspector]
    public string prefabPath;

    public void Start()
    {
        if (!string.IsNullOrEmpty(prefabPath))
        {
            LoadPrefab();
        }
    }

    private void LoadPrefab()
    {
        Node prefabNode = Node.CreateChild();
        PrefabComponent prefabComponent = prefabNode.CreateComponent<PrefabComponent>();
        prefabComponent.SetPrefabGUID(prefabPath);
    }
}
