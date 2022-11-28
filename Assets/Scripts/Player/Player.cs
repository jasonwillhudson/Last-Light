using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

#region REQUIRE COMPONENTS

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(PlayerControl))]
[RequireComponent(typeof(MovementByVelocityEvent))]
[RequireComponent(typeof(MovementByVelocity))]
[RequireComponent(typeof(AnimatePlayer))]
[RequireComponent(typeof(SortingGroup))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(IdleEvent))]
[RequireComponent(typeof(Idle))]
[RequireComponent(typeof(AimWeapon))]
[RequireComponent(typeof(AimWeaponEvent))]
[RequireComponent(typeof(Idle))]
[DisallowMultipleComponent]
#endregion REQUIRE COMPONENTS



public class Player : MonoBehaviour
{
    [HideInInspector] public PlayerDetail playerDetail;
    [HideInInspector] public Health health;
    [HideInInspector] public PlayerControl playerControl;
    [HideInInspector] public MovementByVelocityEvent movementByVelocityEvent;
    [HideInInspector] public MovementToPositionEvent movementToPositionEvent;
    [HideInInspector] public IdleEvent idleEvent;
    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Animator animator;
    [HideInInspector] public AimWeaponEvent aimWeaponEvent;
    [HideInInspector] public PlayerAttackEvent playerAttackEvent;

    public static Player instance;
    public GameObject healthDisplay;

    public int attackDamage = 60;
    public TMP_Text DamageDisplay;
    public GameObject gameover;

    private void Awake()
    {
        instance = this;
        Debug.Log("Player Loading ...");
        // Load components
        health = GetComponent<Health>();
        playerControl = GetComponent<PlayerControl>();
        movementByVelocityEvent = GetComponent<MovementByVelocityEvent>();
        movementToPositionEvent = GetComponent<MovementToPositionEvent>();
        idleEvent = GetComponent<IdleEvent>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        aimWeaponEvent = GetComponent<AimWeaponEvent>();

        //Load Player Attack
        playerAttackEvent = GetComponent<PlayerAttackEvent>();

        //set up the health
        healthDisplay = GameObject.Find("Health");
        health.SetStartHealth(3);

    }

    private void Start()
    {
        GameObject.Find("game over").GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Update()
    {

        //get the health value right now
        int healthValue = health.getHealth();
        

        if (healthValue <= 0)
        {
            healthDisplay.SetActive(false);
            GameObject.Find("UI").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("UI Controller").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("game over").GetComponent<SpriteRenderer>().enabled = true;
            Destroy(this.gameObject);
        }
        else
        {

            //Display the health that suppose to be displayed
            for(int i=0; i<healthValue; i++)
            {
                healthDisplay.transform.GetChild(i).gameObject.SetActive(true);
            }

            //Hide the hearts that supposed to be hide
            for(int i=healthValue; i<6; i++)
            {
                healthDisplay.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        //change the display text
        DamageDisplay.text  = "AD "+attackDamage; 
    }
    /// <summary>
    /// Initialize the player
    /// </summary>
    public void Initialize(PlayerDetail playerDetail)
    {
        this.playerDetail = playerDetail;

  
    }

    public void InitializeHealth()
    {
        // Set player starting health
        health.SetStartHealth(3);
    }


    /// <summary>
    /// Returns the player position
    /// </summary>
    public Vector3 GetPlayerPosition()
    {
        return transform.position;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (collision.gameObject.CompareTag("HealthPortion"))
        {
            Destroy(collision.gameObject);
            health.gainHealth(1);
        }
        switch (obj.tag)
        {

            case "HealthPortion":
                Destroy(collision.gameObject);
                health.gainHealth(1);
                transform.Find("pickupHeartEffect").GetComponent<ParticleSystem>().Play();
                break;

            case "AttackBonus":
                Destroy(collision.gameObject);
                this.attackDamage += 2;
                break;


            default:
                break;
        }

    }

}
