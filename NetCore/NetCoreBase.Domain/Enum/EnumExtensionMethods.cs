using System.ComponentModel;

namespace NetCoreBase.Domain.Enum
{
    public static class EnumExtensionMethods
    {
        public static string GetEnumDescription(this System.Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }
    }
}