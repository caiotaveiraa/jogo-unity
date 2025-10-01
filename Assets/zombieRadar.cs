using UnityEngine;

public class zombieRadar : MonoBehaviour
{
    private Transform target;
    public float range = 5f;
    public float speed = 3f;
    public float rotationSpeed = 10f;
    private Animator zombieAnim;

    public float damagePerSecond = 10f; // Dano que o zumbi causa ao carro

    void Start()
    {
        zombieAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            direction.y = 0;
            direction = direction.normalized;

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerCar"))
        {
            target = other.transform;
            zombieAnim.SetBool("runZombie", true);
            zombieAnim.SetBool("idleZombie", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerCar"))
        {
            target = null;
            zombieAnim.SetBool("runZombie", false);
            zombieAnim.SetBool("idleZombie", true);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerCar"))
        {
            Carro carro = collision.gameObject.GetComponent<Carro>();
            if (carro != null)
            {
                carro.LevarDano(damagePerSecond * Time.deltaTime);
            }
        }
    }
}
