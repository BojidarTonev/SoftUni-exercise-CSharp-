using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetClinicc
{
    public class Clinic :IEnumerable<Pet>
    {
        private int startingPoint;
        public Pet[] animalsInside;
        private string name;       

        public Clinic(string name, int numberOfRooms)
        {
            this.animalsInside = new Pet[numberOfRooms];
            this.startingPoint = numberOfRooms /2;
            this.name = name;
        }

        public bool Add(Pet pet)
        {
            bool isAdded = false;
            int rightMove = startingPoint + 1;
            int leftMove = startingPoint - 1;
            if (animalsInside[startingPoint] == null)
            {
                animalsInside[startingPoint] = pet;
                isAdded = true;
                return true;
            }
            else
            {
                while (leftMove >= 0 && rightMove < animalsInside.Length)
                {
                    if (animalsInside[leftMove] == null)
                    {
                        animalsInside[leftMove] = pet;
                        isAdded = true;
                        return true;
                    }
                    else
                    {
                        leftMove--;
                        if (animalsInside[rightMove] == null)
                        {
                            animalsInside[rightMove] = pet;
                            isAdded = true;
                            return true;
                        }
                        rightMove++;
                    }
                }

                if (isAdded)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Release()
        {
            bool isFound = false;
            if (this.animalsInside[startingPoint] != null)
            {
                animalsInside[startingPoint] = null;
                isFound = true;
                return isFound;
            }
            else
            {
                for (int i = startingPoint; i < animalsInside.Length; i++)
                {
                    if (animalsInside[i] != null)
                    {
                        animalsInside[i] = null;
                        isFound = true;
                        return isFound;
                    }
                    else
                    {
                        isFound = false;
                    }
                }

                if (!isFound)
                {
                    for (int i = 0; i < startingPoint; i++)
                    {
                        if (animalsInside[i] != null)
                        {
                            animalsInside[i] = null;
                            isFound = true;
                            return isFound;
                        }
                        else
                        {
                            isFound = false;
                        }
                    }
                }

                if (isFound)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool HasEmptyRooms()
        {
            bool hasEmpty = false;
            for (int i = 0; i < animalsInside.Length; i++)
            {
                if (animalsInside[i] == null)
                {
                    hasEmpty = true;
                    break;
                }
            }

            if (hasEmpty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public IEnumerator<Pet> GetEnumerator()
        {
            for (int i = 0; i < animalsInside.Length; i++)
            {
                yield return animalsInside[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
