using UnityEngine;

namespace Assets.Scripts {
    [CreateAssetMenu]
    public class BallDatabase : ScriptableObject {
        public Ball[] ball;

        public int BallCount {
            get { return ball.Length; }
        }

        public Ball GetBall(int index) {
            return ball[index];
        }
    }
}