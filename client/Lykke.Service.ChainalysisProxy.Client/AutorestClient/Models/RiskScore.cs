// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Service.ChainalysisProxy.AutorestClient.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for RiskScore.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RiskScore
    {
        [EnumMember(Value = "Red")]
        Red,
        [EnumMember(Value = "Amber")]
        Amber,
        [EnumMember(Value = "Green")]
        Green
    }
    internal static class RiskScoreEnumExtension
    {
        internal static string ToSerializedValue(this RiskScore? value)
        {
            return value == null ? null : ((RiskScore)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this RiskScore value)
        {
            switch( value )
            {
                case RiskScore.Red:
                    return "Red";
                case RiskScore.Amber:
                    return "Amber";
                case RiskScore.Green:
                    return "Green";
            }
            return null;
        }

        internal static RiskScore? ParseRiskScore(this string value)
        {
            switch( value )
            {
                case "Red":
                    return RiskScore.Red;
                case "Amber":
                    return RiskScore.Amber;
                case "Green":
                    return RiskScore.Green;
            }
            return null;
        }
    }
}
