using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro : MonoBehaviour
{
    [SerializeField] WheelCollider RodaTraseiraDireita;
    [SerializeField] WheelCollider RodaFrenteDireita;
    [SerializeField] WheelCollider RodaFrenteEsquerda;
    [SerializeField] WheelCollider RodaTraseiraEsquerda;

    public float aceleracao = 500f;
    public float freio = 300f;
    public float anguloTorque = 15f;

    [SerializeField] Light luzFreioDireita; // Luz de freio direita
    [SerializeField] Light luzFreioEsquerda; // Luz de freio esquerda

    private float aceleracaoAtual = 0f;
    private float freioAtual = 0f;
    private float anguloTorqueAtual = 0f;

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

        // Acende as luzes de freio apenas enquanto estiver freando
        bool estaFreando = freioAtual > 0f;
        if (luzFreioDireita != null)
            luzFreioDireita.enabled = estaFreando;
        if (luzFreioEsquerda != null)
            luzFreioEsquerda.enabled = estaFreando;
    }
}
