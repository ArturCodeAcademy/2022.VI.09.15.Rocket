using UnityEngine;

public class Borders : MonoBehaviour
{
    public static Borders Instance { get; private set; }

    public float LeftBorder { get; private set; }
    public float RightBorder { get; private set; }
    public float UpBorder { get; private set; }
    public float DownBorder { get; private set; }

    private void Awake()
    {
        Instance = this;
        Init();
	}

	private void Init()
    {
        Camera cam = Camera.main;
        UpBorder = cam.transform.position.y + cam.orthographicSize;
        DownBorder = cam.transform.position.y - cam.orthographicSize;
        LeftBorder = cam.transform.position.x - cam.orthographicSize * cam.aspect;
        RightBorder = cam.transform.position.x + cam.orthographicSize * cam.aspect;
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        if (UpBorder == 0 && DownBorder == 0 && LeftBorder == 0 && RightBorder == 0)
            Init();

        Gizmos.color = Color.green;
        Vector3 leftUp = new Vector3(LeftBorder, UpBorder);
        Vector3 rightUp = new Vector3(RightBorder, UpBorder);
        Vector3 leftDown = new Vector3(LeftBorder, DownBorder);
        Vector3 rightDown = new Vector3(RightBorder, DownBorder);

        Gizmos.DrawLine(leftUp, rightUp);
        Gizmos.DrawLine(leftDown, rightDown);
        Gizmos.DrawLine(leftDown, leftUp);
        Gizmos.DrawLine(rightDown, rightUp);
    }

#endif
}
