using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro : MonoBehaviour
{
    [Header("Rodas")]
    [SerializeField] WheelCollider RodaTraseiraDireita;
    [SerializeField] WheelCollider RodaFrenteDireita;
    [SerializeField] WheelCollider RodaFrenteEsquerda;
    [SerializeField] WheelCollider RodaTraseiraEsquerda;

    [Header("Configuração de Movimento")]
    public float aceleracao = 900f;
    public float freio = 300f;
    public float anguloTorque = 50f;

    [Header("Luzes de Freio")]
    [SerializeField] Light luzFreioDireita;
    [SerializeField] Light luzFreioEsquerda;

    [Header("Vida do Carro")]
    public float vidaMaxima = 100f;
    private float vidaAtual;

    private float aceleracaoAtual = 0f;
    private float freioAtual = 0f;
    private float anguloTorqueAtual = 0f;

    private void Start()
    {
        vidaAtual = vidaMaxima;
    }

    private void FixedUpdate()
    {
        aceleracaoAtual = aceleracao * Input.GetAxis("Vertical");

        RodaFrenteDireita.motorTorque = aceleracaoAtual;
        RodaFrenteEsquerda.motorTorque = aceleracaoAtual;

        anguloTorqueAtual = anguloTorque * Input.GetAxis("Horizontal");

        RodaFrenteDireita.steerAngle = anguloTorqueAtual;
        RodaFrenteEsquerda.steerAngle = anguloTorqueAtual;

        if (Input.GetKey(KeyCode.Space))
        {
            freioAtual = freio;
        }
        else
        {
            freioAtual = 0f;
        }

        RodaFrenteDireita.brakeTorque = freioAtual;
        RodaFrenteEsquerda.brakeTorque = freioAtual;
        RodaTraseiraDireita.brakeTorque = freioAtual;
        RodaTraseiraEsquerda.brakeTorque = freioAtual;

        bool estaFreando = freioAtual > 0f;
        if (luzFreioDireita != null)
            luzFreioDireita.enabled = estaFreando;
        if (luzFreioEsquerda != null)
            luzFreioEsquerda.enabled = estaFreando;
    }

    // Receber dano do zumbi
    public void LevarDano(float dano)
    {
        vidaAtual -= dano;
        Debug.Log("Carro levou dano! Vida atual: " + vidaAtual);

        if (vidaAtual <= 0)
        {
            Debug.Log("O carro foi destruído!");
            // Aqui você pode chamar o Game Over ou reiniciar a cena
        }
    }

    // Matar zumbi ao colidir
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Zumbi atropelado!");
        }
    }
}
