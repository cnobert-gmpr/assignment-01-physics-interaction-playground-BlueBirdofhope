using System.Collections;
using UnityEngine;

namespace GMPR2512.Lesson05Coroutines
{
    public class Bumper : MonoBehaviour
    {
        [SerializeField] float _bumperForce = 5, _litDuration =0.2f;

        [SerializeField] private Color _litColour = Color.yellow;

        private bool _isLit = false;
        private Color _originalColour;
        private SpriteRenderer _spriteRenderer;

        void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _originalColour = _spriteRenderer.color;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Ball"))
            {
                #region 
            
                Debug.Log("KAppow");
                Vector2 normal = Vector2.zero;
                if(collision.rigidbody != null)
                {
                    if(collision.contactCount > 0)
                    {
                        
                        ContactPoint2D contact = collision.GetContact(0);
                        normal = contact.normal;
                    }
                    else if (normal ==Vector2.zero){
                        Vector2 direction = (collision.rigidbody.position-(Vector2)transform.position).normalized;
                        normal = direction;
                    }
                    Vector2 impulse = normal * _bumperForce;
                    collision.rigidbody.AddForce(impulse, ForceMode2D.Impulse);
                }
                #endregion

                if(!_isLit){
                    StartCoroutine(LightUp());
                }
            }
        }
        private IEnumerator LightUp(){
            _spriteRenderer.color = _litColour;
            yield return new WaitForSeconds(_litDuration);
            _spriteRenderer.color =_originalColour;
            _isLit = false;
        }
    }
}
