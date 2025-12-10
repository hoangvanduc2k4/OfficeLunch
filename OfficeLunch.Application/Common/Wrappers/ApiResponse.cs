namespace OfficeLunch.Application.Common.Wrappers
{
    public class ApiResponse<T>
    {
        // Indicates whether the request was successful
        public bool Succeeded { get; set; }

        // Message describing the result (success or error)
        public string Message { get; set; }

        // Optional payload returned from the API
        public T? Data { get; set; }

        public ApiResponse() { }

        // Create a successful API response with optional message
        public static ApiResponse<T> Success(T? data, string message = "Success")
        {
            return new ApiResponse<T>
            {
                Succeeded = true,
                Message = message,
                Data = data
            };
        }

        // Create a failed API response with an error message
        public static ApiResponse<T> Fail(string message)
        {
            return new ApiResponse<T>
            {
                Succeeded = false,
                Message = message,
            };
        }
    }
}
