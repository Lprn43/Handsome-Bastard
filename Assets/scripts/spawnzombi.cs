using System.Collections;
using UnityEngine;

public class spawnzombi : MonoBehaviour
{
    public GameObject zombi;
    public Rigidbody2D[] spawnpoint = new Rigidbody2D[7];
    int x;
    float time;
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1.0f);
        print("spawned");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        x = Random.Range(0, 7);
        if (time > 5)
        {
            Vector3 pos = spawnpoint[x].transform.TransformPoint(zombi.transform.position);
            Quaternion qua = new Quaternion(0, 0, 0, 0);
            Instantiate(zombi, spawnpoint[x].transform.position, qua);
            time = 0;
        }
        //StartCoroutine(Spawn());
    }
}
