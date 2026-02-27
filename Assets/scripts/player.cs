using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public bool alive = true;
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer spriteRenderer;
    public Sprite death;
    public GameObject menu;
    public int can = 100;
    public Text canui;
    float sure;
    IEnumerator Dusmandamage()
    {
        can -= 20;
        yield return new WaitForSeconds(1);
    }
    void Start()
    {
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "zombi")
        {
            StartCoroutine
            sure += Time.deltaTime;
            if (sure > 1)
            {
                can -= 20;
                sure = 0;
            }
            //alive = false;
        }
    }*/


    void Update()
    {
        canui.text = can.ToString();
        if (can <= 0)
        {
            alive = false;
        }
        if (alive == true)
        {
            anim.enabled = true;
            if (Input.GetKey(KeyCode.W) == true)
            {
                rb.linearVelocityY = 1;
                //print("W basildi");
            }
            else if (Input.GetKey(KeyCode.S) == true)
            {
                rb.linearVelocityY = -1;
                //print("S basildi");
            }
            else if (Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.S) == false)
            {
                rb.linearVelocityY = 0;
            }
            if (Input.GetKey(KeyCode.D) == true)
            {
                rb.linearVelocityX = 1;
                //print("D basildi");
                rb.transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            else if (Input.GetKey(KeyCode.A) == true)
            {
                rb.linearVelocityX = -1;
                //print("A basildi");
                rb.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else if (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false)
            {
                rb.linearVelocityX = 0;
            }
            if (rb.linearVelocityY > 0 && rb.linearVelocityX > 0)
            {
                rb.linearVelocityX = 0.7071f;
                rb.linearVelocityY = 0.7071f;
            }
            else if (rb.linearVelocityY > 0 && rb.linearVelocityX < 0)
            {
                rb.linearVelocityX = -0.7071f;
                rb.linearVelocityY = 0.7071f;
            }
            else if (rb.linearVelocityY < 0 && rb.linearVelocityX > 0)
            {
                rb.linearVelocityX = 0.7071f;
                rb.linearVelocityY = -0.7071f;
            }
            else if (rb.linearVelocityY < 0 && rb.linearVelocityX < 0)
            {
                rb.linearVelocityX = -0.7071f;
                rb.linearVelocityY = -0.7071f;
            }

        }
        if(alive == false)
        {
            anim.SetBool("alive", false);
            rb.linearVelocityX = 0;
            rb.linearVelocityY = 0;
        }
        if (anim.GetBool("olu") == true)
        {
            spriteRenderer.sprite = death;
            menu.SetActive(true);
            anim.enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        can -= 20;
        Vector2 direction = (collision.transform.position - rb.transform.position).normalized;
    }
}
