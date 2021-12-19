using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public int health = 100;
    public int lives = 3;
    public float flickerTime = 0f;
    public float flickerDuration = 0.1f;
    private SpriteRenderer spriteRenderer;
    public bool isImmune = false;
    public float immunityduration = 1.5f;
    public float immunityTime = 0f;
    public int coinsCollected = 0;
    public Text scoreUI;
    public Slider healthUI;
    public Gradient gradient;
    public Image fill;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        //fill.color = gradient.Evaluate(1f);
    }
    void SpriteFlicker()
    {
        if (this.flickerTime < this.flickerDuration)
            this.flickerTime += Time.deltaTime;
        else if (this.flickerTime >= this.flickerDuration)
        {
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            this.flickerTime = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (this.isImmune == true)
        {
            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityduration)
            {
                this.isImmune = false;
                this.spriteRenderer.enabled = true;
                Debug.Log("Immunity has ended");
            }
        }
        scoreUI.text = "" + coinsCollected;

        healthUI.value = health;
        //fill.color = gradient.Evaluate(healthUI.normalizedValue);
    }
    void playHitReaction()
    {
        this.isImmune = true;
        this.immunityTime = 0f;
    }
    public void TakeDamage(int damage)
    {
        if (this.isImmune == false)
        {
            this.health = this.health - damage;
            if (this.health < 0f)
                this.health = 0;
            if (this.lives > 0f && this.health == 0)
            {
                FindObjectOfType<LevelManager>().RespawnPlayer();
                this.health = 100;
                this.lives--;
            }
            else if (this.lives == 0 && this.health == 0)
            {
                (new NavigationController()).GoToGameOverScene();
                Debug.Log("GameOver");
                Destroy(this.gameObject);
            }
            Debug.Log("Player Health:" + this.health.ToString());
            Debug.Log("Player lives:" + this.lives.ToString());
        }
        playHitReaction();
    }

}