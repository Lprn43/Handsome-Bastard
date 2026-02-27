using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class zombi : MonoBehaviour
{
    Ray2D ray;
    public float speed;
    public Rigidbody2D rb,playerrb;
    public GameObject player;
    Animator animator;
    public Sprite death;
    public int can = 100;
    public Text canui;
    public GameObject canva;
    IEnumerator Yoket()
    {
        yield return new WaitForSeconds(15);
        Destroy(gameObject);
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("player");
        playerrb = player.GetComponent<Rigidbody2D>();
        canva = GameObject.FindGameObjectWithTag("canva");
        CanUISpawn();
    }

    // Update is called once per frame
    void Update()
    {
        BakmaYonu();
        canui.transform.rotation = rb.transform.rotation;
        player playerscript = player.GetComponent<player>();
        
            canui.text = can.ToString();
        if (can <= 0)
        {
            animator.SetBool("death", true);
        }
        if (animator.GetBool("death") == false && playerscript.alive == true)
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
            rb.linearVelocity = new Vector2(0, 0);
            rb.transform.position = rb.transform.position;
            gameObject.GetComponent<SpriteRenderer>().sprite = death;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Animator>().enabled = false;
            rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y, 0.2f);
        }

    }
    void BakmaYonu()
    {
        if (player.transform.position.x - rb.transform.position.x > 0)
        {
            rb.transform.localScale = new Vector3(-0.7f, 0.7f, 0.7f);
        }
        else
        {
            rb.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }
    }
    public void CanUISpawn()
    {
        Instantiate(canui, canva.transform);
        print("canui canvada instantiatelendi");

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("deðdi");
        rb.linearVelocity = new Vector2(0, 0);
        if (collision.transform.tag == "player")
        {
            Vector2 hitdir = (rb.transform.position - playerrb.transform.position).normalized;
            collision.rigidbody.AddForce(hitdir * 100f, ForceMode2D.Impulse);
        }
    }
}
