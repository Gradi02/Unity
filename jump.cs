using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class jump : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;
    [SerializeField] GameObject pl;
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject AudioManager;
    [SerializeField] TextMeshProUGUI info;
    public TextMeshProUGUI info2;
    [SerializeField] float JumpSpeed = 30f;
    public bool move = true;
    public float fadeTime = 1f;
    public Color newColor;

    public bool end = false;


    void Start()
    {
        pl.GetComponent<Rigidbody2D>().gravityScale = 0;
        spawner.GetComponent<spawner>().enabled = false;
        info2.color = newColor;
        player.gameObject.GetComponent<punkty>().sprawdz();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && move)
        {
            if(spawner.GetComponent<spawner>().enabled == false)
            {
                spawner.GetComponent<spawner>().enabled = true;
                pl.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
            player.velocity = Vector3.zero;
            player.AddForce(new Vector3(0, 1) * JumpSpeed);
            AudioManager.gameObject.GetComponent<Audio>().Flip();
        }

        if(player.velocity.y >= 0f)
        {
            transform.rotation = Quaternion.Euler(0,0,30);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, -30);
        }

        if(spawner.GetComponent<spawner>().enabled == true)
        {
            FadeOut();
        }

        if (end && Input.GetKeyDown(KeyCode.Space))
        {
            player.GetComponent<reset>().Reset();
        }
    }
    void FadeOut()
    {
        info.color = Color.Lerp(info.color, newColor, fadeTime * Time.deltaTime);
    }
}
