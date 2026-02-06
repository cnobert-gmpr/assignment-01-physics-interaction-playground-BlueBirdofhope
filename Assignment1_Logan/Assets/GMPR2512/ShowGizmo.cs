using UnityEngine;

namespace GMPR2512
{
    public class ShowGizmo : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    
        [SerializeField] private Color _gizmoColour = Color.red;
        [SerializeField] private float _radius = 0.3f;

        void OnDrawGizmos()
        {
            Gizmos.color = _gizmoColour;
            Gizmos.DrawSphere(transform.position, _radius);
        }
    }
}
