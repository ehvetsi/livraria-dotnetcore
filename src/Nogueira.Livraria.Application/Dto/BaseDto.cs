using Newtonsoft.Json;

namespace Nogueira.Livraria.Application.Dto
{
    public class BaseDto
    {
        public BaseDto()
        {
            IsValid = true;
        }

        public int Id { get; set; }

        [JsonIgnore]
        public bool IsCreate { get; set; }

        [JsonIgnore]
        public bool IsDelete { get; set; }

        [JsonIgnore]
        public bool IsGet { get; set; }

        [JsonIgnore]
        public bool IsList { get; set; }

        [JsonIgnore]
        public bool IsUpdate { get; set; }

        public bool IsValid { get; set; }
    }
}