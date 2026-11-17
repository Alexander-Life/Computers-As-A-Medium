using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float speedX = 0f;
    private float speedY = 0f;
    public Rigidbody2D rb;

    public SpriteRenderer spriteRenderer;
    public Sprite beartop;
    public Sprite beardown;
    public Sprite bearleft;
    public Sprite bearright;
    public GameObject weapon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {

        // Horizontal Movement
        if (Keyboard.current.aKey.isPressed)
        {
            speedX = -moveSpeed;
            spriteRenderer.sprite = bearleft;
            weapon.transform.localScale = new Vector3(-1, 1, 1);
            weapon.transform.localRotation = Quaternion.Euler(0, 0, 0);
            weapon.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            speedX = moveSpeed;
            spriteRenderer.sprite = bearright;
            weapon.transform.localScale = new Vector3(1, 1, 1);
            weapon.transform.localRotation = Quaternion.Euler(0, 0, 0);
            weapon.transform.localPosition = new Vector3(0, 0, 0);
        }
        else
        {
            speedX = 0;
        }

        // Vertical Movement
        if (Keyboard.current.wKey.isPressed)
        {
            speedY = moveSpeed;
            spriteRenderer.sprite = beartop;
            weapon.transform.localRotation = Quaternion.Euler(0, 0, 92);
            weapon.transform.localPosition = new Vector3(0.6f, 1, 0);
            //the transforms you see set to 0 0 0 or 1 1 1 are to reset their transforms so the they do not stack -Alex
            weapon.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            speedY = -moveSpeed;
            spriteRenderer.sprite = beardown;
            weapon.transform.localRotation = Quaternion.Euler(0, 0, -89);
            weapon.transform.localPosition = new Vector3(0.6f, -1.15f, 0);
            weapon.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            speedY = 0;
        }

        rb.linearVelocity = new Vector2(speedX, speedY);
    }
}
