using System;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraLookSequence : MonoBehaviour
{
    [SerializeField] Vector3 cameraOffsetPos;
    [SerializeField] Vector3 cameraOffsetRot;
    //[SerializeField] CameraFollow cameraFollow;
    [SerializeField] IntroCameraWork introCameraWork;
    [SerializeField] GameObject[] targets;
    CancellationTokenSource cts = new CancellationTokenSource();
    Vector3 originPos;
    Quaternion rotation;
    bool isRunning = true;


    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StopCameraWork();
            SceneManager.LoadScene("StoneHenge");
        }
    }

    public void Initialize()
    {
        this.transform.position = cameraOffsetPos;
        this.transform.rotation = Quaternion.Euler(cameraOffsetRot);
        CancellationToken token = cts.Token;
        isRunning = true;
        
        StartCameraSequence(token);
    }   

    async void StartCameraSequence(CancellationToken token)
    {
        while (isRunning)
        {
            foreach (GameObject target in targets)
            {
                try
                {
                    token.ThrowIfCancellationRequested();
                }
                catch (Exception)
                {
                    //cameraFollow.Restore();
                    break;
                }

                introCameraWork_PlayAnime(target);

                await LookAtTarget(target.transform, token);

                await Task.Delay(1000); // Wait 1 second
            }
        }

        async Task introCameraWork_PlayAnime(GameObject target)
        {
            if (target == null)
            {
                Debug.Log("Target object is null. Cannot play animation.");
                return;
            }
            introCameraWork.PlayAnimationByName(target);
        }
    }

    async Task LookAtTarget(Transform target, CancellationToken token)
    {
        //worldSpaceNameTag.DisplayTextType(target.name);

        float elapsed = 0f;
        float duration = 1.5f;
        float smoothSpeed = 6;
        //Vector3 offset = new Vector3(0, 5, -10);
        Vector3 targetCamPos = target.position + cameraOffsetPos;

        while (elapsed < duration)
        {
            try
            {
                token.ThrowIfCancellationRequested();
            }
            catch (Exception)
            {
                //cameraFollow.Restore();
                break;
            }
            elapsed += Time.deltaTime;

            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothSpeed * Time.deltaTime);
            transform.LookAt(target);
            await Task.Yield();
        }///로테이션 오프셋 조정 필요!
    }

    public void OnApplicationQuit()
    {
        StopCameraWork();
    }

    public void StopCameraWork()
    {
        isRunning = false;
        cts.Cancel();
    }

    void OnDestroy()
    {       
        cts?.Cancel();
        cts?.Dispose();
    }
}