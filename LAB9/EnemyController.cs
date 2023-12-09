using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float reactionRadius = 5f; // Promieñ, w którym wróg zareaguje na gracza

    private Rigidbody2D rb;
    private Transform target;
    private GameObject player; // Obiekt gracza
    private bool chasingPlayer = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player"); // gracz po tagu
        target = pointA; //  poruszaniam siê do punktu A
    }

    private void Update()
    {
        // SprawdŸ czy gracz jest w zasiêgu
        if (player != null && Vector2.Distance(transform.position, player.transform.position) <= reactionRadius)
        {
            chasingPlayer = true;
            target = player.transform; // gonie playera
        }
        else
        {
            chasingPlayer = false;
            // Jeœli wróg jest bli¿ej punktu A, ustawiam go jako cel, w przeciwnym razie celuj w punkt B
            target = (Vector2.Distance(transform.position, pointA.position) <= Vector2.Distance(transform.position, pointB.position)) ? pointA : pointB;
        }

        // Poruszam siê w kierunku celu
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        float step = moveSpeed * Time.deltaTime;
        rb.velocity = new Vector2((target.position.x - transform.position.x) * step, rb.velocity.y);

        // obracam wroga w kierunku ruchu
        if (rb.velocity.x > 0 && !chasingPlayer)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (rb.velocity.x < 0 && !chasingPlayer)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    // Zmiana kierunku po osi¹gniêciu punktu patrolu?
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!chasingPlayer && collision.gameObject.CompareTag("patrolPoint"))
        {
            target = target == pointA ? pointB : pointA;
        }
    }
}
