using System.Collections;
using System.Threading;
using UnityEngine;

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
        // 1. Mouse pozisyonunu al
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = 0; // 2D olduðu için Z'yi sýfýrla

        // 2. Yönü hesapla (Hedef - Baþlangýç)
        Vector2 direction = (Vector2)mousepos - (Vector2)player.transform.position;

        // 3. Silahýn pozisyonunu karakterin etrafýnda sabitle (0.4f birim uzaklýkta)
        gun.transform.position = (Vector2)player.position + direction.normalized * 0.4f;

        // 4. Silahýn rotasyonunu ayarla
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0, 0, angle);

        // 5. Görselin ters dönmesini engelle (Senin yaptýðýn scale mantýðý)
        // Silah saða bakýyorsa normal, sola bakýyorsa Y ekseninde ters çevir (Upside down olmamasý için)
        if (Mathf.Abs(angle) > 90)
        {
            weaponpng.transform.localScale = new Vector3(0.3f, -0.3f, 0.3f);
        }
        else
        {
            weaponpng.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }

        // 6. Ateþ etme ve Raycast (Hedef mousepos olmalý, mesafe sýnýrlanabilir)
        if (Input.GetMouseButtonDown(0) && !reload)
        {
            // Raycast'i silahtan fareye doðru atýyoruz
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
        
        // ... Reload kodlarýn ayný kalabilir
        if (Input.GetKeyDown(KeyCode.R) || ammo == 0)
        {
            audio2.Play(0);
            reload = true;
            StartCoroutine(Bekle());
        }
        if(Input.GetMouseButtonDown(0) && reload == true){ print("reloaddayken ates ettin"); }
        /*if (Input.GetMouseButtonDown(0) && reload == false)
        {
            ammo--;
            print(ammo);
            if (raycast && raycast.transform.gameObject.tag == "zombi" && reload == false)
            {
                raycast.transform.gameObject.SetActive(false);
                print(raycast.transform.gameObject.tag);
            }
        }*/
        

    }
}
