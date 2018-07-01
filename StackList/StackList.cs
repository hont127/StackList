using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hont
{
    public struct StackList<T>
    {
        public const byte MAX_ELEMENT_COUNT = 16;

        T mElement0;
        T mElement1;
        T mElement2;
        T mElement3;
        T mElement4;
        T mElement5;
        T mElement6;
        T mElement7;

        T mElement8;
        T mElement9;
        T mElement10;
        T mElement11;
        T mElement12;
        T mElement13;
        T mElement14;
        T mElement15;

        int mInternalIndex;


        public T this[int index]
        {
            get
            {
                if (index < 8)
                {
                    if (index == 0) return mElement0;
                    else if (index == 1) return mElement1;
                    else if (index == 2) return mElement2;
                    else if (index == 3) return mElement3;
                    else if (index == 4) return mElement4;
                    else if (index == 5) return mElement5;
                    else if (index == 6) return mElement6;
                    else return mElement7;
                }
                else
                {
                    if (index == 8) return mElement8;
                    else if (index == 9) return mElement9;
                    else if (index == 10) return mElement10;
                    else if (index == 11) return mElement11;
                    else if (index == 12) return mElement12;
                    else if (index == 13) return mElement13;
                    else if (index == 14) return mElement14;
                    else return mElement15;
                }
            }

            set
            {
                if (index < 8)
                {
                    if (index == 0) mElement0 = value;
                    else if (index == 1) mElement1 = value;
                    else if (index == 2) mElement2 = value;
                    else if (index == 3) mElement3 = value;
                    else if (index == 4) mElement4 = value;
                    else if (index == 5) mElement5 = value;
                    else if (index == 6) mElement6 = value;
                    else mElement7 = value;
                }
                else
                {
                    if (index == 8) mElement8 = value;
                    else if (index == 9) mElement9 = value;
                    else if (index == 10) mElement10 = value;
                    else if (index == 11) mElement11 = value;
                    else if (index == 12) mElement12 = value;
                    else if (index == 13) mElement13 = value;
                    else if (index == 14) mElement14 = value;
                    else mElement15 = value;
                }
            }
        }

        public int Count { get { return mInternalIndex; } }

        public bool Add(T element)
        {
            if (mInternalIndex == MAX_ELEMENT_COUNT) return false;

            this[mInternalIndex] = element;
            mInternalIndex++;

            return true;
        }

        public bool Remove(T element)
        {
            return Remove(element, DefaultComparison);
        }

        public bool Remove(T element, Func<T, T, bool> comparison)
        {
            var removeIndex = -1;
            for (int i = 0; i < MAX_ELEMENT_COUNT; i++)
            {
                if (comparison(this[i], element))
                {
                    removeIndex = i;
                    break;
                }
            }

            if (removeIndex > -1)
            {
                RemoveAt(removeIndex);
            }

            return removeIndex > -1;
        }

        public void RemoveAt(int elementIndex)
        {
            for (int i = elementIndex; i < MAX_ELEMENT_COUNT - 1; i++)
            {
                this[i] = this[i + 1];
            }

            mInternalIndex--;
        }

        bool DefaultComparison(T x, T y)
        {
            return x.Equals(y);
        }
    }
}
