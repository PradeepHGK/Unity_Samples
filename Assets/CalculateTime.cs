/*
Texture Render Workflow Graph:
FLAT VIDEO:                   
                               Camera
                                  | [Camera.targetTexture]
                                  V
                            RenderTexture
                                  |
                       2D         V         STEREO
             ------------------------------------------------------------
             |[RenderTexture.active&&Texture2D.readPixels]               |[Graphics.Blit]
             V                                                           V
         Texture2D                                              StereRenderTexture
             |[Texture.GetRawTextureData]                                |[RenderTexture.active&&Texture2D.readPixels]
             V                                                           V
         FrameData                                                   Texture2D
                                                                         |[Texture.GetRawTextureData]
                                                                         V
                                                                     FrameData

PANORAMA VIDEO:                   
                                         Camera
                                           | [Camera.RenderToCubemap]
                                           V
                                        Cubemap
                                           |
                   CUBEMAP VIDEO           V           EQUIRECTANGULAR
               ---------------------------------------------------------
              |[Texture2D.SetPixels&&Cubemap.GetPixels]                 |[Graphics.Blit]
              V                                                         V
          Texture2D                                                RenderTexture
              |[Texture.GetRawTextureData]                              |
              V                                  EQUIRECTANGULAR STEREO V EQUIRECTANGULAR
          FrameData                              ----------------------------------------------------------
                                                |[Graphics.Blit]                                          |[RenderTexture.active&&Texture2D.readPixels]
                                                V                                                         V
                                         StereRenderTexture                                           Texture2D
                                                |[RenderTexture.active&&Texture2D.readPixels]             |[Texture.GetRawTextureData]
                                                V                                                         V
                                            Texture2D                                                 FrameData                      
                                                |[Texture.GetRawTextureData] 
                                                V    
                                            FrameData     
 
 Detailed Process:

 2D Normal Video:
     1. Init the Camera, the RenderTexture and the Texture2D in Awake(). If the property changes, it will re-init in StartCapture().
     2. Using RenderTexture as Camera TargetTexture object in LateUpdate() to get the render data after StartCapture(), using Texture2D.readPixels to get the RenderTexture pixels data.
        (Using RenderTexture as RenderTexture.active to get the render data in OnRenderImage() when use Main Camera to capture video. 
         Using Texture2D.readPixels to get the RenderTexture pixels data.)
     3. Then send the data of each frame to the native plugin for encoding.
     4. You will get the video file after StopCapture() and mux process finish.
     Note: The main camera and dedicated cameras support recording of flat video and stereo video.
                  
 Panorama Cubemap Video: 
     1. Init the Camera, the RenderTexture and the Texture2D in Awake(). If the property changes, it will re-init in StartCapture().
     2. Set Cubemap as the Camera.RenderToCubemap object in LateUpdate() when StartCapture(), using Texture2D.readPixels to get the each side of the Cubemap pixels data.
     3. Then send the data of each frame to the native plugin for encoding.
     4. You will get the cubemap video after StopCapture() and mux process finish.
     Note: The main camera unsupported to capture panorama video. The Cubemap video unsupported the stereo video.
                         
 Panorama Equirectangular Video:
     1.Init the Camera, the RenderTexture and the Texture2D in Awake(). If the property changes, it will re-init in StartCapture().
     2. Set Cubemap as the Camera.RenderToCubemap object in LateUpdate() when StartCapture(), using Texture2D.readPixels to get the RenderTexture pixels data.
     3. Then send the data of each frame to the native plugin for encoding.
     4. You will get the equirectangular video after StopCapture() and mux process finish.
     Note: The main camera unsupported to capture panorama video and panorama stereo video.
 */

using UnityEngine;


public class CalculateTime : MonoBehaviour
{
    [SerializeField] private float _maxtime = 60;
    [SerializeField] private float _dangerTime = 10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _maxtime -= Time.deltaTime;

        int secs = (int)_maxtime % 60;
        print("Seconds: "+ secs);

#if UNITY_EDITOR
        //print("_maxTime: " + Mathf.FloorToInt(_maxtime));
#endif

        if (_dangerTime > _maxtime)
        {
            //print(_maxtime);
            _maxtime = 20;
            
        }
    }
}
