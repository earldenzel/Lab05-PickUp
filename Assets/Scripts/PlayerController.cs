using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rBody;
    public float speed = 5.0f;
    public Camera mainCamera;
    public Text UIText;
    private float myTime;
    private bool gameStart;
    private int item1Count;
    private int item2Count;
    private int item3Count;
    public string nextLevel;
    private int maxPossible;

    public int Item1Count
    {
        get
        {
            return item1Count;
        }
    }

    public int Item2Count
    {
        get
        {
            return item2Count;
        }
    }

    public int Item3Count
    {
        get
        {
            return item3Count;
        }
    }

    // Use this for initialization
    void Start () {
        rBody = GetComponent<Rigidbody2D>();
        myTime = 30.0f;
        gameStart = false;
        item1Count = 0;
        item2Count = 0;
        item3Count = 0;
        maxPossible = GameObject.FindGameObjectWithTag("GameController").GetComponent<ItemSpawner>().numberOfUnits;
    }

    //use this for physics
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            gameStart = true;
        }
        
        SetCamera();
        SetUIText();

        if (gameStart)
        {
            myTime -= Time.deltaTime;
            rBody.velocity = speed * new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            this.transform.position = new Vector2(
                Mathf.Clamp(this.transform.position.x, 0, 131),
                Mathf.Clamp(this.transform.position.y, -14, 14));
        }

        if (myTime < 0 || (maxPossible == (Item1Count+Item2Count+Item3Count)))
        {
            SceneManager.LoadScene(nextLevel);
        }
        
    }

    private void SetUIText()
    {
        if (gameStart)
        {
            UIText.text = string.Format("Time left: {0:f2}", myTime);
        }
        else
        {
            UIText.text = "Press [SPACEBAR] to start";
        }
    }

    private void SetCamera()
    {
        float xPos = this.transform.position.x;

        if (xPos >= 22 && xPos <= 109)
        {
            mainCamera.transform.position = new Vector3(xPos, 0, mainCamera.transform.position.z);
        }
        else if (xPos > 109)
        {
            mainCamera.transform.position = new Vector3(109, 0, mainCamera.transform.position.z);
        }
        else
        {
            mainCamera.transform.position = new Vector3(22, 0, mainCamera.transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Item1":
                item1Count++;
                break;
            case "Item2":
                item2Count++;
                break;
            case "Item3":
                item3Count++;
                break;
            default:
                break;
        }

        Destroy(collision.gameObject);
    }
}
