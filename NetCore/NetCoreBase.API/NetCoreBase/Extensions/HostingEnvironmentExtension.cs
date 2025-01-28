namespace NetCoreBase.Extensions
{
    /// <summary>
	/// Custom environments extension
	/// </summary>
	public static class HostingEnvironmentExtension
    {
        /// <summary>
        /// Quality assurance environment
        /// </summary>
        private const string Production = "Production";
        /// <summary>
        /// Local environment
        /// </summary>
        private const string Local = "Local";

        /// <summary>
        ///  Checks if the current host environment name is Production.
        /// </summary>
        /// <param name="hostingEnvironment">An instance of <see cref="IWebHostEnvironment"/>.</param>
        /// <returns>True if the environment name is Production.</returns>
        public static bool IsProduction(this IWebHostEnvironment hostingEnvironment)
        {
            return hostingEnvironment.IsEnvironment(Production);
        }

        /// <summary>
        ///  Checks if the current host environment name is Local.
        /// </summary>
        /// <param name="hostingEnvironment">An instance of <see cref="IWebHostEnvironment"/>.</param>
        /// <returns>True if the environment name is local</returns>
        public static bool IsLocal(this IWebHostEnvironment hostingEnvironment)
        {
            return hostingEnvironment.IsEnvironment(Local);
        }
    }
}
