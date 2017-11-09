using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryProcessor : MonoBehaviour {

    private GameObject player;
    private int item1count;
    private int item2count;
    private int item3count;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        item1count = player.GetComponent<PlayerController>().Item1Count;
        item2count = player.GetComponent<PlayerController>().Item2Count;
        item3count = player.GetComponent<PlayerController>().Item3Count;
        Destroy(player);

        transform.GetChild(1).GetComponent<Text>().text = string.Format("x {0}", item1count);
        transform.GetChild(2).GetComponent<Text>().text = string.Format("x {0}", item2count);
        transform.GetChild(3).GetComponent<Text>().text = string.Format("x {0}", item3count);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
