using UnityEngine;

public class canuitakip : MonoBehaviour
{

    public GameObject p;
    public Rigidbody2D player,rb;
    void Start()
    {
        p = GameObject.FindGameObjectWithTag("player");
        player = p.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = player.transform.position.x;
        float y = player.transform.position.y;

        rb.transform.position = new Vector3(x, y+0.4f, rb.transform.position.z);
    }
}
