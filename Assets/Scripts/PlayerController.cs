using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject CoinsCollected;
    float speed = 5.0f;
    public GameObject Coin;


    private int coinCount;
    private int totalCoin;
    // Start is called before the first frame update
    void Start()
    {
        totalCoin = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -speed);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (coinCount == totalCoin)
        {
            SceneManager.LoadScene("WinScene");
        }

        if(transform.position.y < -5)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            coinCount++;

            CoinsCollected.GetComponent<Text>().text = "Coin Collected: " + coinCount;

            Destroy(other.gameObject);
        }
    }
}
