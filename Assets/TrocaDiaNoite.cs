using UnityEngine;

public class TrocaDiaNoite : MonoBehaviour
{
    public Light luzDirecional; // Sol
    public Color corDia = Color.white;
    public Color corNoite = new Color(0.2f, 0.2f, 0.35f); // azul escuro

    public float intensidadeDia = 1f;
    public float intensidadeNoite = 0.2f;

    private bool estaDeDia = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AlternarDiaNoite();
        }
    }

    void AlternarDiaNoite()
    {
        estaDeDia = !estaDeDia;

        if (estaDeDia)
        {
            luzDirecional.color = corDia;
            luzDirecional.intensity = intensidadeDia;
            RenderSettings.ambientLight = Color.white;
        }
        else
        {
            luzDirecional.color = corNoite;
            luzDirecional.intensity = intensidadeNoite;
            RenderSettings.ambientLight = new Color(0.1f, 0.1f, 0.2f);
        }
    }
}
