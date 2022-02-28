using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAIInteractions : MonoBehaviour
{
        public Transform raycastPoint;

    public void Interact(bool IsSpriteFlipped)
    {
        Debug.DrawRay(raycastPoint.position, IsSpriteFlipped ? Vector3.left : Vector3.right, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(raycastPoint.position, IsSpriteFlipped ? Vector3.left : Vector3.right,1);
        if(hit.collider != null)
        {
            if (hit.collider.GetComponent<NPC_Enemy>())
            {
                hit.collider.GetComponent<NPC_Enemy>().GetHit();
            }
            else if (hit.collider.GetComponent<NPC_Friendly>())
            {
                hit.collider.GetComponent<NPC_Friendly>().Talk();
            }
        }

    }
}
