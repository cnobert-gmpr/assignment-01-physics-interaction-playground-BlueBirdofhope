using System.Collections;
using UnityEngine;

namespace GMPR2512.Lesson05Coroutines
{
    public class FreezeZone : MonoBehaviour
    {
        [SerializeField] private float _freezeDuration = 2f;

        private bool _isFreezing = false;

        void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (_isFreezing || !collider2D.CompareTag("Ball"))
            {
                return;
            }

            Rigidbody2D ballRb = collider2D.GetComponent<Rigidbody2D>();
            if (ballRb == null)
            {
                return;
            }

            StartCoroutine(FreezeBall(ballRb));
        }

        private IEnumerator FreezeBall(Rigidbody2D ballRb)
        {
            _isFreezing = true;

            Vector2 savedVelocity = ballRb.linearVelocity;
            float savedAngularVelocity = ballRb.angularVelocity;
            RigidbodyConstraints2D savedConstraints = ballRb.constraints;

            ballRb.linearVelocity = Vector2.zero;
            ballRb.angularVelocity = 0f;
            ballRb.constraints = RigidbodyConstraints2D.FreezeAll;

            yield return new WaitForSeconds(_freezeDuration);

            ballRb.constraints = savedConstraints;
            ballRb.linearVelocity = savedVelocity;
            ballRb.angularVelocity = savedAngularVelocity;

            _isFreezing = false;
        }
    }
}
