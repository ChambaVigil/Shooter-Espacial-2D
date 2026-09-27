using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public static int SCORE = 0;
    public float thrustForce = 10f;
    public float rotationSpeed = 120f;
    public float xBorderLimit = 8f;
    public float yBorderLimit = 4.5f;
    private Rigidbody rigidbody;

    public GameObject gun, bulletPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float rotation = Input.GetAxis("Horizontal") * Time.deltaTime;

        float thrust = Input.GetAxis("Vertical") * Time.deltaTime;
        Vector3 thrustDirection = transform.right;
        rigidbody.AddForce(thrustDirection * thrust * thrustForce);

        transform.Rotate(Vector3.forward, -rotation * rotationSpeed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = BulletPool.Instance.GetBullet();
            if (bullet != null)
            {
                bullet.GetComponent<Bullet>().Disparar(gun.transform.position, transform.right);
            }
        }

        Vector3 newPos = transform.position;

        if (newPos.x > xBorderLimit)
            newPos.x = -xBorderLimit + 1;
        else if (newPos.x < -xBorderLimit)
            newPos.x = xBorderLimit - 1;
        else if (newPos.y > yBorderLimit)
            newPos.y = -yBorderLimit + 1;
        else if (newPos.y < -yBorderLimit)
            newPos.y = yBorderLimit - 1;

        transform.position = newPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // o tambien "SampleScene" si quieres recargar la escena por nombre

        }
    }
}
