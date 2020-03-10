using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSystem : MonoBehaviour {

    public static MainMenuSystem mainMenuSystem;

    [SerializeField] GameObject mainMenuHolder;

	void Start () {

        mainMenuSystem = this;

        ShowMain();
    }
	
	void Update () {
		
	}

    public void ShowMain()
    {

        GameManager.gameManager.UnlockCursor();
        GameManager.gameManager.UpdateMotion(0);
        GameManager.gameManager.DisableControls();

        mainMenuHolder.SetActive(true);

    }

    public void HideMain()
    {
        GameManager.gameManager.LockCursor();
        GameManager.gameManager.UpdateMotion(1);
        GameManager.gameManager.EnableControls();

        mainMenuHolder.SetActive(false);
    }

}
