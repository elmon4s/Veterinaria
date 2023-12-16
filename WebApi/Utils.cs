using Microsoft.AspNetCore.Mvc;

namespace WebApi
{
    public static class Utils
    {
        public static IActionResult Error()
        {
            return new ObjectResult("Internal error. Try again later.")
            {
                StatusCode = 500
            };
        }
    }
}
