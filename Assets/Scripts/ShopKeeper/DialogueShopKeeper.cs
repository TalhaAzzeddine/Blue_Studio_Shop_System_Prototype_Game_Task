using CustomizableCharacters.CharacterEditor.Demo;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueShopKeeper : MonoBehaviour
{

    [Header("Dialogue UI")]
    [SerializeField] private GameObject m_DialogueScreen;
    [SerializeField] private TextMeshProUGUI m_DialogueText;
    [SerializeField] List<string> m_DiaologueParoles;
    [SerializeField] private GameObject m_BuyButton;
    [SerializeField] private GameObject m_ExitButton;
    [SerializeField] private Animator m_DialogueAnimator;
    [SerializeField] private AnimationClip m_closeDialogueAnimation;


    [Space(10)]

    [Header("Clothes Shop UI")]
    [SerializeField] private GameObject m_ClothesShopUI;

    [Space(10)]
    [Header("Type Writer Animation")]
    [SerializeField] float m_TimeBtwChars = 0.1f;

    private bool _firstOpenShop = true;


    public void InteractWithClothesShopKeeper()
    {

        m_DialogueScreen.SetActive(true);

        if (_firstOpenShop)
        {

            m_DialogueText.text = m_DiaologueParoles[0];

            m_BuyButton.SetActive(true);
            m_ExitButton.SetActive(true);

            _firstOpenShop = false;
        }
        else
        {

            m_DialogueText.text = m_DiaologueParoles[1];
            m_BuyButton.SetActive(true);
            m_ExitButton.SetActive(true);


            _firstOpenShop = true;
        }

    }

    public void OpenClothesShop()
    {
        m_DialogueScreen.SetActive(false);
        m_BuyButton.SetActive(false);
        m_ExitButton.SetActive(false);
        m_ClothesShopUI.SetActive(true);
        _firstOpenShop = false;

    }

    public void CloseDialogue()
    {
        m_DialogueAnimator.SetTrigger("Close");
        StartCoroutine(HideUI(m_closeDialogueAnimation.length));
        DemoCharacterController.TogglePlayerMovmenetState(true);


    }


    private IEnumerator HideUI(float timeInSecond)
    {
        yield return new WaitForSeconds(timeInSecond);
        m_DialogueScreen.SetActive(false);
        m_BuyButton.SetActive(false);
        m_ExitButton.SetActive(false);
        _firstOpenShop = true;


    }



}


