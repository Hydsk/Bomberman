using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{
    bool canSpawn = false;
    bool cooldown = true;
    public GameObject bomb;
    GameObject bombPref;
    bool canCall = true;
    //int bombQuant = 1;

    LineRenderer line1;
    bool isPlayerInside = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(bombPref.transform.position, transform.forward * 1000, Color.green);

        if(Input.GetMouseButtonUp(1))
        {
            //Debug.Log(GameController.bombQuant);
            if(canSpawn)
            {
                if(GameController.bombQuant >= 1)
                {
                    if(cooldown)
                    {
                        bombPref = Instantiate(bomb, new Vector3(transform.position.x + 0.5f, transform.position.y + 1.5f, transform.position.z + 0.5f), Quaternion.identity);
                        line1 = bombPref.GetComponent<LineRenderer>();
                        GameController.bombQuant = GameController.bombQuant - 1;
                        bombPref.GetComponent<Collider>().isTrigger = true;
                        StartCoroutine(waitForSpawn());
                        Debug.Log("Bomba spawnada");
                    }
                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canSpawn = true;
            isPlayerInside = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            canSpawn = false;
            bombPref.GetComponent<Collider>().isTrigger = false;
            isPlayerInside = false;
        }
    }
    IEnumerator waitForSpawn()
    {
        cooldown = false;
        yield return new WaitForSeconds(3.0f);
        GameController.bombQuant+=1;
        cooldown = true;
        yield return new WaitForSeconds(1.0f);
        
        Explosion();
    }
    public void Explosion()
    {
        Vector3 fixRay = new Vector3(bombPref.transform.position.x, bombPref.transform.position.y + 0.5f, bombPref.transform.position.z);
        RaycastHit hit;
        if(Physics.Raycast(fixRay, transform.forward, out hit, 3) && hit.transform.gameObject.tag == "Finish" ||
         Physics.Raycast(fixRay, transform.forward, out hit, 3.5f) && hit.transform.gameObject.tag == "Enemy" ||
         Physics.Raycast(fixRay, transform.forward, out hit, 3.5f) && hit.transform.gameObject.tag == "Player")
        {
            Debug.DrawRay(bombPref.transform.position, transform.forward * 1000, Color.green);
            line1.enabled = true;
            line1.SetPosition(0, fixRay);
            Vector3 ro = new Vector3(bombPref.transform.position.x, hit.point.y, hit.point.z+2); 
            line1.SetPosition(1, ro);
    
            Destroy(hit.transform.gameObject);
        }
        else
        {
            Debug.DrawRay(bombPref.transform.position, transform.forward * 3, Color.red);
            if(Physics.Raycast(fixRay, transform.forward, out hit, 3)) //&& hit.transform.gameObject.tag == "Pilar")
            {
                line1.SetPosition(0, fixRay);
                Vector3 ro = new Vector3(bombPref.transform.position.x, hit.point.y, hit.point.z+2); 
                line1.SetPosition(1, ro);
            }
            else
            {
                line1.SetPosition(0, fixRay);
                line1.SetPosition(1, new Vector3(fixRay.x, fixRay.y, fixRay.z + 4));
            }
        }


        Debug.Log("Teste 1");


        if(Physics.Raycast(fixRay, transform.right, out hit, 3) && hit.transform.gameObject.tag == "Finish" ||
         Physics.Raycast(fixRay, transform.right, out hit, 3.5f) && hit.transform.gameObject.tag == "Enemy" ||
         Physics.Raycast(fixRay, transform.right, out hit, 3.5f) && hit.transform.gameObject.tag == "Player")
        {
            Debug.DrawRay(bombPref.transform.position, transform.right * 1000, Color.green);
            line1.SetPosition(2, fixRay);
            Vector3 ro = new Vector3(bombPref.transform.position.x+5, hit.point.y, hit.point.z); 
            line1.SetPosition(3, ro);

            Destroy(hit.transform.gameObject);
        }
        else
        {
            Debug.DrawRay(bombPref.transform.position, transform.right* 3, Color.red);
            if(Physics.Raycast(fixRay, transform.right, out hit, 3)) //&& hit.transform.gameObject.tag == "Pilar")
            {
                line1.SetPosition(2, fixRay);
                Vector3 ro = new Vector3(bombPref.transform.position.x+2, hit.point.y, hit.point.z); 
                line1.SetPosition(3, ro);
            }
            else
            {
                line1.SetPosition(2, fixRay);
                line1.SetPosition(3, new Vector3(fixRay.x + 4.5f, fixRay.y, fixRay.z));
            }
        }


        Debug.Log("Teste 2");


        if(Physics.Raycast(fixRay, -transform.right, out hit, 3) && hit.transform.gameObject.tag == "Finish" ||
         Physics.Raycast(fixRay, -transform.right, out hit, 3.5f) && hit.transform.gameObject.tag == "Enemy" ||
         Physics.Raycast(fixRay, -transform.right, out hit, 3.5f) && hit.transform.gameObject.tag == "Player")
        {
            Debug.DrawRay(bombPref.transform.position, -transform.right * 1000, Color.green);
            line1.SetPosition(4, fixRay);
            Vector3 ro = new Vector3(bombPref.transform.position.x-5, hit.point.y, hit.point.z); 
            line1.SetPosition(5, ro);

            Destroy(hit.transform.gameObject);
        }
        else
        {
            Debug.DrawRay(bombPref.transform.position, -transform.right* 3, Color.red);
            if(Physics.Raycast(fixRay, -transform.right, out hit, 3)) //&& hit.transform.gameObject.tag == "Pilar")
            {
                line1.SetPosition(4, fixRay);
                Vector3 ro = new Vector3(bombPref.transform.position.x-2, hit.point.y, hit.point.z); 
                line1.SetPosition(5, ro);
            }
            else
            {
                line1.SetPosition(4, fixRay);
                line1.SetPosition(5, new Vector3(fixRay.x - 4.5f, fixRay.y, fixRay.z));
            }
        }


        Debug.Log("Teste 3");


        if(Physics.Raycast(fixRay, -transform.forward, out hit, 3) && hit.transform.gameObject.tag == "Finish" ||
         Physics.Raycast(fixRay, -transform.forward, out hit, 3.5f) && hit.transform.gameObject.tag == "Enemy" ||
         Physics.Raycast(fixRay, -transform.forward, out hit, 3.5f) && hit.transform.gameObject.tag == "Player")
        {
            Debug.DrawRay(bombPref.transform.position, -transform.forward * 1000, Color.green);
            line1.SetPosition(6, fixRay);
            Vector3 ro = new Vector3(bombPref.transform.position.x, hit.point.y, hit.point.z-2); 
            line1.SetPosition(7, ro);

            Destroy(hit.transform.gameObject);
        }
        else
        {
            Debug.DrawRay(bombPref.transform.position, -transform.forward * 3, Color.red);
            if(Physics.Raycast(fixRay, -transform.forward, out hit, 3)) //&& hit.transform.gameObject.tag == "Pilar")
            {
                line1.SetPosition(6, fixRay);
                Vector3 ro = new Vector3(bombPref.transform.position.x, hit.point.y, hit.point.z-2); 
                line1.SetPosition(7, ro);
            }
            else
            {
                line1.SetPosition(6, fixRay);
                line1.SetPosition(7, new Vector3(fixRay.x, fixRay.y, fixRay.z - 4));
            }
        }


        Debug.Log("Teste 4");

        ////////////////////////// BOMBS ///////////////////////////


        if(Physics.Raycast(fixRay, transform.forward, out hit, 3.5f) && hit.transform.gameObject.tag == "Bomb")
        {
            RaycastHit hitFloor;
            if(Physics.Raycast(hit.transform.position, -transform.up, out hitFloor, 2) && hitFloor.transform.gameObject.tag == "Floor")
            {
                Debug.Log("Achei o chão..." + hitFloor.transform.gameObject);
                //StartCoroutine(waitToCall());
                if(canCall)
                {
                    Debug.Log("Made my friend explode");
                    canCall = false;
                    //Trail(hit.transform.gameObject);
                    hitFloor.transform.gameObject.GetComponent<SpawnBomb>().Explosion();
                }
                else
                {
                    StartCoroutine(waitToCall());
                }
            }
        }
        else
        {
            //Debug.Log("Didnt find a bomb...");
        }

        Debug.Log("Teste 5");


        if(Physics.Raycast(fixRay, -transform.forward, out hit, 3.5f) && hit.transform.gameObject.tag == "Bomb")
        {
            RaycastHit hitFloor;
            if(Physics.Raycast(hit.transform.position, -transform.up, out hitFloor, 2) && hitFloor.transform.gameObject.tag == "Floor")
            {
                Debug.Log("Achei o chão..." + hitFloor.transform.gameObject);
                //StartCoroutine(waitToCall());
                if(canCall)
                {
                    Debug.Log("Made my friend explode");
                    canCall = false;
                    //Trail(hit.transform.gameObject);
                    hitFloor.transform.gameObject.GetComponent<SpawnBomb>().Explosion();
                }
                else
                {
                    StartCoroutine(waitToCall());
                }
            }
        }

        Debug.Log("Teste 6");


        if(Physics.Raycast(fixRay, transform.right, out hit, 3.5f) && hit.transform.gameObject.tag == "Bomb")
        {
            RaycastHit hitFloor;
            if(Physics.Raycast(hit.transform.position, -transform.up, out hitFloor, 2) && hitFloor.transform.gameObject.tag == "Floor")
            {
                Debug.Log("Achei o chão..." + hitFloor.transform.gameObject);
                //StartCoroutine(waitToCall());
                if(canCall)
                {
                    Debug.Log("Made my friend explode");
                    canCall = false;
                    //Trail(hit.transform.gameObject);
                    hitFloor.transform.gameObject.GetComponent<SpawnBomb>().Explosion();
                }
                else
                {
                    StartCoroutine(waitToCall());
                }
            }
        }

        Debug.Log("Teste 7");


        if(Physics.Raycast(fixRay, -transform.right, out hit, 3.5f) && hit.transform.gameObject.tag == "Bomb")
        {
            RaycastHit hitFloor;
            if(Physics.Raycast(hit.transform.position, -transform.up, out hitFloor, 2) && hitFloor.transform.gameObject.tag == "Floor")
            {
                Debug.Log("Achei o chão..." + hitFloor.transform.gameObject);
                //StartCoroutine(waitToCall());
                if(canCall)
                {
                    Debug.Log("Made my friend explode");
                    canCall = false;

                    hitFloor.transform.gameObject.GetComponent<SpawnBomb>().Explosion();
                    StartCoroutine(waitToDespawn());
                }
                else
                {
                    StartCoroutine(waitToCall());
                }
            }
        }
        Debug.Log("Teste 8");
        StartCoroutine(waitToDespawn());
        //Destroy(bombPref);
    }

    IEnumerator waitToCall()
    {
        yield return new WaitForSeconds(0.2f);
        canCall = true;
        Explosion();
    }

    IEnumerator waitToDespawn()
    {
        Debug.Log("Tentando destruir");

        if(isPlayerInside)
        {
            Destroy(GameObject.Find("/Player"));
        }

        yield return new WaitForSeconds(0.5f);
        
        bombPref.transform.position = new Vector3(0,-10,0);

        line1.enabled = false;

        Destroy(bombPref);
    }
}
