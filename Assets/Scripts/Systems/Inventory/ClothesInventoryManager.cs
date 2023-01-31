using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClothesInventoryManager : MonoBehaviour
{
    [SerializeField]
    private List<ClothCardUI> playerClothCards = new List<ClothCardUI>();
    [SerializeField] private GameObject m_CardClothPrefab;
    [Space(10)]
    [SerializeField] private TextMeshProUGUI m_ActiveListText;
    [Space(10)]
    [SerializeField] private Transform m_ClothesCardParent;
    [Space(10)]
    [SerializeField] private GameObject[] m_playerSides;

    private void OnEnable()
    {
        InitApperanceClothesData();
    }

    public void InitApperanceClothesData()
    {
        if (m_ClothesCardParent.childCount > 0)
            ClearCards();

        // Init Cloth Card Of this Section
        foreach (var Cloth in playerClothCards)
        {
            if (Cloth.CardClothCategory == ClothCategory.Equipment)
                continue;
            GameObject clothPrefabCard = Instantiate(m_CardClothPrefab, m_ClothesCardParent);
            clothPrefabCard.transform.SetParent(m_ClothesCardParent);

            ClothCardUI clothCardUI = clothPrefabCard.GetComponent<ClothCardUI>();

            clothCardUI.ConfigurateClothCard(Cloth.GetAllClothSideSprites(), Cloth.Price, Cloth.CardClothType, Cloth.CardClothCategory, true);
            clothCardUI.ToggleCardClothEquipeState(clothCardUI.IsEquiped);
        }

        m_ActiveListText.text = ClothCategory.Apperance.ToString();
    }

    public void InitEquipmentClothesData()
    {
        if (m_ClothesCardParent.childCount > 0)
            ClearCards();
        // Init Cloth Card Of this Section
        foreach (var Cloth in playerClothCards)
        {
            if (Cloth.CardClothCategory == ClothCategory.Apperance)
                continue;

            GameObject clothPrefabCard = Instantiate(m_CardClothPrefab, m_ClothesCardParent);
            clothPrefabCard.transform.SetParent(m_ClothesCardParent);

            ClothCardUI clothCardUI = clothPrefabCard.GetComponent<ClothCardUI>();

            clothCardUI.ConfigurateClothCard(Cloth.GetAllClothSideSprites(), Cloth.Price, Cloth.CardClothType, Cloth.CardClothCategory, true);

            clothCardUI.ToggleCardClothEquipeState(clothCardUI.IsEquiped);
        }

        m_ActiveListText.text = ClothCategory.Equipment.ToString();

    }

    private void ClearCards()
    {
        for (int i = 0; i < m_ClothesCardParent.childCount; i++)
        {
            m_ClothesCardParent.GetChild(i).gameObject.SetActive(false);
            Destroy(m_ClothesCardParent.GetChild(i).gameObject);
        }
    }


    public List<string> GetCardsClothesId()
    {
        var cardIds = new List<string>();

        foreach (var cardsCloth in playerClothCards)
        {
            cardIds.Add(cardsCloth.CardId);
        }

        return cardIds;
    }

    public void AddClothesToInventory(ClothCardUI clothCard)
    {
        playerClothCards.Add(clothCard);
    }

    public void RemoveClothesCardFromInventory(ClothCardUI removedclothCardUI)
    {
        foreach (var clothcard in playerClothCards)
        {
            if (clothcard.CardId.Equals(removedclothCardUI.CardId))
            {
                playerClothCards.Remove(clothcard);
                break;
            }
        }


    }

    public void TurnPlayerAround(int index)
    {
        foreach (var side in m_playerSides)
        {
            if (side.activeInHierarchy)
            {
                side.SetActive(false);
                break;
            }


        }



        if (index == m_playerSides.Length)
        {
            foreach (var side in m_playerSides)
            {
                if (side.activeInHierarchy)
                    side.SetActive(false);



            }
            m_playerSides[index].transform.localScale = new Vector3(-1f, 1f, 1f);
            m_playerSides[index - 1].SetActive(true);
        }
        else
            m_playerSides[index].SetActive(true);

    }

}
