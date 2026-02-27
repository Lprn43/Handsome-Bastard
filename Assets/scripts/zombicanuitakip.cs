using UnityEngine;
using UnityEngine.UI;

public class zombicanuitakip : MonoBehaviour
{

    public GameObject p;
    public Rigidbody2D player, rb;
    public Text text;
    void Start()
    {
        p = GameObject.FindGameObjectWithTag("zombi");
        player = p.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        text.text = p.GetComponent<zombi>().can.ToString();
        if (p.GetComponent<Animator>().GetBool("olu") == true)
        {
            Destroy(gameObject);
        }
        rb.transform.position = new Vector3(x, y + 0.4f, rb.transform.position.z);
        p.tag = "uilizombi";
    }
}
