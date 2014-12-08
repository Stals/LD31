using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;


public class UnitController : UnitControllerBase
{

    #region ClassesForBehavior

    public struct PositionInfo
    {
        private LinkViewModel myCurrentLink;

        public LinkViewModel MyCurrentLink
        {
            get { return myCurrentLink; }
            set { myCurrentLink = value; }
        }

        private MapNodeViewModel startNode;

        public MapNodeViewModel StartNode
        {
            get { return startNode; }
            set { startNode = value; }
        }

        private float myCurrentWalk;

        public float MyCurrentWalk
        {
            get { return myCurrentWalk; }
            set { myCurrentWalk = value; }
        }
    }

    public abstract class UnitBehavior
    {


        public virtual void UpdateMe(UnitViewModel unit, UnitController controller)
        {

        }

        public virtual void GoToNode(UnitViewModel unit, UnitController controller, MapNodeViewModel target)
        {

        }

        public static UnitState myState;
    }


    public class GoToNodeBehavior : UnitBehavior
    {
        public static UnitState myState = UnitState.Walking;

        MovingBetweenNodesController movingController;

        MapNodeViewModel target;

        private GoToNodeBehavior(MovingBetweenNodesController movingController, MapNodeViewModel target)
        {
            this.movingController = movingController;
            this.target = target;
        }

        static public GoToNodeBehavior tryCreateBehavior(MapNodeViewModel fromNode, MapNodeViewModel toNode)
        {
            GoToNodeBehavior newGoingBehavior = null;

            MovingBetweenNodesController movingController = MovingControllerCreator.Instance.CreatePath(fromNode, toNode);
            MapNodeViewModel target = toNode;

            if (movingController != null)
            {
                newGoingBehavior = new GoToNodeBehavior(movingController, target);
            }

            return newGoingBehavior; 
            
        }

        static public GoToNodeBehavior tryCreateBehavior(MapNodeViewModel toNode, PositionInfo standBehavior)
        {

            GoToNodeBehavior newGoingBehavior = null;

            MapNodeViewModel target = toNode;

            MovingBetweenNodesController firstControllerPath = MovingControllerCreator.Instance.CreatePath(standBehavior.MyCurrentLink.node1, toNode);
            MovingBetweenNodesController secondControllerPath = MovingControllerCreator.Instance.CreatePath(standBehavior.MyCurrentLink.node2, toNode);


            int chosenPath = -1;

            if (firstControllerPath == null)
            {
                chosenPath = 2;
            }
            else if (secondControllerPath == null)
            {
                chosenPath = 1;
            } else
            {
                float firstLength = standBehavior.MyCurrentWalk + firstControllerPath.TotalLength;
                float secondLength = standBehavior.MyCurrentLink.PathLength - standBehavior.MyCurrentWalk + secondControllerPath.TotalLength;

                if (firstLength > secondLength)
                {
                    chosenPath = 2;
                }
                else
                {
                    chosenPath = 1;
                }
            }

            if (chosenPath == 1)
            {
                firstControllerPath.PushLinkToStart(standBehavior.MyCurrentLink);
                firstControllerPath.addWalkedLength(standBehavior.MyCurrentWalk);
                newGoingBehavior = new GoToNodeBehavior(firstControllerPath, target);
            }

            if (chosenPath == 2)
            {
                secondControllerPath.PushLinkToStart(standBehavior.MyCurrentLink);
                secondControllerPath.addWalkedLength(standBehavior.MyCurrentLink.PathLength - standBehavior.MyCurrentWalk);
                newGoingBehavior = new GoToNodeBehavior(secondControllerPath, target);
            }

            return newGoingBehavior;
        }

        public override void UpdateMe(UnitViewModel unit, UnitController controller)
        {
            movingController.moveMe(unit, GameSceneManager.speed); 
            if (movingController.reachedEnd)
            {

                MapNodeViewModel nowTarget = target;
                controller.ExecuteCommand(nowTarget.Interact, unit);
            }
        }

