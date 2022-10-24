using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathCreation.Examples 
{
    public class CustomPathFollower : MonoBehaviour{
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed;

        [SerializeField]private TypeCuy colorCuy;
        [SerializeField]private CuysStats stats;

        float distanceTravelled;

        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }
        private void FixedUpdate() {
            
        }

        void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += UpdateCuyVelocity() * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                //transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        } 

        private float UpdateCuyVelocity(){
            switch (colorCuy){
                case TypeCuy.Amarillo:
                return stats.amarilloVelocity;
                case TypeCuy.Cafe:
                return stats.cafeVelocity;
                case TypeCuy.Rojo:
                return stats.rojoVelocity;
            }
            return 0;
        }    
    }
    
}

