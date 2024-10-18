using UnityEngine;

public class AlertSystem : MonoBehaviour
{
    // fov가 45라면 45도 각도안에 있는 aesteriod를 인식할 수 있음.
    [SerializeField] private float fov = 45f;
    // radius가 10이라면 반지름 10 범위에서 aesteriod들을 인식할 수 있음.
    [SerializeField] private float radius = 10f;
    private float alertThreshold;

    private Animator animator;
    private static readonly int blinking = Animator.StringToHash("isBlinking");

    private void Start()
    {
        animator = GetComponent<Animator>();
        // FOV를 라디안으로 변환하고 코사인 값을 계산
        float fovRadian = fov * (Mathf.PI / 180.0f);
        float fovCos = Mathf.Cos(fovRadian);
        alertThreshold = fovCos;
    }

    private void Update()
    {
        CheckAlert();
    }

    private void CheckAlert()
    {
        // 주변 반경의 소행성들을 확인하고 이를 감지하여 Alert를 발생시킴(isBlinking -> true)
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, radius);
        bool isObstructionExist = false;

        for (int i = 0; i < colls.Length; i++)
        {
            if (colls[i].gameObject.CompareTag("Obstruction"))
            {
                Vector2 positionToObstruction = colls[i].gameObject.transform.position - transform.position;
                float dotProduct = Vector2.Dot(transform.up, positionToObstruction.normalized);

                if (dotProduct >= alertThreshold && positionToObstruction.y > 0.0f)
                {
                    isObstructionExist = true;
                    break;
                }
            }
        }

        if (isObstructionExist)
        {
            Debug.Log("Obstuction!");
        }
    }
}