using UnityEngine;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class MovementScript : MonoBehaviour
{
    private SpriteRenderer objectRender;

    /// <summary>
    /// Object speed
    /// </summary>
    public Vector2 speed = new Vector2(1000, 10);

    /// <summary>
    /// Moving direction
    /// </summary>
    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;

    void Update()
    {
        // 2 - Movement
        movement = new Vector2(
          speed.x * direction.x,
          speed.y * direction.y);

        objectRender = GetComponent<SpriteRenderer>();
        if (!objectRender.IsVisibleFrom(Camera.main))
        {
            Destroy(gameObject, 0);
        }
    }

    void FixedUpdate()
    {
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        // Apply movement to the rigidbody
        rigidbodyComponent.velocity = movement;
    }
}