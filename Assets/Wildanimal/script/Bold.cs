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
    public float anguloVista = 80f;

    public float pesoCohesion = 1f;
    public float pesoAlineacion = 1f;
    public float pesoSeparacion = 1.5f;
    public float pesolimite = 4f;
    public float pesoObstaculo = 4f;

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
        Vector3 Limite = CalcularLimite();
        Vector3 Obstaculo = CalcularDifObstaculo();

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
            if(Vector3.SqrMagnitude(transform.position - actualbold.transform.position) < radio * radio && EnVista(actualbold))
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
            if (Vector3.SqrMagnitude(transform.position - actualbold.transform.position) < radio * radio && EnVista(actualbold))
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
            if (Vector3.SqrMagnitude(transform.position - actualbold.transform.position) < radioSeparacion*radioSeparacion)
            {
                dir += (transform.position - actualbold.transform.position);
            }
        }
        return Vector3.zero;
    }

    private Vector3 CalcularLimite()
    {
        Vector3 dir = Vector3.zero;
        if (Vector3.SqrMagnitude(manager.transform.position - transform.position) < manager.radiozone * manager.radiozone)
        {
            return Vector3.zero;
        }
        return (manager.transform.position - transform.position).normalized;
    }
    private Vector3 CalcularDifObstaculo()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, radio, capaobjetos))
        {
            return hit.normal;
        }
        return (manager.transform.position - transform.position).normalized;
    }

    bool EnVista(Bold otros)
    {
        Vector3 dirOtros = otros.transform.position - transform.position;
        float angle = Vector3.Angle(transform.forward,dirOtros);
        if (angle < anguloVista) return true;
        return false;
    }
}
