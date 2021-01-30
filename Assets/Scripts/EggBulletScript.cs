using Assets.Scripts.Entities.Enums;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EggBulletScript : MonoBehaviour
{
    public Direction ThrownDirection;

    public int AttackDamage = 4;

    public float Speed = 5; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (ThrownDirection)
        {
            case Direction.Up:
                transform.position += new Vector3(0, Speed) * Time.deltaTime;
                break;
            case Direction.Right:
                transform.position += new Vector3(Speed, -0.001f) * Time.deltaTime;
                break;
            case Direction.Down:
                transform.position += new Vector3(0, -Speed) * Time.deltaTime;
                break;
            case Direction.Left:
                transform.position += new Vector3(-Speed, -0.001f) * Time.deltaTime;
                break;
        }

        Speed -= 0.1f;

        if (Speed < 0)
            Death(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {


            collision.gameObject.GetComponent<Attributes>().Health -= AttackDamage;
            Death(); 
        }
       // else if (collision.gameObject.tag ) //TODO: 
    }

    void Death()
    {
        var explosionPrefab = GameManager.GM.Prefabs.FirstOrDefault(x => x.Name == "Explosion");
        var mini = Instantiate(explosionPrefab.Prefab, transform.position, explosionPrefab.Prefab.transform.rotation);
        mini.transform.localScale = new Vector3(0.1f, 0.1f); 

        Destroy(gameObject);

    }
}
