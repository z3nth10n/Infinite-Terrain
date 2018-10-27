using InfiniteTerrain.Core;
using UnityEngine;

namespace InfiniteTerrain.Controllers
{
    public class TerrainControl : MonoBehaviour
    {
        // the terrain generator component.
        public TerrainGenerator generator;

        public FlyCamera flyCamera;

        // Value ranges.
        public float maxDetail;

        public float minDetail;
        public float minHeight;
        public float maxHeight;

        private float detailScale;
        private float heightScale;

        private void Start()
        {
            detailScale = generator.detailScale;
            heightScale = generator.heightScale;
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(10, 10, 400, 20), "Infinite Terrain. Go on, fly around! it'll never run out :)");

            flyCamera.autoFly = GUI.Toggle(new Rect(10, 30, 100, 20), flyCamera.autoFly, "Auto Fly");
            flyCamera.followTerrain = GUI.Toggle(new Rect(10, 50, 100, 20), flyCamera.followTerrain, "Follow Terrain");

            GUI.Label(new Rect(10, 70, 90, 20), "Detail Scale");
            GUI.Label(new Rect(10, 90, 90, 20), "Height Scale");
            detailScale = GUI.HorizontalSlider(new Rect(90, 75, 200, 10), detailScale, minDetail, maxDetail);
            heightScale = GUI.HorizontalSlider(new Rect(90, 95, 200, 10), heightScale, minHeight, maxHeight);

            if (GUI.Button(new Rect(10, 120, 100, 30), "Generate"))
            {
                generator.Generate(detailScale, heightScale);
            }
        }
    }
}