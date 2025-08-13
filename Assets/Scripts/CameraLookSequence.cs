using System;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraLookSequence : MonoBehaviour
{

    //[SerializeField] CameraFollow cameraFollow;
    [SerializeField] IntroCameraWork introCameraWork;
    [SerializeField] Transform[] targets;
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
        CancellationToken token = cts.Token;
        isRunning = true;
        
        StartCameraSequence(token);
    }

    void RemoveBillBoard()
    {

    }

   

    async void StartCameraSequence(CancellationToken token)
    {
        while (isRunning)
        {
            foreach (Transform target in targets)
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
                await LookAtTarget(target, token);
                await introCameraWork_PlayAnime(target);
                await Task.Delay(1000); // Wait 1 second
            }
        }

        async Task introCameraWork_PlayAnime(Transform target)
        {
            introCameraWork.PlayAnimationByName(target);
        }
    }

    async Task LookAtTarget(Transform target, CancellationToken token)
    {
        //worldSpaceNameTag.DisplayTextType(target.name);

        float elapsed = 0f;
        float duration = 1.5f;
        float smoothSpeed = 6;
        Vector3 offset = new Vector3(0, 5, -10);
        Vector3 targetCamPos = target.position + offset;

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
        }
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