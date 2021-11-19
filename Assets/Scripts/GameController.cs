using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static int bombQuant = 1;

    GameObject player;
    GameObject cam;

    Vector3 playerT;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindWithTag("Respawn");
        player = GameObject.Find("/Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerT = player.transform.position;
        Vector3 followPlayer = new Vector3(playerT.x, cam.transform.position.y, playerT.z);          // Make camera follow player

        cam.transform.position = followPlayer;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
