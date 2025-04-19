namespace NetCoreBase.Application.Delegates
{
    internal class SingleCastDelegate
    {
        internal delegate void SingleCastDelegateDeclaration(string message);

        /// <summary>
        /// Single cast delegate method
        /// </summary>
        /// <param name="message">
        /// message to be printed
        /// </param>
        internal static void SingleCastMethod(string message)
        {
            Console.WriteLine($"SingleCastMethod: {message}");
        }
    }
}
