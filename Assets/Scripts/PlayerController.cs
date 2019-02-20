using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]


public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpSpeed = 5f;

    [Space]

    [SerializeField]
    [Range(0, 100)]
    private float lookSensitivity = 10f;

    private Vector3 movement;

    private float gravity = -0.2f;
    private float maxFallSpeed = -1f;
    private CharacterController controller;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        movement = Vector3.zero;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("Cancel"))
            SceneManager.LoadScene("Game");

        float turn = Input.GetAxis("Turn") * lookSensitivity;

        transform.Rotate(new Vector3(0, turn, 0));

        movement = new Vector3(0, movement.y, 0);
        movement += Input.GetAxis("Vertical") * transform.forward * Time.deltaTime * moveSpeed;
        movement += Input.GetAxis("Horizontal") * transform.right * Time.deltaTime * moveSpeed;
        anim.SetFloat("Forward", Input.GetAxis("Vertical"));
        anim.SetFloat("Strafe", Input.GetAxis("Horizontal"));

        if (controller.isGrounded)
        {
            anim.SetBool("InAir", false);
            movement.y = 0;
            if (Input.GetButton("Jump"))
                movement.y = jumpSpeed / 10;
        }
        else
        {
           
            if (movement.y > maxFallSpeed)
            {
                movement.y += gravity * Time.deltaTime;
            }

            else if (movement.y < maxFallSpeed)
            {
                movement.y = maxFallSpeed;
            }

            if (Mathf.Abs(movement.y) > 0.01)
                anim.SetBool("InAir", true);
        }

        controller.Move(movement);
    }
}

