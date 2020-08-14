using UnityEngine;
namespace Pigs.MapTools
{
    public class FieldAngleHandler : MonoBehaviour
    {
        [SerializeField] private Transform pointA;
        [SerializeField] private Transform pointB;
        public float AngleInRands { get; private set; }
        private const float degToRad = 57.2958f;
        private void Start()
        {
            AngleInRands = GetAngleInRads();
        }
        private float GetAngleInRads()
        {
            Vector2 pointBDir = pointB.position - pointA.position;
            Vector2 forward = Vector2.up;

            float angelBetween = Vector2.SignedAngle(pointBDir, forward);

            return angelBetween / degToRad;
        }
    }
}