using UnityEngine;

public class weapon : MonoBehaviour
{
    Ray2D ray;
    public Rigidbody2D player,gun,weaponpng,pistolsonu;
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 mousepos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        ray = new Ray2D(player.transform.position,mousepos);
        //Debug.DrawLine(player.transform.position, mousepos);
        Debug.Log(ray.direction);
        if (gun.transform.position.x - player.transform.position.x > 0)
        {
            weaponpng.transform.localScale = new Vector3(0.3f,-0.3f,0.3f);
        }
        else
        {
            weaponpng.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }

        gun.transform.right = -ray.direction;
        //gun.transform.rotation = new Quaternion(ray.direction.x,0,0,0);
        gun.transform.position = new Vector2(player.position.x + ray.direction.normalized.x*0.4f,player.position.y + ray.direction.normalized.y*0.4f);
        RaycastHit2D raycast = Physics2D.Raycast(pistolsonu.transform.position,mousepos);
        Debug.DrawLine(pistolsonu.transform.position,mousepos);
        if(raycast && Input.GetMouseButtonDown(0))
        {
            raycast.transform.gameObject.SetActive(false);
        }

    }
}
