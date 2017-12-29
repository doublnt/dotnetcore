using Microsoft.AspNetCore.Builder;

namespace Robert.Middleware.OnlyPassGet {
    public static class OnlyPassGetMiddlewareExtension {
        public static IApplicationBuilder UseOnlyPassGet (this IApplicationBuilder builder) {
            return builder.UseMiddleware<OnlyPassGetMiddleware> ();
        }
    }

}