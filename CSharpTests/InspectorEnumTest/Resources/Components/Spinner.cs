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


public enum TestEnum
{
    ZERO,
    ONE,
    TWO,
    THREE,
    FIVE = 5,
    SIX,
    EIGHT = 8
}


public class Spinner : CSComponent
{

    [Inspector]
    float speed = 1.0f;

    /// <summary>
    ///  This is set to emissive in the scene component xml
    /// </summary>
    [Inspector]
    private TextureUnit textureUnitTest = TextureUnit.TU_SPECULAR;

    [Inspector]
    private TestEnum textureEnumUnitialized;

    // set in editor to 8
    [Inspector]
    private TestEnum textureEnumSetToEight;

    [Inspector]
    private TestEnum textureEnumZero = TestEnum.ZERO;

    [Inspector]
    private TestEnum textureEnumOne = TestEnum.ONE;

    [Inspector]
    private TestEnum textureEnumTwo = TestEnum.TWO;

    [Inspector]
    private TestEnum textureEnumThree = TestEnum.THREE;

    [Inspector]
    private TestEnum textureEnumFive = TestEnum.FIVE;

    [Inspector]
    private TestEnum textureEnumSix = TestEnum.SIX;

    [Inspector]
    private TestEnum textureEnumEight = TestEnum.EIGHT;


    [Inspector]
    private TextureUnit textureUnit0 = TextureUnit.TU_DIFFUSE;

    [Inspector]
    private TextureUnit textureUnit1 = TextureUnit.TU_NORMAL;

    [Inspector]
    private TextureUnit textureUnit2 = TextureUnit.TU_SPECULAR;

    [Inspector]
    private TextureUnit textureUnit3 = TextureUnit.TU_EMISSIVE;

    [Inspector]
    private TextureUnit textureUnit4 = TextureUnit.TU_ENVIRONMENT;

    [Inspector]
    private TextureUnit textureUnit5 = TextureUnit.MAX_MATERIAL_TEXTURE_UNITS;

    [Inspector]
    private TextureUnit textureUnit6 = TextureUnit.TU_LIGHTSHAPE;

    [Inspector]
    private TextureUnit textureUnit7 = TextureUnit.TU_SHADOWMAP;

    [Inspector]
    private TextureUnit textureUnit8 = TextureUnit.MAX_TEXTURE_UNITS;

    void Start()
    {

        // default should be TestEnum.Zero
        if (textureEnumUnitialized != TestEnum.ZERO)
        {
            throw new System.InvalidOperationException("textureEnumUnitialized != TestEnum.ZERO");
        }

        // set to eight in scene file
        if (textureEnumSetToEight != TestEnum.EIGHT)
        {
            throw new System.InvalidOperationException("textureEnumUnitialized !=TestEnum.ZERO");
        }

        if (textureEnumZero != TestEnum.ZERO)
        {
            throw new System.InvalidOperationException("textureEnumZero != TestEnum.ZERO");
        }

        if (textureEnumOne != TestEnum.ONE)
        {
            throw new System.InvalidOperationException("textureEnumOne != TestEnum.ONE");
        }

        if (textureEnumTwo != TestEnum.TWO)
        {
            throw new System.InvalidOperationException("textureEnumTwo != TestEnum.TWO");
        }

        if (textureEnumThree != TestEnum.THREE)
        {
            throw new System.InvalidOperationException("textureEnumThree != TestEnum.THREE");
        }

        if (textureEnumFive != TestEnum.FIVE)
        {
            throw new System.InvalidOperationException("textureEnumFive != TestEnum.FIVE");
        }

        if (textureEnumSix != TestEnum.SIX)
        {
            throw new System.InvalidOperationException("textureEnumSix != TestEnum.SIX");
        }

        if (textureEnumEight != TestEnum.EIGHT)
        {
            throw new System.InvalidOperationException("textureEnumEight != TestEnum.EIGHT");
        }

        // default as TU_SPECULAR, set in scene file to TU_EMISSIVE
        if (textureUnitTest != TextureUnit.TU_EMISSIVE)
        {
            throw new System.InvalidOperationException("textureUnitTest != TextureUnit.TU_EMISSIVE");
        }

        if (textureUnit0 != TextureUnit.TU_DIFFUSE)
        {
            throw new System.InvalidOperationException("textureUnit0 != TextureUnit.TU_DIFFUSE");
        }

        if (textureUnit1 != TextureUnit.TU_NORMAL)
        {
            throw new System.InvalidOperationException("textureUnit1 != TextureUnit.TU_NORMAL");
        }

        if (textureUnit2 != TextureUnit.TU_SPECULAR)
        {
            throw new System.InvalidOperationException("textureUnit2 != TextureUnit.TU_SPECULAR");
        }

        if (textureUnit3 != TextureUnit.TU_EMISSIVE)
        {
            throw new System.InvalidOperationException("textureUnit3 != TextureUnit.TU_EMISSIVE");
        }

        if (textureUnit4 != TextureUnit.TU_ENVIRONMENT)
        {
            throw new System.InvalidOperationException("textureUnit4 != TextureUnit.TU_ENVIRONMENT");
        }

        if (textureUnit5 != TextureUnit.MAX_MATERIAL_TEXTURE_UNITS)
        {
            throw new System.InvalidOperationException("textureUnit5 != TextureUnit.MAX_MATERIAL_TEXTURE_UNITS");
        }

        if (textureUnit6 != TextureUnit.TU_LIGHTSHAPE)
        {
            throw new System.InvalidOperationException("textureUnit6 != TextureUnit.TU_LIGHTSHAPE");
        }

        if (textureUnit7 != TextureUnit.TU_SHADOWMAP)
        {
            throw new System.InvalidOperationException("textureUnit7 != TextureUnit.TU_SHADOWMAP");
        }

        if (textureUnit8 != TextureUnit.MAX_TEXTURE_UNITS)
        {
            throw new System.InvalidOperationException("textureUnit8 != TextureUnit.MAX_TEXTURE_UNITS");
        }
    }

    void Update(float timeStep)
    {

    }

}
