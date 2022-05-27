namespace MethodsAndProperties;

public class BusinessRules
{
    //Business Rule: Customers can get a voucher if they have made at least 5 purchases and the largest is worth > $100
    //Value types are always passed by value, unless you specify otherwise
    //That means methods get copies of struct parameters - not original instances
    //It takes machine cycles to make those copies
    //decimal is larger than int - so will take more time to copy
    // in decimal biggestPurchase - This means the method  receives the original decimal, not a copy
    public static bool EligibleForVoucher(int nPurchases, in decimal biggestPurchase)
        => nPurchases > 5 && biggestPurchase > 100m;
}

/* void DoSomething(in MyValueType data){} -- Do this if by reference is just for performance
 * void DoSomething(ref MyValueType data){} -- Do this if you want to modify the value in the caller
 * void DoSomething(out MyValueType data){} -- Do this to use  the value as a return value
 */