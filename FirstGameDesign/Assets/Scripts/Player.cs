using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveAmount;
    protected Joystick joystick;

    private Animator anim;

    public int health;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Animator gethurt;

    private SceneTransition scene;


    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        scene = FindObjectOfType<SceneTransition>();
        joystick = FindObjectOfType<Joystick>();
    }

    private void Update()
    {

        Vector2 moveImput = new Vector2(Input.GetAxisRaw("Horizontal")+ joystick.Horizontal, Input.GetAxisRaw("Vertical") + joystick.Vertical);
        moveAmount = moveImput.normalized * speed;

        //Chequeo si se esta moviendo
        if (moveImput != Vector2.zero)
        {

            if (Input.GetKeyDown("left shift")) {
                anim.SetBool("isWalking", true);
                anim.SetBool("isAlsoRunning", true);
            }
            else {
                anim.SetBool("isWalking", true);
                anim.SetBool("isAlsoRunning", false);
            }
            
        }
        else {
            anim.SetBool("isWalking", false);
            anim.SetBool("isAlsoRunning", false);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }
    public void takeDamage(int damageAmount)
    {
        gethurt.GetComponent<Animator>().SetTrigger("hurt");
        health -= damageAmount;
        UpdateHealthUI(health);
        if (health <= 0)
        {
            Destroy(gameObject);
            scene.LoadScene("lose");
        }
    }
    public void ChangeWeapon(WeaponScript weapontoEquip) {
        Transform weaponPlace = GameObject.FindGameObjectWithTag("Weapon").transform;
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));

        weapontoEquip.tag = "Weapon";
        
        weapontoEquip.transform.localScale += new Vector3(0.7F, 0.7F, 0);
        
        Instantiate(weapontoEquip, weaponPlace.position, weaponPlace.rotation, transform);
        
    }
    void UpdateHealthUI(int currentHealth) {
        for (int i = 0; i < hearts.Length; i++) {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    public void Heal(int healAmount) {
        if (health + healAmount > 5)
        {
            health = 5;
        }
        else {
            health += healAmount;
        }
        UpdateHealthUI(health);
    }

    /*
    GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }*/

    

}
