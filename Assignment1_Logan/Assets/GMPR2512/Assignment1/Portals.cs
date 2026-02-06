using System.Collections;
using UnityEngine;

namespace GMPR2512.Lesson05Coroutines
{
    public class Portals : MonoBehaviour
    {
        [SerializeField] private Transform _portal;
        [SerializeField] private float _respawnDelay = 0.5f, _coolDown = 4f, _litDuration = 0.4f;

        [SerializeField] private Color _litColour = new Color(0f, 71f, 146f);
        private bool _telporting = false;

        private bool _isLit = false;

        private Color _originColour;

        private SpriteRenderer _spriteRender;

        void Awake()
        {
            _spriteRender = GetComponent<SpriteRenderer>();
            _originColour = _spriteRender.color;
        }
        void OnTriggerEnter2D(Collider2D collider2D)
        {
            GameObject ball = collider2D.gameObject;
            if (!_telporting)
            {
                
                _telporting = true;
                _portal.GetComponent<Portals>()._telporting = true;
                StartCoroutine(Transport(ball));
                if(!_isLit){
                    StartCoroutine(LightUp());
                }
            }
        }
        private IEnumerator Transport(GameObject ball)
        {
            yield return new WaitForSeconds(_respawnDelay);
            ball.transform.position = _portal.position;
            yield return new WaitForSeconds(_coolDown);
            _telporting = false;
            _portal.GetComponent<Portals>()._telporting = false;
        }

        private IEnumerator LightUp(){
            _spriteRender.color = _litColour;
            yield return new WaitForSeconds(_litDuration);
            _spriteRender.color =_originColour;
            _isLit = false;
        }
    }
}
