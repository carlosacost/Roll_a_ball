using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JugadorController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float velocidad;
    private int contador;
    public Text textoContador, textoGanar;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        contador = 0;
        setTextoContador();
        //Inicio el texto de ganar a vacío
        textoGanar.text = "";
    }
    void FixedUpdate()
    {
        //Estas variables nos capturan el movimiento en horizontal y
        
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");
        //Un vector 3 es un trío de posiciones en el espacio XYZ, en este
        
      Vector3 movimiento = new Vector3(movimientoH, 0.0f,
                     movimientoV);
        //Asigno ese movimiento o desplazamiento a mi RigidBody
        rb.AddForce(movimiento * velocidad);
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coleccionable"))
        {
            other.gameObject.SetActive(false);
            contador = contador + 1;
            setTextoContador();
        }
    }
    void setTextoContador()
    {
        textoContador.text = "Contador: " + contador.ToString();
        if (contador >= 12)
        {
            textoGanar.text = "¡Ganaste!";
        }
    }
}
