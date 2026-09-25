using UnityEngine;

public class Bold : MonoBehaviour
{
    //aca pondremos las normas

    [Header("Movimiento")]
    public float velo = 2f;
    public float velocidadgiro = 2f;

    public float radio = 4f;
    public float radioSeparacion = 0.5f;
    public float pesoCohesion = 1f;
    public float pesoAlineacion = 1f;
    public float pesoSeparacion = 1.5f;

    BoldManager manager;

    private void Start()
    {
        manager = BoldManager.Instance;
    }

    private void Update()
    {
        Vector3 Cohesion = CalcularCohesion();
        Vector3 Alineacion = CalcularAlineacion();
        Vector3 Separacion = CalcularSeparacion();

        Vector3 dirObjetivo = Cohesion*pesoCohesion + Alineacion*pesoAlineacion + Separacion*pesoSeparacion;
        dirObjetivo.Normalize();

        transform.position = Vector3.Lerp(transform.forward, dirObjetivo, velocidadgiro);

        transform.position += transform.forward* velo* Time.deltaTime;
    }


    private Vector3 CalcularCohesion()
    { 
        Vector3 centro = Vector3.zero;
        int numvector = 0;

        foreach ()
        {

        }

        return Vector3.zero;
    }
    private Vector3 CalcularAlineacion()
    { return Vector3.zero; }
    private Vector3 CalcularSeparacion()
    { return Vector3.zero; }
}
