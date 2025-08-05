using UnityEngine;
public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] CannonShake cannonShake;
    [SerializeField] ParticleSystem firePS;
    [SerializeField] CameraFollow cameraFollow;
    public ProjectileSO projectileSO;
    public Transform launchPoint;
    public GameObject projectile;
    public float launchSpeed = 10f;

    [Header("Trajectory Display")]
    public LineRenderer lineRenderer;
    public int linePoints = 175;
    public float timeIntervalInPoints = 0.01f;

    public bool isDrawing = true;


    private void Start()
    {
        FlyingStone.OnMissionComplete += OnMissionComplete;
        firePS.Stop();
    }

    private void OnMissionComplete()
    {
        lineRenderer.enabled = true;        
    }

    void Update()
    {
        DrawTrajectory();
      /*  if (lineRenderer != null)
        {
            if(isDrawing)
            {
                DrawTrajectory();
                lineRenderer.enabled = true;
            }
            else
                lineRenderer.enabled = false;
        }*/
    }

    public void ThrowStone()
    {
        cannonShake.Fire();
        firePS.Play();

        lineRenderer.enabled = false;
        Quaternion rot = launchPoint.rotation;
        rot.x = projectileSO.angleX;
        rot.y = projectileSO.angleY;
        rot.z = projectileSO.angleZ;
        var _projectile = Instantiate(projectile, launchPoint.position, rot);
        _projectile.GetComponent<Rigidbody>().linearVelocity = projectileSO.speed * launchPoint.up;
        _projectile.GetComponent<Rigidbody>().mass = projectileSO.mass;
        cameraFollow.SetTarget(_projectile.transform);
    }
 
    void DrawTrajectory()
    {
        Vector3 origin = launchPoint.position;
        Vector3 startVelocity = projectileSO.speed * launchPoint.up;

        lineRenderer.positionCount = linePoints;
        float time = 0;
        for (int i = 0; i < linePoints; i++)
        {
            var x = (startVelocity.x * time) + (Physics.gravity.x / 2 * time * time);
            var y = (startVelocity.y * time) + (Physics.gravity.y / 2 * time * time);
            var z= (startVelocity.z * time) + (Physics.gravity.z / 2 * time * time);
            Vector3 point = new Vector3(x, y, z);
            lineRenderer.SetPosition(i, origin + point);
            time += timeIntervalInPoints;
        }
    }
}