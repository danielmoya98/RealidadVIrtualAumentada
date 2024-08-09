using UnityEngine;

public class CharacterController1 : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;

    // Define los límites del plano
    float xMin = -10f, xMax = 10f, zMin = -10f, zMax = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento horizontal y vertical
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed * Time.deltaTime;
        transform.Translate(movement);

        // Limitar la posición a los límites definidos
        float clampedX = Mathf.Clamp(transform.position.x, xMin, xMax);
        float clampedZ = Mathf.Clamp(transform.position.z, zMin, zMax);
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);

        // Saltar si el personaje está en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el personaje está en contacto con el suelo
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Detecta si el personaje ha salido del contacto con el suelo
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
