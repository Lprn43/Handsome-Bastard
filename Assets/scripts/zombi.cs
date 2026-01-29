using System.Collections;
using UnityEngine;

public class zombi : MonoBehaviour
{
    Ray2D ray;
    public float speed;
    public Rigidbody2D rb,playerrb;
    public GameObject player;
    Animator animator;
    public Sprite death;
    IEnumerator Yoket()
    {
        yield return new WaitForSeconds(15);
        Destroy(gameObject);
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("death") == false)
        {
            player = GameObject.FindGameObjectWithTag("player");
            playerrb = player.GetComponent<Rigidbody2D>();
            ray = new Ray2D(rb.transform.position, player.transform.position);
            rb.transform.position = Vector2.MoveTowards(rb.transform.position, player.transform.position, speed * Time.deltaTime);
            Debug.DrawLine(rb.transform.position, player.transform.position);
        }
        if(animator.GetBool("olu") == true)
        {
            StartCoroutine(Yoket());
            gameObject.GetComponent<SpriteRenderer>().sprite = death;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Animator>().enabled = false;
        }
    }
}
