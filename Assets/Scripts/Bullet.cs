using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public float maxLifetime = 5f;
    public Vector3 targetVector;
    public bool enUso = false; 
    private float tiempoActual = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        EsconderBala();
    }

    // Update is called once per frame
    void Update()
    {
        if (enUso == true)
        {
            transform.Translate(speed * targetVector * Time.deltaTime);
            tiempoActual += Time.deltaTime;
            
            if (tiempoActual >= maxLifetime)
            {
                EsconderBala(); 
            }
        }
    }

    public void Disparar(Vector3 posicionInicial, Vector3 direccion)
    {
        transform.position = posicionInicial;
        targetVector = direccion;
        tiempoActual = 0f; 
        enUso = true;
    }

    public void EsconderBala()
    {
        enUso = false;
        transform.position = new Vector3(9999, 9999, 0); 
    }

private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Enemy") && enUso)
    {
        IncreaseScore();
        
        Enemy enemigo = collision.gameObject.GetComponent<Enemy>();
        if (enemigo != null)
        {
            enemigo.Morir(); 
        }
        else
        {
            Fragment fragmento = collision.gameObject.GetComponent<Fragment>();
            if (fragmento != null)
            {
                Destroy(fragmento.gameObject); 
            }
        }

        EsconderBala();
    }
}

    private void IncreaseScore()
    {
        Player.SCORE++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Score: " + Player.SCORE;
    }
}
