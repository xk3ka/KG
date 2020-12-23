using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation05
{
    public class ArrayUtils
    {
        const int DEFAULT_SIZE = 10;

        private Element[] Data { get; set; } 

        private Random rnd { get; set; }

        public ArrayUtils()
        {
            Data = new Element[DEFAULT_SIZE];
            Generate();
        }

        public ArrayUtils(int length)
        {
            Data = new Element[length];
            Generate();
        }

        public ArrayUtils(params int[] array)
        {
            Data = new Element[array.Length];
            Load(array);
        }

        private void Generate()
        {                
            for(int i = 0; i < Data.Length-1; i++)
            {
                Data[i] = new Element(20 + i * 40, 100, rnd.Next(0, 100), Color.Black);
            }
        }

        private void Load(int[] array)
        {
            for (int i = 0; i < Data.Length; i++)
            {
                Data[i] = new Element(20 + i * 40, 100, array[i], Color.Black);
            }
        }

        public void Sort()
        {
            int leftSite = 0; 
            int rightSite = Data.Length - 1;
            bool sortedFront = false; 
            bool sortedBack = false;
            int last = 0;
            while (leftSite < rightSite)
            {
                sortedFront = false;
                for (int index = leftSite; index < rightSite; index++)
                {
                    if (Data[index].Value > Data[index + 1].Value)
                    {
                        Swap(index, index + 1);
                        sortedFront = true;
                        last = index;
                    }
                }
                rightSite = last;
                if (!sortedFront && !sortedBack) break;
                sortedBack = false;
                for (int index = rightSite; index > leftSite; index--)
                {
                    if (Data[index].Value < Data[index - 1].Value)
                    {
                        Swap(index, index - 1);
                        sortedBack = true;
                        last = index;
                    }
                }
                leftSite = last;
                if (!sortedFront) break;
            }
        }

        private void Swap(int x, int y)
        {
            int tmp = Data[x].Value;
            Data[x] = Data[y];
            Data[y].Value = tmp;
        }

        public string Print()
        {
            string result = "";
            foreach(Element e in Data)
            {
                result += e.Value + " ";
            }
            return result;
        }
    }
}
