namespace CJBasic.ObjectManagement.Trees.KDimension
{
    using System;

    public class KDSearchScope
    {
        private string columnName;
        private CJBasic.ObjectManagement.Trees.KDimension.KDSearchType kDSearchType;
        private string matchString;
        private bool maxClosed;
        private IComparable maxValue;
        private bool minClosed;
        private IComparable minValue;

        public KDSearchScope()
        {
            this.columnName = "";
            this.kDSearchType = CJBasic.ObjectManagement.Trees.KDimension.KDSearchType.Default;
            this.minClosed = false;
            this.maxClosed = false;
        }

        public KDSearchScope(string column, CJBasic.ObjectManagement.Trees.KDimension.KDSearchType searchType, string _matchString)
        {
            this.columnName = "";
            this.kDSearchType = CJBasic.ObjectManagement.Trees.KDimension.KDSearchType.Default;
            this.minClosed = false;
            this.maxClosed = false;
            this.columnName = column;
            this.kDSearchType = searchType;
            this.matchString = _matchString;
        }

        public KDSearchScope(string column, IComparable min, bool _minClosed, IComparable max, bool _maxClosed)
        {
            this.columnName = "";
            this.kDSearchType = CJBasic.ObjectManagement.Trees.KDimension.KDSearchType.Default;
            this.minClosed = false;
            this.maxClosed = false;
            this.columnName = column;
            this.minValue = min;
            this.maxValue = max;
            this.minClosed = _minClosed;
            this.maxClosed = _maxClosed;
        }

        public string ColumnName
        {
            get
            {
                return this.columnName;
            }
            set
            {
                this.columnName = value;
            }
        }

        public CJBasic.ObjectManagement.Trees.KDimension.KDSearchType KDSearchType
        {
            get
            {
                return this.kDSearchType;
            }
            set
            {
                this.kDSearchType = value;
            }
        }

        public string MatchString
        {
            get
            {
                return this.matchString;
            }
            set
            {
                this.matchString = value;
            }
        }

        public bool MaxClosed
        {
            get
            {
                return this.maxClosed;
            }
            set
            {
                this.maxClosed = value;
            }
        }

        public IComparable MaxValue
        {
            get
            {
                return this.maxValue;
            }
            set
            {
                this.maxValue = value;
            }
        }

        public bool MinClosed
        {
            get
            {
                return this.minClosed;
            }
            set
            {
                this.minClosed = value;
            }
        }

        public IComparable MinValue
        {
            get
            {
                return this.minValue;
            }
            set
            {
                this.minValue = value;
            }
        }
    }
}

