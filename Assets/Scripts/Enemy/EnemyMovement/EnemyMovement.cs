using UnityEngine;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        public IMovingPattern MovingPattern;

        public float enemySpeed;
        // Start is called before the first frame update
        void Start()
        {
            MovingPattern = new FollowPlayerPattern();
        }

        // Update is called once per frame
        void Update()
        {
            MovingPattern.Move(new EnemyMovementInformation(gameObject.transform, enemySpeed, gameObject.GetComponent<Rigidbody2D>(), gameObject.GetComponent<SpriteRenderer>()));
        
        }
    }
}

