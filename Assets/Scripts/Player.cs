using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public List<Sprite> ufosSprites = new List<Sprite>();

    [HideInInspector] public bool started;
    [HideInInspector] public bool loadingAdCanvasShowing;
    [HideInInspector] public int movementForce;
    [HideInInspector] public SpriteRenderer spriteRenderer;

    Rigidbody2D rb;
    int jumpForce = 11;
    float gravityScale = 3.5f;
    AudioSource jumpSound;
    ShopCanvas shopCanvasScript;
    GameObject shopCanvas;
    AdsManager adsManagerScript;
    TrailRendererManager trailRendererManagerScript;

    void Start()
    {
        AssignVariables();
        CreateRandomMovementForce();
    }

    void AssignVariables()
    {
        movementForce = 10;
        rb = GetComponent<Rigidbody2D>();
        jumpSound = GameObject.FindGameObjectWithTag("JumpSound").GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        shopCanvasScript = GameObject.FindObjectOfType<ShopCanvas>();
        shopCanvas = GameObject.FindGameObjectWithTag("ShopCanvas");
        adsManagerScript = GameObject.FindObjectOfType<AdsManager>();
        trailRendererManagerScript = GameObject.FindObjectOfType<TrailRendererManager>();
    }

    void CreateRandomMovementForce()
    {
        int randomNumber = Random.Range(1, 3);
        
        if(randomNumber == 1)
        {
            movementForce = 6;
        }

        if(randomNumber == 2)
        {
            movementForce = -6;
        }
    }

    void Update()
    {
        Jump();
        Movement();
    }

    void Jump()
    {
        if(Input.GetMouseButtonDown(0) && !isAnyButtonPressed() && !loadingAdCanvasShowing && !adsManagerScript.showingRewardedAd)
        {
            started = true;
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void Movement()
    {
        if(started)
        {
            shopCanvas.SetActive(false);
            rb.gravityScale = gravityScale;
            rb.velocity = new Vector2(movementForce, rb.velocity.y);
        }
    }

    bool isAnyButtonPressed()
    {
        ButtonPressingManager[] buttonPressingManagerArray = GameObject.FindObjectsOfType<ButtonPressingManager>();
        List<ButtonPressingManager> buttonPressingManagerScripts = new List<ButtonPressingManager>();

        foreach(var buttonPressingManager in buttonPressingManagerArray)
        {
            buttonPressingManagerScripts.Add(buttonPressingManager);
        }

        foreach(var buttonPressingManagerScript in buttonPressingManagerScripts)
        {
            if(buttonPressingManagerScript.buttonPressed == true)
            {
                return true;
            }
        }

        return false;
    }

    public bool isPlayerMovingRight()
    {
        if(movementForce > 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool isPlayerMovingLeft()
    {
        if(movementForce < 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }

    public void SetSpriteRenderer(int selectedSprite)
    {
        spriteRenderer.sprite = ufosSprites[selectedSprite];
        trailRendererManagerScript.SetTrailColor(selectedSprite);
    }
}
