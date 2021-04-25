﻿using System;
using System.Collections.Generic;

namespace MapManagement.MapLib
{
    public class Map
    {
        private Branch _root;

        public Map()
        {
            _root = new Branch();
        }

        public void AddLocation(Location location)
        {
            Branch destinationBranch = ChooseSubtree(location.Longitude, location.Latitude);
            destinationBranch.AddChild(location);
        }

        private Branch ChooseSubtree(double xDot, double yDot)
        {
            Branch currentBranch = _root;


            while (true)
            {
                if (currentBranch.GetNodeType() == "PreBranch")
                {
                    return currentBranch;
                }
                else
                {
                    Branch childBranch1 = (Branch) currentBranch.GetChilds()[0];
                    Branch childBranch2 = (Branch) currentBranch.GetChilds()[1];
                    if (childBranch1.GetNodeType() == "PreBranch")
                    {
                        if (Rectangle.CheckOverlapChange(childBranch1.Rectangle, childBranch2.Rectangle, xDot, yDot) !=
                            0)
                        {
                            if (Rectangle.CheckOverlapChange(childBranch1.Rectangle, childBranch2.Rectangle, xDot,
                                yDot) > 0)
                            {
                                currentBranch = childBranch1;
                            }
                            else
                            {
                                currentBranch = childBranch2;
                            }
                        }
                        else
                        {
                            if (Rectangle.CheckShapeChange(childBranch1.Rectangle, childBranch2.Rectangle, xDot,
                                yDot) != 0)
                            {
                                if (Rectangle.CheckShapeChange(childBranch1.Rectangle, childBranch2.Rectangle, xDot,
                                    yDot) > 0)
                                {
                                    currentBranch = childBranch1;
                                }
                                else
                                {
                                    currentBranch = childBranch2;
                                }
                            }
                            else
                            {
                                if (childBranch1.RectangleShape <= childBranch2.RectangleShape)
                                {
                                    currentBranch = childBranch1;
                                }
                                else
                                {
                                    currentBranch = childBranch2;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Rectangle.CheckShapeChange(childBranch1.Rectangle, childBranch2.Rectangle, xDot,
                            yDot) != 0)
                        {
                            if (Rectangle.CheckShapeChange(childBranch1.Rectangle, childBranch2.Rectangle, xDot,
                                yDot) > 0)
                            {
                                currentBranch = childBranch1;
                            }
                            else
                            {
                                currentBranch = childBranch2;
                            }
                        }
                        else
                        {
                            if (childBranch1.RectangleShape <= childBranch2.RectangleShape)
                            {
                                currentBranch = childBranch1;
                            }
                            else
                            {
                                currentBranch = childBranch2;
                            }
                        }
                    }
                }
            }
        }

        private Branch CheckSmallestOverlap(List<Node> nodes)
        {
            int n = 1;
            Branch branch1 = (Branch) nodes[0];
            Branch branch2 = (Branch) nodes[1];
            if (branch1.RectangleShape <= branch2.RectangleShape)
            {
                return branch1;
            }
            else
            {
                return branch2;
            }

            return null;
        }

        private Branch CheckSmallestShape(List<Node> nodes)
        {
            int n = 1;
            Branch branch1 = (Branch) nodes[0];
            Branch branch2 = (Branch) nodes[1];
            if (branch1.RectangleShape <= branch2.RectangleShape)
            {
                return branch1;
            }
            else
            {
                return branch2;
            }

            return null;
        }
    }
}