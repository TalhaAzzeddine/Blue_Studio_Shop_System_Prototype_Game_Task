using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrancySystem : MonoBehaviour
{
    [SerializeField]
    private float Currancy = 0;

    public float PlayerCurrancy => Currancy;

    public void AddCurrancy(float currancy)
    {
        Currancy += currancy;
    }

    public void RemoveCurrancy(float currancy)
    {
        Currancy -= currancy;
    }

}
