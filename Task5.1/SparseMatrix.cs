using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task5._1
{
    public class SparseMatrix : IEnumerable<long>
    {
        private readonly Dictionary<(int row, int column), long> _sparseMatrix = new Dictionary<(int, int), long>();
        public int Rows { get; }
        public int Columns { get; }

        public SparseMatrix(int row, int column)
        {
            if (row <= 0 || column<=0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Rows = row;
            Columns = column;
        }

        public long this[int i, int j]
        {
            get
            {
                ArgumentCheck(i, j);

                return _sparseMatrix.ContainsKey((i, j)) ? _sparseMatrix[(i,j)] : 0;
            }
            set
            {
                ArgumentCheck(i, j);

                if (_sparseMatrix.ContainsKey((i, j)))
                {
                    if (value == 0)
                    {
                        _sparseMatrix.Remove((i, j));
                    }
                    else
                    {
                        _sparseMatrix[(i, j)] = value;
                    }
                }
                else
                {
                    if (value != 0)
                    {
                        _sparseMatrix.Add((i, j), value);
                    }
                }
            }
        }

        private void ArgumentCheck(int i, int j)
        {
            if (i > Rows || i <= 0 || j > Columns || j <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public IEnumerator<long> GetEnumerator()
        {
            for (var i = 1; i <= Rows; i++)
            {
                for(var j = 1; j <= Columns; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        public override string ToString()
        {
            var str = "";
            for(var i = 1; i <= Rows; i++)
            {
                for(var j = 1; j <= Columns; j++)
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
            return _sparseMatrix.OrderBy(x => x.Key.column).ThenBy(x => x.Key.row).Select(x => (x.Key.row, x.Key.column, x.Value));
        }

        public int GetCount(long value)
        {
            return value == 0 ? Rows * Columns - _sparseMatrix.Count() : _sparseMatrix.Where(x => x.Value == value).Count();
        }
    }
}
