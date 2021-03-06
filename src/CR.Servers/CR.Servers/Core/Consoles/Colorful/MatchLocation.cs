using System;

namespace CR.Servers.Core.Consoles.Colorful
{
    /// <summary>
    ///     Exposes properties describing the indices of the beginning and end of a pattern match.
    /// </summary>
    public class MatchLocation : IEquatable<MatchLocation>, IComparable<MatchLocation>, IPrototypable<MatchLocation>
    {
        /// <summary>
        ///     Exposes properties describing the indices of the beginning and end of a pattern match.
        /// </summary>
        /// <param name="beginning">The index of the beginning of the pattern match.</param>
        /// <param name="end">The index of the end of the pattern match.</param>
        public MatchLocation(int beginning, int end)
        {
            Beginning = beginning;
            End = end;
        }

        /// <summary>
        ///     The index of the beginning of the pattern match.
        /// </summary>
        public int Beginning { get; }

        /// <summary>
        ///     The index of the end of the pattern match.
        /// </summary>
        public int End { get; }

        public int CompareTo(MatchLocation other)
        {
            return Beginning.CompareTo(other.Beginning);
        }

        public bool Equals(MatchLocation other)
        {
            if (other == null)
                return false;

            return Beginning == other.Beginning
                   && End == other.End;
        }

        public MatchLocation Prototype()
        {
            return new MatchLocation(Beginning, End);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MatchLocation);
        }

        public override int GetHashCode()
        {
            var hash = 163;

            hash *= 79 + Beginning.GetHashCode();
            hash *= 79 + End.GetHashCode();

            return hash;
        }

        public override string ToString()
        {
            return Beginning + ", " + End;
        }
    }
}