using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task5._1
{
    public class SparseMatrix : IEnumerable<long>
    {
        private Dictionary<(int row, int column), long> _sparseMatrix = new Dictionary<(int, int), long>();
        private int _rows;
        private int _columns;

        public SparseMatrix(int row, int column)
        {
            if (row <= 0 || column<=0)
            {
                throw new ArgumentOutOfRangeException();
            }
            _rows = row;
            _columns = column;
        }

        public long this[int i, int j]
        {
            get
            {
                if (i > _rows || i <= 0 || j > _columns || j <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return _sparseMatrix.ContainsKey((i, j)) ? _sparseMatrix.Where(x => x.Key == (i, j)).Select(x => x.Value).First() : 0;
            }
            set
            {
                if (i > _rows || i <= 0 || j > _columns || j <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (_sparseMatrix.ContainsKey((i, j)))
                {
                    _sparseMatrix[(i, j)] = value;
                }
                else
                {
                    _sparseMatrix.Add((i, j), value);
                }
            }
        }

        public IEnumerator<long> GetEnumerator()
        {
            for (var i = 1; i <= _rows; i++)
            {
                for(var j = 1; j <= _columns; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        public override string ToString()
        {
            var str = "";
            for(var i = 1; i <= _rows; i++)
            {
                for(var j = 1; j <= _columns; j++)
                {
                    str += string.Format("{0,10:D}", this[i,j].ToString());
                }
                str += "\n";
            }
            return str;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<(int,int,long)> GetNonzeroElements()
        {
            var elements = _sparseMatrix.OrderBy(x => x.Key.column).OrderBy(x => x.Key.row).Select(x => (x.Key.column, x.Key.row, x.Value));
            foreach (var element in elements)
            {
                yield return element;
            }
        }

        public int GetCount(long value)
        {
            if (_sparseMatrix.ContainsValue(value) || value == 0)
            {
                if (value == 0)
                {
                    return _rows * _columns - _sparseMatrix.Count();
                }
                else
                {
                    return _sparseMatrix.Where(x => x.Value == value).Count();
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
