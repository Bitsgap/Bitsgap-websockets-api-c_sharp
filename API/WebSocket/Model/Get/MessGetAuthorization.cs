using Newtonsoft.Json;

namespace API.WebSocket.Model.Get
{
    class MessGetAuthorization
    {
        /// <summary>
        /// Transport field
        /// </summary>
        [JsonProperty("login")]
        public string LoginString { get; set; }

        /// <summary>
        /// Authorization result: "valid" - ok, else - not ok
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonIgnore]
        public bool IsNeedAuthorize => LoginString != null && Status == null;
        [JsonIgnore]
        public bool IsAuthorizeOk => Status == "valid";

        public static MessGetAuthorization Convert(string value) => JsonConvert.DeserializeObject<MessGetAuthorization>(value);

        /// <summary>
        /// Parsing and using JSON string
        /// </summary>
        public bool Parse(string value)
        {
            bool result = false;

            if (string.IsNullOrWhiteSpace(value)) return result;

            try
            {
                var data = Convert(value);
                if (data.LoginString != null)
                {
                    result = true;

                    LoginString = data.LoginString;
                    Status = data.Status;
                }
            }
            catch
            { 
                // None 
            }

            return result;
        }

        /// <summary>
        /// Creating a SHA-512 HMAC for response
        /// </summary>
        public void GenerateResponse(string public_key, string private_key)
        {
            LoginString = Utils.SHA512HMAC.Generate(public_key + LoginString, private_key);
            Status = null;
        }
    }
}
