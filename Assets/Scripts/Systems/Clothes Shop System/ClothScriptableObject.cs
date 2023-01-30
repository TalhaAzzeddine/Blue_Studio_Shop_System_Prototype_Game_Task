using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cloth
{

    public ClothesTypes clothesType;

    [Range(0f, 99999f)]
    public float ClothPrice;

    [Tooltip("The Clothe Sprites Values ((Index 0)Front, (Index 1)Back, (Index 2)Side)) ")]
    public List<Sprite> ClothSprites;


}

[CreateAssetMenu(fileName = "Cloth", menuName = "Clothes Shop System/Cloth")]
public class ClothScriptableObject : ScriptableObject
{

    public List<Cloth> clothes;

}
