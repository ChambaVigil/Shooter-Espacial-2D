using UnityEngine;

public class Fragment : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 direccion;
    public float tiempoDeVida = 3f;

    void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }

    void Update()
    {
        transform.Translate(direccion.normalized * speed * Time.deltaTime);
    }
}