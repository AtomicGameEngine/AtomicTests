using System;
using AtomicEngine;
using AtomicPlayer;


public enum TextureUnit
{
    TU_DIFFUSE = AtomicEngine.TextureUnit.TU_DIFFUSE,
    TU_NORMAL = AtomicEngine.TextureUnit.TU_NORMAL,
    TU_SPECULAR = AtomicEngine.TextureUnit.TU_SPECULAR,
    TU_EMISSIVE = AtomicEngine.TextureUnit.TU_EMISSIVE,
    TU_ENVIRONMENT = AtomicEngine.TextureUnit.TU_ENVIRONMENT,
    MAX_MATERIAL_TEXTURE_UNITS = AtomicEngine.TextureUnit.MAX_MATERIAL_TEXTURE_UNITS,
    TU_LIGHTSHAPE = AtomicEngine.TextureUnit.TU_LIGHTSHAPE,
    TU_SHADOWMAP = AtomicEngine.TextureUnit.TU_SHADOWMAP,
    MAX_TEXTURE_UNITS = AtomicEngine.TextureUnit.MAX_TEXTURE_UNITS
}

public class Spinner : CSComponent
{

    [Inspector]
    float speed = 1.0f;

    [Inspector]
    private TextureUnit textureUnit = TextureUnit.TU_DIFFUSE;


    void Start()
    {

    }

    void Update(float timeStep)
    {

    }

}
