using UnityEngine;
using System.Collections;

namespace RTS
{
    
    public static class ResourceManager
    {
        //speed modifieres
        public static float ScrollSpeed { get { return 25; } }
        public static float RotateSpeed { get { return 100; } }

        //how far away the mouse must be from the border of the screen in order to scroll.
        public static int ScrollWidth {  get { return 15; } }


        //how high the camera can go. limits it to not go above MaxCameraHeight or below MinCameraHeight
        public static float MinCameraHeight { get { return 10; } }
        public static float MaxCameraHeight { get { return 40; } }
    }
}
