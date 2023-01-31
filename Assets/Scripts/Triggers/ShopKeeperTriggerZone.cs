using CustomizableCharacters.CharacterEditor.Demo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperTriggerZone : TriggerZoneBase
{
    [Space(10)]
    [Header("Shop Keeper Diaologue")]
    [SerializeField] private DialogueShopKeeper shopKeeper;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);


    }
    public override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);

        if (collision.CompareTag("Player"))
        {

            if (Input.GetKey(_intearctInputKey))
            {
                DemoCharacterController.TogglePlayerMovmenetState(false);
                _InteractButtonUI.SetActive(false);

                shopKeeper.InteractWithClothesShopKeeper();

                _InteractionAudioSource.PlayOneShot(_InteractionSound);

            }

        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);


    }

}
