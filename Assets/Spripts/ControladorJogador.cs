using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float velocidade = 10;
    [SerializeField] float teto = 468;
    [SerializeField] float chão = 32;
    [SerializeField] float parede = 960;
    
    void Start()
    {
        
    }

    void Update()
    {
        MãozinhaMexer();
    }

    private void MãozinhaMexer()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.position += new Vector3(input.x, input.y, 0) * velocidade * Time.deltaTime;
        transform.position = new Vector3 (transform.position.x, Mathf.Clamp(transform.position.y, chão, teto), 0);
        transform.position = new Vector3 (Mathf.Clamp(transform.position.x, 0, parede), transform.position.y, 0);
    }
}