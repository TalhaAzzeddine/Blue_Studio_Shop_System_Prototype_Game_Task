using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClothCardUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI m_priceText;
    [SerializeField] private Image m_spriteRender;
    [SerializeField] private string m_currancy = "£";
    [SerializeField] private GameObject m_BuyButton;
    [SerializeField] private GameObject m_SellButton;
    [SerializeField] private GameObject m_EquipeButton;
    [SerializeField] private GameObject m_UnequipeButton;

    //"All the sides sprites of that cloth ( 0 -> Up, 1 -> Down , 2 -> Side)"
    private List<Sprite> _clothSprites = new List<Sprite>();
    private ClothTypeEnum _clothTypeValue;
    private ClothCategory _clothCategory;
    private float price;
    private string _cardId;
    private bool isEquiped = false;


    public void ConfigurateClothCard(List<Sprite> clotheSidesSprites, float price, ClothTypeEnum clothType, ClothCategory clothCategory, bool isInventory)
    {


        _clothSprites = clotheSidesSprites;
        SetClothPrice(price);
        SetSpriteRender(_clothSprites[0]);
        _cardId = _clothSprites[0].name;
        _clothTypeValue = clothType;
        _clothCategory = clothCategory;

        if (isInventory)
        {
            m_EquipeButton.SetActive(true);
            m_BuyButton.SetActive(false);
        }
        else
        {
            m_EquipeButton.SetActive(false);
            m_BuyButton.SetActive(true);

        }
    }

    public void SetSpriteRender(Sprite sprite)
    {
        m_spriteRender.sprite = sprite;
    }

    public void SetClothPrice(float price)
    {
        this.price = price;
        m_priceText.text = $" {price}{m_currancy}";
    }

    public List<Sprite> GetAllClothSideSprites() => _clothSprites;

    public Sprite GetClothSprite() => m_spriteRender.sprite;

    public ClothCategory CardClothCategory => _clothCategory;
    public ClothTypeEnum CardClothType => _clothTypeValue;

    public string CardId => _cardId;

    public float Price => price;

    public bool IsEquiped => isEquiped;


    public void ToggleCardClothState(bool isInInventory)
    {
        if (isInInventory)
        {
            m_BuyButton.SetActive(false);
            m_SellButton.SetActive(true);
        }
        else
        {
            m_BuyButton.SetActive(true);
            m_SellButton.SetActive(false);
        }


    }

    public void ToggleCardClothEquipeState(bool isEquiped)
    {
        if (isEquiped)
        {
            m_EquipeButton.SetActive(false);
            m_UnequipeButton.SetActive(true);
        }
        else
        {
            m_EquipeButton.SetActive(true);
            m_UnequipeButton.SetActive(false);
        }
    }

    public void Buy()
    {
        ClothShopManager.Instance.SetClothSprites(GetAllClothSideSprites());
        ClothShopManager.Instance.EquipeCloth(_clothTypeValue, price, this, true);
    }

    public void Sell()
    {
        ClothShopManager.Instance.SetClothSprites(GetAllClothSideSprites());
        ClothShopManager.Instance.UnEquipeCloth(_clothTypeValue, price, this, true);
    }

    public void Equipe()
    {
        ClothShopManager.Instance.SetClothSprites(GetAllClothSideSprites());
        ClothShopManager.Instance.EquipeCloth(_clothTypeValue, price, this, false);
        isEquiped = true;
    }

    public void UnEquipe()
    {
        ClothShopManager.Instance.SetClothSprites(GetAllClothSideSprites());
        ClothShopManager.Instance.UnEquipeCloth(_clothTypeValue, price, this, false);
        isEquiped = false;
    }



}
