using System.Text.Json.Serialization;
using Kadense.Models.Malleable;

namespace Kadense.Malleable.Reflection.Tests 
{
    [MalleableClass("Kadense.Malleable.Reflection", "Tests", "MalleableBasicMockClass")]
    public class MalleableBasicMockClass : MalleableBase
    {
        
        /// <summary>
        /// A test string property
        /// </summary>
        [JsonPropertyName("testProperty")]
        public string? TestProperty { get; set; }
    }
}