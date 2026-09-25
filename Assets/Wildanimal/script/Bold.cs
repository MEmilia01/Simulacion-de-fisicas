using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

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

        transform.position = Vector3.Lerp(transform.forward, dirObjetivo, velocidadgiro*Time.deltaTime);
        transform.position += transform.forward* velo* Time.deltaTime;
    }


    private Vector3 CalcularCohesion()
    { 
        Vector3 centro = Vector3.zero;
        int numvecinos = 0;

        foreach (Bold actualbold in manager.bolds)
        {
            if (actualbold == this) continue;
            if(Vector3.Distance(transform.position, actualbold.transform.position) < radio)
            {
                centro += actualbold.transform.position;
                numvecinos++;    
            }
        }
        centro/=numvecinos;
        return Vector3.zero;
    }
    private Vector3 CalcularAlineacion()
    { 
        Vector3 dir = Vector3.zero;

        foreach (Bold actualbold in manager.bolds)
        {
            if (actualbold == this) continue;
            if (Vector3.Distance(transform.position, actualbold.transform.position) < radio)
            {
                dir += actualbold.transform.position;
            }
        }
        return dir.normalized; 
    }
    private Vector3 CalcularSeparacion()
    {
        Vector3 dir = Vector3.zero;

        foreach (Bold actualbold in manager.bolds)
        {
            if (actualbold == this) continue;
            if (Vector3.Distance(transform.position,actualbold.transform.position) < radioSeparacion)
            {
                dir += (transform.position - actualbold.transform.position);
            }
        }
        return Vector3.zero;
    }
}
