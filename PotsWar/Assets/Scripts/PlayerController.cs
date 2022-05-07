using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    private Rigidbody2D rBody;
    private Animator animator;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 inputVector;
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = Input.GetAxisRaw("Vertical");
        inputVector.Normalize();

        rBody.velocity = inputVector * moveSpeed;

        animator.SetFloat("Speed", inputVector.sqrMagnitude);

        if (inputVector.sqrMagnitude != 0)
        {
            animator.SetFloat("Horizontal", inputVector.x);
            animator.SetFloat("Vertical", inputVector.y);

            if (inputVector.x > 0f)
                transform.localScale = new Vector3(-1f, 1f, 1f);
            else
                transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
