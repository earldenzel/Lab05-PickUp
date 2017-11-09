using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public int numberOfUnits = 30;
    private float unitRandomizer;
    private Vector3 unitPosition;


	// Use this for initialization
	void Start () {
        for (int i = 0; i < numberOfUnits; i++)
        {
            do
            {
                unitPosition = new Vector3(Random.Range(-9, 140), Random.Range(-13, 13));
            }
            while (Physics2D.OverlapCircle(unitPosition, 1.0f) != null);

            unitRandomizer = Random.Range(0.0f, 3.0f);
            if (unitRandomizer < 1.0f)
            {
                Instantiate(item1, unitPosition, Quaternion.identity);
            }
            else if (unitRandomizer < 2.0f)
            {
                Instantiate(item2, unitPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(item3, unitPosition, Quaternion.identity);
            }            
        }
	}

    // Update is called once per frame
    void Update()
    {
		
	}
}
