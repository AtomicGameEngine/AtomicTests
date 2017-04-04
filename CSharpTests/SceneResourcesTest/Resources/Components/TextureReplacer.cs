using System;

using AtomicEngine;

public class TextureReplacer : CSComponent
{
    [Inspector]
    private string texturePath;

    [Inspector]
    private bool instanceMaterial;

    public void Start()
    {
        if (!string.IsNullOrEmpty(texturePath))
        {
            ReplaceTexture();
        }
    }

    private void ReplaceTexture()
    {
        StaticModel model = Node.GetComponent<StaticModel>(true);
        if (model != null)
        {
            ResourceCache cache = GetSubsystem<ResourceCache>();
            Texture2D texture = cache.GetResource<Texture2D>(texturePath);
            Material material = model.GetMaterial(0);
            if (texture != null && material != null)
            {
                if (instanceMaterial)
                {
                    Material materialClone = material.Clone();
                    model.SetMaterial(0, materialClone);
                    material = materialClone;
                }

                material.SetTexture(TextureUnit.TU_DIFFUSE, texture);
            }
        }
    }
}
