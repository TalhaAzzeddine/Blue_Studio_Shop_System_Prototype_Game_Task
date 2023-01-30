using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClothCategory
{
    Apperance,
    Equipment
}

public enum ClothTypeEnum
{
    Hair,
    FacialHair,
    Ears,
    Eyebrows,
    Eyes,
    Iris,
    Mouth,
    Makeup,
    Headwear,
    Top,
    TopOverlay,
    Belt,
    Pants,
    Handwear,
    Shoes,
    Glasses,
    Shoulders

}


[System.Serializable]
public class ClothType
{
    public ClothTypeEnum ClothTypeValue;

    [Tooltip("List of clothes of that cloth type")]
    public List<ClothScriptableObject> ClothesList;
    public ClothCategory ClothCategory;


}

[CreateAssetMenu(fileName = "Clothes Types", menuName = "Clothes Shop System/Cloth Types")]
public class ClothesTypes : ScriptableObject
{
    public List<ClothType> ClothTypesList;

}