        public override void GoToNode(UnitViewModel unit, UnitController controller, MapNodeViewModel target)
        {
            PositionInfo nowInfo = new PositionInfo();
            nowInfo.StartNode = movingController.NowStartNode;
            nowInfo.MyCurrentLink = movingController.NowLink;
            nowInfo.MyCurrentWalk = movingController.NowLength;

            GoToNodeBehavior newBehavior = GoToNodeBehavior.tryCreateBehavior(target, nowInfo);

            if (newBehavior != null)
            {
                unit.MyBehavior = newBehavior;
            }

        }
    }

    public class StandingBehavior : UnitBehavior
    {
        public static UnitState myState = UnitState.StandingOutside;

        PositionInfo myPosInfo = new PositionInfo();

        public StandingBehavior(LinkViewModel nowLink, MapNodeViewModel inStartNode, float nowLength)
        {
            myPosInfo.MyCurrentLink = nowLink;
            myPosInfo.StartNode = inStartNode;

            if (inStartNode == nowLink.node1)
            {
                myPosInfo.MyCurrentWalk = nowLength;
            }
            else
            {
                myPosInfo.MyCurrentWalk = nowLink.PathLength - nowLength;
            }


        }

        public override void UpdateMe(UnitViewModel unit, UnitController controller)
        {
            controller.ExecuteCommand(unit.TakeDamage, 1);
        }

        public override void GoToNode(UnitViewModel unit, UnitController controller, MapNodeViewModel target)
        {
            GoToNodeBehavior newBehavior = GoToNodeBehavior.tryCreateBehavior(target, myPosInfo);
            if (newBehavior != null)
            {
                unit.MyBehavior = newBehavior;
            }
        }
    }

    public class InCityBehavior : UnitBehavior
    {
        public static UnitState myState = UnitState.InCity;

        MapNodeViewModel nowNode;

        Vector3 position;

        public InCityBehavior(MapNodeViewModel city)
        {
            nowNode = city;

        }

        public override void UpdateMe(UnitViewModel unit, UnitController controller)
        {
            //unit.Position = nowNode.position;
        }

        public override void GoToNode(UnitViewModel unit, UnitController controller, MapNodeViewModel target)
        {
            GoToNodeBehavior newBehavior = GoToNodeBehavior.tryCreateBehavior(nowNode, target);
            if (newBehavior != null)
            {
                unit.MyBehavior = newBehavior;
            }
        }
    }

    public abstract class AttackBehavior : UnitBehavior
    {
        MapNodeViewModel enemyNode;

        Vector3 position;

        public AttackBehavior(MapNodeViewModel enemy, Vector3 nowPosition)
        {
            enemyNode = enemy;
            position = nowPosition;


        }

        public override void UpdateMe(UnitViewModel unit, UnitController controller)
        {
            controller.ExecuteCommand(enemyNode.TakeDamage, unit.attack);

        }

        public override void GoToNode(UnitViewModel unit, UnitController controller, MapNodeViewModel target)
        {

        }

        public static UnitState myState;
    }

    #endregion

    public override void InitializeUnit(UnitViewModel unit) {
        unit.state = UnitState.InCity;

    }

    public override void GoTo(UnitViewModel unit, MapNodeViewModel arg)
    {
        base.GoTo(unit, arg);

        unit.MyBehavior.GoToNode(unit, this, arg);
    }

    public override void InitUnit(UnitViewModel unit, MapNodeViewModel arg)
    {
        base.InitUnit(unit, arg);

        unit.MyBehavior = new InCityBehavior(arg);
    }

    public override void UpdateMe(UnitViewModel unit)
    {
        base.UpdateMe(unit);

        if (unit.MyBehavior != null)
        {
            unit.MyBehavior.UpdateMe(unit, this);
        }
    }
}
