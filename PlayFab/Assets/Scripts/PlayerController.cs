using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rig;

    private float startTime;
    private float timeTaken;

    private int collectabledPicked;
    public int maxCollectables = 10;

    public GameObject playButton;
    public TextMeshProUGUI curTimeText;

    private bool isPlaying;


    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isPlaying)
            return;

        float x = Input.GetAxis("Horizontal") * speed;
        float z = Input.GetAxis("Vertical") * speed;

        rig.velocity = new Vector3(x, rig.velocity.y, z);

        curTimeText.text = (Time.time - startTime).ToString("F2");

    }

    public void Begin ()
    {
        startTime = Time.time;  
        isPlaying = true;
        playButton.SetActive(false);   
    }

    void End ()
    {
        timeTaken = Time.time - startTime;
        isPlaying = false;
        Leaderboard.instance.SetLeaderboardEntry(-Mathf.RoundToInt(timeTaken * 1000.0f));
        playButton.SetActive(false);
    }

    void OnTriggerEnter (Collider other)
    {
        //Debug.Log("TRIGGER");
        if(other.gameObject.CompareTag("Collectable"))
        {
            collectabledPicked++;
            Destroy(other.gameObject);

            if (collectabledPicked == maxCollectables)
                End();
        }
    }
}
