using UnityEngine;
using System.Collections;

/// <Resumen>
/// Script para que la carta rote correctamente.
/// </Resumen>

[ExecuteInEditMode]
public class BetterCardRotation : MonoBehaviour {

    // Parent de todos los elementos del frente de la carta
    public RectTransform CardFront;

    // Parent de todos los elementos del revés de la carta
    public RectTransform CardBack;

    // Un GameObject vacío 
    public Transform targetFacePoint;

    // Box COllider de la carta
    public Collider col;

    // Boolana ¿Frente o revés? 
    private bool showingBack = false;

	// Update is called once per frame
	void Update () 
    {
        // Raycast de la Cámara a un punto del frente de la carta, si pasa por el box collider, mostrar el "back"
        RaycastHit[] hits;
        hits = Physics.RaycastAll(origin: Camera.main.transform.position, direction: (-Camera.main.transform.position + targetFacePoint.position).normalized, 
            maxDistance: (-Camera.main.transform.position + targetFacePoint.position).magnitude) ;

        bool passedThroughColliderOnCard = false;

        foreach (RaycastHit h in hits)
        {
            if (h.collider == col)
                passedThroughColliderOnCard = true;
        }

        if (passedThroughColliderOnCard!= showingBack)
        {
            // Leer si algo cambió
            showingBack = passedThroughColliderOnCard;
            if (showingBack)
            {
                // Mostrar revés
                CardFront.gameObject.SetActive(false);
                CardBack.gameObject.SetActive(true);
            }
            else
            {
                // Mostrar Frente
                CardFront.gameObject.SetActive(true);
                CardBack.gameObject.SetActive(false);
            }

        }

	}
}
