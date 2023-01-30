using CustomizableCharacters.CharacterEditor.Demo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneBase : MonoBehaviour
{
    [SerializeField] protected KeyCode _intearctInputKey = KeyCode.E;
    [SerializeField] protected GameObject _InteractButtonUI;


    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            Debug.Log("Player Enter ....");

            if (DemoCharacterController.CanMove)
                _InteractButtonUI.SetActive(true);
        }
    }
    public virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Stay ....");
        }
    }

    public virtual void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Exit ....");

            _InteractButtonUI.SetActive(false);
        }

    }

}
