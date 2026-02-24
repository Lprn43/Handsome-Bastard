using System.Collections;
using System.Threading;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;

public class weapon : MonoBehaviour
{
    
    public int capacity,reloadtime;
    int ammo;
    bool reload;
    Ray2D ray;
    public Rigidbody2D player,gun,weaponpng,pistolsonu;
    public Animator animator;
    public Sprite zombiedeath;
    public AudioSource audio1,audio2;
    public Text ac;
    public GameObject playerob,silah;
    //public Animator enemyanimator;
    IEnumerator Bekle()
    {
        print("bekle");
        yield return new WaitForSeconds(reloadtime);
        print("bekleme bitti");
        reload = false;
        ammo = capacity;
    }
    void Start()
    {
        ammo = capacity;
    }
    
    void Update()
    {
        Animator olu = playerob.GetComponent<Animator>();
        if (olu.GetBool("olu") == true)
        {
            silah.SetActive(false);
        }
        ac.text = ammo.ToString();
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = 0;

        Vector2 direction = (Vector2)mousepos - (Vector2)player.transform.position;

        gun.transform.position = (Vector2)player.position + direction.normalized * 0.4f;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0, 0, angle);

        if (Mathf.Abs(angle) > 90)
        {
            weaponpng.transform.localScale = new Vector3(0.3f, -0.3f, 0.3f);
        }
        else
        {
            weaponpng.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }

        if (Input.GetMouseButtonDown(0) && !reload)
        {
            RaycastHit2D hit = Physics2D.Raycast(pistolsonu.transform.position, direction);
            Debug.DrawRay(pistolsonu.transform.position, direction * 10, Color.red, 0.2f);
            audio1.Play(0);
            ammo--;
            print(ammo);
            if (hit.collider != null)
            {
                Animator enemyanimator = hit.collider.GetComponent<Animator>();
                hit.collider.GetComponent<SpriteRenderer>().sprite = zombiedeath;
                enemyanimator.SetBool("death", true);
            }

        }
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("shoot", true);
        }
        else animator.SetBool("shoot", false);
        
        if (Input.GetKeyDown(KeyCode.R) || ammo == 0 && ammo != 10)
        {
            audio2.Play(0);
            ammo = 0;
            reload = true;
            StartCoroutine(Bekle());
        }
        if(Input.GetMouseButtonDown(0) && reload == true){ print("reloaddayken ates ettin"); }
    }
}
