using Models.Converters;
using System.ComponentModel;

namespace Models
{
    [TypeConverter(typeof(EnumTypeConverter))]
    public enum Gender
    {
        Male,
        Female
    }
}