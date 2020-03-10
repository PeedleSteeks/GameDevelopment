using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvSystem : MonoBehaviour
{

    [SerializeField] private GameObject invHolder;
    [SerializeField] private bool usingInv;

    public static InvSystem invSystem;

    private void Awake()
    {
        invSystem = this;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E) && !usingInv)
        {
            if (GameManager.gameManager.inGameFunction) return;

            ShowInv();
        }
        else if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape)) && usingInv)
        {
            HideInv();
            InventoryButtons.inventoryButtons.CloseNotes();
        }
    }

    public void ShowInv()
    {
        usingInv = true;
        GameManager.gameManager.inGameFunction = true;

        invHolder.SetActive(true);

        GameManager.gameManager.UnlockCursor();
        GameManager.gameManager.UpdateMotion(0);
        GameManager.gameManager.DisableControls();
    }

    public void HideInv()
    {
        usingInv = false;
        GameManager.gameManager.inGameFunction = false;

        invHolder.SetActive(false);

        GameManager.gameManager.LockCursor();
        GameManager.gameManager.UpdateMotion(1);
        GameManager.gameManager.EnableControls();
    }

}
