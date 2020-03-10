using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{

    [SerializeField] private bool doorIsOpen;

	public void OpenCheck (GameObject currentDoor)
    {
        if (gameObject.GetComponent<LockedScript>() != null)
        {
            if (gameObject.GetComponent<LockedScript>().GetIsLocked() == true)
            {
                gameObject.GetComponent<LockedScript>().TryUnlock(currentDoor);
            }
            else
            {
                DoorInteract(currentDoor);
            }
        }
        else
        {
            DoorInteract(currentDoor);
        }
	}

    public void DoorInteract(GameObject currentDoor)
    {
        if (currentDoor.GetComponent<Animation>().isPlaying == false)
        {
            if (doorIsOpen == false)
            {
                currentDoor.GetComponent<Animation>().Play("DoorOpen");
                doorIsOpen = true;
            }
            else if (doorIsOpen == true)
            {
                currentDoor.GetComponent<Animation>().Play("DoorClose");
                doorIsOpen = false;
            }
        }
    }	
}
