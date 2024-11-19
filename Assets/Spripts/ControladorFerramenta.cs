using TMPro;
using UnityEngine;

public class Ferramenta : MonoBehaviour
{
    [SerializeField] float velocidade;
    [SerializeField] float teto;
    [SerializeField] float chão;
    Geral geral;

    Rigidbody2D rb;
    int sentido = -1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        geral = GameObject.Find("Geral").GetComponent<Geral>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) velocidade = 800;
        transform.position += new Vector3(1, sentido, 0) * velocidade * Time.deltaTime;

        if(transform.position.y > teto) sentido = -1;
        if(transform.position.y < chão) sentido = 1;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        geral.GerarFerramenta();
        if (other.CompareTag("Player"))
        {
            geral.ScoreOnePoint();
        }
        if (other.CompareTag("Finish"))
        {
            geral.GameOver();            
        }
        Destroy(gameObject);
    }    

}
