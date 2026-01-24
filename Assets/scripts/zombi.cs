using UnityEngine;

public class zombi : MonoBehaviour
{
    Ray2D ray;
    public float speed;
    public Rigidbody2D rb,playerrb;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("player");
        playerrb = player.GetComponent<Rigidbody2D>();
        ray = new Ray2D(rb.transform.position,player.transform.position);
        rb.transform.position = Vector2.MoveTowards(rb.transform.position,player.transform.position,speed * Time.deltaTime);
        Debug.DrawLine(rb.transform.position, player.transform.position);
    }
}
