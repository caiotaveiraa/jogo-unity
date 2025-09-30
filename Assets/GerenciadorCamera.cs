using UnityEngine;

public class GerenciadorCamera : MonoBehaviour
{
    public Camera camera3Pessoa;
    public Camera cameraInterna;
    public Camera cameraRoda;

    void Start()
    {
        AtivarCamera(1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            AtivarCamera(1);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            AtivarCamera(2);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            AtivarCamera(3);
    }

    void AtivarCamera(int num)
    {
        camera3Pessoa.gameObject.SetActive(num == 1);
        cameraInterna.gameObject.SetActive(num == 2);
        cameraRoda.gameObject.SetActive(num == 3);
    }
}
