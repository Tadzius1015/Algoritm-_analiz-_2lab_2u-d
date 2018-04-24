using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_programa
{
    class FriendsPresents
    {
        private int[] PresentsPrice;
        private List<int> FriendA { get; set; }
        private List<int> FriendB { get; set; }
        private int Substraction;
        
        public FriendsPresents(int[] presentsPrice, List<int> friendA, List<int> friendB, int substraction)
        {
            PresentsPrice = presentsPrice;
            FriendA = friendA;
            FriendB = friendB;
            Substraction = substraction;
        }
        public FriendsPresents(int[] presentsPrice)
        {
            PresentsPrice = presentsPrice;
        }
        public FriendsPresents() { }
        public int getPresentValue(int index)
        {
            return PresentsPrice[index];
        }
        public int getSubstraction()
        {
            return this.Substraction;
        }
        public string subSeq(int index)
        {
            return "1 Draugės dovanų vertės: " + string.Join(",", FriendA) + " || " + "2 Draugės dovanų vertės: " + string.Join(",", FriendB);
        }
        public string subSeqq(int index)
        {
            return "1 Draugės dovanų vertės: " + string.Join(",", FriendB) + " || " + "2 Draugės dovanų vertės: " + string.Join(",", FriendA);
        }
        public int getFriendAValue(int index)
        {
            return FriendA.ElementAt(index);
        }
        public int getFriendBValue(int index)
        {
            return FriendB.ElementAt(index);
        }
        public void setFriendAValue(int index, int value)
        {
            FriendA[index] = value;
        }
        public void setFriendBValue(int index, int value)
        {
            FriendB[index] = value;
        }
        public int getLength()
        {
            return FriendA.Count;
        }
        public void addPresentFriendA(int value)
        {
            FriendA.Add(value);
        }
        public void addPresentFriendB(int value)
        {
            FriendB.Add(value);
        }
        public void removePresentFriendB(int index)
        {
            FriendB.Remove(index);
        }
        public int ListASum()
        {
            return FriendA.Sum();
        }
        public int ListBSum()
        {
            return FriendB.Sum();
        }
        public FriendsPresents CloneFriendA()
        {
            return new FriendsPresents(this.PresentsPrice, CloneList(FriendA), CloneList(FriendB), this.Substraction);
        }
        public List<int> CloneList(List<int> a)
        {
            List<int> tmp = new List<int>();
            for (int i = 0; i < a.Count; i++)
            {
                tmp.Add(a.ElementAt(i));
            }
            return tmp;
        }
        public FriendsPresents Give(int n, int m)
        {
            int value = D(n, m);
            this.Substraction = this.Substraction + value;
            return this;
        }

        private int D(int n, int m)
        {
            if (m == 0)
            {
                addPresentFriendA(this.PresentsPrice[n]);
                return this.PresentsPrice[n];
            }

            if (m == 1)
            {
                addPresentFriendB(this.PresentsPrice[n]);
                return -1 * this.PresentsPrice[n];
            }

            return 0;
        }

    }
}
