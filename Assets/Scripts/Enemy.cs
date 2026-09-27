using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject fragmentPrefab; 


    public float speed = 3f;
    void Update()
    {
    transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    
    public void Morir()
    {

        if (fragmentPrefab != null)
        {
            GameObject frag1 = Instantiate(fragmentPrefab, transform.position, Quaternion.identity);
            GameObject frag2 = Instantiate(fragmentPrefab, transform.position, Quaternion.identity);


            frag1.GetComponent<Fragment>().direccion = new Vector3(-1, -1, 0);
            frag2.GetComponent<Fragment>().direccion = new Vector3(1, -1, 0);
        }


        Destroy(gameObject);
    }
}