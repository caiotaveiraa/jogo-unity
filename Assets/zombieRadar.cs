using UnityEngine;

public class zombieRadar : MonoBehaviour
{
    private Transform target;
    public float range = 5f;
    public float speed = 3f;
    public float rotationSpeed = 10f;
    private Animator zombieAnim;

    void Start()
    {
        zombieAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (target != null)
        {
            // Calcula a direção horizontal ignorando a diferença de altura
            Vector3 direction = target.position - transform.position;
            direction.y = 0;
            direction = direction.normalized;

            // Rotaciona suavemente em direção ao personagem
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

            // Move o zumbi em direção ao personagem
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    // Detecta quando o personagem entra no trigger do zumbi
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Personagem"))
        {
            target = other.transform;
            zombieAnim.SetBool("runZombie", true);
            zombieAnim.SetBool("idleZombie", false);
        }
    }

    // Detecta quando o personagem sai do trigger do zumbi
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Personagem"))
        {
            target = null;
            zombieAnim.SetBool("runZombie", false);
            zombieAnim.SetBool("idleZombie", true);
        }
    }
}
