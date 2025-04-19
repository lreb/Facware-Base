namespace NetCoreBase.Application.Delegates
{
    internal class MultiCastDelegate
    {
        // Define a delegate
        internal delegate decimal MultiCastDelegateDeclaration(decimal price);

        // Methods to be assigned to the delegate
        internal static decimal AddIva(decimal price)
        {
            return price * 0.016m;
        }

        internal static decimal AddISR(decimal price)
        {
            return price * 0.020m;
        }

        internal static decimal AddProfit(decimal price)
        {
            return price * 0.030m;
        }
    }
}
