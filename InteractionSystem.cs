using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionSystem : MonoBehaviour {

    [SerializeField] private GameObject player;
    [SerializeField] private Camera mainCam;
    [SerializeField] private float interactDistance = 5.0f;
    [SerializeField] private GameObject necklaceSlot;
    private UpdatePlayerStatusAndObjectiveScript statusandobjectiveUpdater;

    private bool canInteract;
    bool guiShow = false;

    private GameObject interactingGameObject;
    private string interactingObjectName;

    [Header("Object Color Palettes")]
    [SerializeField] private Color interactionColor = Color.red;
    [SerializeField] private Material[] defaultMaterial;

	void Start ()
    {
        statusandobjectiveUpdater = player.gameObject.GetComponent<UpdatePlayerStatusAndObjectiveScript>();
        InvokeRepeating("Search", 0f, 0.25f);
    }
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && canInteract)
        {
            if (interactingObjectName == TagManager.candle)
            {
                Inventory.inventory.AddItem(interactingObjectName, interactingGameObject);
                ClearData();

                return;
            }
            else if (interactingObjectName == TagManager.blessedcandle)
            {
                Inventory.inventory.AddItem(interactingObjectName, interactingGameObject);
                ClearData();

                return;
            }
            else if (interactingObjectName == TagManager.librarykey)
            {
                Inventory.inventory.AddItem(interactingObjectName, interactingGameObject);
                ClearData();

                return;
            }
            else if (interactingObjectName == TagManager.herb)
            {
                Inventory.inventory.AddItem(interactingObjectName, interactingGameObject);
                ClearData();

                return;
            }
            else if (interactingObjectName == TagManager.bandage)
            {
                Inventory.inventory.AddItem(interactingObjectName, interactingGameObject);
                ClearData();

                return;
            }
            else if (interactingObjectName == TagManager.adrenaline)
            {
                Inventory.inventory.AddItem(interactingObjectName, interactingGameObject);
                ClearData();

                return;
            }
            else if (interactingObjectName == TagManager.glass)
            {
                Inventory.inventory.AddItem(interactingObjectName, interactingGameObject);
                ClearData();

                return;
            }
            else if (interactingObjectName == TagManager.note1)
            {
                Inventory.inventory.AddItem(interactingObjectName, interactingGameObject);
                ClearData();
                statusandobjectiveUpdater.UpdateObjective("Follow Louis and his notes, it could lead you to him or whatever he is looking for.");

                return;
            }
            else if (interactingObjectName == TagManager.note2)
            {
                Inventory.inventory.AddItem(interactingObjectName, interactingGameObject);
                ClearData();
                statusandobjectiveUpdater.UpdateObjective("Madison is inside this room, the key must be somewhere in this building. Might as well pick up other things I might need on the way.");

                return;
            }
            else if (interactingObjectName == TagManager.note3)
            {
                Inventory.inventory.AddItem(interactingObjectName, interactingGameObject);
                ClearData();
                statusandobjectiveUpdater.UpdateObjective("The three of them are inside, it looks like they are unconcious... Louis must have left before they went asleep. I just need something to open this door.");

                return;
            }
            else if (interactingObjectName == TagManager.note4)
            {
                Inventory.inventory.AddItem(interactingObjectName, interactingGameObject);
                ClearData();
                statusandobjectiveUpdater.UpdateObjective("Follow the sound of cicadas, Louis might be at the end of this path.");

                return;
            }
            else if (interactingObjectName == TagManager.note5)
            {
                Inventory.inventory.AddItem(interactingObjectName, interactingGameObject);
                ClearData();
                statusandobjectiveUpdater.UpdateObjective("Louis is wounded and cannot move, and I learned that I need some kind of necklace to save him and the others. I have to find a way to tend his wounds and then give him a necklace.");

                return;
            }
            else if (interactingObjectName == TagManager.note6)
            {
                Inventory.inventory.AddItem(interactingObjectName, interactingGameObject);
                ClearData();
                statusandobjectiveUpdater.UpdateObjective("");

                return;
            }
            else if (interactingObjectName == TagManager.note0)
            {
                Inventory.inventory.AddItem(interactingObjectName, interactingGameObject);
                ClearData();
                statusandobjectiveUpdater.UpdateObjective("Footsteps... is someone running outside? Is that what Louis mentioned? I better go check what it was...");

                return;
            }
            else if (interactingObjectName == TagManager.ladder)
            {
                Inventory.inventory.AddItem(interactingObjectName, interactingGameObject);
                ClearData();

                return;
            }
            else if (interactingObjectName == TagManager.crowbar)
            {
                Inventory.inventory.AddItem(interactingObjectName, interactingGameObject);
                ClearData();

                return;
            }
            else if (interactingObjectName == TagManager.studykey)
            {
                Inventory.inventory.AddItem(interactingObjectName, interactingGameObject);
                ClearData();

                return;
            }
            else if (interactingObjectName == TagManager.shedkey)
            {
                Inventory.inventory.AddItem(interactingObjectName, interactingGameObject);
                ClearData();

                return;
            }
            else if (interactingObjectName == TagManager.necklace)
            {
                Inventory.inventory.AddItem(interactingObjectName, interactingGameObject);
                ClearData();

                return;
            }
            else if (interactingObjectName == TagManager.shovel)
            {
                Inventory.inventory.AddItem(interactingObjectName, interactingGameObject);
                ClearData();

                return;
            }
            else if (interactingObjectName == TagManager.goggles)
            {
                Inventory.inventory.AddItem(interactingObjectName, interactingGameObject);
                ClearData();

                return;
            }
            else if (interactingObjectName == TagManager.companies)
            {
                if (interactingGameObject.GetComponent<WoundedScript>() != null)
                {
                    if (interactingGameObject.GetComponent<WoundedScript>().GetIsWounded() == false)
                    {
                        player.GetComponent<SavedCharactersScript>().TrySave(interactingGameObject.
                            GetComponent<CompanionNumberScript>().GetCompanionNumber());
                        if (player.GetComponent<SavedCharactersScript>().IsCompanionSaved(interactingGameObject.
                            GetComponent<CompanionNumberScript>().GetCompanionNumber()) == true)
                        {
                            ClearData();
                        }
                    }
                    else
                    {
                        interactingGameObject.gameObject.GetComponent<WoundedScript>().IsStillWounded();
                    }
                }
                else 
                {
                    player.GetComponent<SavedCharactersScript>().TrySave(interactingGameObject.
                         GetComponent<CompanionNumberScript>().GetCompanionNumber());
                    if (player.GetComponent<SavedCharactersScript>().IsCompanionSaved(interactingGameObject.
                            GetComponent<CompanionNumberScript>().GetCompanionNumber()) == true)
                    {
                        ClearData();
                    }
                }
            }
            else if (interactingObjectName == TagManager.entnote)
            {
                Inventory.inventory.AddItem(interactingObjectName, interactingGameObject);
                ClearData();
                statusandobjectiveUpdater.UpdateObjective("Look for Louis at the Library.");

                return;
            }
        }
	}

    private void Search()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit) && hit.transform.gameObject.layer == LayerMask.NameToLayer("Interactable") && hit.distance <= interactDistance)
        {
            guiShow = true;
            canInteract = true;

            interactingObjectName = hit.collider.tag;
            interactingGameObject = hit.transform.gameObject;
            for (int x = 0; x < defaultMaterial.Length; x++)
            {
                if (interactingGameObject.GetComponent<Renderer>() == null)
                {
                    defaultMaterial[x] = interactingGameObject.GetComponentInChildren<Renderer>().material;
                    interactingGameObject.GetComponentInChildren<Renderer>().material.color = interactionColor;
                }
                else
                {
                    defaultMaterial[x] = interactingGameObject.GetComponent<Renderer>().material;
                    interactingGameObject.GetComponent<Renderer>().material.color = interactionColor;
                }
            }
        }
        else
        {
            guiShow = false;

            canInteract = false;

            ResetData();
        }
    }

    void ResetData()
    {
        guiShow = false;

        if (interactingGameObject == null) return;

        for (int x = 0; x < defaultMaterial.Length; x++)
        {
            if (interactingGameObject.GetComponent<Renderer>() == null)
            {
                interactingGameObject.GetComponentInChildren<Renderer>().material = defaultMaterial[x];
            }
            else
            {
                interactingGameObject.GetComponent<Renderer>().material = defaultMaterial[x];
            }
        }

        
        interactingGameObject = null;
        interactingObjectName = null;

    }

    void ClearData()
    {
        guiShow = false;

        if (interactingGameObject != null)
        {
            interactingGameObject.SetActive(false);
        }
        interactingGameObject = null;
        interactingObjectName = null;
    }

    void OnGUI()
    {
        if (guiShow == true)
        {
            GUI.Box(new Rect(Screen.width / 2 - 100, 3 * Screen.height / 4, 200, 25), "Left Click Mouse to Interact");
        }
    }
}
