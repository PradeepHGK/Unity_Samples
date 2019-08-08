using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Interface Seggregation Principle
namespace Assets.Scripts
{
    //player actions 
    interface IPlayerActions
    {
        void MoveForward();
        void MoveBackward();
        void Jump();
        void RotateLeft();
        void RotateRight();

    }

    interface IAttackOptions
    {
        void BulletLoader();
        void Shooting();
    }

    interface IInterface
    {

    }    
}
