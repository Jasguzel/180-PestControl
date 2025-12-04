using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 * Author: Guzeldere, Jasmine
 * Last Updated: 12/02/2025
 * Storing the basic information of items
 * 
 */
public class Item : MonoBehaviour
{
    public string itemsName = "";
    public int doubloons = 0; //discuss w team
    public TMP_Text nameText;
    public TMP_Text costText;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = itemsName;
        costText.text = "This Item Costs: " + doubloons + " doubloons!";
    }
}
