using System;
using System.Collections.Generic;

namespace MapManagement.MapLib
{
    public class Map
    {
        private Branch _root;

        public Branch Root => _root;

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
    }
}