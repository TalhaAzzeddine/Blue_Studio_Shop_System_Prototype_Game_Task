using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Build;
using UnityEngine;

[System.Serializable]
public class PlayerClothes
{
    public ClothTypeEnum ClothesTypes;
    public List<SpriteRenderer> _clothSpritesRenders = new List<SpriteRenderer>();


}

public class ClothShopManager : MonoBehaviour
{

    public static ClothShopManager Instance;


    [Space]
    [Header("Cloth UI Section")]
    [Space(10)]
    [SerializeField] private GameObject m_CardClothPrefab;
    [Space(10)]
    [SerializeField] private Transform m_ClothesCardParent;
    [Space(10)]
    [SerializeField] private TextMeshProUGUI m_PlayerCurrancyText;
    [Space(10)]
    [SerializeField] private string m_currancy;

    [Space]
    [Header("Cloths Data Section")]
    [Space(10)]
    [SerializeField] private ClothesTypes m_ClothTypes;
    [Space(10)]
    [SerializeField] private List<PlayerClothes> m_PlayerClothes;
    [Space(10)]
    [SerializeField] private GameObject[] m_playerSides;

    private List<Sprite> _currentBuySprites;



    [Space(10)]
    [Header("Player Currancy")]
    [Space(10)]
    [SerializeField] private PlayerCurrancySystem m_PlayerCurrancy;

    [Space(10)]
    [Header("Player Clothes Inventory")]
    [Space(10)]
    [SerializeField] private ClothesInventoryManager m_ClothesInventoryManager;



    private void Awake()
    {
        if (Instance)
            Destroy(Instance);
        Instance = this;
    }

    private void OnEnable()
    {
        m_PlayerCurrancyText.text = $"{m_PlayerCurrancy.PlayerCurrancy} {m_currancy}";

        InitApperanceClothesData();
    }

    public void InitApperanceClothesData()
    {
        if (m_ClothesCardParent.childCount > 0)
            ClearCards();

        // Init Cloth Card Of this Section
        foreach (var Cloth in m_ClothTypes.ClothTypesList)
        {
            if (Cloth.ClothCategory == ClothCategory.Equipment)
                continue;

            foreach (var clothItems in Cloth.ClothesList)
            {

                foreach (var clothItem in clothItems.clothes)
                {
                    GameObject clothPrefabCard = Instantiate(m_CardClothPrefab, m_ClothesCardParent);
                    clothPrefabCard.transform.SetParent(m_ClothesCardParent);

                    ClothCardUI clothCardUI = clothPrefabCard.GetComponent<ClothCardUI>();
                    clothCardUI.ConfigurateClothCard(clothItem.ClothSprites, clothItem.ClothPrice, Cloth.ClothTypeValue, Cloth.ClothCategory, false);
                    clothCardUI.ToggleCardClothState(CheckIfExistInInventory(clothCardUI.CardId));
                }

            }
        }



    }

    public void InitEquipmentClothesData()
    {
        if (m_ClothesCardParent.childCount > 0)
            ClearCards();

        foreach (var Cloth in m_ClothTypes.ClothTypesList)
        {
            if (Cloth.ClothCategory == ClothCategory.Apperance)
                continue;

            foreach (var clothItems in Cloth.ClothesList)
            {

                foreach (var clothItem in clothItems.clothes)
                {
                    GameObject clothPrefabCard = Instantiate(m_CardClothPrefab, m_ClothesCardParent);
                    clothPrefabCard.transform.SetParent(m_ClothesCardParent);

                    ClothCardUI clothCardUI = clothPrefabCard.GetComponent<ClothCardUI>();
                    clothCardUI.ConfigurateClothCard(clothItem.ClothSprites, clothItem.ClothPrice, Cloth.ClothTypeValue, Cloth.ClothCategory, false);

                    clothCardUI.ToggleCardClothState(CheckIfExistInInventory(clothCardUI.CardId));
                }

            }
        }
    }


    private void ClearCards()
    {
        for (int i = 0; i < m_ClothesCardParent.childCount; i++)
        {
            m_ClothesCardParent.GetChild(i).gameObject.SetActive(false);
            Destroy(m_ClothesCardParent.GetChild(i).gameObject);
        }
    }

    public void SetClothSprites(List<Sprite> sprites) => _currentBuySprites = sprites;



    public void EquipeCloth(ClothTypeEnum clothType, float price, ClothCardUI clothCard, bool isBuying)
    {
        if (!isBuying)
        {
            foreach (var playercloth in m_PlayerClothes)
            {
                if (playercloth.ClothesTypes == clothType)
                {
                    for (int i = 0; i < playercloth._clothSpritesRenders.Count; i++)
                    {
                        playercloth._clothSpritesRenders[i].sprite = _currentBuySprites[i];
                    }

                }
            }
        }
        else
        {
            m_PlayerCurrancyText.text = $"{m_PlayerCurrancy.PlayerCurrancy} {m_currancy}";
            m_ClothesInventoryManager.AddClothesToInventory(clothCard);
            m_PlayerCurrancy.RemoveCurrancy(price);
        }


    }


    public void UnEquipeCloth(ClothTypeEnum clothType, float price, ClothCardUI clothCard, bool isSelling)
    {
        foreach (var playercloth in m_PlayerClothes)
        {
            if (playercloth.ClothesTypes == clothType)
            {
                for (int i = 0; i < playercloth._clothSpritesRenders.Count; i++)
                {
                    playercloth._clothSpritesRenders[i].sprite = null;
                }

            }
        }

        if (isSelling)
        {
            m_PlayerCurrancy.AddCurrancy(price);
            m_PlayerCurrancyText.text = $"{m_PlayerCurrancy.PlayerCurrancy} {m_currancy}";
            m_ClothesInventoryManager.RemoveClothesCardFromInventory(clothCard);
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

    public bool CheckIfExistInInventory(string cardId)
    {
        foreach (var card in m_ClothesInventoryManager.GetCardsClothesId())
        {
            if (cardId.Equals(card))
                return true;
            else
                continue;
        }

        return false;
    }


}
