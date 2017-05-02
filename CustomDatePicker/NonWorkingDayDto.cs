using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomDatePicker
{
    [DataContract]
    [DebuggerDisplay("{Date.ToShortDateString()}({Description})")]
    public class NonWorkingDayDto : IEquatable<NonWorkingDayDto>
{
        public NonWorkingDayDto(DateTime date, string description)
        {
            Date = date;
            Description = description;
        }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string Description { get; set; }

        public bool Equals(NonWorkingDayDto other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return this.Date.Equals(other.Date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((NonWorkingDayDto)obj);
        }

        public override int GetHashCode()
        {
            return this.Date.GetHashCode();
        }

        public static bool operator ==(NonWorkingDayDto left, NonWorkingDayDto right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(NonWorkingDayDto left, NonWorkingDayDto right)
        {
            return !Equals(left, right);
        }
    }

    public class NonWorkingDayComparer : IEqualityComparer<NonWorkingDayDto>
{
        public bool Equals(NonWorkingDayDto x, NonWorkingDayDto y)
        {
            return x.Date == y.Date;
        }

        public int GetHashCode(NonWorkingDayDto obj)
        {
            return obj.Date.GetHashCode();
        }
    }
}
