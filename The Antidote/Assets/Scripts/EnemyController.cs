using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 100;
    public bool isFacingRight = false;
    public float maxSpeed = 3f;
    public int damage = 6;
    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnemyDamage(int damage)
    {
        
            this.health = this.health - damage;
            if (this.health < 0f)
                this.health = 0;
        if (this.health == 0 || this.health < 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.health -= damage;
        }
            
            Debug.Log("Enemy Health:" + this.health.ToString());  
    }
    
}
