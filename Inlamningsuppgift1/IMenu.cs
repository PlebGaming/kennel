namespace Inlamningsuppgift1
{
    public interface IMenu
    {
        bool Show(IKennel kennel);
        bool CheckIn(IKennel kennel, string checkInOfdog, bool dogFound);
        bool CheckOut(IKennel kennel, string checkOutDog, bool dogOutFound);
        bool CustomerCheck(IKennel kennel, string dogName, string custName, bool customerFound);
        void DogsInTheKennel(IKennel kennel);
    }
}