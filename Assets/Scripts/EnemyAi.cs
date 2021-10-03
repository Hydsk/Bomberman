using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent navMesh;
    GameObject player;
    public float dis;
    float disSave;

    Vector3 playerT;
    Vector3 enemyT; 

    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();    //Getting Nav from enemy
        player = GameObject.Find("/Player");                      //Getting player GmObj
        
        disSave = dis;                                            //Saving distance limit
    }

    // Update is called once per frame
    void Update()
    {
        playerT = player.transform.position;
        enemyT = transform.position;

        Debug.Log(Mathf.Abs(Mathf.Abs(playerT.x + playerT.z) - Mathf.Abs(enemyT.x + enemyT.z)));

        if(Mathf.Abs(Mathf.Abs(playerT.x + playerT.z) - Mathf.Abs(enemyT.x + enemyT.z)) <= dis)        // If distance beetwen player and enemy <= to distance limit
        {
            navMesh.isStopped = false;                         // Making enemy go after player
            navMesh.SetDestination(playerT);                   // Set enemy destination
        }
        else
        {
            navMesh.isStopped = true;                           // Making enemy stop going after player
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")                         // If enemy hit with player, will make enemy stop follow and will destroy player
        {
            dis = -999;
            navMesh.isStopped = true;
            Debug.Log("Colidiu");
            Destroy(player);
            StartCoroutine(stopFollow());
        }
    }
    IEnumerator stopFollow()
    {
        yield return new WaitForSeconds(1.0f);
        dis = disSave;
    }
}
