using UnityEngine;

public class FarolCarro : MonoBehaviour
{
    public Light farolEsquerdo;
    public Light farolDireito;

    private bool faroisLigados = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            faroisLigados = !faroisLigados;

            farolEsquerdo.enabled = faroisLigados;
            farolDireito.enabled = faroisLigados;
        }
    }
}
