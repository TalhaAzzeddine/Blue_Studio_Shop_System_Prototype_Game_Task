using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClothSectionButtonUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_ClothSectionText;

    public void SetClothSectionText(string name)
    {
        m_ClothSectionText.text = name;
    }
}
