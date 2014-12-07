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


        public void UpdateMe(UnitViewModel unit, UnitController controller)
        {

        }

        public void GoToNode(UnitViewModel unit, UnitController controller, MapNodeViewModel target)
        {

        }

        public static UnitState myState;
    }


    public class GoToNodeBehavior : UnitBehavior
    {
        public static UnitState myState = UnitState.Walking;

        MovingBetweenNodesController movingController;

        MapNodeViewModel target;


        public GoToNodeBehavior(MapNodeViewModel fromNode, MapNodeViewModel toNode)
        {
            movingController = MovingControllerCreator.Instance.CreatePath(fromNode, toNode);

            target = toNode;

        }

        public GoToNodeBehavior(MapNodeViewModel toNode, PositionInfo standBehavior)
        {
            
            target = toNode;

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
                movingController = firstControllerPath;
                movingController.PushLinkToStart(standBehavior.MyCurrentLink);
                movingController.addWalkedLength(standBehavior.MyCurrentWalk);
            }

            if (chosenPath == 1)
            {
                movingController = firstControllerPath;
                movingController.PushLinkToStart(standBehavior.MyCurrentLink);
                movingController.addWalkedLength(standBehavior.MyCurrentLink.PathLength - standBehavior.MyCurrentWalk);
            }

        }

        public void UpdateMe(UnitViewModel unit, UnitController controller)
        {
            movingController.moveMe(unit, GameSceneManager.speed);
            
        }

        public void GoToNode(UnitViewModel unit, UnitController controller, MapNodeViewModel target)
        {
            PositionInfo nowInfo = new PositionInfo();
            nowInfo.StartNode = movingController.NowStartNode;
            nowInfo.MyCurrentLink = movingController.NowLink;
            nowInfo.MyCurrentWalk = movingController.NowLength;

            unit.MyBehavior = new GoToNodeBehavior(target, nowInfo);
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

        public void UpdateMe(UnitViewModel unit, UnitController controller)
        {
            controller.ExecuteCommand(unit.TakeDamage, 1);
        }

        public void GoToNode(UnitViewModel unit, UnitController controller, MapNodeViewModel target)
        {
            unit.MyBehavior = new GoToNodeBehavior(target, myPosInfo);
        }

    }

    public class InCityBehavior : UnitBehavior
    {
        public static UnitState myState = UnitState.InCity;

        MapNodeViewModel nowNode;

        public InCityBehavior(MapNodeViewModel city)
        {
            nowNode = city;
        }

        public void UpdateMe(UnitViewModel unit, UnitController controller)
        {
            unit.Position = Vector3.zero;
        }

        public void GoToNode(UnitViewModel unit, UnitController controller, MapNodeViewModel target)
        {
            unit.MyBehavior = new GoToNodeBehavior(nowNode, target);
        }
    }

    #endregion

    public void initOnCreation(UnitViewModel unit, MapNodeViewModel nowCity)
    {
        unit.MyBehavior = new InCityBehavior(nowCity);
    }

    public override void InitializeUnit(UnitViewModel unit) {
        unit.state = UnitState.InCity;

    }

    public override void GoTo(UnitViewModel unit, MapNodeViewModel arg)
    {
        base.GoTo(unit, arg);

        unit.MyBehavior.GoToNode(unit, this, arg);
    }
}
