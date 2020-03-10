using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour {

    public static Inventory inventory;

    public bool[] items = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
    public int[] collectables = { 0, 0, 0, 0, 0, 0};

    [SerializeField] private Text pickUpText;
    public RectTransform[] invSlots;

    [SerializeField] private GameObject noItem;
    [SerializeField] private GameObject footSteps;
    private AudioSource footStepsAudio;

    void Start ()
    {
        inventory = this;
        footStepsAudio = footSteps.gameObject.GetComponent<AudioSource>();
	}
	
	public void AddItem(string ItemID, GameObject Object)
    {
        int amount = Object.GetComponent<CheckCount>().amount;
        if (ItemID == TagManager.candle)
        {
            collectables[0] += amount;
            CreateData(0, amount, ItemID, 0);
        }
        else if (ItemID == TagManager.bandage)
        {
            collectables[1] += amount;
            CreateData(1, amount, ItemID, 1);
        }
        else if (ItemID == TagManager.herb)
        {
            collectables[2] += amount;
            CreateData(2, amount, ItemID, 2);
        }
        else if (ItemID == TagManager.blessedcandle)
        {
            collectables[3] += amount;
            CreateData(3, amount, ItemID, 3);
        }
        else if (ItemID == TagManager.adrenaline)
        {
            collectables[4] += amount;
            CreateData(4, amount, ItemID, 4);
        }
        else if (ItemID == TagManager.necklace)
        {
            collectables[5] += amount;
            CreateData(5, amount, ItemID, 5);
        }
        else if (ItemID == TagManager.goggles)
        {
            items[0] = true;
            CreateData(6, amount, ItemID, 0);
        }
        else if (ItemID == TagManager.shovel)
        {
            items[1] = true;
            CreateData(7, amount, ItemID, 1);
        }
        else if (ItemID == TagManager.glass)
        {
            items[2] = true;
            CreateData(8, amount, ItemID, 2);
        }
        else if (ItemID == TagManager.librarykey)
        {
            items[3] = true;
            CreateData(9, amount, ItemID, 3);
        }
        else if (ItemID == TagManager.note1)
        {
            items[4] = true;
            CreateData(10, amount, ItemID, 4);
        }
        else if (ItemID == TagManager.note2)
        {
            items[5] = true;
            CreateData(11, amount, ItemID, 5);
        }
        else if (ItemID == TagManager.note3)
        {
            items[6] = true;
            CreateData(12, amount, ItemID,6);
        }
        else if (ItemID == TagManager.note4)
        {
            items[7] = true;
            CreateData(13, amount, ItemID, 7);
        }
        else if (ItemID == TagManager.note5)
        {
            items[8] = true;
            CreateData(14, amount, ItemID, 8);
        }
        else if (ItemID == TagManager.note0)
        {
            items[9] = true;
            CreateData(15, amount, ItemID, 9);
            footSteps.SetActive(true);
            footStepsAudio.Play();
        }
        else if (ItemID == TagManager.note6)
        {
            Application.Quit();
        }
        else if (ItemID == TagManager.ladder)
        {
            items[10] = true;
            CreateData(16, amount, ItemID, 10);
        }
        else if (ItemID == TagManager.crowbar)
        {
            items[11] = true;
            CreateData(17, amount, ItemID, 11);
        }
        else if (ItemID == TagManager.studykey)
        {
            items[12] = true;
            CreateData(18, amount, ItemID, 12);
        }
        else if (ItemID == TagManager.shedkey)
        {
            items[13] = true;
            CreateData(19, amount, ItemID, 13);
        }
        else if (ItemID == TagManager.entnote)
        {
            items[14] = true;
            CreateData(20, amount, ItemID, 14);
        }

        TextAnimation(ItemID, amount);
    }

    private void CreateData(int item, int amount, string ItemID, int itemIndex)
    {
        invSlots[item].gameObject.SetActive(true);

        SlotData data = invSlots[item].GetComponent<SlotData>();

        data.itemIndex = itemIndex;
        data.invIndex = item;

        data.amount += amount;
        data.amountText.text = "Quantity: " + data.amount;

        data.name = ItemID;
        data.nameText.text = "Name: " + data.name;

        if (noItem.activeSelf)
        {
            noItem.SetActive(false);
        }
    }

    private void TextAnimation(string ItemID, int amount)
    {
        pickUpText.text = "Picked up " + amount + " " + ItemID;
        pickUpText.gameObject.GetComponent<Animation>().Stop();
        pickUpText.gameObject.GetComponent<Animation>().Play("PickUpText");
    }

}
