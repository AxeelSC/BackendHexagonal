namespace HexagonalModular.API.Common
{
    public class ApiResponse<T>
    {
        /// <summary>
        /// Indicates whether the operation completed successfully.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Returned data (null if operation failed).
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// A single error message (for simple errors).
        /// </summary>
        public string? Error { get; set; }

        /// <summary>
        /// A list of error messages (for validation or multi-error scenarios).
        /// </summary>
        public List<string>? Errors { get; set; }

        /// <summary>
        /// Error code used for frontend or integration decision-making.
        /// </summary>
        public string? ErrorCode { get; set; }

        /// <summary>
        /// Unique identifier for tracing/logging across the system.
        /// </summary>
        public string? TraceId { get; set; }

        /// <summary>
        /// Metadata (pagination, warnings, processing time, etc.).
        /// </summary>
        public Dictionary<string, object>? Meta { get; set; }

        // ------------------------
        //      FACTORY METHODS
        // ------------------------

        public static ApiResponse<T> SuccessResult(
            T data,
            string? message = null,
            Dictionary<string, object>? meta = null,
            string? traceId = null)
            => new ApiResponse<T>
            {
                Success = true,
                Data = data,
                Error = null,
                Errors = null,
                ErrorCode = null,
                TraceId = traceId,
                Meta = meta
            };

        public static ApiResponse<T> ErrorResult(
            string errorCode,
            string message,
            List<string>? errors = null,
            string? traceId = null,
            Dictionary<string, object>? meta = null)
            => new ApiResponse<T>
            {
                Success = false,
                Data = default,
                Error = message,
                Errors = errors,
                ErrorCode = errorCode,
                TraceId = traceId,
                Meta = meta
            };
    }

}
