using UnityEngine;

public class EnemyFlashLight : MonoBehaviour
{
    public Light flashlight;
    public float interval = 4f;     // cada cuanto prende
    public float onDuration = 1f;   // cuanto dura prendida
    public float rayDistance = 20f; // distancia del raycast

    private bool isOn = false;

    void Start()
    {
        StartCoroutine(FlashRoutine());
    }

    System.Collections.IEnumerator FlashRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            // prender linterna
            flashlight.enabled = true;
            isOn = true;

            // check si ves al jugador
            CheckPlayerHit();

            yield return new WaitForSeconds(onDuration);

            // apagar linterna
            flashlight.enabled = false;
            isOn = false;
        }
    }

    void CheckPlayerHit()
{
    Debug.DrawRay(transform.position + Vector3.up, transform.forward * rayDistance, Color.red, 1f);

    if (Physics.Raycast(transform.position + Vector3.up, transform.forward,
        out RaycastHit hit, rayDistance))
    {
        Debug.Log("Pegó contra: " + hit.collider.name);

        if (hit.collider.CompareTag("Player"))
        {
            Debug.Log("PERDISTE");
        }
    }
    else
    {
        Debug.Log("Raycast no tocó nada");
    }
}

}
