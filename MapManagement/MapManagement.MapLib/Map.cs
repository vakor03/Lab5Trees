using System;
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
            Branch destinationBranch = ChooseSubtree(location.x, location.y);
            destinationBranch.AddChild(location);
        }

        private Branch ChooseSubtree(double xDot, double yDot)
        {
            Branch currentBranch = _root;
            currentBranch.RefindShape(xDot, yDot);

            while (true)
            {
                if (currentBranch.GetNodeType() == "PreBranch")
                {
                    return currentBranch;
                }

                Branch childBranch1 = (Branch) currentBranch.GetChilds()[0];
                Branch childBranch2 = (Branch) currentBranch.GetChilds()[1];
                if (childBranch1.GetNodeType() == "PreBranch")
                {
                    if (Rectangle.CheckOverlapChange(childBranch1.Rect, childBranch2.Rect, xDot, yDot) !=
                        0)
                    {
                        currentBranch = Rectangle.CheckOverlapChange(childBranch1.Rect, childBranch2.Rect, xDot,
                            yDot) > 0
                            ? childBranch1
                            : childBranch2;
                    }
                    else
                    {
                        if (Rectangle.CheckShapeChange(childBranch1.Rect, childBranch2.Rect, xDot,
                            yDot) != 0)
                        {
                            currentBranch = Rectangle.CheckShapeChange(childBranch1.Rect, childBranch2.Rect, xDot,
                                yDot) > 0
                                ? childBranch1
                                : childBranch2;
                        }
                        else
                        {
                            currentBranch = childBranch1.Rect.Shape <= childBranch2.Rect.Shape
                                ? childBranch1
                                : childBranch2;
                        }
                    }
                }

                else
                {
                    if (Rectangle.CheckShapeChange(childBranch1.Rect, childBranch2.Rect, xDot,
                        yDot) != 0)
                    {
                        currentBranch = Rectangle.CheckShapeChange(childBranch1.Rect, childBranch2.Rect, xDot,
                            yDot) > 0
                            ? childBranch1
                            : childBranch2;
                    }
                    else
                    {
                        currentBranch = childBranch1.Rect.Shape <= childBranch2.Rect.Shape
                            ? childBranch1
                            : childBranch2;
                    }
                }

                currentBranch.RefindShape(xDot, yDot);
            }
        }

        private void SearchTree(Branch current, List<Leaf> leaves)
        {
            for (int i = 0; i < current.Childs.Count; i++)
            {
                
            }
        }
        
        public List<Location> FindNearest(double latitude, double longitude, double radius, string type)
        {
            return null;
        }

        private double GetDistance(double lat1, double lon1, double lat2, double lon2)
        {
            double[] coordsInRadians = { lat1 * 3.1415 / 180, lon1 * 3.1415 / 180,
                                         lat2 * 3.1415 / 180, lon2 * 3.1415 / 180 };
            
            double a = Math.Pow(Math.Sin((coordsInRadians[2] - coordsInRadians[0]) / 2), 2) + Math.Cos(coordsInRadians[0]) *
                Math.Cos(coordsInRadians[2]) * Math.Pow(Math.Sin((coordsInRadians[3] - coordsInRadians[1]) / 2), 2);
            return 7922 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        }
        // private Branch CheckSmallestOverlap(List<Node> nodes)
        // {
        //     int n = 1;
        //     Branch branch1 = (Branch) nodes[0];
        //     Branch branch2 = (Branch) nodes[1];
        //     if (branch1.RectangleShape <= branch2.RectangleShape)
        //     {
        //         return branch1;
        //     }
        //     else
        //     {
        //         return branch2;
        //     }
        //
        //     return null;
        // }
        //
        // private Branch CheckSmallestShape(List<Node> nodes)
        // {
        //     int n = 1;
        //     Branch branch1 = (Branch) nodes[0];
        //     Branch branch2 = (Branch) nodes[1];
        //     if (branch1.RectangleShape <= branch2.RectangleShape)
        //     {
        //         return branch1;
        //     }
        //     else
        //     {
        //         return branch2;
        //     }
        //
        //     return null;
        // }
    }
}