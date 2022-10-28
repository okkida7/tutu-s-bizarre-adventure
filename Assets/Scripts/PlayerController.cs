using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// Takes and handles input and movement for a player character
public class PlayerController : ViewBase
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public SwordAttack swordAttack;
    private Health healthUI;
    public float health;
    private Color originalColor;
    public GameOver gameOver;
    [SerializeField] public AudioSource grassSound;
    [SerializeField] public AudioSource zone1Sound;
    [SerializeField] public AudioSource zone2Sound;
    [SerializeField] public AudioSource zone3Sound;
    [SerializeField] public AudioSource zone4Sound;
    public GameObject grassObject;
    public GameObject zone1Object;
    public GameObject zone2Object;
    public GameObject zone3Object;
    public GameObject zone4Object;
    public GameObject tutuAttack;
    public GameObject tutuDefeated;
    public UIBossHealth bossHealthBar;

    public UnityEngine.Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    public bool canMove = true;
    bool island = true;
    bool zone1 = false;
    bool zone2 = false;
    bool zone3 = false;
    bool zone4 = false;
    bool isActive1 = false;
    bool isActive2 = false;
    bool isActive3 = false;
    bool isActive4 = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void FixedUpdate(){
        if (canMove) {
            // If movement input is not 0, try to move
            if(movementInput != UnityEngine.Vector2.zero){
                
                bool success = TryMove(movementInput);
                if(!success) {
                    zone1Object.SetActive(false);
                    zone2Object.SetActive(false);
                    zone3Object.SetActive(false);
                    zone4Object.SetActive(false);
                    grassObject.SetActive(false);

                    success = TryMove(new UnityEngine.Vector2(movementInput.x, 0));
                }

                if(!success) {
                    zone1Object.SetActive(false);
                    zone2Object.SetActive(false);
                    zone3Object.SetActive(false);
                    zone4Object.SetActive(false);
                    grassObject.SetActive(false);

                    success = TryMove(new UnityEngine.Vector2(0, movementInput.y));
                }
                if(success){
                    if(zone1&&island){
                        zone1Object.SetActive(true);
                        zone2Object.SetActive(false);
                        zone3Object.SetActive(false);
                        zone4Object.SetActive(false);
                        grassObject.SetActive(false);
                    }
                    if(zone2&&island){
                        zone2Object.SetActive(true);
                        zone1Object.SetActive(false);
                        zone3Object.SetActive(false);
                        zone4Object.SetActive(false);
                        grassObject.SetActive(false);
                    }
                    if(zone3&&island){
                        zone3Object.SetActive(true);
                        zone1Object.SetActive(false);
                        zone2Object.SetActive(false);
                        zone4Object.SetActive(false);
                        grassObject.SetActive(false);
                    }
                    if(zone4&&island){
                        zone4Object.SetActive(true);
                        zone1Object.SetActive(false);
                        zone2Object.SetActive(false);
                        zone3Object.SetActive(false);
                        grassObject.SetActive(false);
                    }
                    if(!zone1&&!zone2&&!zone3&&!zone4){
                        zone1Object.SetActive(false);
                        zone2Object.SetActive(false);
                        zone3Object.SetActive(false);
                        zone4Object.SetActive(false);
                        grassObject.SetActive(true);
                    }
                    
                }
                
                animator.SetBool("isMoving", success);
            } else {
                animator.SetBool("isMoving", false);
                zone1Object.SetActive(false);
                zone2Object.SetActive(false);
                zone3Object.SetActive(false);
                zone4Object.SetActive(false);
                grassObject.SetActive(false);
            }

            // Set direction of sprite to movement direction
            if(movementInput.x < 0) {
                spriteRenderer.flipX = true;
            } else if (movementInput.x > 0) {
                spriteRenderer.flipX = false;
            }
        }
    }

    private bool TryMove(UnityEngine.Vector2 direction) {
        if(direction != UnityEngine.Vector2.zero) {
            // Check for potential collisions
            int count = rb.Cast(
                direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions
                movementFilter, // The settings that determine where a collision can occur on such as layers to collide with
                castCollisions, // List of collisions to store the found collisions into after the Cast is finished
                moveSpeed * Time.fixedDeltaTime + collisionOffset); // The amount to cast equal to the movement plus an offset
            if(count == 0){
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            } else {
                return false;
            }
        } else {
            // Can't move if there's no direction to move in
            return false;
        }
        
    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<UnityEngine.Vector2>();
    }

    void OnFire() {
        animator.SetTrigger("swordAttack");
    }

    public void SwordAttack() {
        LockMovement();
        zone1Object.SetActive(false);
        zone2Object.SetActive(false);
        zone3Object.SetActive(false);
        zone4Object.SetActive(false);
        grassObject.SetActive(false);
        tutuAttack.SetActive(true);
        if(spriteRenderer.flipX == true){
            swordAttack.AttackLeft();
        } else {
            swordAttack.AttackRight();
        }
    }

    public void HealthUI(){
        healthUI.Update();
    }


    public void EndSwordAttack() {
        tutuAttack.SetActive(false);
        swordAttack.StopAttack();
        UnlockMovement();
        zone1 = isActive1;
        zone2 = isActive2;
        zone3 = isActive3;
        zone4 = isActive4;
    }

    public void LockMovement() {
        canMove = false;
    }

    public void UnlockMovement() {
        canMove = true;
    }

    public float Health {
        set {
            health = value;
            if(health <= 0) {
                Defeated();
                //gameOver.Show();
                Invoke("GameOver", 5f);
                //Invoke("Exit", 1f);
            }
        }
        get {
            return health;
        }
    }
    
    private void GameOver(){
        gameOver.Show();
    }

    public void Defeated(){
        bossHealthBar.DestroyAll();
        animator.SetTrigger("Defeated");
        tutuDefeated.SetActive(true);
        Destroy(zone1Object);
        Destroy(zone2Object);
        Destroy(zone3Object);
        Destroy(zone4Object);
        Destroy(grassObject);
        Destroy(tutuAttack);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void Exit() {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

    public void FlashColor(float time){
        if(health>0){
            spriteRenderer.color = Color.red;
            Invoke("ResetColor", time);
        }
    }

    public void ResetColor(){
        spriteRenderer.color = originalColor;
    }

    private void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Zone1"){
            zone1 = true;
            isActive1 = zone1;
            isActive2 = false;
            isActive3 = false;
            isActive4 = false;
        }
        if(other.tag == "Zone2"){
            zone2 = true;
            isActive2 = zone2;
            isActive1 = false;
            isActive3 = false;
            isActive4 = false;
        }
        if(other.tag == "Zone3"){
            zone3 = true;
            isActive3 = zone3;
            isActive1 = false;
            isActive2 = false;
            isActive4 = false;
        }
        if(other.tag == "Zone4"){
            zone4 = true;
            isActive4 = zone4;
            isActive1 = false;
            isActive2 = false;
            isActive3 = false;
        }
        if (other.tag != "Zone1" && other.tag != "Zone2" && other.tag != "Zone3" && other.tag != "Zone4")
        {
            isActive1 = false;
            isActive2 = false;
            isActive3 = false;
            isActive4 = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Zone1"){
            zone1 = false;
            isActive1 = false;
        }
        if(other.tag == "Zone2"){
            zone2 = false;
            isActive2 = false;
        }
        if(other.tag == "Zone3"){
            zone3 = false;
            isActive3 = false;
        }
        if(other.tag == "Zone4"){
            zone4 = false;
            isActive4 = false;
        }
    }
}
