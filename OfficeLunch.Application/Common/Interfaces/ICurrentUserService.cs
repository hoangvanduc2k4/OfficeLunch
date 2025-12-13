namespace OfficeLunch.Application.Common.Interfaces
{
    /// <summary>
    /// Abstraction for accessing the current logged-in user's information.
    /// This keeps the Application layer clean of ASP.NET Core dependencies (HttpContext).
    /// </summary>
    public interface ICurrentUserService
    {
        /// <summary>
        /// Gets the unique identifier (GUID) of the current user.
        /// Returns Guid.Empty if the user is not authenticated.
        /// </summary>
        Guid UserId { get; }

        /// <summary>
        /// Gets the username (usually the email or login name) of the current user.
        /// Returns null if not authenticated.
        /// </summary>
        string? UserName { get; }

        /// <summary>
        /// Checks if the current request is authenticated.
        /// </summary>
        bool IsAuthenticated { get; }

        /// <summary>
        /// Checks if the current user belongs to a specific role.
        /// </summary>
        /// <param name="role">The role name to check (e.g., "Admin").</param>
        /// <returns>True if the user is in the role; otherwise, false.</returns>
        bool IsInRole(string role);

        /// <summary>
        /// Retrieves a specific claim value by its type.
        /// </summary>
        /// <param name="claimType">The type of the claim (e.g., "email").</param>
        /// <returns>The claim value or null if not found.</returns>
        string? GetClaim(string claimType);
    }
}