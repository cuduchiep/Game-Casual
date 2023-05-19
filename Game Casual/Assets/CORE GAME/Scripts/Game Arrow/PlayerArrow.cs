using UnityEngine;


    public class PlayerArrow : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _startSpawnPos;

        [SerializeField]
        private float _minX, _maxX;

        [SerializeField]
        private float _moveTime;

        [SerializeField]
        private ParticleSystem _trailParticle;

        [SerializeField]
        private GameObject _explosionPrefab;

        [SerializeField]
        private AudioClip _moveClip, _pointClip, _loseClip;

        private float speed;
        private bool canClick, canMove;

        private void Awake()
        {
            transform.position = _startSpawnPos;
            _trailParticle.Pause();
            canClick = false;
            canMove = false;
            speed = (_maxX - _minX) / _moveTime;
        }


        private void OnEnable()
        {
            GameArrowManager.Instance.GameStarted += GameStarted;
        }

        private void OnDisable()
        {
            GameArrowManager.Instance.GameStarted -= GameStarted;
        }

        private void GameStarted()
        {
            _trailParticle.Play();
            canMove = true;
            canClick = true;
        }

        private void Update()
        {
            if (!canClick) return;
            if (Input.GetMouseButtonDown(0))
            {
                AudioArrowManager.Instance.PlaySound(_moveClip);
                speed *= -1;
            }
        }

        private void FixedUpdate()
        {
            if (!canMove) return;

            transform.Translate(speed * Time.fixedDeltaTime * Vector3.right);
            if (transform.position.x < _minX || transform.position.x > _maxX) speed *= -1f;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(Constants.Tags.SCORE))
            {
                AudioArrowManager.Instance.PlaySound(_pointClip);
                collision.gameObject.GetComponent<ScoreArrow>().DestroySprite();
                GameArrowManager.Instance.UpdateScore();
                return;
            }

            if (collision.CompareTag(Constants.Tags.OBSTACLE))
            {
                AudioArrowManager.Instance.PlaySound(_loseClip);
                GameArrowManager.Instance.EndGame();
                Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
                canMove = false;
                canClick = false;
                return;
            }

        }
    }
