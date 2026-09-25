using UnityEngine;
using System.Collections.Generic;

public class BoldManager : MonoBehaviour
{
    public static BoldManager Instance(get; private set;);
    [SerializeField] GameObject boldprefab;

    //spaw info
    public int cantidad = 5;
    public int radioSpaw = 5;

    public List<Bold> bolds = new List<Bold> ();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        { Destroy(this.gameObject;)}
        else { Instance = this; }
    }

    private void start()
    {
        for (int i = 0; i < cantidad; i++)
        {
            GameObject go = Instantiate(boldprefab, this.transform.position + Random.insideUnitSphere + radioSpaw, Random.rotation);
            bolds.Add
        }
    }

}
